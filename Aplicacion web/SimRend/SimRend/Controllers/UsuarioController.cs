﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimRend.Models;
using SimRend.DbSimRend;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using MySqlX.XDevAPI;
using SimRend.Filters;

namespace SimRend.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CambiarClave()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 14)]
        public IActionResult UsuariosRepresentantes()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 14)]
        public IActionResult UsuariosDirectores()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 14)]
        public IActionResult UsuariosVicerectores()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 14)]
        public IActionResult UsuariosAdministradores()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 13)]
        public IActionResult CrearUsuarioRepresentante()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 13)]
        public IActionResult CrearUsuarioDirector()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 13)]
        public IActionResult CrearUsuarioVicerector()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 13)]
        public IActionResult CrearUsuarioAdministrador()
        {
            return View();
        }

        public IActionResult ModificarClave()
        {
            return View();
        }

        [AutorizacionUsuario(idOperacion: 15)]
        public IActionResult ActualizarUsuarioDirector()
        {
            return View();
        }

        public IActionResult ActualizarPerfilDirector()
        {
            int Id = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario").Id;
            HttpContext.Session.SetComplexData("IdUsuarioDirector", Id);
            return View();
        }

        [AutorizacionUsuario(idOperacion: 15)]
        public IActionResult ActualizarUsuarioRepresentante()
        {
            return View();
        }

        public IActionResult ActualizarPerfilRepresentante()
        {
            int Id = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario").Id;
            HttpContext.Session.SetComplexData("IdUsuarioRepresentante", Id);
            return View();
        }

        [AutorizacionUsuario(idOperacion: 15)]
        public IActionResult ActualizarUsuarioVicerector()
        {
            return View();
        }

        public IActionResult ActualizarPerfilVicerector()
        {
            int Id = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario").Id;
            HttpContext.Session.SetComplexData("IdUsuarioVicerector", Id);
            return View();
        }

        [AutorizacionUsuario(idOperacion: 15)]
        public IActionResult ActualizarUsuarioAdministrador()
        {
            return View();
        }

        public IActionResult ActualizarPerfilAdministrador()
        {
            int Id = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario").Id;
            HttpContext.Session.SetComplexData("IdUsuarioAdministrador", Id);
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string clave, string tipoUsuario)
        {
            try
            {
                var usuario = ConsultaUsuario.IniciarSesion(email, clave, tipoUsuario);
                if(!tipoUsuario.Equals("Administrador") && usuario!=null)
                {
                    var organizaciones = ConsultaUsuario.LeerOrganizacion(usuario.Id, tipoUsuario);
                    HttpContext.Session.SetComplexData("Organizaciones", usuario);
                }

                if(usuario == null)
                {
                    ViewBag.Error = "Usuario o clave invalida";
                    return View();
                }
                HttpContext.Session.SetString("TipoUsuario", tipoUsuario);
                HttpContext.Session.SetComplexData("DatosUsuario", usuario);
                HttpContext.Session.SetString("Nombre", usuario.Nombre.Split(" ")[0]);
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
                HttpContext.Session.SetString("Email", usuario.Email);
                HttpContext.Session.SetString("Cargo", usuario.Rol.Nombre);
                //HttpContext.Session.SetString("OE", usuario.Organizacion.Nombre);
                //return RedirectToAction("Procesos", "Proceso");

                if (tipoUsuario.Equals("Administrador"))
                {
                    return RedirectToAction("OrganizacionesEstudiantiles", "OrganizacionEstudiantil");
                }
                else if (tipoUsuario.Equals("Vicerector"))
                {
                    return RedirectToAction("OrganizacionesEstudiantiles", "Proceso");
                }
                else
                {
                    return RedirectToAction("Procesos", "Proceso");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return View();
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.SetComplexData("DatosUsuario", null);
                HttpContext.Session.SetString("Nombre", "");
                HttpContext.Session.SetString("NombreUsuario", "");
                HttpContext.Session.SetString("Email", "");
                HttpContext.Session.SetString("Cargo", "");
                HttpContext.Session.SetString("OE", "");

                return RedirectToAction("Login", "Usuario");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return View();
        }

        [AutorizacionUsuarioJS(idOperacion: 14)]
        [HttpGet]
        public JsonResult LeerDirectores()
        {
            List<UsuarioDirector> Directores = ConsultaUsuario.LeerDirectores();
            return Json(Directores);
        }

        [HttpGet]
        public JsonResult ObtenerCampus()
        {
            List<Campus> Campus = ConsultaCampus.LeerCampus();
            return Json(Campus);
        }

        [HttpGet]
        public JsonResult ObtenerOEs(int IdCampus)
        {
            List<Organizacion> OEs;
            if (IdCampus >0)
            {
                OEs = ConsultaOrganizacionEstudiantil.LeerOrganizaciones(IdCampus);
            }
            else
            {
                OEs = ConsultaOrganizacionEstudiantil.LeerOrganizaciones();
            }
            
            return Json(OEs);
        }
        [AutorizacionUsuarioJS(idOperacion: 16)]
        [HttpDelete]
        public JsonResult EliminarDirector(int IdDirector)
        {
            String msj;
            bool validar;            
            validar = ConsultaUsuario.EliminarDirector(IdDirector);

            if (validar)
            {
                msj = "Los datos se han eliminado exitosamente";
            }
            else
            {
                msj = "Los datos no se han eliminado correctamente. Esto se debe a que probablemente el usuario tenga asociados procesos o" +
                    "usted no tenga conexión a internet. Intentelo nuevamente y si el problema persiste favor de contactarse con soporte.";
            }

            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [AutorizacionUsuarioJS(idOperacion: 13)]
        [HttpPost]
        public JsonResult RegistrarUsuarioDirector(String Nombre, String Email, String Clave, String Sexo, String Cargo, int FonoAnexo,  int IdOE)
        {
            List<UsuarioDirector> Directores = ConsultaUsuario.LeerDirectores();

            String msj;
            bool respuesta;

            if (Directores.Find(director => director.Email.ToLower().Equals(Email.ToLower())) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario director porque ya existe otro con el mismo email.";
            }
            else if (Directores.Find(director => director.Nombre.Equals(Nombre) && director.Sexo.Equals(Sexo)
            && director.Cargo.Equals(Cargo) && director.Organizacion.Id == IdOE) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario director porque ya existe otro con el mismo nombre, sexo, cargo y O.E.";
            }
            else
            {
                respuesta = ConsultaUsuario.CrearUsuarioDirector(Nombre, Email, Clave, Sexo, Cargo, FonoAnexo, IdOE);

                if (respuesta)
                {
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            var datos = new
            {
                validar = respuesta,
                msj
            };

            return Json(datos);
        }

        [HttpPost]
        public void GuardarIdUsuarioDirector(int Id)
        {
            HttpContext.Session.SetComplexData("IdUsuarioDirector", Id);
        }

        [HttpGet]
        public JsonResult LeerUsuarioDirector()
        {
            int Id = HttpContext.Session.GetComplexData<int>("IdUsuarioDirector");
            return Json(ConsultaUsuario.LeerDirector(Id));
        }

        [HttpPost]
        public JsonResult ActualizarUsuarioDirector(String Nombre, String Email, String Clave, String Sexo, String Cargo, int FonoAnexo, int Id, int IdOE)
        {
            List<UsuarioDirector> Directores = ConsultaUsuario.LeerDirectores();

            String msj;
            bool respuesta;

            if (Directores.Find(director => director.Email.ToLower().Equals(Email.ToLower()) && director.Id!=Id) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario director porque ya existe otro con el mismo email.";
            }
            else if (Directores.Find(director => director.Id != Id && director.Nombre.Equals(Nombre) && director.Sexo.Equals(Sexo)
            && director.Cargo.Equals(Cargo) && director.Organizacion.Id == IdOE) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario director porque ya existe otro con el mismo nombre, sexo, cargo y O.E.";
            }
            else if (Directores.Find(director => director.Id == Id && director.Nombre.Equals(Nombre) && director.Sexo.Equals(Sexo)
            && director.Cargo.Equals(Cargo) && director.Organizacion.Id == IdOE && director.Email.ToLower().Equals(Email.ToLower())) != null && String.IsNullOrEmpty(Clave))
            {
                respuesta = false;
                msj = "No se han guardado los datos porque siguen siendo los mismos.";
            }
            else
            {
                respuesta = ConsultaUsuario.ActualizarUsuarioDirector(Nombre, Email, Clave, Sexo, Cargo, FonoAnexo, Id);

                if (respuesta)
                {
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            var datos = new
            {
                validar = respuesta,
                msj
            };

            return Json(datos);
        }

        [AutorizacionUsuarioJS(idOperacion: 15)]
        [HttpPost]
        public JsonResult HabilitarUsuarioDirector(int IdUsuarioDirector, String Estado)
        {
            return Json(ConsultaUsuario.HabilitarUsuarioDirector(IdUsuarioDirector, Estado));
        }

        [AutorizacionUsuarioJS(idOperacion: 14)]
        [HttpGet]
        public JsonResult LeerRepresentantes(int IdCampus, int IdOE, int IdRol)
        {
            List<UsuarioRepresentante> Representantes = ConsultaUsuario.LeerRepresentantes(IdCampus, IdOE, IdRol);
            return Json(Representantes);
        }

        [AutorizacionUsuarioJS(idOperacion: 15)]
        [HttpPost]
        public JsonResult HabilitarUsuarioRepresentante(int IdUsuarioRepresentante, String Estado)
        {
            return Json(ConsultaUsuario.HabilitarUsuarioRepresentante(IdUsuarioRepresentante, Estado));
        }

        [HttpGet]
        public JsonResult LeerRolesRepresentantes()
        {
            List<Rol> Roles = ConsultaUsuario.LeerRolesRepresentantes();
            return Json(Roles);
        }

        [HttpGet]
        public JsonResult LeerCampusRepresentantes()
        {
            List<Campus> campus = ConsultaUsuario.LeerCampusRepresentantes();
            return Json(campus);
        }

        [AutorizacionUsuarioJS(idOperacion: 16)]
        [HttpDelete]
        public JsonResult EliminarRepresentante(int IdRepresentante)
        {
            String msj;
            bool validar;
            validar = ConsultaUsuario.EliminarRepresentante(IdRepresentante);

            if (validar)
            {
                msj = "Los datos se han eliminado exitosamente";
            }
            else
            {
                msj = "Los datos no se han eliminado correctamente. Esto se debe a que probablemente el usuario tenga asociados procesos o" +
                    "usted no tenga conexión a internet. Intentelo nuevamente y si el problema persiste favor de contactarse con soporte.";
            }

            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [AutorizacionUsuarioJS(idOperacion: 13)]
        [HttpPost]
        public JsonResult RegistrarUsuarioRepresentante(String Nombre, String Run, int Matricula, String Email, String Clave, String Sexo, int IdRol, int IdOE, int IdInstitucion)
        {
            List<UsuarioRepresentante> Representantes = ConsultaUsuario.LeerRepresentantes(0, IdOE, IdRol);

            String msj;
            bool respuesta;

            if (Representantes.Find(representante => representante.Email.ToLower().Equals(Email.ToLower())) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario representante porque ya existe otro con el mismo email.";
            }
            else if (Representantes.Find(representante => representante.RUN.Equals(Run) && representante.Matricula == Matricula && representante.Institucion.Id ==IdInstitucion) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario representante porque ya existe otro con el mismo RUN, matrícula e institución";
            }
            else
            {
                respuesta = ConsultaUsuario.CrearUsuarioRepresentante(Nombre, Run, Matricula, Email, Clave, Sexo, IdRol, IdOE, IdInstitucion);

                if (respuesta)
                {
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            var datos = new
            {
                validar = respuesta,
                msj
            };

            return Json(datos);
        }

        [HttpGet]
        public JsonResult LeerInstituciones()
        {
            return Json(ConsultaInstitucion.LeerInstituciones());
        }

        [HttpPost]
        public void GuardarIdRepresentante(int Id)
        {
            HttpContext.Session.SetComplexData("IdUsuarioRepresentante", Id);
        }

        [HttpGet]
        public JsonResult LeerRepresentante()
        {
            int Id = HttpContext.Session.GetComplexData<int>("IdUsuarioRepresentante");
            return Json(ConsultaUsuario.LeerRepresentante(Id));
        }

        [HttpPost]
        public JsonResult ActualizarUsuarioRepresentante(int Id, String Nombre, String RUN, int Matricula, String Email, String Clave, String Sexo, int IdRol, int IdCampus, int IdOE, int IdInstitucion)
        {
            List<UsuarioRepresentante> Representantes = ConsultaUsuario.LeerRepresentantes(IdCampus, IdOE, IdRol);

            String msj;
            bool respuesta;

            if (Representantes.Find(representante => representante.Email.ToLower().Equals(Email.ToLower()) && representante.Id != Id) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario representante porque ya existe otro con el mismo email.";
            }
            else if (Representantes.Find(representante => representante.Id != Id && representante.RUN.Equals(RUN) && representante.Matricula == Matricula && representante.Institucion.Id == IdInstitucion) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario representante porque ya existe otro con el mismo RUN, matrícula e institución";
            }
            else if (Representantes.Find(representante => representante.Id != Id && representante.Nombre.Equals(Nombre) && representante.RUN.Equals(RUN) && representante.Matricula == Matricula &&  representante.Sexo.Equals(Sexo) && representante.Institucion.Id==IdInstitucion) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario representante porque ya existe otro con el mismo nombre, sexo e institución";
            }
            else if (Representantes.Find(representante => representante.Id == Id  && representante.Nombre.Equals(Nombre) && representante.RUN.Equals(RUN) && representante.Matricula == Matricula && representante.Sexo.Equals(Sexo) && representante.Institucion.Id == IdInstitucion && representante.Email.ToLower().Equals(Email.ToLower())) != null && String.IsNullOrEmpty(Clave))
            {
                respuesta = false;
                msj = "No se han guardado los datos porque siguen siendo los mismos.";
            }
            else
            {
                respuesta = ConsultaUsuario.ActualizarUsuarioRepresentante(Id, Nombre, RUN, Matricula, Email, Clave, Sexo, IdInstitucion);

                if (respuesta)
                {
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            var datos = new
            {
                validar = respuesta,
                msj
            };

            return Json(datos);
        }

        [AutorizacionUsuarioJS(idOperacion: 14)]
        [HttpGet]
        public JsonResult LeerVicerectores()
        {
            List<UsuarioVicerector> Vicerrectores = ConsultaUsuario.LeerVicerectores();
            return Json(Vicerrectores);
        }
        [AutorizacionUsuarioJS(idOperacion: 15)]
        [HttpPost]
        public JsonResult HabilitarUsuarioVicerector(int IdUsuarioVicerector, String Estado)
        {
            return Json(ConsultaUsuario.HabilitarUsuarioVicerector(IdUsuarioVicerector, Estado));
        }

        [AutorizacionUsuarioJS(idOperacion: 16)]
        [HttpDelete]
        public JsonResult EliminarVicerector(int IdVicerector)
        {
            String msj;
            bool validar;
            validar = ConsultaUsuario.EliminarVicerector(IdVicerector);

            if (validar)
            {
                msj = "Los datos se han eliminado exitosamente";
            }
            else
            {
                msj = "Los datos no se han eliminado correctamente. Esto se debe a que probablemente el usuario tenga asociados procesos o" +
                    "usted no tenga conexión a internet. Intentelo nuevamente y si el problema persiste favor de contactarse con soporte.";
            }

            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [AutorizacionUsuarioJS(idOperacion: 13)]
        [HttpPost]
        public JsonResult RegistrarUsuarioVicerector(String Nombre, String Email, String Clave, String Sexo, String Cargo, int FonoAnexo)
        {
            List<UsuarioVicerector> Vicerectores = ConsultaUsuario.LeerVicerectores();

            String msj;
            bool respuesta;

            if (Vicerectores.Find(vicerector => vicerector.Email.ToLower().Equals(Email.ToLower())) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario director porque ya existe otro con el mismo email.";
            }
            else if (Vicerectores.Find(vicerector => vicerector.Nombre.Equals(Nombre) && vicerector.Sexo.Equals(Sexo)
            && vicerector.Cargo.Equals(Cargo)) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario director porque ya existe otro con el mismo nombre, sexo y cargo";
            }
            else
            {
                respuesta = ConsultaUsuario.CrearUsuarioVicerector(Nombre, Email, Clave, Sexo, Cargo, FonoAnexo);

                if (respuesta)
                {
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            var datos = new
            {
                validar = respuesta,
                msj
            };

            return Json(datos);
        }

        [HttpPost]
        public void GuardarIdUsuarioVicerector(int Id)
        {
            HttpContext.Session.SetComplexData("IdUsuarioVicerector", Id);
        }

        [HttpGet]
        public JsonResult LeerUsuarioVicerector()
        {
            int Id = HttpContext.Session.GetComplexData<int>("IdUsuarioVicerector");
            return Json(ConsultaUsuario.LeerVicerector(Id));
        }

        [HttpPost]
        public JsonResult ActualizarUsuarioVicerector(String Nombre, String Email, String Clave, String Sexo, String Cargo, int FonoAnexo, int Id)
        {
            List<UsuarioVicerector> Vicerectores = ConsultaUsuario.LeerVicerectores();

            String msj;
            bool respuesta;

            if (Vicerectores.Find(vicerector => vicerector.Email.ToLower().Equals(Email.ToLower()) && vicerector.Id != Id) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario vicerector porque ya existe otro con el mismo email.";
            }
            else if (Vicerectores.Find(vicerector => vicerector.Id != Id && vicerector.Nombre.Equals(Nombre) && vicerector.Sexo.Equals(Sexo)
            && vicerector.Cargo.Equals(Cargo)) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario vicerector porque ya existe otro con el mismo nombre, sexo y cargo.";
            }
            else if (Vicerectores.Find(vicerector => vicerector.Id == Id && vicerector.Nombre.Equals(Nombre) && vicerector.Sexo.Equals(Sexo)
            && vicerector.Cargo.Equals(Cargo) && vicerector.Email.ToLower().Equals(Email.ToLower())) != null && String.IsNullOrEmpty(Clave))
            {
                respuesta = false;
                msj = "No se han guardado los datos porque siguen siendo los mismos.";
            }
            else
            {
                respuesta = ConsultaUsuario.ActualizarUsuarioVicerector(Nombre, Email, Clave, Sexo, Cargo, FonoAnexo, Id);

                if (respuesta)
                {
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            var datos = new
            {
                validar = respuesta,
                msj
            };

            return Json(datos);
        }

        [AutorizacionUsuarioJS(idOperacion: 14)]
        [HttpGet]
        public JsonResult LeerAdministradores()
        {
            List<UsuarioAdministrador> Administradores = ConsultaUsuario.LeerAdministradores();
            return Json(Administradores);
        }

        [AutorizacionUsuarioJS(idOperacion: 16)]
        [HttpDelete]
        public JsonResult EliminarAdministrador(int IdAdministrador)
        {
            String msj;
            bool validar;
            validar = ConsultaUsuario.EliminarAdministrador(IdAdministrador);

            if (validar)
            {
                msj = "Los datos se han eliminado exitosamente";
            }
            else
            {
                msj = "Los datos no se han eliminado correctamente. Esto se debe a que probablemente el usuario tenga asociados procesos o" +
                    "usted no tenga conexión a internet. Intentelo nuevamente y si el problema persiste favor de contactarse con soporte.";
            }

            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);
        }

        [AutorizacionUsuarioJS(idOperacion: 13)]
        [HttpPost]
        public JsonResult RegistrarUsuarioAdministrador(String Nombre, String Email, String Clave, String Sexo, int Campus)
        {
            List<UsuarioAdministrador> Administradores = ConsultaUsuario.LeerAdministradores();

            String msj;
            bool respuesta;

            if (Administradores.Find(administrador => administrador.Email.ToLower().Equals(Email.ToLower())) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario administrador porque ya existe otro con el mismo email.";
            }
            else
            {
                respuesta = ConsultaUsuario.CrearUsuarioAdministrador(Nombre, Email, Clave, Sexo, Campus);

                if (respuesta)
                {
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            var datos = new
            {
                validar = respuesta,
                msj
            };

            return Json(datos);
        }

        [HttpPost]
        public void GuardarIdUsuarioAdministrador(int Id)
        {
            HttpContext.Session.SetComplexData("IdUsuarioAdministrador", Id);
        }

        [HttpGet]
        public JsonResult LeerUsuarioAdministrador()
        {
            int Id = HttpContext.Session.GetComplexData<int>("IdUsuarioAdministrador");
            return Json(ConsultaUsuario.LeerAdministrador(Id));
        }


        [AutorizacionUsuarioJS(idOperacion: 15)]
        [HttpPost]
        public JsonResult ActualizarUsuarioAdministrador(String Nombre, String Email, String Clave, String Sexo, int Campus,int Id)
        {
            List<UsuarioAdministrador> Administradores = ConsultaUsuario.LeerAdministradores();

            String msj;
            bool respuesta;

            if (Administradores.Find(administrador => administrador.Email.ToLower().Equals(Email.ToLower()) && administrador.Id != Id) != null)
            {
                respuesta = false;
                msj = "No se puede guardar al usuario administrador porque ya existe otro con el mismo email.";
            }
            else if (Administradores.Find(administrador => administrador.Email.ToLower().Equals(Email.ToLower()) && administrador.Id == Id && administrador.Nombre.Equals(Nombre) && administrador.Sexo.Equals(Sexo)
            && administrador.Campus.Id==Campus) != null && String.IsNullOrEmpty(Clave))
            {
                respuesta = false;
                msj = "No se han guardado los datos porque siguen siendo los mismos.";
            }
            else
            {
                respuesta = ConsultaUsuario.ActualizarUsuarioAdministrador(Nombre, Email, Clave, Sexo, Campus, Id);

                if (respuesta)
                {
                    msj = "Los datos se han guardado exitosamente";
                }
                else
                {
                    msj = "Los datos no se han guardado correctamente. Verifique que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
                }
            }
            var datos = new
            {
                validar = respuesta,
                msj
            };

            return Json(datos);
        }
        [HttpPost]
        public JsonResult RecuperarClave(String email, String tipoUsuario)
        {
            string obtenerEmail = ConsultaUsuario.Leer_Correo(email, tipoUsuario);
            String msj;
            bool validar = false;
            if (obtenerEmail != null && obtenerEmail.Equals(email))
            {
                string clave = RandomPassword.Generate(8);
                ConsultaUsuario.Cambiar_clave(tipoUsuario, email, clave);
                EmailSender.Send(email, "Cambio de clave", "Su nueva clave temporal es: " + clave);
                validar = true;
                msj = "Se ha enviado una clave temporal a su correo exitosamente. Recuerde modificar su clave.";
            }
            else
            {
                msj = "No se ha podido generar una clave temporal. Verifique que los datos ingresados sean correcto o que tenga conexión a internet e intentelo nuevamente. Si el problema persiste favor de contactarse con soporte.";
            }

            var datos = new
            {
                validar,
                msj
            };

            return Json(datos);

        }

        [HttpGet]
        public IActionResult ActualizarDatosTemporales()
        {
            try
            {
                String tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
                Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");

                usuario = ConsultaUsuario.IniciarSesion(usuario.Email, usuario.Clave, tipoUsuario);

                HttpContext.Session.SetComplexData("DatosUsuario", usuario);
                HttpContext.Session.SetString("Nombre", usuario.Nombre.Split(" ")[0]);
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
                HttpContext.Session.SetString("Email", usuario.Email);
                HttpContext.Session.SetString("Cargo", usuario.Rol.Nombre);


                if (tipoUsuario.Equals("Administrador"))
                {
                    return RedirectToAction("OrganizacionesEstudiantiles", "OrganizacionEstudiantil");
                }
                else if (tipoUsuario.Equals("Vicerector"))
                {
                    return RedirectToAction("OrganizacionesEstudiantiles", "Proceso");
                }
                else
                {
                    return RedirectToAction("Procesos", "Proceso");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return RedirectToAction("Usuario", "Login");
        }

        [HttpPost]
        public JsonResult ActualizarClave(String ClaveActual, String NuevaClave, String ConfirmacionNuevaClave)
        {
            String tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
            Usuario usuario = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
            bool validar = false;
            String msj;

            if (NuevaClave.Equals(ConfirmacionNuevaClave))
            {
                if(ClaveActual.Equals(usuario.Clave))
                {
                    if(!ClaveActual.Equals(NuevaClave))
                    {
                        ConsultaUsuario.Cambiar_clave(tipoUsuario, usuario.Email, NuevaClave);
                        EmailSender.Send(usuario.Email, "Cambio de clave", "Su nueva clave es: " + NuevaClave);
                        validar = true;
                        msj = "Su clave se ha modificado y se envió un respaldo a su correo.";
                    }
                    else
                    {
                        msj = "No se ha podido modificar la clave debido a que la clave actual es la misma que la nueva clave. Favor de verificar los campos y vuelva a intentarlo";

                    }

                }
                else
                {
                    msj = "No se ha podido modificar la clave debido a que la clave actual es incorrecta. Favor de verificar los campos y vuelva a intentarlo";

                }

            }
            else
            {
                msj = "No se ha podido modificar la clave debido a que la nueva clave y su confirmación no son iguales. Favor de verificar los campos y vuelva a intentarlo";

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