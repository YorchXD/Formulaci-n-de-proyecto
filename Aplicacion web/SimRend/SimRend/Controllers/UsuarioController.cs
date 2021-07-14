using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.Models;
using SimRend.DbSimRend;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using MySqlX.XDevAPI;

namespace SimRend.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string clave, string tipoUsuario)
        {
            try
            {
                var usuario = ConsultaUsuario.IniciarSesion(email, clave, tipoUsuario);
                if(usuario == null)
                {
                    ViewBag.Error = "Usuario o clave invalida";
                    return View();
                }

                HttpContext.Session.SetComplexData("DatosUsuario", usuario);
                HttpContext.Session.SetString("Nombre", usuario.Nombre.Split(" ")[0]);
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
                HttpContext.Session.SetString("Email", usuario.Email);
                HttpContext.Session.SetString("Cargo", usuario.NombreRol);
                HttpContext.Session.SetString("OE", usuario.NombreOrganizacionEstudiantil);
                return RedirectToAction("Procesos", "Proceso");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return View();
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.SetComplexData("DatosUsuario", null);
                HttpContext.Session.SetString("Nombre", "");
                HttpContext.Session.SetString("NombreUsuario", "");
                HttpContext.Session.SetString("Email", "");
                HttpContext.Session.SetString("Cargo", "");
                HttpContext.Session.SetString("OE", "");

                return RedirectToAction("Login", "Usuario");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return View();
        }

    }
}