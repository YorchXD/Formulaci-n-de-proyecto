using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SimRend.Models;
using SimRend.DbSimRend;
using System.Data;
using Microsoft.AspNetCore.Http;
using SimRend.Helpers;
using DinkToPdf;

namespace SimRend.Controllers
{
    public class SolicitudController : Controller
    {
        private readonly RequestHandler _requestHandler;

        public SolicitudController(RequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }
/*#######################################Proceso de Redirecciones##############################################*/
        public IActionResult IrCategoria(int IdSolicitud)
        {
            _requestHandler.SetIdSolicitud(IdSolicitud);
            return RedirectToAction("Category", "Solicitud");
        }

        public IActionResult IrCategoria()
        {
            return RedirectToAction("Category", "Solicitud");
        }
        public IActionResult IrPersona()
        {
            int idSolicitud = _requestHandler.GetIdSolicitud();
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud_Finalizada(idSolicitud);
            if(modelo.Solicitud.TipoActividad.Equals("Masiva"))
            {
                return IrResumen(idSolicitud);
            }
            return RedirectToAction("Person", "Solicitud");
        }

        public IActionResult IrPrincipal()
        {
            return RedirectToAction("TablaSolicitudes", "Principal");
        }

        public IActionResult IrResumen(int IdSolicitud)
        {
            _requestHandler.SetIdSolicitud(IdSolicitud);
            //return RedirectToAction("ProcesoFondoPorRendir", "Solicitud");
            return RedirectToAction("Resume", "Solicitud");
            //return RedirectToAction("GeneratePDF", "GeneratePDF");
            //return RedirectToAction("InfoRendicion", "Rendicion");
            //return RedirectToAction("Resolucion", "Resolucion");
            //return RedirectToAction("Rendicion", "Rendicion");
        }

/*###################################Fin Proceso de Redirecciones##############################################*/

/*#######################################Proceso de creacion###################################################*/

        /*Muestra el listado de responsables habilitados para realizar el proceso de solicitud de fondos*/
        public IActionResult Create()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            //Organizacion organizacion = new Organizacion();
            //organizacion.Id = Convert.ToInt32(TempData["idOrganizacion"]);
            int idOrganizacion = _requestHandler.GetIdAcceso();
            //TempData["idOrganizacion"] = idOrganizacion;
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Responsables = ConsultasGenerales.LeerRepresetantes(idOrganizacion);
            if (modelo.Responsables != null)
            {
                modelo.Responsables = modelo.Responsables.Where(responsable => !responsable.Estado.Equals("Desabilitado")).ToList();
                return View(modelo);
            }
            return View(modelo);

        }

        // POST: Solicitud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Monto,NombreEvento,FechaInicioEvento,FechaTerminoEvento,LugarEvento,RutResponsable, TipoActividad")] Solicitud solicitud)
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            if (ModelState.IsValid)
            {
                ConsultasGenerales.ModificarEstadoResponsable(solicitud.RutResponsable, "Desabilitado");
                solicitud.FechaActual = DateTime.Now;
                solicitud.FechaFinPdf = DateTime.Now;
                int idOrganizacion = _requestHandler.GetIdAcceso();
                int idSolicitud = ConsultaSolicitud.CrearSolicitud(solicitud);
                int estado = 1; /*Representa que la solicitud esta en estado de edicion*/
                ConsultaSolicitud.AgregarProcesoFondo(idOrganizacion, idSolicitud, estado);
                //TempData["idOrganizacion"] = idOrganizacion;
                return IrCategoria(idSolicitud);
            }
            return View(solicitud);
        }

        [HttpPost]
        public IActionResult AgregarCategoria(String Nombre)
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            SolicitudCategoria solcat = new SolicitudCategoria()
            {
                RefCategoria = Nombre,
                RefSolicitud = _requestHandler.GetIdSolicitud()
            };

            if (ModelState.IsValid)
            {
                ConsultaSolicitud.AgregarCategoria(solcat);
                return IrCategoria();
            }
            //int idOrganizacion = Convert.ToInt32(TempData["idOrganizacion"]);
            //TempData["idOrganizacion"] = idOrganizacion;
            return View(solcat);
        }

        [HttpPost]
        public IActionResult AgregarPersona([Bind("Nombre,Run")] Persona persona)
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();

            if (ModelState.IsValid)
            {
                ConsultaSolicitud.AgregarPersona(persona);
                ConsultaSolicitud.AgregarPerSol(persona.Run, idSolicitud);
                return IrPersona();
            }
            //int idOrganizacion = Convert.ToInt32(TempData["idOrganizacion"]);
            //TempData["idOrganizacion"] = idOrganizacion;
            return View(persona);
        }


/*###################################Fin Proceso de creacion###################################################*/

/*#######################################Proceso de Lecturas###################################################*/

        /*Muestra las categorias que ya han sido registradas en el sistema*/
        public IActionResult Category()
        {
            
            int idSolicitud = _requestHandler.GetIdSolicitud();
            ViewData["_usuario"] = _requestHandler.GetUsuario(); 
            List<Categoria> Categorias = ConsultaSolicitud.LeerTodoCategorias();
            
            List<Categoria> CategoriasSeleccionadas = ConsultaSolicitud.LeerCategoriasSeleccionadas(idSolicitud);

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
                ViewData["Seleccionadas"] = CategoriasSeleccionadas;
            }
            //int idOrganizacion = Convert.ToInt32(_requestHandler.GetIdAcceso());
            //TempData["idOrganizacion"] = idOrganizacion;
            return View(Categorias);
        }

        /*Muestra las personas que ya se encuentran registradas en el sistema*/
        public IActionResult Person()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            List<Persona> Personas = ConsultaSolicitud.LeerPersonasSolicitud(idSolicitud);

            if (Personas != null)
            {
                ViewData["Personas"] = Personas;
            }
            return View();
        }
/*###################################Fin Proceso de Lecturas###################################################*/

/*#######################################Proceso de Actualizacion##############################################*/

        public void Actualizar_FechaPDF_EstadoProceso()
        {
            int idSolicitud = _requestHandler.GetIdSolicitud();
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud_Finalizada(idSolicitud);
            modelo.Solicitud.FechaFinPdf = DateTime.Now;
            ConsultaSolicitud.Actualizar_Solicitud(modelo.Solicitud);
            int proceso=1; /*Indica que estamos en la solicitud*/
            int estado = 2; /*Indica que la solicitud esta ingresada y en espera de aceptacion*/
            ConsultasGenerales.Actualizar_Estado_Proceso(proceso, idSolicitud, estado);

        }
/*###################################Fin Proceso de Actualizacion##############################################*/

/*#######################################Proceso de Eliminar###################################################*/

// POST: Solicitud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult EliminarCategoria(String Nombre)
        {
            SolicitudCategoria solcat = new SolicitudCategoria()
            {
                RefCategoria = Nombre,
                RefSolicitud = _requestHandler.GetIdSolicitud()
            };

            if (ModelState.IsValid)
            {
                ConsultaSolicitud.EliminarCategoria(solcat);
                return IrCategoria();
            }
            return View(solcat);
        }

        // POST: Solicitud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult EliminarPersona(String Run)
        {
            SolicitudPersona solper = new SolicitudPersona()
            {
                RefPersona = Run,
                RefSolicitud = _requestHandler.GetIdSolicitud()
            };

            if (ModelState.IsValid)
            {
                ConsultaSolicitud.EliminarPersona(solper);
                return IrPersona();
            }
            return View(solper);
        }

/*###################################Fin Proceso de Eliminar###################################################*/

        
/*########################Funciones relacionadas con generar el pdf y mostrar la informacion del pdf###########################*/
        public IActionResult Resume()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            int idOrganizacion = _requestHandler.GetIdAcceso();
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud(idSolicitud);
            modelo.Solicitud.NombreResponsable = BuscarRepresentante(idOrganizacion, modelo.Solicitud.RutResponsable);
            return View(modelo);
        }

        private ModeloSolicitud obtenerModelo()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud_Finalizada(idSolicitud);
            modelo.Solicitud.FechaPdf = modelo.Solicitud.FechaFinPdf.ToString("D", new System.Globalization.CultureInfo("es-ES"));
            modelo.Responsable = ConsultasGenerales.Leer_Responsable(idSolicitud);
            modelo.Categorias = ConsultaSolicitud.LeerCategoriasSeleccionadas(idSolicitud);
            modelo.Participantes = ConsultaSolicitud.LeerPersonasSolicitud(idSolicitud);
            modelo.Organizacion = ConsultasGenerales.Leer_Organizacion(idSolicitud);
            if (modelo.Participantes != null)
            {
                modelo.Solicitud.MontoPorPersona = modelo.Solicitud.Monto / modelo.Participantes.Count();
            }
            if (modelo.Organizacion.Tipo.Equals("CAA"))
            {
                modelo.CAA = ConsultasGenerales.Leer_CAA(modelo.Organizacion.Id);
            }
            else
            {
                modelo.Federacion = ConsultasGenerales.Leer_Federacion(modelo.Organizacion.Id);
            }

            if (modelo.Solicitud.FechaInicioEvento != modelo.Solicitud.FechaTerminoEvento)
            {
                modelo.Solicitud.FechaEvento = "Desde el " + modelo.Solicitud.FechaInicioEvento.ToString("dddd", new System.Globalization.CultureInfo("es-ES")) + ", " + modelo.Solicitud.FechaInicioEvento.ToString("M", new System.Globalization.CultureInfo("es-ES")) +
                " hasta el " + modelo.Solicitud.FechaTerminoEvento.ToString("D", new System.Globalization.CultureInfo("es-ES"));
                
            }
            else
            {
                modelo.Solicitud.FechaEvento = modelo.Solicitud.FechaInicioEvento.ToString("D", new System.Globalization.CultureInfo("es-ES"));
            }

            return modelo;
        }

        public IActionResult GeneratePDF()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            ModeloSolicitud modelo = obtenerModelo();
            return View(modelo);
        }

        public IActionResult VerModEliPDF()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            ModeloSolicitud modelo = obtenerModelo();
            return View(modelo);
        }

        public string hacerPdf()
        {
            ModeloSolicitud modelo = obtenerModelo();
            String pagina = "<!DOCTYPE html><html><head><title></title>";
            pagina += "<style type = 'text/css'>";
            pagina += "table {border-spacing: 1;border-collapse: collapse;background: white;margin: 0 auto;position: relative;}";
            pagina += "table * {position: relative;}";
            pagina += "table td, table th {padding-left: 8px;}";
            pagina += "table thead tr {height: 40px;background: #000000;}";
            pagina += "table tbody tr {height: 30px;}";
            pagina += "table tbody tr:last-child {border: 0;}";
            pagina += "table td, table th {text-align: left;}";
            pagina += "table td.l, table th.l {text-align: right;}";
            pagina += "table td.c, table th.c {text-align: center;}";
            pagina += "table td.r, table th.r {text-align: center;}";

            pagina += ".table100-head th{color: #fff;line-height: 1.2;font-weight: unset;}";
            pagina += "tbody tr:nth-child(even) {background-color: #f5f5f5;}";
            pagina += "tbody tr {color: #000000;line-height: 1.2;font-weight: unset;}";
            pagina += "tbody tr:hover {color: #000000;background-color: #f5f5f5;cursor: pointer;}";
            pagina += ".column1 {width: 260px;padding-left: 40px;}";
            pagina += ".column2 {width: 260px;text-align: right;padding-right: 62px;}</style>";

            pagina += "</head><body> <div id='Solicitud'><DIV ALIGN='center'><img src='https://i.imgur.com/SS6BFCs.png' width='10%'  border=0></DIV--><div ALIGN='right'><P> " + modelo.Solicitud.FechaPdf + "</P></div><DIV ALIGN='left'>";
            
            if (modelo.CAA != null)
            {
                if (modelo.CAA.SexoDirCarrera.Equals("Femenino"))
                {
                    pagina += "<P style='line-height:1px'><B>Sra. " + modelo.CAA.NomDirCarrera +"</B></P>";
                }
                else
                {
                    pagina += "<P style='line-height:1px'><B>Sr. " + modelo.CAA.NomDirCarrera +"/B></P>";
                }
                pagina+="<P style='line-height:3px'><I>" + modelo.CAA.Cargo + "</I></P>";
                pagina+="<P style='line-height:3px'><I>" + modelo.CAA.Carrera + "</I></P>";
            }
            else
            {
                if (modelo.CAA.SexoDirCarrera.Equals("Femenino"))
                {
                    pagina += "<P style='line-height:1px'><B>Sra. " + modelo.Federacion.NomDirDAAE +"/B></P>";
                }
                else
                {
                    pagina += "<P style='line-height:1px'><B>Sr. " + modelo.Federacion.NomDirDAAE +"/B></P>";
                }
                pagina+="<P style='line-height:3px'><I>" + modelo.Federacion.Cargo + "</I></P>";
            }

            pagina+="<P style='line-height:1px'><I>Universidad de Talca</I></P><P style='line-height:1px'><B><U>Presente.</U></B></P></DIV><DIV style='text-align:justify'><P>De nuestra consideración:</P>";
            
            if (modelo.Organizacion.Tipo.Equals("CAA"))
            {
                pagina += "<P>Junto con saludar cordialmente, me dirijo a usted como " + modelo.Responsable.Cargo + "del centro de alumnos de  " + modelo.CAA.Carrera + ", para solicitarle apoyo económico con el fin de realizar la actividad estudiantil que se indica a continuación:</P>";
            }
            else
            {
                pagina += "<P>Junto con saludar cordialmente, me dirijo a usted como " + modelo.Responsable.Cargo + "de " + modelo.Federacion.NombreFederacion + ", para solicitarle apoyo económico con el fin de realizar la actividad estudiantil que se indica a continuación:</P>";
            }
            
            pagina += "<ul><li><B>Nombre de la actividad: </B>" + modelo.Solicitud.NombreEvento +".</li>";
            pagina += "<li><B>Periodo: </B>" + modelo.Solicitud.FechaEvento + ".</li>";
            pagina += "<li><B>Ubicación: </B>" + modelo.Solicitud.LugarEvento + ".</li></ul>";
            
            
            if (modelo.Participantes != null)
            {
                pagina += "<P>Para llevar a cabo esta actividad se solicita un monto total de $" + modelo.Solicitud.Monto + " sujeto a rendición y así poder otorgar una ayuda de $";
                pagina += modelo.Solicitud.MontoPorPersona+ " a cada estudiante para solventar parcialmente sus gastos de " + modelo.CategoriasConcatenadas +".</P>";
                

                pagina += "<P>Los alumnos que participarán en la actividad son:</P>";
                pagina += "<table align='center'><thead><tr class='table100-head'><th class='column1'>Nombre</th><th class='column2'>Run/Matrícula</th></tr></thead>";
                pagina += "<tbody>";
                foreach (var item in modelo.Participantes)
                {
                    pagina+="<tr class='table-light'>";
                    pagina+="<td class='column1'>" + item.Nombre + "</td>";
                    pagina+="<td class='column2'>" + item.Run + "</td>";
                    pagina+="</tr>";
                }
                pagina+="</tbody></table>";
            }
            else
            {
                pagina += "<P>Se solicita un monto total de $" + modelo.Solicitud.Monto + " sujeto a rendición para solventar parcialmente los gastos de " + modelo.CategoriasConcatenadas + ".</P>";
            }
            
            
            if (modelo.Organizacion.Tipo.Equals("CAA"))
            {
                pagina += "<P>Dicho monto quedará bajo la responsabilidad de " + modelo.Responsable.Nombre +", RUT " + modelo.Responsable.Run;
                pagina += ", matrícula " + modelo.Responsable.Matricula + ", en su calidad de " + modelo.Responsable.Cargo ;
                pagina += " del Centro de Alumnos de " + modelo.CAA.Carrera + " de la Universidad de Talca. </P>";
            }
            else
            {
                pagina += "<P>Dicho monto quedará bajo la responsabilidad de " + modelo.Responsable.Nombre + ", RUT " + modelo.Responsable.Run ;
                pagina += ", matrícula " + modelo.Responsable.Matricula + ", en su calidad de  " +  modelo.Responsable.Cargo + " de ";
                pagina += modelo.Federacion.NombreFederacion + " de la Universidad de Talca.</P>";
            }
                
            pagina += "<P>Esperando una buena acogida y una pronta respuesta de esta solicitud, se despide atentamente de usted.</P>";
            pagina += "<DIV ALIGN='center' style='padding-top:80px;'><P style='line-height:3px'><B>" + modelo.Responsable.Nombre + "</B></P>";
            pagina += "<P style='line-height:3px'>" + modelo.Responsable.Cargo + "</P>";
            
            if (modelo.Organizacion.Tipo.Equals("CAA"))
            {
                pagina += "<P style='line-height:3px'>CAA " + modelo.CAA.Carrera + "</P>";
            }
            else
            {
                pagina += "<P style='line-height:3px'>" + modelo.Federacion.NombreFederacion + "</P>";
            }

            pagina += "<P style='line-height:3px'>Universidad de Talca</P></DIV>";

            return pagina;
        }
        public FileResult DescargarPDF()
        {
            var convertidor = new BasicConverter(new PdfTools());
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.Letter,
                },

                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HtmlContent = @""+hacerPdf(),

                        WebSettings =
                        {
                            DefaultEncoding = "utf-8"
                        },
                    }
                }
            };
            byte[] pdf = convertidor.Convert(doc);

            return File(pdf, "application/pdf", "Solicitud.pdf");
        }

        public static String BuscarRepresentante(int idOrganizacion, String rut)
        {
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Responsables = ConsultasGenerales.LeerRepresetantes(idOrganizacion);
            
            foreach (Responsable responsable in modelo.Responsables)
            {
                if (responsable.Run.Equals(rut))
                {
                    return responsable.Nombre;
                }
            }
            return null;
        }

        public IActionResult FinalizarSolicitud()
        {
            Actualizar_FechaPDF_EstadoProceso();
            /*El proceso cambia de solicitd a resolucion (tabla intermedio de proceso)*/
            return IrPrincipal();
            
        }
/*####################Fin funciones relacionadas con generar el pdf y mostrar la informacion del pdf###########################*/



        /*public IActionResult VolverIndex()
        {
            _requestHandler.RemoveIdSolicitud();
            return RedirectToAction("Index", "Solicitud");
        }*/
    }
}
