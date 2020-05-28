using BibliotecaUPN.Web.DB;

using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BibliotecaUPN.Web.Controllers
{
    public class AuthController : Controller
    {
        private IUsuario iusuario;
        private IUsuarioSession iUsuarioSession;
        public AuthController(IUsuario iusuario, IUsuarioSession iUsuarioSession)
        {
            this.iusuario = iusuario;
            this.iUsuarioSession = iUsuarioSession;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            var usuarioGet = iusuario.GetUsuario(username, password);

            if (usuarioGet != null)
            {
                iUsuarioSession.AutenticaUsername(username, false);

                iUsuarioSession.SetIdUsuario(usuarioGet);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}