using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.DbSimRend;
using SimRend.Filters;
using SimRend.Models;

namespace SimRend.Controllers
{
    public class OrganizacionEstudiantilController : Controller
    {
        [AutorizacionUsuario(idOperacion: 30)]
        public IActionResult OrganizacionesEstudiantiles()
        {
            return View();
        }

        [AutorizacionUsuarioJS(idOperacion: 29)]
        public IActionResult CrearOE()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 31)]
        public IActionResult ActualizarOE()
        {
            return View();
        }

        [AutorizacionUsuarioJS(idOperacion: 30)]
        [HttpPost]
        public JsonResult LeerOrganizaciones()
        {
            List<Organizacion> Organizaciones = ConsultaOrganizacionEstudiantil.LeerOrganizaciones();
            return Json(Organizaciones);
        }

        [AutorizacionUsuarioJS(idOperacion: 30)]
        [HttpGet]
        public JsonResult ObtenerDatosPrincipales()
        {
            List<TipoOE> tiposOE = ConsultaOrganizacionEstudiantil.Leer_TipoOE();
            List<Campus> campus = ConsultaOrganizacionEstudiantil.Leer_Campus();
            List<Institucion> instituciones = ConsultaInstitucion.LeerInstituciones();
            if (tiposOE != null && campus !=null)
            {
                return Json(new
                {
                    tiposOE,
                    campus,
                    instituciones
                });
            }
            return Json(new object());
        }

        [AutorizacionUsuarioJS(idOperacion: 29)]
        [HttpPost]
        public JsonResult RegistrarOE(String Nombre, String Email, int IdCampus, int IdTipoOE, int IdInstitucion)
        {
            List<Organizacion> organizaciones = ConsultaOrganizacionEstudiantil.LeerOrganizaciones();

            String msj;
            bool respuesta;
          
            if(organizaciones.Find(organizacion=>organizacion.Email.ToLower().Equals(Email.ToLower())) !=null)
            {
                respuesta = false;
                msj = "No se puede guardar la Organización estudiantil porque ya existe otra con el mismo email.";
            }
            else if(organizaciones.Find(organizacion => organizacion.Nombre.ToLower().Equals(Nombre.ToLower()) && organizacion.Campus.Id == IdCampus && organizacion.TipoOE.Id == IdTipoOE && organizacion.Institucion.Id == IdInstitucion) !=null)
            {
                respuesta = false;
                msj = "No se puede guardar la Organización estudiantil porque ya existe otra con el mismo nombre, campus y tipo de O.E.";
            }
            else
            {
                respuesta = ConsultaOrganizacionEstudiantil.CrearOrganizacion(Nombre, Email, IdCampus, IdTipoOE, IdInstitucion);

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

        [AutorizacionUsuarioJS(idOperacion: 31)]
        [HttpPost]
        public JsonResult ModificarOE(String Nombre, String Email, int IdCampus, int IdTipoOE, int IdOE, int IdInstitucion)
        {
            List<Organizacion> organizaciones = ConsultaOrganizacionEstudiantil.LeerOrganizaciones();
            Organizacion oe = organizaciones.Find(org => org.Id == IdOE);

            String msj;
            bool validar;

            if (organizaciones.Find(organizacion => organizacion.Id!= IdOE && organizacion.Email.ToLower().Equals(Email.ToLower())) != null)
            {
                validar = false;
                msj = "No se puede guardar la Organización estudiantil porque ya existe otra con el mismo email.";
            }
            else if (organizaciones.Find(organizacion => organizacion.Id != IdOE && organizacion.Nombre.ToLower().Equals(Nombre.ToLower()) && organizacion.Campus.Id == IdCampus && organizacion.TipoOE.Id == IdTipoOE && organizacion.Institucion.Id == IdInstitucion) != null)
            {
                validar = false;
                msj = "No se puede guardar la Organización estudiantil porque ya existe otra con el mismo nombre, campus y tipo de O.E.";
            }
            else if(oe.Nombre.Equals(Nombre.ToLower()) && oe.Email.ToLower().Equals(Email.ToLower()) && oe.Campus.Id == IdCampus && oe.TipoOE.Id== IdTipoOE && oe.Institucion.Id == IdInstitucion)
            {
                validar = false;
                msj = "No se han guardado los datos porque siguen siendo los mismos.";
            }
            else
            {
                validar = ConsultaOrganizacionEstudiantil.ActualizarOrganizacion(Nombre, Email, IdCampus, IdTipoOE, IdOE, IdInstitucion);

                if (validar)
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
                validar,
                msj
            };

            return Json(datos);
        }

        [HttpPost]
        public void GuardarIdOE(int IdOE)
        {
            HttpContext.Session.SetComplexData("IdOE", IdOE);
        }

        [AutorizacionUsuarioJS(idOperacion: 30)]
        [HttpGet]
        public JsonResult LeerOE()
        {
            int IdOE = HttpContext.Session.GetComplexData<int>("IdOE");
            return Json(ConsultaOrganizacionEstudiantil.LeerOE(IdOE));
        }

        [AutorizacionUsuarioJS(idOperacion: 32)]
        [HttpDelete]
        public JsonResult EliminarOE(int IdOE)
        {
            String msj;
            bool validar = ConsultaOrganizacionEstudiantil.EliminarOE(IdOE);

            if (validar)
            {
                msj = "Los datos se han eliminado exitosamente";
            }
            else
            {
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
