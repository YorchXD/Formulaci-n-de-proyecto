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

        public IActionResult Index()
        {
            //string SessionKeyID = "_identificacion";
            //int idOrganizacion = Convert.ToInt32(TempData["idOrganizacion"]);
            ViewData["_usuario"] = _requestHandler.GetUsuario();

            int idOrganizacion = _requestHandler.GetIdAcceso();
            var solicitudes = ConsultaSolicitud.LeerSolicitudOrganizacion(idOrganizacion);
            //TempData["idOrganizacion"] = idOrganizacion;
            return View(solicitudes);
        }

        // GET: Solicitud/Create
        public IActionResult Create()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            //Organizacion organizacion = new Organizacion();
            //organizacion.Id = Convert.ToInt32(TempData["idOrganizacion"]);
            int idOrganizacion = _requestHandler.GetIdAcceso();
            //TempData["idOrganizacion"] = idOrganizacion;
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Responsables = ConsultaSolicitud.LeerRepresetantes(idOrganizacion);
            if (modelo.Responsables != null)
            {
                modelo.Responsables = modelo.Responsables.Where(responsable => !responsable.Estado.Equals("Desabilitado")).ToList();
                return View(modelo);
            }
            return View(modelo);

        }


        // GET: Solicitud/Create
        //public IActionResult Create()
        //{
        /*var categoriasGuardadas = ConsultaSolicitud.LeerTodoCategorias();
        return View(categoriasGuardadas);*/



        //List<Categoria> Categorias = ConsultaSolicitud.LeerTodoCategorias();
        //List<Categoria> CategoriasSeleccionadas = new List<Categoria>();
        //List<string> CategoriaFlotante;
        //DataSet datosTemp = TempData["Seleccionadas"] as DataSet;

        /*Esto sirve para cuando  existan cookie con TempData en el navegador y la hace null*/
        //TempData["Seleccionadas"] = null;
        /*int Cont = 0;
        String var;
        while(TempData["Seleccionadas"] != null)
        {
            var = (String)TempData["Seleccionadas"];
            CategoriaFlotante.Add(var);
            Cont++;
        }*/


        //if(CategoriasSeleccionadas.Count>0)
        //{
        //foreach (Categoria categoria in CategoriasSeleccionadas)
        //{
        //Categorias.Remove(categoria);
        //}
        //ViewData["Seleccionadas"] = CategoriasSeleccionadas;
        //}

        //return View();
        //return View();
        //}


        // POST: Solicitud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Monto,NombreEvento,FechaInicioEvento,FechaTerminoEvento,LugarEvento,Responsable")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                ConsultaSolicitud.ModificarEstadoResponsable(solicitud.Responsable, "Desabilitado");
                solicitud.FechaActual = DateTime.Now;
                solicitud.Estado = "Editando";
                int idOrganizacion = _requestHandler.GetIdAcceso();
                int idSolicitud = ConsultaSolicitud.CrearSolicitud(solicitud);
                ConsultaSolicitud.AgregarOrgSol(idOrganizacion, idSolicitud);
                //TempData["idOrganizacion"] = idOrganizacion;
                _requestHandler.SetIdSolicitu(idSolicitud);
                return RedirectToAction("Category", "Solicitud");
            }
            return View(solicitud);
        }


        // GET: Solicitud/Create
        public IActionResult Category()
        {
            int idSolicitud = _requestHandler.GetIdSolicitud();
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            List<Categoria> Categorias = ConsultaSolicitud.LeerTodoCategorias();
            List<Categoria> CategoriasSeleccionadas = ConsultaSolicitud.LeerCategoriasSeleccionadas(idSolicitud);


            //DataSet datosTemp = TempData["Seleccionadas"] as DataSet;

            /*Esto sirve para cuando  existan cookie con TempData en el navegador y la hace null*/
            //TempData["Seleccionadas"] = null;
            /*int Cont = 0;
            String var;
            while(TempData["Seleccionadas"] != null)
            {
                var = (String)TempData["Seleccionadas"];
                CategoriaFlotante.Add(var);
                Cont++;
            }*/



            /*if (TempData["Seleccionadas"] != null)
            {
                //CategoriaFlotante = TempData["Seleccionada"] ;

                //List<string> var = (List<string>)TempData["Seleccionadas"];
                //Console.WriteLine(var);
                //var.Split();

                CategoriaFlotante = TempData["Seleccionadas"].ToString();


                foreach (var e in CategoriaFlotante)
                {
                    CategoriasSeleccionadas.Add(new Categoria { Nombre = e });
                }
                ViewData["Seleccionadas"] = CategoriasSeleccionadas;
            }*/

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

                    //Categorias.Remove(categoria);

                }
                ViewData["Seleccionadas"] = CategoriasSeleccionadas;
            }
            //int idOrganizacion = Convert.ToInt32(_requestHandler.GetIdAcceso());
            //TempData["idOrganizacion"] = idOrganizacion;
            return View(Categorias);
        }

        // POST: Solicitud/Category
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*public IActionResult Category1()
        {
            return View();
        }*/

        /*public ActionResult AgregarCategoria(String Nombre)
        {
            List<String> CategoriaFlotante = new List<String>();

            if (TempData["Seleccionadas"] != null)
            {
                string var = TempData["Seleccionada"].ToString();
                Console.WriteLine(var);

                CategoriaFlotante = TempData["Seleccionadas"] as List<String>;
                CategoriaFlotante.Add(Nombre);
                TempData["Seleccionadas"] = CategoriaFlotante;
            }
            else
            {
                CategoriaFlotante.Add(Nombre);
                TempData["Seleccionadas"] = CategoriaFlotante;
            }

            return RedirectToAction("Category", "Solicitud");
        }*/

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
                return RedirectToAction("Category", "Solicitud");
            }
            return View(solcat);
        }

        [HttpPost]
        public IActionResult AgregarCategoria(String Nombre)
        {
            SolicitudCategoria solcat = new SolicitudCategoria()
            {
                RefCategoria = Nombre,
                RefSolicitud = _requestHandler.GetIdSolicitud()
            };

            if (ModelState.IsValid)
            {
                ConsultaSolicitud.AgregarCategoria(solcat);
                return RedirectToAction("Category", "Solicitud");
            }
            //int idOrganizacion = Convert.ToInt32(TempData["idOrganizacion"]);
            //TempData["idOrganizacion"] = idOrganizacion;
            return View(solcat);
        }

        public IActionResult Person()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            //TempData["idSolicitud"] = 1;
            int idSolicitud = _requestHandler.GetIdSolicitud();
            List<Persona> Personas = ConsultaSolicitud.LeerPersonasSolicitud(idSolicitud);

            if (Personas != null)
            {
                ViewData["Personas"] = Personas;
            }
            //int idOrganizacion = Convert.ToInt32(TempData["idOrganizacion"]);
            //TempData["idOrganizacion"] = idOrganizacion;
            return View();
        }

        [HttpPost]
        public IActionResult AgregarPersona([Bind("Nombre,Run")] Persona persona)
        {
            int idSolicitud = _requestHandler.GetIdSolicitud();

            if (ModelState.IsValid)
            {
                ConsultaSolicitud.AgregarPersona(persona);
                ConsultaSolicitud.AgregarPerSol(persona.Run, idSolicitud);
                return RedirectToAction("Resumen", "Solicitud");
            }
            //int idOrganizacion = Convert.ToInt32(TempData["idOrganizacion"]);
            //TempData["idOrganizacion"] = idOrganizacion;
            return View(persona);
        }


        public IActionResult Resume()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud(idSolicitud);
            return View(modelo);
        }


        public IActionResult IrResumen(int IdSolicitud)
        {
            _requestHandler.SetIdSolicitu(IdSolicitud);
            return RedirectToAction("Resolucion", "Resolucion");
        }

        private ModeloSolicitud obtenerModelo()
        {
            ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            //int idSolicitud = 12;
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud(idSolicitud);
            modelo.Solicitud.FechaPdf = DateTime.Now.ToString("D", new System.Globalization.CultureInfo("es-ES"));
            modelo.Responsable = ConsultaSolicitud.Leer_Responsable(idSolicitud);
            modelo.Categorias = ConsultaSolicitud.LeerCategoriasSeleccionadas(idSolicitud);
            modelo.Participantes = ConsultaSolicitud.LeerPersonasSolicitud(idSolicitud);
            modelo.Organizacion = ConsultaSolicitud.Leer_Organizacion(idSolicitud);
            if (modelo.Participantes != null)
            {
                modelo.Solicitud.MontoPorPersona = modelo.Solicitud.Monto / modelo.Participantes.Count();
            }
            if (modelo.Organizacion.Tipo.Equals("CAA"))
            {
                modelo.CAA = ConsultaSolicitud.Leer_CAA(modelo.Organizacion.Id);
            }
            else
            {
                modelo.Federacion = ConsultaSolicitud.Leer_Federacion(modelo.Organizacion.Id);
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
            /*ViewData["_usuario"] = _requestHandler.GetUsuario();
            int idSolicitud = _requestHandler.GetIdSolicitud();
            //int idSolicitud = 12;
            ModeloSolicitud modelo = new ModeloSolicitud();
            modelo.Solicitud = ConsultaSolicitud.Leer_Solicitud(idSolicitud);
            modelo.Solicitud.FechaPdf = DateTime.Now.ToString("D", new System.Globalization.CultureInfo("es-ES"));
            modelo.Responsable = ConsultaSolicitud.Leer_Responsable(idSolicitud);
            modelo.Categorias = ConsultaSolicitud.LeerCategoriasSeleccionadas(idSolicitud);
            modelo.Participantes = ConsultaSolicitud.LeerPersonasSolicitud(idSolicitud);
            modelo.Organizacion = ConsultaSolicitud.Leer_Organizacion(idSolicitud);
            if(modelo.Participantes!=null)
            {
                modelo.Solicitud.MontoPorPersona = modelo.Solicitud.Monto / modelo.Participantes.Count();
            }
            if(modelo.Organizacion.Tipo.Equals("CAA"))
            {
                modelo.CAA = ConsultaSolicitud.Leer_CAA(modelo.Organizacion.Id);
            }
            else
            {
                modelo.Federacion = ConsultaSolicitud.Leer_Federacion(modelo.Organizacion.Id);
            }

            if(modelo.Solicitud.FechaInicioEvento!=modelo.Solicitud.FechaTerminoEvento)
            {
                modelo.Solicitud.FechaEvento = "Desde el " + modelo.Solicitud.FechaInicioEvento.ToString("dddd", new System.Globalization.CultureInfo("es-ES")) + ", " + modelo.Solicitud.FechaInicioEvento.ToString("M", new System.Globalization.CultureInfo("es-ES")) +
                " hasta el " + modelo.Solicitud.FechaTerminoEvento.ToString("D", new System.Globalization.CultureInfo("es-ES")); 
                return View(modelo);
            }
            else
            {
                modelo.Solicitud.FechaEvento = modelo.Solicitud.FechaInicioEvento.ToString("D", new System.Globalization.CultureInfo("es-ES"));
                return View(modelo);
            }*/
            ModeloSolicitud modelo = obtenerModelo();
            return View(modelo);
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
                        HtmlContent = GeneratePDF().ToString(),
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

        public IActionResult VolverIndex()
        {
            _requestHandler.RemoveIdSolicitud();
            return RedirectToAction("Index", "Solicitud");
        }
    }
}
