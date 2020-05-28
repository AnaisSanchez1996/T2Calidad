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
    public class LibroControllerTest
    {
        [Test]
        public void RetornarDetalleId()
        {
            var detalle = new Mock<ILibros>();
            Libro li = new Libro() { Id = 1, Nombre = "caperucita", Autor = new Autor() {Id = 1, Nombres = "cape1"},
            Comentarios = new List<Comentario>() { new Comentario() { Id=1, Texto="es cuento para niños"} } };
            detalle.Setup(a => a.GetLibroId(1)).Returns(li);
            var controller = new LibroController(detalle.Object, null, null);
            var view = controller.Details(1) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void NoRetornarDetalleId()
        {
            var detalle = new Mock<ILibros>();
            Libro li = new Libro(){ Nombre ="caperucita",Id = 1, Autor = new Autor(){Id = 1, Nombres = "cape1"},
            Comentarios = new List<Comentario>() {new Comentario() { Id = 1,Texto = "es cuento para niños"}}};

            detalle.Setup(o => o.GetLibroId(1)).Returns(li);

            var controller = new LibroController(detalle.Object, null, null);

            var view = controller.Details(2) as ViewResult;

           
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void RetornaagregarComentario()
        {
            var Comentario = new Mock<IAddComentario>();

            var faker = new Mock<IUsuario>();

            Usuario usuario = new Usuario() {  Id = 1, Nombres = "Anais", Password = "Administrador",  Username = "123"};

            Comentario comentario = new Comentario(){ Texto = "es cuento para niños", Id = 1, Puntaje = 15, UsuarioId = 1, LibroId = 1, Fecha = DateTime.Now.Date };
            Comentario.Setup(a => a.addComentario(comentario, usuario));

            faker.Setup(s => s.setNombreUsuario()).Returns(usuario);

            var controller = new LibroController(null, Comentario.Object, faker.Object);

            var view= controller.AddComentario(comentario);

            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
    }
}