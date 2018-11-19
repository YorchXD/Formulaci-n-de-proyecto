using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.Models;
using SimRend.DbSimRend;

namespace SimRend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            /*Solicitud solcitud = new Solicitud();
            solcitud.Estado = "Editando";
            solcitud.FechaActual = DateTime.Now;
            solcitud.FechaEvento = new DateTime(2018,12,25);
            solcitud.NombreEvento = "Aniversario ICC";
            solcitud.Monto = 256000;
            solcitud.Responsable = "Daniela Paredes";
            solcitud.LugarEvento = "Linares";

            ConsultaSolicitud.CrearSolicitud(solcitud);

            List<Solicitud> solicitudes = ConsultaSolicitud.LeerTodo();*/
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
