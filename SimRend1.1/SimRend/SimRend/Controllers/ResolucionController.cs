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
            
            ConsultasGenerales.idSolicitud = idSolicitud;
            ConsultasGenerales.Leer_Id_Proceso();
            _requestHandler.SetIdProceso(ConsultasGenerales.idProceso);
            ConsultasGenerales.idProceso=-1;
            
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
            if (ModelState.IsValid)
            {
                int idproceso = _requestHandler.GetIdProceso();
                int idResolucion = ConsultaResolucion.CrearResolucion(resolucion);
                ConsultasGenerales.Actualizar_Proceso_Resolucion_DecGatos(2,idproceso, idResolucion); //el dos significa que se agregara el id de la resolucion
                int estado = 3; /*Representa el estado de la resolucion finalizada*/
                ConsultasGenerales.Actualizar_Estado_Proceso(idproceso,estado);
                return RedirectToAction("TablaSolicitudes", "Principal");
            }
            return View(resolucion);
        }
    }
}