using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.DbSimRend;
using SimRend.Models;

namespace SimRend.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Categoria()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LeerCategorias()
        {
            List<Categoria> Categorias = ConsultaCategoria.LeerCategorias();
            return Json(Categorias);
        }

        [HttpPost]
        public JsonResult CrearCategoria(String Nombre)
        {
            List<Categoria> Categorias = ConsultaCategoria.LeerCategorias();
            String msj;
            bool validar;

            if (Categorias.Find(categoria => categoria.Nombre.Equals(Nombre, StringComparison.OrdinalIgnoreCase)) == null)
            {
                int respuesta = ConsultaCategoria.CrearCategoria(Nombre);

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
                msj = "No se puede guardar la categoría porque ya existe otra con el mismo nombre.";
            }
            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [HttpPost]
        public JsonResult ActualizarCategoria(int IdCategoria, String Nombre)
        {
            List<Categoria> Categorias = ConsultaCategoria.LeerCategorias();
            String msj;
            bool validar;

            if (Categorias.Find(categoria => categoria.Nombre.Equals(Nombre, StringComparison.OrdinalIgnoreCase) && categoria.Id != IdCategoria) == null)
            {
                if (!Categorias.Find(categoria => categoria.Id == IdCategoria).Nombre.Equals(Nombre))
                {
                    int respuesta = ConsultaCategoria.ActualizarCategoria(IdCategoria, Nombre);

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
                msj = "No se puede modificar la categoría porque ya existe otra con el mismo nombre.";
            }
            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [HttpDelete]
        public JsonResult EliminarCategoria(int IdCategoria)
        {
            String msj;
            bool validar;
            int respuesta = ConsultaCategoria.EliminarCategoria(IdCategoria);

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
