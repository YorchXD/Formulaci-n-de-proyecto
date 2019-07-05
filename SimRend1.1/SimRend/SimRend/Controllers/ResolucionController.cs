using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.Models;
using SimRend.Helpers;
using SimRend.DbSimRend;


namespace SimRend.Controllers
{
    public class ResolucionController : Controller
    {
        private readonly RequestHandler _requestHandler;

        public ResolucionController(RequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public IActionResult Resolucion()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            int idOrganizacion = _requestHandler.GetIdAcceso();
            ModeloResolucion modelo = new ModeloResolucion();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud(idSolicitud);
            modelo.Solicitud.NombreResponsable = SolicitudController.BuscarRepresentante(idOrganizacion, modelo.Solicitud.RutResponsable);
            return View(modelo);
        }

        [HttpPost]
        public IActionResult AgregarResolucion(Resolucion resolucion)
        {
            resolucion.RefSolicitud= _requestHandler.GetIdSolicitud();
            return RedirectToAction("Index", "Solicitud");
        }
    }
}