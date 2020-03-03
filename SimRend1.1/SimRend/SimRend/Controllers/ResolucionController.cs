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

        public IActionResult IrPrincipal()
        {
            return RedirectToAction("TablaSolicitudes", "Principal");
        }

        public IActionResult Resolucion()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            ModeloResolucion modelo = new ModeloResolucion();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud(idSolicitud);
            return View(modelo);
        }

        [HttpPost]
        /*public IActionResult AgregarResolucion(Resolucion resolucion)
        {
            resolucion.RefSolicitud= _requestHandler.GetIdSolicitud();
            return IrPrincipal();
        }*/

        //public IActionResult AgregarResolucion([Bind("NumeroResolucion,AnioResolucion")] Resolucion resolucion)
        public IActionResult AgregarResolucion([Bind("NumeroResolucion,AnioResolucion")] Resolucion resolucion)
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
           // if (ModelState.IsValid)
           // {
                //int idproceso = _requestHandler.GetProceso();
                /*.ModificarEstadoResponsable(solicitud.RutResponsable, "Desabilitado");
                solicitud.FechaActual = DateTime.Now;
                solicitud.FechaFinPdf = DateTime.Now;
                int idOrganizacion = _requestHandler.GetIdAcceso();
                int idSolicitud = ConsultaSolicitud.CrearSolicitud(solicitud);*/
                //int estado = 1; /*Representa que la solicitud esta en estado de edicion*/
                //ConsultaSolicitud.AgregarProcesoFondo(idOrganizacion, idSolicitud, estado);
                //TempData["idOrganizacion"] = idOrganizacion;
                //return IrPrincipal();
            //}
            return View(resolucion);
        }
    }
}