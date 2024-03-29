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
    public class DeclaracionGastosController : Controller
    {
        private readonly RequestHandler _requestHandler;

        public DeclaracionGastosController(RequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public IActionResult InfoRendicion()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            int idOrganizacion = _requestHandler.GetIdAcceso();
            return View();
        }

        /*Falta solicitar los datos de la Resolucion*/
        public IActionResult DeclaracionGastos()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            int idOrganizacion = _requestHandler.GetIdAcceso();
            
            ConsultasGenerales.idSolicitud = idSolicitud;
            ConsultasGenerales.Leer_Id_Proceso();
            _requestHandler.SetIdProceso(ConsultasGenerales.idProceso);
            ConsultasGenerales.idProceso=-1;

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