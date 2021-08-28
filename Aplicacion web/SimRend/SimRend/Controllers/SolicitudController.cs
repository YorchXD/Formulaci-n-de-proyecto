using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimRend.DbSimRend;
using SimRend.Filters;
using SimRend.Models;
using SimRend.Utility;

namespace SimRend.Controllers
{
    public class SolicitudController : Controller
    {
        private IConverter _converter;
        public SolicitudController(IConverter converter)
        {
            _converter = converter;
        }

        [AutorizacionUsuario(idOperacion:2)]
        public IActionResult Solicitudes()
        {
            return View();
        }

  
        [AutorizacionUsuario(idOperacion: 1)]
        public IActionResult CrearSolicitud()
        {
            HttpContext.Session.SetComplexData("Proceso", null);
            return View();
        }

        [AutorizacionUsuario(idOperacion: 2)]
        public IActionResult VerSolicitud()
        {
            //String idSolicitud = HttpContext.Session.GetComplexData<String>("idSolicitud");
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

        [AutorizacionUsuario(idOperacion: 3)]
        public IActionResult ActualizarSolicitud()
        {
            //String idSolicitud = HttpContext.Session.GetComplexData<String>("idSolicitud");
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

        /*#######################################Proceso de creacion###################################################*/
        

        [HttpPost]
        public JsonResult AgregarCategoria(int IdCategoria, string NombreCategoria)
        {
            try
            {
                //Solicitud solicitud = HttpContext.Session.GetComplexData<Solicitud>("Solicitud");
                Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
                Categoria categoria = new Categoria()
                {
                    Id = IdCategoria,
                    Nombre = NombreCategoria
                };


                if(proceso.Solicitud.Categorias==null)
                {
                    proceso.Solicitud.Categorias = new List<Categoria>();
                }

                proceso.Solicitud.Categorias.Add(categoria);

                ConsultaSolicitud.AgregarCategoria(proceso.Solicitud.Id, categoria.Id, DateTime.Now);
                HttpContext.Session.SetComplexData("Proceso", proceso);
                return Json(true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Json(false);
        }

        [HttpPost]
        public JsonResult AgregarParticipante(String Nombre, String RUN)
        {
            try
            {
                Persona participante = new Persona()
                {
                    Nombre = Nombre,
                    RUN = RUN
                };

                //Solicitud solicitud = HttpContext.Session.GetComplexData<Solicitud>("Solicitud");
                Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");

                if(proceso.Solicitud.Participantes==null)
                {
                    proceso.Solicitud.Participantes = new List<Persona>();
                }

                if (ConsultaSolicitud.LeerParticipante(participante.RUN)==null)
                {
                    ConsultaSolicitud.AgregarParticipante(participante);
                }

                ConsultaSolicitud.AgregarParSol(participante.RUN, proceso.Solicitud.Id, DateTime.Now);
                proceso.Solicitud.Participantes.Add(participante);
                HttpContext.Session.SetComplexData("Proceso", proceso);

                return Json(new
                {
                    validacion = true,
                    mensaje = "Se ha guardado los datos del participante satisfactoriamente."
                });

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Json(new
            {
                validacion = false,
                mensaje = "No se han guardado los datos del participante. Verifique los campos y vuelva a intentarlo nuevamente."
            });
        }


        /*###################################Fin Proceso de creacion###################################################*/

        /*#######################################Proceso de Lecturas###################################################*/
        [HttpPost]
        public JsonResult LeerParticipante(String RUN)
        {
            /*Buscar participante si es que existe en la solicitud*/
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            List<Persona> Participantes = ConsultaSolicitud.LeerParticipantes(proceso.Solicitud.Id);
            Boolean exitPartSol = false;
            if (Participantes != null)
            {
                exitPartSol = Participantes.Any(participante => participante.RUN == RUN);
            }

            Persona participante;

            /*Si existe el participante en la solicitud envia los datos del participante de la solicitud*/
            if (exitPartSol)
            {
                participante = Participantes.Find(participante => participante.RUN == RUN);
            }
            /*Si no existe el participante en la solicitud envia los datos del participante que se encuentre registrado en el sistema. Y si no existe, se envia un null*/
            else
            {
                participante = ConsultaSolicitud.LeerParticipante(RUN);
            }
            return Json(new { participante, exitPartSol });
        }

        [HttpPost]
        public JsonResult LeerRepresentantesHabilitados()
        {
            //Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
            String tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
            if (tipoUsuario.Equals("Estudiante dirigente"))
            {
                Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                List<Organizacion> organizaciones = ConsultaUsuario.LeerOrganizacion(usuario.Id, tipoUsuario);
                Organizacion organizacion = organizaciones[0];
                List<UsuarioRepresentante> representantes = ConsultaUsuario.LeerRepresentantes(0, organizacion.Id, 0);
                //List<UsuarioRepresentante> representantes = ConsultaSolicitud.LeerRepresetantesHabilitados(usuario.Organizacion.Id);
                if (representantes != null)
                {
                    representantes = representantes.Where(responsable => !responsable.CrearSolicitud.Equals("Deshabilitado")).ToList();
                    return Json(representantes);
                }
            }
            
            return Json(new object());
        }

        [HttpPost]
        public JsonResult LeerRepresentantesHabilitadosActualizar(int IdResponsable)
        {
            //Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
            String tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
            if (tipoUsuario.Equals("Representante"))
            {
                Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                List<Organizacion> organizaciones = ConsultaUsuario.LeerOrganizacion(usuario.Id, tipoUsuario);
                Organizacion organizacion = organizaciones[0];
                List<UsuarioRepresentante> representantes = ConsultaUsuario.LeerRepresentantes(0, organizacion.Id, 0);
                //List<UsuarioRepresentante> representantes = ConsultaSolicitud.LeerRepresetantesHabilitados(usuario.Organizacion.Id);
                if (representantes != null)
                {
                    UsuarioRepresentante representanteSelec = representantes.Find(responsable => responsable.Id == IdResponsable);
                    representantes = representantes.Where(responsable => !responsable.CrearSolicitud.Equals("Desabilitado")).ToList();
                    representantes.Add(representanteSelec);
                    return Json(representantes);
                }
            }
            
            return Json(new object());
        }

        /*Muestra las categorias que aun no han sido registradas en la solicitud*/
        [HttpPost]
        public JsonResult LeerCategorias()
        {
            //Solicitud solicitud = HttpContext.Session.GetComplexData<Solicitud>("Solicitud");
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");

            List<Categoria> Categorias = ConsultaSolicitud.LeerCategorias();
            List<Categoria> CategoriasSeleccionadas = null;

            if(proceso!=null && proceso.Solicitud!=null)
            {
                CategoriasSeleccionadas = ConsultaSolicitud.LeerCategoriasSeleccionadas(proceso.Solicitud.Id);
            }

            if (CategoriasSeleccionadas != null)
            {
                foreach (Categoria categoria in CategoriasSeleccionadas)
                {
                    int count = 0;
                    while (!Categorias[count].Nombre.Equals(categoria.Nombre))
                    {
                        count++;
                    }
                    if (count < Categorias.Count)
                    {
                        Categorias.RemoveAt(count);
                    }
                }                
            }
            return Json(Categorias);
        }

        [HttpPost]
        public JsonResult LeerCategoriasSeleccionadas()
        {
            //Solicitud solicitud = HttpContext.Session.GetComplexData<Solicitud>("Solicitud");
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            //Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");

            List<Categoria> CategoriasSeleccionadas = ConsultaSolicitud.LeerCategoriasSeleccionadas(proceso.Solicitud.Id);

            if (CategoriasSeleccionadas != null)
            {
                return Json(CategoriasSeleccionadas);
            }
            return Json(new object());
        }

        [HttpPost]
        public JsonResult LeerSolicitud()
        {
            //Solicitud solicitud = HttpContext.Session.GetComplexData<Solicitud>("Solicitud");
            //int idSolicitud = Convert.ToInt32(HttpContext.Session.GetComplexData<String>("idSolicitud"));
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            /*if (proceso.Solicitud==null)
            {
                proceso.Solicitud = ConsultaSolicitud.LeerSolicitud(idSolicitud);
            }*/

            if(proceso.Solicitud.NombreResponsable == null)
            {
                proceso.Solicitud.NombreResponsable = proceso.Responsable.Nombre;
            }

            if(proceso.Solicitud.Categorias==null)
            {
                proceso.Solicitud.Categorias = ConsultaSolicitud.LeerCategoriasSeleccionadas(proceso.Solicitud.Id);
            }

            if(proceso.Solicitud.Participantes==null)
            {
                proceso.Solicitud.Participantes = ConsultaSolicitud.LeerParticipantes(proceso.Solicitud.Id);
            }

            HttpContext.Session.SetComplexData("Proceso", proceso);

            //HttpContext.Session.SetComplexData("Solicitud", solicitud);

            return Json(new
            {
                validacion = true,
                solicitud = proceso.Solicitud,
                idResponsable = proceso.Responsable.Id,
                estado = proceso.Estado,
                estadoFinal = proceso.EstadoFinal
            }) ;
        }

        [HttpPost]
        public JsonResult LeerParticipantes()
        {
            //Solicitud solicitud = HttpContext.Session.GetComplexData<Solicitud>("Solicitud");
            //Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            List<Persona> Participantes = ConsultaSolicitud.LeerParticipantes(proceso.Solicitud.Id);

            if (Participantes != null)
            {
                return Json(Participantes);
            }
            return Json(new object());
        }


        /*###################################Fin Proceso de Lecturas###################################################*/

        /*#######################################Proceso de Actualizacion##############################################*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NombreEvento"></param>
        /// <param name="LugarEvento"></param>
        /// <param name="Monto"></param>
        /// <param name="FechaInicio"></param>
        /// <param name="FechaTermino"></param>
        /// <param name="Responsable"></param>
        /// <param name="TipoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarDatosPrincipales(String NombreEvento, String LugarEvento, int Monto, DateTime FechaInicio, DateTime FechaTermino, int IdResponsable, String TipoEvento)
        {
            try
            {
                Solicitud solicitud = new Solicitud()
                {
                    NombreEvento = NombreEvento,
                    LugarEvento = LugarEvento,
                    Monto = Monto,
                    FechaInicioEvento = FechaInicio,
                    FechaTerminoEvento = FechaTermino,
                    TipoEvento = TipoEvento,
                    FechaCreacion = DateTime.Now,
                    FechaFinPdf = DateTime.Now,
                    FechaModificacion = DateTime.Now
                };

                Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");

                Solicitud solExistente = null;

                if(proceso!=null)
                {
                    solExistente = proceso.Solicitud;
                }
                    
              
                if (solExistente == null)
                {
                    //Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                    String tipoUsuario = HttpContext.Session.GetString("TipoUsuario");

                    /*Se asume que el usuario es un representante*/
                    Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                    List<Organizacion> organizaciones = ConsultaUsuario.LeerOrganizacion(usuario.Id, tipoUsuario);
                    Organizacion organizacion = organizaciones[0];

                    solicitud.Id = ConsultaSolicitud.CrearSolicitud(solicitud); //Creacion de la solicitud
                    
                    int idOrganizacion = organizacion.Id;
                    int estado = 1; /*Representa que la solicitud esta en estado de edicion*/
                    solicitud.RefProceso = ConsultaSolicitud.CrearProcesoFondo(idOrganizacion, solicitud.Id, estado, IdResponsable); //Agrega el estado en que se encuentra la solicitud
                    ConsultasGenerales.ActualizarEstadoUsuarioRepresentate(IdResponsable, "Deshabilitado");

                    proceso = new Proceso()
                    {
                        Responsable = ConsultaUsuario.LeerRepresentante(IdResponsable),
                        Solicitud = solicitud
                    };

                    HttpContext.Session.SetComplexData("Proceso", proceso);

                    return Json(new
                    {
                        validacion = true,
                        mensaje = "Se han guardado los datos satisfactoriamente.",
                        solicitud = proceso.Solicitud
                    });
                }
                else
                {
                    Boolean DatosModificados = VerificarCambiosSolicitud(solExistente, solicitud);
                    if (DatosModificados)
                    {
                        solicitud.Id = solExistente.Id;
                        ConsultaSolicitud.ModificarSolicitud(solicitud);
                        ConsultaSolicitud.ModificarResponsableFondo(solicitud.Id, IdResponsable);

                        if (proceso.Responsable.Id != IdResponsable)
                        {
                            ConsultasGenerales.ActualizarEstadoUsuarioRepresentate(proceso.Responsable.Id, "Habilitado");
                            ConsultasGenerales.ActualizarEstadoUsuarioRepresentate(IdResponsable, "Desabilitado");
                            proceso.Responsable = ConsultaUsuario.LeerRepresentante(IdResponsable);
                        }
                        
                        proceso.Solicitud = solicitud;

                        HttpContext.Session.SetComplexData("Proceso", proceso);
                        return Json(new
                        {
                            validacion = true,
                            mensaje = "Se han guardado los datos satisfactoriamente.",
                            solicitud = proceso.Solicitud
                        });
                    }
                    else if (!DatosModificados)
                    {

                        return Json(new
                        {
                            validacion = true,
                            mensaje = "No existen cambios en la solicitud.",
                            solicitud = proceso.Solicitud
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return Json(new
            {
                validacion = false,
                mensaje = "No se han guardado los datos. Verifique los campos y vuelva a intentarlo nuevamente."
            });

        }

        public Boolean VerificarCambiosSolicitud(Solicitud solExistente, Solicitud solNueva)
        {
            if (!solExistente.NombreEvento.Equals(solNueva.NombreEvento) || !solExistente.LugarEvento.Equals(solNueva.LugarEvento) ||
                solExistente.Monto != solNueva.Monto || solExistente.FechaInicioEvento != solNueva.FechaInicioEvento ||
                solExistente.FechaTerminoEvento != solNueva.FechaTerminoEvento  ||
                !solExistente.TipoEvento.Equals(solNueva.TipoEvento))
            {
                return true;
            }

            return false;
        }

        public JsonResult ActualizarEstadoProceso()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            Boolean validar = ConsultasGenerales.ActualizarEstadoProceso(2, proceso.Solicitud.Id, "Solicitud");
            if(validar)
            {
                proceso.Estado = 2;
                HttpContext.Session.SetComplexData("Proceso", proceso);
            }
            
            return Json(validar);
        }

        public JsonResult ActualizarParticipante(String Run, String Nombre)
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            DateTime fechaModificacion = DateTime.Now;
            int validar = ConsultaSolicitud.ModificarParticipante(Nombre, Run, proceso.Solicitud.Id, fechaModificacion);
            return Json(validar);
        }

        
        /*###################################Fin Proceso de Actualizacion##############################################*/

        /*#######################################Proceso de Eliminar###################################################*/

        [HttpPost]
        public JsonResult EliminarCategoria(int IdCategoria)
        {
            //Solicitud solicitud = HttpContext.Session.GetComplexData<Solicitud>("Solicitud");
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            Boolean validar = ConsultaSolicitud.EliminarCategoria(proceso.Solicitud.Id, IdCategoria, DateTime.Now);

            if(validar)
            {
                HttpContext.Session.SetComplexData("Proceso", proceso);
            }
            return Json(validar);
        }

        [HttpPost]
        public JsonResult EliminarParticipante(String IdParticipante)
        {
            //Solicitud solicitud = HttpContext.Session.GetComplexData<Solicitud>("Solicitud");
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            Boolean validar = ConsultaSolicitud.EliminarParticipante(proceso.Solicitud.Id, IdParticipante, DateTime.Now);
            if(validar)
            {
                proceso.Solicitud.Participantes.RemoveAll(participante => participante.RUN == IdParticipante);
                HttpContext.Session.SetComplexData("Proceso", proceso);
            }
            return Json(validar);
        }

        [HttpPost]
        public JsonResult EliminarSolicitud()
        {
            Boolean validar;
            string titulo, msj;
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            int validacion = ConsultaSolicitud.EliminarSolicitud(proceso.Solicitud.Id);
            if (validacion > 0)
            {
                HttpContext.Session.SetComplexData("Proceso", null);
                validar = true;
                titulo = "Solicitud eliminada existosamente";
                msj = "Se ha eliminado los datos de la solicitud en el sistema sin inconveniente.";
            }
            else if (validacion == -2)
            {
                validar = false;
                titulo = "Se ha producido un problema";
                msj = "La solicitud no se pudo eliminar. Esto puede suceder a causa de valores erroneos internamente. Si el problema persiste, favor de contactarse con soporte.";
            }
            else
            {
                validar = false;
                titulo = "Se ha producido un problema";
                msj = "La solicitud no se pudo eliminar. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
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
        public FileResult DescargarSolicitud()
        {
            Proceso proceso = obtenerProceso();
            var convertidor = new SynchronizedConverter(new PdfTools());
            //var convertidor = new BasicConverter(new PdfTools());
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.Letter,

                /*ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },*/
                DocumentTitle = "PDF Solicitud"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = @"" + TemplatePDF.SolicitudPdf(proceso),
                WebSettings ={DefaultEncoding = "utf-8"},
                //WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            //var file = _converter.Convert(pdf);
            byte[] file = convertidor.Convert(pdf);
            return File(file, "application/pdf", "Soliciud.pdf");
        }

        private Proceso obtenerProceso()
        {
            Proceso procesoAux = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            Proceso proceso = new Proceso();
            proceso.Solicitud = ConsultaSolicitud.LeerSolicitud(procesoAux.Solicitud.Id);
            proceso.Solicitud.FechaPdf = proceso.Solicitud.FechaFinPdf.ToString("D", new System.Globalization.CultureInfo("es-ES"));
            proceso.Solicitud.Categorias = ConsultaSolicitud.LeerCategoriasSeleccionadas(procesoAux.Solicitud.Id);
            proceso.Solicitud.Participantes = ConsultaSolicitud.LeerParticipantes(procesoAux.Solicitud.Id);
            
            proceso.Responsable = ConsultaUsuario.LeerRepresentante(procesoAux.Responsable.Id);
            
            proceso.Organizacion = ConsultaSolicitud.LeerOrganizacion(procesoAux.Solicitud.Id);
            proceso.Direccion = ConsultaSolicitud.LeerDireccion(procesoAux.Solicitud.Id);

            if (proceso.Solicitud.Participantes != null)
            {
                proceso.Solicitud.MontoPorPersona = proceso.Solicitud.Monto / proceso.Solicitud.Participantes.Count();
            }

            if (proceso.Solicitud.FechaInicioEvento != proceso.Solicitud.FechaTerminoEvento)
            {
                proceso.Solicitud.FechaEvento = "Desde el " + proceso.Solicitud.FechaInicioEvento.ToString("dddd", new System.Globalization.CultureInfo("es-ES")) + ", " + proceso.Solicitud.FechaInicioEvento.ToString("M", new System.Globalization.CultureInfo("es-ES")) +
                " hasta el " + proceso.Solicitud.FechaTerminoEvento.ToString("D", new System.Globalization.CultureInfo("es-ES"));
            }
            else
            {
                proceso.Solicitud.FechaEvento = proceso.Solicitud.FechaInicioEvento.ToString("D", new System.Globalization.CultureInfo("es-ES"));
            }
            return proceso;
        }
    }
}
