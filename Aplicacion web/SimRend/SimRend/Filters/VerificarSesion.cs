using System;
using SimRend.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using SimRend.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SimRend.Filters
{
    public class VerificarSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                Usuario usuario = (Usuario)filterContext.HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                if(usuario == null)
                {
                    if(filterContext.Controller is UsuarioController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Usuario/Login");
                    }
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Usuario/Login");
            }

        }
    }
}
