using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.Models;
using SimRend.DbSimRend;

namespace SimRend.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Validar(String usuario, String clave)
        {
            Login login = new Login()
            {
                Usuario = usuario,
                Clave = clave
            };
            int idOrganizacion = ConsultaSolicitud.IniciarSesion(login);
            if(idOrganizacion!=-1)
            {
                TempData["idOrganizacion"] = idOrganizacion;
                return RedirectToAction("Index", "Solicitud");
            }
            return RedirectToAction("Login", "Usuario");

        }
    }
}