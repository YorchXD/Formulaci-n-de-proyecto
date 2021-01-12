using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet.Messages;
using SimRend.DbSimRend;
using SimRend.Filters;
using SimRend.Models;

namespace SimRend.Controllers
{
    public class ProcesoController : Controller
    {
        public IActionResult Procesos()
        {
            CrearCarpetaOrganizacion();
            HttpContext.Session.SetComplexData("Proceso", null);
            /*HttpContext.Session.SetComplexData("Solicitud", null);
            HttpContext.Session.SetComplexData("idSolicitud", null);
            HttpContext.Session.SetComplexData("idResolucion", null);
            HttpContext.Session.SetComplexData("idDeclaracionGastos", null);
            ViewData["idSolicitud"] = null;*/
            return View();
        }

        [AutorizacionUsuario(idOperacion: 2)]
        public IActionResult VerProceso()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");

            if (proceso.Solicitud != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Procesos", "Proceso");
            }
        }

        /// <summary>
        /// Guarda todos los id de un proceso en particular en session(id de la solicitud, id de la resolucion  y el 
        /// id de la declaracion de gastos). Por otra parte se guarda además el estado actual que se encuentra el proceso
        /// los cuales pueden ser (1.) Edicion solicitud, (2.) Solicitud terminada, (3.) Resolucion terminada, (4.) Declaracion de gastos terminada
        /// </summary>
        /// <param name="IdSolicitud"></param>
        /// <param name="IdResolucion"></param>
        /// <param name="IdDeclaracionGastos"></param>
        /// <param name="Estado"></param>
        [HttpPost]
        public void GuardarId(int IdSolicitud, int IdResolucion, int IdDeclaracionGastos, int Estado)
        {
            //HttpContext.Session.SetComplexData("idSolicitud", IdSolicitud);
            Proceso proceso = new Proceso();
            proceso.Estado = Estado;
            proceso.Solicitud = ConsultaSolicitud.LeerSolicitud(IdSolicitud);
            if (proceso.Solicitud.NombreResponsable == null)
            {
                proceso.Solicitud.NombreResponsable = ConsultaSolicitud.LeerResponsable(proceso.Solicitud.IdResponsable).Nombre;
            }

            if (IdResolucion!=-1)
            {
                //HttpContext.Session.SetComplexData("idResolucion", IdResolucion);
                proceso.Resolucion = ConsultaResolucion.LeerResolucion(IdResolucion);
            }

            if(IdDeclaracionGastos!=-1)
            {
                HttpContext.Session.SetComplexData("idDeclaracionGastos", IdDeclaracionGastos);
            }
            HttpContext.Session.SetComplexData("Proceso", proceso);
        }

        [HttpPost]
        public JsonResult LeerProcesos()
        {
            Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
            List<Proceso> procesos = ConsultasGenerales.LeerProcesosOrganizacion(usuario.IdOrganizacionEstudiantil);
            if (procesos != null)
            {
                return Json(procesos);
            }
            return Json(new Object());
        }

        /// <summary>
        /// Se encarga de leer un proceso en particular que se encuentra registrado en sesion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LeerProceso()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            var datos = new
            {
                solicitud = proceso.Solicitud,
                estado = proceso.Estado
            };

            return Json(datos);
        }

        public void CrearCarpetaOrganizacion()
        {
            Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
            string carpeta = @"wwwroot/Procesos/" + usuario.NombreOrganizacionEstudiantil;
            try
            {
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
