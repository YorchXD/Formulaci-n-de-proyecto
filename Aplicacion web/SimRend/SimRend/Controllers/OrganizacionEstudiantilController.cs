using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.DbSimRend;
using SimRend.Models;

namespace SimRend.Controllers
{
    public class OrganizacionEstudiantilController : Controller
    {
        public IActionResult OrganizacionesEstudiantiles()
        {
            return View();
        }

        public IActionResult CrearOE()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LeerOrganizaciones()
        {
            List<Organizacion> Organizaciones = ConsultaOrganizacionEstudiantil.LeerOrganizaciones();
            return Json(Organizaciones);
        }

        [HttpGet]
        public JsonResult ObtenerDatosPrincipales()
        {
            List<TipoOE> tiposOE = ConsultaOrganizacionEstudiantil.Leer_TipoOE();
            List<Campus> campus = ConsultaOrganizacionEstudiantil.Leer_Campus();
            if (tiposOE != null && campus !=null)
            {
                return Json(new
                {
                    tiposOE,
                    campus
                });
            }
            return Json(new object());
        }

        [HttpPost]
        public JsonResult RegistrarOE(String Nombre, String Email, int IdCampus, int IdTipoOE)
        {
            List<Organizacion> organizaciones = ConsultaOrganizacionEstudiantil.LeerOrganizaciones();

            List<TipoOE> tiposOE = ConsultaOrganizacionEstudiantil.Leer_TipoOE();
            List<Campus> campus = ConsultaOrganizacionEstudiantil.Leer_Campus();

            Campus camp = campus.Find(campusAux=> campusAux.Id == IdCampus);
            TipoOE tipoOE = tiposOE.Find(tipoOE=>tipoOE.Id == IdTipoOE);

            String msj;
            bool respuesta;
          
            if(organizaciones.Find(organizacion=>organizacion.Email.ToLower() == Email.ToLower()) !=null)
            {
                respuesta = false;
                msj = "No se puede guardar la Organización estudiantil porque ya existe otra con el mismo email.";
            }
            else if(organizaciones.Find(organizacion => organizacion.Nombre.ToLower() == Nombre.ToLower() && organizacion.Campus == camp.Nombre && organizacion.Tipo==tipoOE.Nombre)!=null)
            {
                respuesta = false;
                msj = "No se puede guardar la Organización estudiantil porque ya existe otra con el mismo nombre, campus y tipo de O.E.";
            }
            else
            {
                respuesta = ConsultaOrganizacionEstudiantil.CrearOrganizacion(Nombre, Email, IdCampus, IdTipoOE);

                if (respuesta)
                {
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            var datos = new
            {
                validar = respuesta,
                msj
            };

            return Json(datos);
        }

        [HttpDelete]
        public JsonResult EliminarOE(int IdOE)
        {
            String msj;
            bool validar;
            int respuesta = ConsultaOrganizacionEstudiantil.EliminarOE(IdOE);

            if (respuesta == 1)
            {
                validar = true;
                msj = "Los datos se han eliminado exitosamente";
            }
            else
            {
                validar = false;
                msj = "Los datos no se han eliminado correctamente. Esto se debe a que probablemente tenga asociados representantes, directores o" +
                    " puede que no tenga conexión. Intentelo nuevamente y si el problema persiste favor de contactarse con soporte.";
            }

            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }
    }
}
