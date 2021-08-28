using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet.Messages;
using SimRend.DbSimRend;
using SimRend.Filters;
using SimRend.Models;

namespace SimRend.Controllers
{
    public class ProcesoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProcesoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Procesos()
        {
            CrearCarpetaOrganizacion();
            HttpContext.Session.SetComplexData("Proceso", null);
            HttpContext.Session.SetComplexData("IdParticipante", null);
            HttpContext.Session.SetComplexData("IdDocumento", null);
            /*HttpContext.Session.SetComplexData("Solicitud", null);
            HttpContext.Session.SetComplexData("idSolicitud", null);
            HttpContext.Session.SetComplexData("idResolucion", null);
            HttpContext.Session.SetComplexData("idDeclaracionGastos", null);
            ViewData["idSolicitud"] = null;*/
            return View();
        }

        [AutorizacionUsuario(idOperacion: 2)]
        public IActionResult VerProceso()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");

            if (proceso.Solicitud != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Procesos", "Proceso");
            }
        }

        /// <summary>
        /// Guarda todos los id de un proceso en particular en session(id de la solicitud, id de la resolucion  y el 
        /// id de la declaracion de gastos). Por otra parte se guarda además el estado actual que se encuentra el proceso
        /// los cuales pueden ser (1.) Edicion solicitud, (2.) Solicitud terminada, (3.) Resolucion terminada, (4.) Declaracion de gastos terminada
        /// </summary>
        /// <param name="IdSolicitud"></param>
        /// <param name="IdResolucion"></param>
        /// <param name="IdDeclaracionGastos"></param>
        /// <param name="Estado"></param>
        [HttpPost]
        public void GuardarId(int IdSolicitud, int IdResolucion, int IdDeclaracionGastos, int IdResponsable, int Estado, String EstadoFinal)
        {
            //HttpContext.Session.SetComplexData("idSolicitud", IdSolicitud);
            Proceso proceso = new Proceso();
            proceso.Estado = Estado;
            proceso.EstadoFinal = EstadoFinal;
            proceso.Solicitud = ConsultaSolicitud.LeerSolicitud(IdSolicitud);
            proceso.Responsable = ConsultaUsuario.LeerRepresentante(IdResponsable);
            proceso.Direccion = ConsultaSolicitud.LeerDireccion(IdSolicitud);
            proceso.Solicitud.Categorias = ConsultaSolicitud.LeerCategoriasSeleccionadas(IdSolicitud);

            if (proceso.Solicitud.NombreResponsable == null)
            {
                proceso.Solicitud.NombreResponsable = ConsultaUsuario.LeerRepresentante(IdResponsable).Nombre;
            }

            if(proceso.Solicitud.TipoEvento == "Grupal" && proceso.Solicitud.Participantes==null)
            {
                proceso.Solicitud.Participantes = ConsultaSolicitud.LeerParticipantes(proceso.Solicitud.Id);
            }
            
            if(proceso.Solicitud.Participantes == null)
            {
                proceso.Solicitud.Participantes = new List<Persona>();
            }
            
            proceso.Solicitud.Participantes.Add(new Persona()
            {
                Nombre = "Documentos en conjunto",
                RUN = "-1"
            });

            if (IdResolucion!=-1)
            {
                proceso.Resolucion = ConsultaResolucion.LeerResolucion(IdResolucion);
            }

            if(IdDeclaracionGastos!=-1)
            {
                proceso.DeclaracionGastos = ConsultaDeclaracionGastos.LeerDeclaracionGastos(IdDeclaracionGastos);
            }
            HttpContext.Session.SetComplexData("Proceso", proceso);
        }

        [HttpPost]
        public JsonResult LeerProcesos(int Anio, String TipoProceso)
        {
            
            String tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
            if (tipoUsuario.Equals("Director")||tipoUsuario.Equals("Estudiante dirigente"))
            {
                Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                List<Organizacion> organizaciones = ConsultaUsuario.LeerOrganizacion(usuario.Id, tipoUsuario);
                List<Proceso> procesos = ConsultasGenerales.LeerProcesosOrganizacion(organizaciones[0].Id, Anio, TipoProceso);
                if (procesos != null)
                {
                    return Json(procesos);
                }
            }
            else if(tipoUsuario.Equals("Vicerrector"))
            {
                Organizacion organizacion = HttpContext.Session.GetComplexData<Organizacion>("Organizacion");
                List<Proceso> procesos = ConsultasGenerales.LeerProcesosOrganizacion(organizacion.Id, Anio, TipoProceso);
                if (procesos != null)
                {
                    return Json(procesos);
                }
            }

            return Json(new Object());
        }

        [HttpPost]
        public JsonResult LeerAniosProceso()
        {
            String tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
            if (tipoUsuario.Equals("Director") || tipoUsuario.Equals("Estudiante dirigente"))
            {
                Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                List<Organizacion> organizaciones = ConsultaUsuario.LeerOrganizacion(usuario.Id, tipoUsuario);
                return Json(ConsultasGenerales.LeerAniosProcesos(organizaciones[0].Id));
            }
            else if (tipoUsuario.Equals("Vicerrector"))
            {
                Organizacion organizacion = HttpContext.Session.GetComplexData<Organizacion>("Organizacion");
                return Json(ConsultasGenerales.LeerAniosProcesos(organizacion.Id));
            }

            return null;
        }

        /// <summary>
        /// Se encarga de leer un proceso en particular que se encuentra registrado en sesion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult LeerProceso()
        {
            Proceso proceso = HttpContext.Session.GetComplexData<Proceso>("Proceso");
            var datos = new
            {
                solicitud = proceso.Solicitud,
                estado = proceso.Estado,
                estadoFinal = proceso.EstadoFinal
            };

            return Json(datos);
        }

        public void CrearCarpetaOrganizacion()
        {
            try
            {
                //Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                String tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
                if (tipoUsuario.Equals("Estudiante dirigente"))
                {
                    Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                    List<Organizacion> organizaciones = ConsultaUsuario.LeerOrganizacion(usuario.Id, tipoUsuario);
                    Organizacion organizacion = organizaciones[0];
                    if (organizacion != null)
                    {
                        string carpeta = @"wwwroot/Procesos/" + organizacion.Nombre;
                        if (!Directory.Exists(carpeta))
                        {
                            Directory.CreateDirectory(carpeta);
                        }
                    }

                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [HttpPost]
        public JsonResult EliminarPoceso(int IdSolicitud, int IdResolucion, int IdDeclaracionGastos, int fechaTerminoEvento, String EstadoFinal)
        {
            String tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
            string webRootPath = _webHostEnvironment.WebRootPath, msj, titulo;
            int eliminarSolicitud = -1, eliminarResolucion = -1, eliminarDG = -1;
            Boolean eliminarCarpeta = false, validar = false;

            if (tipoUsuario.Equals("Estudiante dirigente"))
            {
                Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                List<Organizacion> organizaciones = ConsultaUsuario.LeerOrganizacion(usuario.Id, tipoUsuario);
                Organizacion organizacion = organizaciones[0];

                if (IdDeclaracionGastos != -1)
                {
                    eliminarDG = ConsultaDeclaracionGastos.EliminarDocumentosDG(IdDeclaracionGastos);
                    if (eliminarDG == 1)
                    {
                        eliminarResolucion = ConsultaResolucion.EliminarResolucion(IdResolucion);
                        if (eliminarResolucion == 1)
                        {
                            eliminarSolicitud = ConsultaSolicitud.EliminarSolicitud(IdSolicitud);
                            eliminarCarpeta = true;
                        }
                    }
                }
                else if (IdResolucion != -1)
                {
                    eliminarResolucion = ConsultaResolucion.EliminarResolucion(IdResolucion);
                    if (eliminarResolucion == 1)
                    {
                        eliminarSolicitud = ConsultaSolicitud.EliminarSolicitud(IdSolicitud);
                        eliminarCarpeta = true;
                    }
                }
                else
                {
                    eliminarSolicitud = ConsultaSolicitud.EliminarSolicitud(IdSolicitud);
                    eliminarCarpeta = true;
                }

                try
                {
                    if (eliminarCarpeta)
                    {
                        string rutaCarpetaProceso = Path.Combine(webRootPath, "Procesos", organizacion.Nombre, fechaTerminoEvento.ToString(), IdSolicitud.ToString());
                        if (Directory.Exists(rutaCarpetaProceso))
                        {
                            Directory.Delete(rutaCarpetaProceso, true);
                        }
                        titulo = "Eliminación exitosa";
                        msj = "El proceso se ha eliminado correctamente";
                        validar = true;
                    }
                    else
                    {
                        titulo = "Se ha producido un problema";
                        msj = "El proceso no se ha podido eliminar. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                        validar = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    titulo = "Error";
                    msj = "Es probable que no se pueda eliminar el proceso debido a que exista algun problema de conexión o no exista la carpeta del proceso. Favor de contactarse con soporte";
                    validar = false;
                }

            }
            else
            {
                titulo = "Error";
                msj = "Usted no tiene permisos para eliminar procesos ya que no es un usuario representante";
                validar = false;
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
