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
    class BibliotecaControllerTest
    {
        [Test]
        public void ListBiblioteca()
        {


            var user = new Mock<IUsuario>();
            var list = new Mock<IBiblioteca>();
            Usuario usuario = new Usuario() { Id = 1, Nombres = "Anais", Password = "Admin", Username = "Admin" };

            user.Setup(s => s.setNombreUsuario()).Returns(usuario);
            list.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(list.Object, user.Object);

            var view = listaBi.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void ParaAddBiblio()
        {
            var user = new Mock<IUsuario>();
            var listbi = new Mock<IBiblioteca>();
            Usuario usuario = new Usuario() { Id = 1, Nombres = "Anais", Password = "Admin", Username = "Admin" };

            user.Setup(s => s.setNombreUsuario()).Returns(usuario);
            listbi.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(listbi.Object, user.Object);

            var view = listaBi.Add(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }

        [Test]
        public void MarcarComoLeyendo()
        {
            var user = new Mock<IUsuario>();
            var listbi = new Mock<IBiblioteca>();
            Usuario usuario = new Usuario() {Id = 1, Nombres = "Anais",  Password = "Admin",  Username = "Admin"};

            user.Setup(s => s.setNombreUsuario()).Returns(usuario);
            listbi.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(listbi.Object, user.Object);

            var view = listaBi.MarcarComoLeyendo(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        [Test]
        public void MarcarComoTerminado()
        {
            var user= new Mock<IUsuario>();
            var listbi = new Mock<IBiblioteca>();
            Usuario usuario = new Usuario(){Id = 1, Nombres = "Anais", Password = "Admin", Username = "Admin" };

            user.Setup(s => s.setNombreUsuario()).Returns(usuario);
            listbi.Setup(a => a.GetBibliotecas(usuario)).Returns(new List<Biblioteca>());

            var listaBi = new BibliotecaController(listbi.Object, user.Object);

            var view = listaBi.MarcarComoTerminado(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
    }
}
