using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.DbSimRend;
using SimRend.Models;

namespace SimRend.Controllers
{
    public class InstitucionController : Controller
    {
        public IActionResult Institucion()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LeerInstituciones()
        {
            List<Institucion> listadoInstitucion = ConsultaInstitucion.LeerInstituciones();
            return Json(listadoInstitucion);
        }

        [HttpPost]
        public JsonResult CrearInstitucion(String Abreviacion, String Nombre)
        {
            List<Institucion> listadoInstitucion = ConsultaInstitucion.LeerInstituciones();
            String msj;
            bool validar;

            if (listadoInstitucion.Find(institucion => institucion.Abreviacion.Equals(Abreviacion, StringComparison.OrdinalIgnoreCase) || institucion.Nombre.Equals(Nombre, StringComparison.OrdinalIgnoreCase)) == null)
            {
                int respuesta = ConsultaInstitucion.CrearInstitucion(Abreviacion, Nombre);

                if (respuesta == 1)
                {
                    validar = true;
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    validar = false;
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            else
            {
                validar = false;
                msj = "No se puede guardar la institucion porque ya existe otra con el mismo nombre o abreviación.";
            }
            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [HttpPost]
        public JsonResult ActualizarInstitucion(int IdInstitucion, String Abreviacion, String Nombre)
        {
            List<Institucion> listadoInstitucion = ConsultaInstitucion.LeerInstituciones();
            String msj;
            bool validar;

            if (listadoInstitucion.Find(institucion => institucion.Abreviacion.Equals(Abreviacion, StringComparison.OrdinalIgnoreCase) || institucion.Nombre.Equals(Nombre, StringComparison.OrdinalIgnoreCase) && institucion.Id!=IdInstitucion) == null)
            {
                if (!listadoInstitucion.Find(institucion => institucion.Id == IdInstitucion).Abreviacion.Equals(Abreviacion) || !listadoInstitucion.Find(institucion => institucion.Id == IdInstitucion).Nombre.Equals(Nombre))
                {
                    int respuesta = ConsultaInstitucion.ActualizarInstitucion(IdInstitucion, Abreviacion, Nombre);

                    if (respuesta == 1)
                    {
                        validar = true;
                        msj = "Los datos se han modificado exitosamente";
                    }
                    else
                    {
                        validar = false;
                        msj = "Los datos no se han modificado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                    }
                }
                else
                {
                    validar = false;
                    msj = "No se han guardados los datos debido a que no existen cambios";
                }
            }
            else
            {
                validar = false;
                msj = "No se puede modificar la isntitucion porque ya existe otra con el mismo nombre.";
            }
            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [HttpDelete]
        public JsonResult EliminarInstitucion(int IdInstitucion)
        {
            String msj;
            bool validar;
            int respuesta = ConsultaInstitucion.EliminarInstitucion(IdInstitucion);

            if (respuesta == 1)
            {
                validar = true;
                msj = "Los datos se han eliminado exitosamente";
            }
            else
            {
                validar = false;
                msj = "Los datos no se han eliminado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
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
