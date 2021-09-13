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
    public class CampusController : Controller
    {
        [AutorizacionUsuario(idOperacion: 18)]
        public IActionResult Campus()
        {
            return View();
        }

        [AutorizacionUsuarioJS(idOperacion: 18)]
        [HttpPost]
        public JsonResult LeerCampus()
        {
            List<Campus> Campus = ConsultaCampus.LeerCampus();
            return Json(Campus);
        }

        [AutorizacionUsuarioJS(idOperacion: 17)]
        [HttpPost]
        public JsonResult CrearCampus(String Nombre)
        {
            List<Campus> Campus = ConsultaCampus.LeerCampus();
            String msj;
            bool validar;

            if (Campus.Find(campus => campus.Nombre.Equals(Nombre, StringComparison.OrdinalIgnoreCase)) == null)
            {
                int respuesta = ConsultaCampus.CrearCampus(Nombre);

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
                msj = "No se puede guardar el campus porque ya existe otra con el mismo nombre.";
            }
            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [AutorizacionUsuarioJS(idOperacion: 19)]
        [HttpPost]
        public JsonResult ActualizarCampus(int IdCampus, String Nombre)
        {
            List<Campus> Campus = ConsultaCampus.LeerCampus();
            String msj;
            bool validar;

            if (Campus.Find(campus => campus.Nombre.Equals(Nombre, StringComparison.OrdinalIgnoreCase) && campus.Id != IdCampus) == null)
            {
                if (!Campus.Find(campus => campus.Id == IdCampus).Nombre.Equals(Nombre))
                {
                    int respuesta = ConsultaCampus.ActualizarCampus(IdCampus, Nombre);

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
                msj = "No se puede modificar el campus porque ya existe otra con el mismo nombre.";
            }
            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [AutorizacionUsuarioJS(idOperacion: 20)]
        [HttpDelete]
        public JsonResult EliminarCampus(int IdCampus)
        {
            String msj;
            bool validar;
            int respuesta = ConsultaCampus.EliminarCampus(IdCampus);

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
