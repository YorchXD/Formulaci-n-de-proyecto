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
    public class RendicionController : Controller
    {
        private readonly RequestHandler _requestHandler;

        public RendicionController(RequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        /*Falta solicitar los datos de la Resolucion*/
        public IActionResult Rendicion()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            int idOrganizacion = _requestHandler.GetIdAcceso();
            ModeloRendicion modelo = new ModeloRendicion();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud(idSolicitud);
            modelo.Solicitud.NombreResponsable = SolicitudController.BuscarRepresentante(idOrganizacion, modelo.Solicitud.RutResponsable);
            
            List<Persona> Personas = ConsultaSolicitud.LeerPersonasSolicitud(idSolicitud);

            if (Personas != null)
            {
                ViewData["Personas"] = Personas;
            }
            return View();
        }

        /*Falta solicitar los datos de la Resolucion y de la persona que lo solicita*/
        public IActionResult RendicionParticipante()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            int idOrganizacion = _requestHandler.GetIdAcceso();
            ModeloRendicion modelo = new ModeloRendicion();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud(idSolicitud);
            List<Categoria> CategoriasSeleccionadas = ConsultaSolicitud.LeerCategoriasSeleccionadas(idSolicitud);
            ViewData["Seleccionadas"] = CategoriasSeleccionadas;
            return View();
        }

        [HttpPost]
        public IActionResult AgregarBoleta()
        {
            return RedirectToAction("Rendicion", "Rendicion");
        }
    }
}