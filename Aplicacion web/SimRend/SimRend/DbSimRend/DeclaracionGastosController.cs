﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimRend.Models;

namespace SimRend.DbSimRend
{
    public class DeclaracionGastosController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeclaracionGastosController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult VerDeclaracionGastos()
        {
            return View();
        }

        public IActionResult DocumentacionPersonas()
        {
            HttpContext.Session.SetComplexData("IdParticipante", null);
            HttpContext.Session.SetComplexData("IdDocumento", null);
            return View();
        }

        public IActionResult Documentos()
        {
            HttpContext.Session.SetComplexData("IdDocumento", null);
            return View();
        }

        public IActionResult CrearDocumento()
        {
            return View();
        }

        public IActionResult VerDocumento()
        {
            return View();
        }

        public IActionResult ActualizarDocumento()
        {
            return View();
        }

        /*#######################################Proceso de creacion###################################################*/
        [HttpPost]
        public JsonResult GuardarIdParticipante(String IdParticipante)
        {
            HttpContext.Session.SetComplexData("IdParticipante", IdParticipante);
            return Json(new object());
        }

        [HttpPost]
        public JsonResult GuardarIdDocumento(String IdDocumento)
        {
            HttpContext.Session.SetComplexData("IdDocumento", IdDocumento);
            return Json(new object());
        }

        [HttpPost]
        public JsonResult CrearDeclaracionDocumento(String CodigoDocumento, String Proveedor, DateTime FechaDocumento, int Monto,
            String DescripcionDocumento, int Categoria, String TipoDocumento, IFormFile Archivo)
        {
            string msj, titulo;
            bool validar;
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            String IdParticipante = HttpContext.Session.GetComplexData<String>("IdParticipante");
            int IdDocumento = 1;
            proceso.Solicitud.Participantes = ConsultaDeclaracionGastos.LeerDocumentos(proceso.DeclaracionGastos.Id, proceso.Solicitud.Participantes, proceso.Solicitud.Categorias);
            List<Documento> documentos = proceso.Solicitud.Participantes.Find(participante => participante.RUN.Equals(IdParticipante)).Documentos;

            if (documentos != null)
            {
                int i = documentos.Count - 1;
                FileInfo archivo = new FileInfo(documentos[i].CopiaDoc);
                String nombreDoc = Path.GetFileNameWithoutExtension(archivo.Name);
                IdDocumento = Convert.ToInt32(nombreDoc) + 1;
            }

            Documento DocumentoAux = new Documento()
            {
                CodigoDocumento = CodigoDocumento,
                Proveedor = Proveedor,
                FechaDocumento = FechaDocumento,
                Monto = Monto,
                DescripcionDocumento = DescripcionDocumento,
                Categoria = proceso.Solicitud.Categorias.Find(categoria => categoria.Id == Categoria),
                TipoDocumento = TipoDocumento,
                CopiaDoc = GuardarArchivoDeclaracionGastos(Archivo, proceso.Solicitud.Id, IdDocumento, IdParticipante)
            };

            DocumentoAux.Id = ConsultaDeclaracionGastos.CrearDocumento(DocumentoAux, IdParticipante, proceso.DeclaracionGastos.Id);

            if (DocumentoAux.Id > 0)
            {
                validar = true;
                titulo = "Datos guardados exitosamente";
                msj = "Los datos se han guardado exitosamente";
            }
            else if (DocumentoAux.Id == -2)
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

        public String GuardarArchivoDeclaracionGastos(IFormFile archivo, int idSolicitud, int idDocumento, String IdParticipante)
        {
            Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            string webRootPath = _webHostEnvironment.WebRootPath;
            string carpeta = Path.Combine(webRootPath, "Procesos", usuario.NombreOrganizacionEstudiantil, proceso.Solicitud.FechaTerminoEvento.Year.ToString(), idSolicitud.ToString(), "DeclaracionGastos", IdParticipante);
            //string carpeta = "wwwroot/Procesos/" + usuario.NombreOrganizacionEstudiantil + "/" + DateTime.Today.Year + "/" + idSolicitud + "/Resolucion";
            try
            {
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                /*string nombreArchivoAux = Path.GetFileName(archivo.FileName);
                String [] datosArchivo =  nombreArchivoAux.Split(".");
                string nombreArchivo = idDocumento.ToString()+"."+ datosArchivo[datosArchivo.Length - 1];*/

                String extension = Path.GetExtension(archivo.FileName);
                string nombreArchivo = idDocumento.ToString() + extension;
                string rutaArchivo = Path.Combine(carpeta, nombreArchivo);
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
        /*###################################Fin Proceso de creacion###################################################*/

        /*#######################################Proceso de Lecturas###################################################*/
        /// <summary>
        /// Se encarga de leer el resumen de una declaracion de gastos en particular que se encuentra registrado en sesion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LeerDeclaracionGastos()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            proceso.DeclaracionGastos = ConsultaDeclaracionGastos.LeerDeclaracionGastos(proceso.DeclaracionGastos.Id);
            HttpContext.Session.SetComplexData("Proceso", proceso);

            var datos = new
            {
                proceso
            };

            return Json(datos);
        }

        [HttpPost]
        public JsonResult LeerParticipantes()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            if (proceso.Solicitud.Participantes != null)
            {
                var datos = new
                {
                    participantes = ConsultaDeclaracionGastos.LeerDocumentos(proceso.DeclaracionGastos.Id, proceso.Solicitud.Participantes, proceso.Solicitud.Categorias),
                    montoSolicitado = proceso.Solicitud.Monto
                };
                return Json(datos);
            }
            return Json(new object());
        }


        [HttpPost]
        public JsonResult LeerParticipante()
        {
            String IdParticipante = HttpContext.Session.GetComplexData<String>("IdParticipante");
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");

            if (IdParticipante != null)
            {
                List<Persona> participantes = ConsultaDeclaracionGastos.LeerDocumentos(proceso.DeclaracionGastos.Id, proceso.Solicitud.Participantes, proceso.Solicitud.Categorias);
                int montoDocs = 0;
                for (int i = 0; i < participantes.Count(); i++)
                {
                    for (int j = 0; participantes[i].Documentos != null && j < participantes[i].Documentos.Count(); j++)
                    {
                        montoDocs += participantes[i].Documentos[j].Monto;
                    }
                }

                var datos = new
                {
                    participante = participantes.Find(participante => participante.RUN == IdParticipante),
                    montoSolicitado = proceso.Solicitud.Monto,
                    categorias = proceso.Solicitud.Categorias,
                    montoDocs
                };
                return Json(datos);
            }

            return Json(new object());
        }

        [HttpPost]
        public JsonResult ObtenerDatos()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            var datos = new
            {
                fechaInicio = proceso.Solicitud.FechaInicioEvento,
                fechaTermino = proceso.Solicitud.FechaTerminoEvento,
                categorias = proceso.Solicitud.Categorias,
                monto = proceso.Solicitud.Monto
            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult DatosDocumento()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            String IdParticipante = HttpContext.Session.GetComplexData<String>("IdParticipante");
            int IdDocumento = HttpContext.Session.GetComplexData<int>("IdDocumento");
            proceso.Solicitud.Participantes = ConsultaDeclaracionGastos.LeerDocumentos(proceso.DeclaracionGastos.Id, proceso.Solicitud.Participantes, proceso.Solicitud.Categorias);
            Documento documento = proceso.Solicitud.Participantes.Find(participante => participante.RUN.Equals(IdParticipante)).Documentos.Find(documento => documento.Id == IdDocumento);
            return Json(documento);
        }
        /*###################################Fin Proceso de Lecturas###################################################*/

        /*#######################################Proceso de Actualizacion##############################################*/
        [HttpPost]
        public JsonResult ModificarDocumento(String CodigoDocumento, String Proveedor, DateTime FechaDocumento, int Monto,
            String DescripcionDocumento, int Categoria, String TipoDocumento, IFormFile Archivo, Boolean CambioArchivo)
        {
            String msj, titulo, rutaDoc;
            bool validar;

            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            String IdParticipante = HttpContext.Session.GetComplexData<String>("IdParticipante");
            int IdDocumento = HttpContext.Session.GetComplexData<int>("IdDocumento");
            proceso.Solicitud.Participantes = ConsultaDeclaracionGastos.LeerDocumentos(proceso.DeclaracionGastos.Id, proceso.Solicitud.Participantes, proceso.Solicitud.Categorias);
            Documento documento = proceso.Solicitud.Participantes.Find(participante => participante.RUN.Equals(IdParticipante)).Documentos.Find(documento => documento.Id == IdDocumento);

            if (documento.CodigoDocumento != CodigoDocumento || documento.Proveedor != Proveedor || documento.FechaDocumento != FechaDocumento || documento.Monto != Monto ||
                documento.DescripcionDocumento != DescripcionDocumento || documento.Categoria.Id != Categoria || documento.TipoDocumento != TipoDocumento || CambioArchivo)
            {
                rutaDoc = documento.CopiaDoc;
                if (CambioArchivo)
                {
                    System.IO.File.Delete(documento.CopiaDoc);
                    Path.GetFileNameWithoutExtension(documento.CopiaDoc);
                    int nombreDoc = Convert.ToInt32(Path.GetFileNameWithoutExtension(documento.CopiaDoc));
                    rutaDoc = GuardarArchivoDeclaracionGastos(Archivo, proceso.Solicitud.Id, nombreDoc, IdParticipante);
                }

                Documento DocumentoAux = new Documento()
                {
                    Id = documento.Id,
                    CodigoDocumento = CodigoDocumento,
                    Proveedor = Proveedor,
                    FechaDocumento = FechaDocumento,
                    Monto = Monto,
                    DescripcionDocumento = DescripcionDocumento,
                    Categoria = proceso.Solicitud.Categorias.Find(categoria => categoria.Id == Categoria),
                    TipoDocumento = TipoDocumento,
                    CopiaDoc = rutaDoc
                };

                int respuesta = ConsultaDeclaracionGastos.ModificarDocumento(DocumentoAux);

                if (respuesta == 1)
                {
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
        /*###################################Fin Proceso de Actualizacion##############################################*/

        /*#######################################Proceso de Eliminar###################################################*/
        [HttpPost]
        public JsonResult EliminarDocumento(int IdDocumento)
        {
            string msj, titulo, carpetaDeclaracionGasto = "", carpetaRepresentante = "";
            /*Obtiene el ID del participante al cual se le eliminara el documento*/
            String IdParticipante = HttpContext.Session.GetComplexData<String>("IdParticipante");
            /*Obtiene los datos del proceso en general*/
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            /*Lee los documentos y se los asigna a los perticipantes correspondientes*/
            List<Persona> participantes = ConsultaDeclaracionGastos.LeerDocumentos(proceso.DeclaracionGastos.Id, proceso.Solicitud.Participantes, proceso.Solicitud.Categorias);

            int cantDocumentos = 0;
            int cantParticipantes = participantes.Count();
            int cantDocumentosParticipante = 0;
            Documento documento = null;
            int respEliminacion = -1;
            Boolean validar = false;

            try
            {
                for (int i = 0; i < cantParticipantes; i++)
                {
                    cantDocumentos += participantes[i].Documentos.Count();
                    if (participantes[i].RUN.Equals(IdParticipante))
                    {
                        cantDocumentosParticipante = participantes[i].Documentos.Count();
                        documento = participantes[i].Documentos.Find(documento => documento.Id == IdDocumento);
                    }
                }

                /*Eliminacion del documento*/
                if (documento != null)
                {
                    /*Elimina un documento en particular*/
                    respEliminacion = ConsultaDeclaracionGastos.EliminarDocumento(IdDocumento);
                    if (respEliminacion == 1)
                    {
                        System.IO.File.Delete(documento.CopiaDoc);
                    }
                }

                /*Eliminacion de carpetas en caso de que no existan documentos asociados tanto al participante como a la declaracion de gastos*/
                string[] ruta = documento.CopiaDoc.Split("\\");

                for (int i = 0; i < ruta.Length - 1; i++)
                {
                    if (i < ruta.Length - 2)
                    {
                        carpetaDeclaracionGasto = Path.Combine(carpetaDeclaracionGasto, ruta[i]);
                    }
                    carpetaRepresentante = Path.Combine(carpetaRepresentante, ruta[i]);
                }

                /*Borrara la carpeta que contiene los documentos del participante*/
                if (cantDocumentosParticipante == 1 && respEliminacion == 1)
                {
                    System.IO.Directory.Delete(carpetaRepresentante);
                }

                /*Borrara la carpeta de Declaracion de gastos que contiene los documentos(Boletas o facturas)*/
                if (cantDocumentos == 1 && respEliminacion == 1)
                {
                    System.IO.Directory.Delete(carpetaDeclaracionGasto);
                    proceso.Estado = 3;
                    HttpContext.Session.SetComplexData("Proceso", proceso);
                }

                if (respEliminacion == 1)
                {
                    validar = true;
                    titulo = "Eliminación exitosa";
                    msj = "Se ha eliminado el documento exitosamente";
                }
                else if (respEliminacion == -1)
                {
                    validar = false;
                    titulo = "Se ha producido un problema";
                    msj = "El documento no se ha podido eliminar. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
                else
                {
                    validar = false;
                    titulo = "Se ha producido un problema";
                    msj = "El documento no se ha podido eliminar. Puede que exista un problema en la funcion que elimina el documento en la base de datos. Favor de contactarse con soporte.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                validar = false;
                titulo = "Error";
                msj = "Es probable que no se pueda eliminar el documento debido a que la carpeta donde se encuentra el documento no se encuentre vacia.";
            }
            var datos = new
            {
                validar,
                titulo,
                msj
            };

            return Json(datos);
        }
        /*###################################Fin Proceso de Eliminar###################################################*/








        

        


        

        

        
        

        [HttpGet]
        public FileResult DescargarDocumento()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            String IdParticipante = HttpContext.Session.GetComplexData<String>("IdParticipante");
            int IdDocumento = HttpContext.Session.GetComplexData<int>("IdDocumento");
            proceso.Solicitud.Participantes = ConsultaDeclaracionGastos.LeerDocumentos(proceso.DeclaracionGastos.Id, proceso.Solicitud.Participantes, proceso.Solicitud.Categorias);
            Documento documento = proceso.Solicitud.Participantes.Find(participante => participante.RUN.Equals(IdParticipante)).Documentos.Find(documento => documento.Id == IdDocumento);
            String extension = Path.GetExtension(documento.CopiaDoc);
            String tipoDoc = "";

            switch (extension)
            {
                case ".jpeg":
                    tipoDoc = "image/jpeg";
                    break;
                case ".jpg":
                    tipoDoc = "image/jpg'";
                    break;
                case ".png":
                    tipoDoc = "image/png'";
                    break;
                default:
                    tipoDoc = "application/pdf";
                    break;
            }

            string nombreArchivoAux = Path.GetFileName(documento.CopiaDoc);
            var fileContent = new System.Net.WebClient().DownloadData(documento.CopiaDoc);
            return File(fileContent, tipoDoc, nombreArchivoAux);
        }

        /// <summary>
        /// Actualiza el estado del documento(1 para indicar que el documento esta seleccionado y 0 para indicar que el documento no esta seleccionado).
        /// A nivel de base de datos se actualizan los montos totales rendidos y los montos totales de los documentos en la tabla Declaracion de Gastos.
        /// </summary>
        /// <param name="Estado"></param>
        /// <param name="IdDocumento"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DocumentoSeleccionado(int Estado, int IdDocumento)
        {
            int validar = ConsultaDeclaracionGastos.DocumentoSeleccionado(Estado, IdDocumento);
            return Json(validar);
        }

        /// <summary>
        /// Obtiene todos los documentos del participante, el monto total de la solicitud y 
        /// el monto total de los documentos declarados como gasto del evento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DocumentosSeleccionados()
        {
            String IdParticipante = HttpContext.Session.GetComplexData<String>("IdParticipante");
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");

            if (IdParticipante != null)
            {
                List<Persona> participantes = ConsultaDeclaracionGastos.LeerDocumentos(proceso.DeclaracionGastos.Id, proceso.Solicitud.Participantes, proceso.Solicitud.Categorias);
                int montoDocsSelec = 0;
                for (int i = 0; i < participantes.Count(); i++)
                {
                    for (int j = 0; participantes[i].Documentos != null && j < participantes[i].Documentos.Count(); j++)
                    {
                        if(participantes[i].Documentos[j].Estado==1)
                        {
                            montoDocsSelec += participantes[i].Documentos[j].Monto;
                        }
                        
                    }
                }

                var datos = new
                {
                    participante = participantes.Find(participante => participante.RUN == IdParticipante),
                    montoSolicitado = proceso.Solicitud.Monto,
                    montoDocsSelec
                };
                return Json(datos);
            }

            return Json(new object());
        }
    }
}
