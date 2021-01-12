using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace SimRend.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult OperacionNoAutorizada(String operacion, String modulo, String msjeErrorExcepcion)
        {
            ViewBag.operacion = operacion;
            ViewBag.modulo = modulo;
            ViewBag.msjeErrorExcepcion = msjeErrorExcepcion;
            return View();
        }
    }
}