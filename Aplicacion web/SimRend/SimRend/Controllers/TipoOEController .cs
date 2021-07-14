using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.DbSimRend;
using SimRend.Models;

namespace SimRend.Controllers
{
    public class TipoOEController : Controller
    {
        public IActionResult TipoOE()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LeerTipoOE()
        {
            List<TipoOE> listadoTipoOE = ConsultaTipoOE.LeerTipoOE();
            return Json(listadoTipoOE);
        }

        [HttpPost]
        public JsonResult CrearTipoOE(String Nombre, String NombreExtendido)
        {
            List<TipoOE> listadoTipoOE = ConsultaTipoOE.LeerTipoOE();
            String msj;
            bool validar;

            if (listadoTipoOE.Find(tipoOE => tipoOE.Nombre.Equals(Nombre, StringComparison.OrdinalIgnoreCase) && tipoOE.NombreExtendido.Equals(NombreExtendido, StringComparison.OrdinalIgnoreCase)) == null)
            {
                int respuesta = ConsultaTipoOE.CrearTipoOE(Nombre, NombreExtendido);

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
                msj = "No se puede guardar el tipo de O.E. porque ya existe otra con el mismo nombre.";
            }
            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [HttpPost]
        public JsonResult ActualizarTipoOE(int IdTipoOE, String Nombre, String NombreExtendido)
        {
            List<TipoOE> listadoTipoOE = ConsultaTipoOE.LeerTipoOE();
            String msj;
            bool validar;

            if (listadoTipoOE.Find(tipoOE => tipoOE.Nombre.Equals(Nombre, StringComparison.OrdinalIgnoreCase) && tipoOE.NombreExtendido.Equals(NombreExtendido, StringComparison.OrdinalIgnoreCase)) == null)
            {
                if (!listadoTipoOE.Find(tipoOE => tipoOE.Id == IdTipoOE).Nombre.Equals(Nombre) || !listadoTipoOE.Find(tipoOE => tipoOE.Id == IdTipoOE).NombreExtendido.Equals(NombreExtendido))
                {
                    int respuesta = ConsultaTipoOE.ActualizarTipoOE(IdTipoOE, Nombre, NombreExtendido);

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
                msj = "No se puede modificar el tipo de O.E. porque ya existe otra con el mismo nombre.";
            }
            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [HttpDelete]
        public JsonResult EliminarTipoOE(int IdTipoOE)
        {
            String msj;
            bool validar;
            int respuesta = ConsultaTipoOE.EliminarTipoOE(IdTipoOE);

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
