using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SimRend.Models;
using SimRend.DbSimRend;
using System.Data;
using Microsoft.AspNetCore.Http;
using SimRend.Helpers;
using DinkToPdf;

namespace SimRend.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly RequestHandler _requestHandler;

        public PrincipalController(RequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public IActionResult TablaSolicitudes()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();

            int idOrganizacion = _requestHandler.GetIdAcceso();
            List<Solicitud> solicitudes = ConsultaSolicitud.LeerSolicitudOrganizacion(idOrganizacion);
            foreach (Solicitud solicitud in solicitudes)
            {
                solicitud.NombreResponsable =  SolicitudController.BuscarRepresentante(idOrganizacion,solicitud.RutResponsable);
            }
            return View(solicitudes);
        }

        public IActionResult IrProcesoFondo(int IdSolicitud)
        {
            _requestHandler.SetIdSolicitud(IdSolicitud);
            return RedirectToAction("Proceso", "Principal");
            //return RedirectToAction("ProcesoFondoPorRendir", "Solicitud");
            //return RedirectToAction("Resume", "Solicitud");
            //return RedirectToAction("GeneratePDF", "GeneratePDF");
            //return RedirectToAction("InfoRendicion", "Rendicion");
            //return RedirectToAction("Resolucion", "Resolucion");
            //return RedirectToAction("Rendicion", "Rendicion");
        }

        public IActionResult Proceso()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            int idOrganizacion = _requestHandler.GetIdAcceso();
            ModeloResolucion modelo = new ModeloResolucion();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud_Finalizada(idSolicitud);
            modelo.Solicitud.NombreResponsable = SolicitudController.BuscarRepresentante(idOrganizacion, modelo.Solicitud.RutResponsable);
            return View(modelo);
        }

        public IActionResult IrResumen(int IdSolicitud)
        {
            //_requestHandler.SetIdSolicitud(IdSolicitud);
            //return RedirectToAction("ProcesoFondoPorRendir", "Solicitud");
            return RedirectToAction("Resume", "Solicitud");
            //return RedirectToAction("GeneratePDF", "GeneratePDF");
            //return RedirectToAction("InfoRendicion", "Rendicion");
            //return RedirectToAction("Resolucion", "Resolucion");
            //return RedirectToAction("Rendicion", "Rendicion");
        }
    }
}