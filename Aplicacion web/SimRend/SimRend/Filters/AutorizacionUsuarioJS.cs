﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using SimRend.Models;
using Microsoft.AspNetCore.Http;
using SimRend.DbSimRend;

namespace SimRend.Filters
{
    //[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AutorizacionUsuarioJS : Attribute, IAuthorizationFilter
    {
        private int idOperacion;
        public Usuario usuario { get; set; }

        public AutorizacionUsuarioJS(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";
            try 
            {
                this.usuario = filterContext.HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                if(usuario!=null)
                {
                    int cantOperaciones = ConsultaUsuario.Leer_Rol_Operacion(usuario.Rol.Id, idOperacion);

                    if (cantOperaciones < 1)
                    {
                        filterContext.Result = new UnauthorizedResult();

                    }
                }
                else
                {
                    Operacion operacion = ConsultasGenerales.Leer_Operacion(idOperacion);
                    Modulo modulo = ConsultasGenerales.Leer_Modulo(operacion.IdModulo);
                    nombreOperacion = operacion.Nombre;
                    nombreModulo = modulo.Nombre;
                    filterContext.Result = new RedirectResult("~/Error/OperacionNoAutorizada?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=");

                }

            }
            catch(Exception ex)
            {
                filterContext.Result = new UnauthorizedResult();
            }
        }
    }
}
