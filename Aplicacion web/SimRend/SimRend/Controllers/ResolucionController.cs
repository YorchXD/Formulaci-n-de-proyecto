using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimRend.DbSimRend;
using SimRend.Models;

namespace SimRend.Controllers
{
    public class ResolucionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ResolucionController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// En caso de existir la solicitud se procede a la vista Crear Resolución
        /// </summary>
        /// <returns></returns>
        public IActionResult CrearResolucion()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            if (proceso != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Procesos", "Proceso");
            }
        }
        
        public IActionResult VerResolucion()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            if (proceso.Resolucion != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Procesos", "Proceso");
            }


        }

        public IActionResult ActualizarResolucion()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CrearResolucion(int NumResolucion, int AnioResolucion, IFormFile Archivo)
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            string idSolicitud = proceso.Solicitud.Id.ToString();
            string ruta = GuardarArchivoResolucion(Archivo, idSolicitud);
            int idResolucion = ConsultaResolucion.CrearResolucion(AnioResolucion, NumResolucion, idSolicitud, ruta);
            string msj, titulo;
            bool validar;
            if (idResolucion > 0)
            {
                proceso.Resolucion = new Resolucion
                {
                    AnioResolucion = AnioResolucion,
                    NumResolucion = NumResolucion,
                    CopiaDoc = ruta,
                    Id = idResolucion
                };
                proceso.Estado = 3;
                HttpContext.Session.SetComplexData("Proceso", proceso);
                validar = true;
                titulo = "Datos guardados exitosamente";
                msj = "Los datos se han guardado exitosamente";
            }
            else if (idResolucion == -2)
            {
                validar = false;
                titulo = "Se ha producido un problema";
                msj = "Los datos no se han registrado correctamente. Esto se debe a que el número de la resolución y el año ya se encuentran registrado con anterioridad";
            }
            else
            {
                validar = false;
                titulo = "Se ha producido un problema";
                msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
            }

            var datos = new
            {
                validar,
                titulo,
                msj
            };

            return Json(datos);
        }

        public String GuardarArchivoResolucion(IFormFile archivo, string idSolicitud)
        {
            Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
            string webRootPath = _webHostEnvironment.WebRootPath;
            string carpeta = "";
            carpeta = Path.Combine(webRootPath, "Procesos", usuario.NombreOrganizacionEstudiantil, DateTime.Today.Year.ToString(), idSolicitud, "Resolucion");
            string rutaArchivo = "";
            //string carpeta = "wwwroot/Procesos/" + usuario.NombreOrganizacionEstudiantil + "/" + DateTime.Today.Year + "/" + idSolicitud + "/Resolucion";
            try
            {
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                //string nombreArchivo = Path.GetFileName(archivo.FileName);
                string nombreArchivo = "Resolucion.pdf";
                rutaArchivo = Path.Combine(carpeta, nombreArchivo);
                using (FileStream stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    archivo.CopyTo(stream);
                }
                return rutaArchivo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }



        /// <summary>
        /// Se encarga de obtener todos los datos de la resolucion los cuales son el año, el número de 
        /// la resolución y la copia del la resolucion en PDF
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LeerResolucion()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            var datos = new 
            {
                Estado=proceso.Estado,
                Resolucion = proceso.Resolucion
            };
            return Json(datos);
        }

        [HttpGet]
        public FileResult DescargarResolucion()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            //var ruta = @proceso.Resolucion.CopiaDoc;
            var fileContent = new System.Net.WebClient().DownloadData(proceso.Resolucion.CopiaDoc);
            return File(fileContent,
                        "application/pdf",
                        "Resolucion.pdf");
        }

        [HttpPost]
        public JsonResult ModificarResolucion(int NumResolucion, int AnioResolucion, IFormFile Archivo, Boolean CambioArchivo)
        {
            string msj, titulo, ruta;
            bool validar;
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");

            if (proceso.Resolucion.AnioResolucion!= AnioResolucion || proceso.Resolucion.NumResolucion!= NumResolucion || CambioArchivo)
            {

                if(CambioArchivo)
                {
                    System.IO.File.Delete(proceso.Resolucion.CopiaDoc);
                    ruta = GuardarArchivoResolucion(Archivo, proceso.Solicitud.Id.ToString());
                    proceso.Resolucion.CopiaDoc = ruta;
                }
                proceso.Resolucion.AnioResolucion = AnioResolucion;
                proceso.Resolucion.NumResolucion = NumResolucion;

                int respuesta = ConsultaResolucion.ActualizarResolucion(proceso.Resolucion);

                if(respuesta==1)
                {
                    HttpContext.Session.SetComplexData("Proceso", proceso);
                    validar = true;
                    titulo = "Datos modificados exitosamente";
                    msj = "Los datos se han modificado exitosamente";
                }
                else
                {
                    validar = false;
                    titulo = "Se ha producido un problema";
                    msj = "Los datos no se han modificado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            else
            {
                validar = true;
                titulo = "No existen cambios";
                msj = "No se han guardados los datos debido a que no existen cambios";
            }
            var datos = new
            {
                validar,
                titulo,
                msj
            };

            return Json(datos);
        }

        [HttpPost]
        public JsonResult EliminarResolucion()
        {
            string msj, titulo, carpeta="", carpeta1 = "";
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            string [] ruta = proceso.Resolucion.CopiaDoc.Split("\\");
            Boolean validar = false;

            for(int i = 0; i< ruta.Length - 1; i++)
            {
                if(i < ruta.Length - 2)
                {
                    carpeta = Path.Combine(carpeta, ruta[i]);
                }
                carpeta1 = Path.Combine(carpeta, ruta[i]);
            }

            try
            {
                System.IO.File.Delete(proceso.Resolucion.CopiaDoc);
                System.IO.Directory.Delete(carpeta1);
                System.IO.Directory.Delete(carpeta);
                int respuesta = ConsultaResolucion.EliminarResolucion(proceso.Resolucion.Id);

                if(respuesta == 1)
                {
                    proceso.Resolucion = null;
                    proceso.Estado = 2;
                    HttpContext.Session.SetComplexData("Proceso", proceso);
                    validar = true;
                    titulo = "Eliminación exitosa";
                    msj = "Se ha eliminado la resolución exitosamente";
                }
                else
                {
                    validar = false;
                    titulo = "Se ha producido un problema";
                    msj = "La resolución no se ha podido eliminar. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                validar = false;
                titulo = "Error";
                msj = "Es probable que no se pueda eliminar la resolucion debido a que la carpeta donde se encuentra la resolucion no se encuentan vacias.";
            }

            var datos = new
            {
                validar,
                titulo,
                msj
            };

            return Json(datos);
        }
    }
}
