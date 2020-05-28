using BibliotecaUPN.Web.Controllers;
using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebasUnitarias.TestController
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void RetornaListaLibros()
        {
            var listaL = new Mock<ILibros>();

            listaL.Setup(x=> x.GetLibros()).Returns(new List<Libro>());

            var controller = new HomeController(listaL.Object);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsInstanceOf<List<Libro>>(view.Model);

        }
        [Test]

        public void NoRetornaListaDeLibros()
        {
            var listaL = new Mock<ILibros>();

            listaL.Setup(x => x.GetLibros());

            var controller = new HomeController(listaL.Object);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
            Assert.IsNull(view.Model);
        }
    }
}
