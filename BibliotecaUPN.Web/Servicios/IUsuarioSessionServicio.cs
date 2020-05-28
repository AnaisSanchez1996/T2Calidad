using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace BibliotecaUPN.Web.Servicios
{
    public class IUsuarioSessionServicio : IUsuarioSession
    {
        public void AutenticaUsername(string Username, bool valor)
        {
            FormsAuthentication.SetAuthCookie(Username, valor);
        }

        public void SetIdUsuario(Usuario usuario)
        {
            HttpSessionState Session = HttpContext.Current.Session;
            Session["Usuario"] = usuario;
        }
    }
}