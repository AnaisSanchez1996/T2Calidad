using BibliotecaUPN.Web.Constantes;
using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUPN.Web.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private IBiblioteca biblioteca;
        private IUsuario usuarioSession;
        public BibliotecaController(IBiblioteca biblioteca, IUsuario usuarioSession)
        {
            this.biblioteca = biblioteca;
            this.usuarioSession = usuarioSession;
        }
        [HttpGet]
        public ActionResult Index()
        {
            Usuario user = usuarioSession.setNombreUsuario();

            var model = biblioteca.GetBibliotecas(user);
            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {

            Usuario user = usuarioSession.setNombreUsuario();

            biblioteca.agregarBibLIOTECA(libro, user);

            TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            var app = new AppContext();
            Usuario user = usuarioSession.setNombreUsuario();

            // TO-DO validar si ya existe el libro en la biblioteca, en ese caso no guardar y notificar

            biblioteca.agregarBi(libroId, user);
            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            var app = new AppContext();
            Usuario user = usuarioSession.setNombreUsuario();

            // TO-DO validar si ya existe el libro en la biblioteca, en ese caso no guardar y notificar
            biblioteca.marcarComoTerminado(libroId, user);
            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }
    }
}