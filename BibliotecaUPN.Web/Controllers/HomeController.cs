using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUPN.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ILibros GetLibros;
        public HomeController(ILibros GetLibros)
        {
            this.GetLibros = GetLibros;
        }

        [HttpGet]
        public ActionResult Index()
        {

            var model = GetLibros.GetLibros();
            return View(model);
        }       

    }
}