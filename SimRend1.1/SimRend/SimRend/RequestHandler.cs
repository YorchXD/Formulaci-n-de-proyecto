﻿using Microsoft.AspNetCore.Http;
using System;

namespace SimRend.Helpers
{
    public class RequestHandler
    {
        IHttpContextAccessor _httpContextAccessor;
        public RequestHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        internal void HandleAboutRequest()
        {
            // handle the request
            var message = "The HttpContextAccessor seems to be working!!";
            _httpContextAccessor.HttpContext.Session.SetString("message", message);
        }

        internal void SetIdAcceso(int id, string usuario)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("_identificacion", id);
            _httpContextAccessor.HttpContext.Session.SetString("_usuario", usuario);
        }

        internal int GetIdAcceso()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32("_identificacion").Value;
        }

        internal string GetUsuario()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("_usuario");
        }

        internal void RemoveIdAcceso()
        {
            _httpContextAccessor.HttpContext.Session.Remove("_identificacion");
            _httpContextAccessor.HttpContext.Session.Remove("_usuario");
        }

        internal void SetIdSolicitud(int id)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("_solicitud", id);
        }

        internal int GetIdSolicitud()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32("_solicitud").Value;
        }

        internal void RemoveIdSolicitud()
        {
            _httpContextAccessor.HttpContext.Session.Remove("_solicitud");
        }

        internal void SetIdProceso(int id)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("_proceso", id);
        }

        internal int GetIdProceso()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32("_proceso").Value;
        }

        internal void RemoveIdProceso()
        {
            _httpContextAccessor.HttpContext.Session.Remove("_proceso");
        }

        

        internal void SetIdResolucion(int id)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("_resolucion", id);
        }

        internal int GetIdResolucion()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32("_resolucion").Value;
        }

        internal void RemoveIdResolucion()
        {
            _httpContextAccessor.HttpContext.Session.Remove("_resolucion");
        }

        internal void SetIdRendicion(int id)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("_rendicion", id);
        }

        internal int GetIdRendicion()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32("_rendicion").Value;
        }

        internal void RemoveIdRendicion()
        {
            _httpContextAccessor.HttpContext.Session.Remove("_rendicion");
        }

        internal void SetIdPrincipal(int id)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("_principal", id);
        }

        internal int GetIdPrincipal()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32("_principal").Value;
        }

        internal void RemoveIdPrincipal()
        {
            _httpContextAccessor.HttpContext.Session.Remove("_principal");
        }
    }
}