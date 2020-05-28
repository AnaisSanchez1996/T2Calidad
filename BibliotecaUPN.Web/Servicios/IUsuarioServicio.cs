using BibliotecaUPN.Web.DB;

using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BibliotecaUPN.Web.Servicios
{
    public class IUsuarioServicio : IUsuario
    {
        private AppContext Context;
        HttpSessionState session = HttpContext.Current.Session;
        public IUsuarioServicio(AppContext Context)
        {
            this.Context = Context;
        }
        public Usuario GetUsuario(string username, string password)
        {
            var usuario = Context.Usuarios.Where(a => a.Username == username && a.Password == password).FirstOrDefault();
            return usuario;
        }

        public Usuario setNombreUsuario()
        {
            return (Usuario)session["Usuario"];
        }
    }
}