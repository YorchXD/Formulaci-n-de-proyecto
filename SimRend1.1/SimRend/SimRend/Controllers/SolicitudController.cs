using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SimRend.Models;
using SimRend.DbSimRend;


namespace SimRend.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: /<controller>/
        /*public IActionResult Index()
        {
            return View();
        }*/
        

        // GET: Solicitud
        public IActionResult Index()
        {
            var solicitudes = ConsultaSolicitud.LeerTodo();
            return View(solicitudes);
        }


        // GET: Solicitud/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Monto,NombreEvento,FechaEvento,LugarEvento,Responsable")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                solicitud.FechaActual = DateTime.Now;
                solicitud.Estado = "Editando";
                ConsultaSolicitud.CrearSolicitud(solicitud);
                return RedirectToAction(nameof(Index));
            }
            return View(solicitud);
        }

    }
}
