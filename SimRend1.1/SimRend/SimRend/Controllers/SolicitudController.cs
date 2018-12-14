using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SimRend.Models;
using SimRend.DbSimRend;
using System.Data;




namespace SimRend.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: /<controller>/
        /*public IActionResult Index()
        {
            return View();
        }*/
        

        // GET: Solicitud
        public IActionResult Index()
        {
            int idOrganizacion = Convert.ToInt32(TempData["idOrganizacion"]);
            var solicitudes = ConsultaSolicitud.LeerSolicitudOrganizacion(idOrganizacion);
            TempData["idOrganizacion"] = idOrganizacion;
            return View(solicitudes);
        }

        // GET: Solicitud/Create
        public IActionResult Create()
        {
            return View();
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
                solicitud.FechaActual = DateTime.Now;
                solicitud.Estado = "Editando";
                int idOrganizacion = Convert.ToInt32(TempData["idOrganizacion"]);
                int idSolicitud = ConsultaSolicitud.CrearSolicitud(solicitud);
                ConsultaSolicitud.AgregarOrgSol(idOrganizacion, idSolicitud);
                TempData["idOrganizacion"] = idOrganizacion;
                TempData["idSolicitud"] = idSolicitud;
                return RedirectToAction("Category", "Solicitud");
            }
            return View(solicitud);
        }


        // GET: Solicitud/Create
        public IActionResult Category()
        {
            //TempData["idSolicitud"] = 1;
            /*var categoriasGuardadas = ConsultaSolicitud.LeerTodoCategorias();
            return View(categoriasGuardadas);*/
            int idSolicitud = Convert.ToInt32(TempData["idSolicitud"].ToString());

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
                    int count=0;
                    while(!Categorias[count].Nombre.Equals(categoria.Nombre))
                    {
                        count++;
                    }
                    if(count<Categorias.Count)
                    {
                        Categorias.RemoveAt(count);
                    }
                    
                    //Categorias.Remove(categoria);
                    
                }
                ViewData["Seleccionadas"] = CategoriasSeleccionadas;
            }
            TempData["idSolicitud"] = idSolicitud;
            return View(Categorias);
            //return View();
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
                RefSolicitud = Convert.ToInt32(TempData["idSolicitud"].ToString())
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
            int idSolicitud = Convert.ToInt32(TempData["idSolicitud"].ToString());
            SolicitudCategoria solcat = new SolicitudCategoria()
            {
                RefCategoria = Nombre,
                RefSolicitud = Convert.ToInt32(idSolicitud)
            };

            if (ModelState.IsValid)
            {
                ConsultaSolicitud.AgregarCategoria(solcat);
                return RedirectToAction("Category", "Solicitud");
            }
            TempData["idSolicitud"] = idSolicitud;
            return View(solcat);
        }

        public IActionResult Person()
        {
            //TempData["idSolicitud"] = 1;
            int idSolicitud = Convert.ToInt32(TempData["idSolicitud"].ToString());
            List<Persona> Personas = ConsultaSolicitud.LeerPersonasSolicitud(idSolicitud);

            if(Personas!=null)
            {
                ViewData["Personas"] = Personas;
            }
            TempData["idSolicitud"] = idSolicitud;
            return View();
        }

        [HttpPost]
        public IActionResult AgregarPersona([Bind("Nombre,Run")] Persona persona)
        {
            int idSolicitud = Convert.ToInt32(TempData["idSolicitud"].ToString());

            if (ModelState.IsValid)
            {
                ConsultaSolicitud.AgregarPersona(persona);
                ConsultaSolicitud.AgregarPerSol(persona.Run, idSolicitud);
                TempData["idSolicitud"] = idSolicitud;
                return RedirectToAction("Person", "Solicitud");
            }
            TempData["idSolicitud"] = idSolicitud;
            return View(persona);
        }



    }
}
