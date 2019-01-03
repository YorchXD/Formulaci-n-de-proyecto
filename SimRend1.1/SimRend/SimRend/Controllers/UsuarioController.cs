using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.Models;
using SimRend.DbSimRend;
using Microsoft.AspNetCore.Http;
using SimRend.Helpers;
using System.Diagnostics;

namespace SimRend.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly RequestHandler _requestHandler;

        public UsuarioController(RequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Organizacion() {
            

            return View();
        }

        public IActionResult CrearOrganizacion() {
            return View();
        }

        public IActionResult CrearFederacion() {
            if (TempData.ContainsKey("idOrga")) ViewBag.idOrga = TempData["idOrga"];

            return View();
        }

        public IActionResult CrearCaa() {
            if (TempData.ContainsKey("idOrga")) ViewBag.idOrga = TempData["idOrga"];


            return View();
        }

        public ActionResult Crear(String Tipo, String Nombre, String Email) {
            //metodos para poder guardar usuario
            String pass = GenerarClaveAleatoria();

            int id = DbSimRend.Usuario.CrearOrganizacion(Tipo, Nombre, Email, pass);

            //hacer un gif, que si no guarda vuelve a crear. Si guarda, se va a otra ventana
            if (id != -1 ) {
                EnviarEmail("Cuenta Creada", Email, "Bienvenido! Su nueva contraseña es" + pass);
                TempData["idOrga"] = id;

                if(Tipo == "CAA") {
                    return RedirectToAction("CrearCaa", "Usuario");
                }
                else {
                    return RedirectToAction("CrearFederacion", "Usuario");
                }
            }

            return RedirectToAction("CrearOrganizacion", "Usuario");
        }


        public ActionResult DeshabilitarHabilitar(int id, String Estado) {
            if (DbSimRend.Usuario.DeshabilitarHabilitarOrganizacion(id, Estado))
            {
                //algo Pasa
            }

            return RedirectToAction("Organizacion", "Usuario");
         }

        public String GenerarClaveAleatoria() {
            return RandomPassword.Generate(8);
        }

        public void EnviarEmail(String Subject, String Email, String Content) {
            EmailSender.Send(Email, Subject, Content);
        }

        public IActionResult Validar(String usuario, String clave)
        {
            //string SessionKeyID = "_identificacion";
            Login login = new Login()
            {
                Usuario = usuario,
                Clave = clave
            };
            int idOrganizacion = ConsultaSolicitud.IniciarSesion(login);
            if(idOrganizacion!=-1)
            {
                _requestHandler.SetIdAcceso(idOrganizacion, usuario);
          
                //HttpContext.Session.SetString(SessionKeyID, idOrganizacion.ToString());
                //int idOrg= Convert.ToInt32(HttpContext.Session.GetString(SessionKeyID));
                //TempData["idOrganizacion"] = idOrganizacion;
               // Session["idOrganizacion"] = idOrganizacion;
                //HttpContext.Current.Session["idOrganizacion"] = idOrganizacion;
                return RedirectToAction("Index", "Solicitud");
            }
            return RedirectToAction("Login", "Usuario");
        }

        public IActionResult RecuperarClave(String email)
        {
            string obtenerClave = ConsultaSolicitud.Leer_Correo(email);

            if(obtenerClave!=null && obtenerClave.Equals(email))
            {
                string clave = RandomPassword.Generate(8);
                ConsultaSolicitud.Cambiar_clave(email, clave);
                EmailSender.Send(email, "Cambio de contraseña", "Su nueva contraseña temporal es: " + clave);
               
                return RedirectToAction("Login", "Usuario");
            }
            Console.WriteLine("No envio coreo");
            return RedirectToAction("Login", "Usuario");

        }

        [HttpGet]
        public IActionResult Logout()
        {
            //HttpContext.Session.Remove("username");
            _requestHandler.RemoveIdAcceso();
            return RedirectToAction("Login");
        }
    }
}