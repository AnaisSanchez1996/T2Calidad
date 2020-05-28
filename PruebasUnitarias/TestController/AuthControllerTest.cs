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
    public class AuthControllerTest
    {
        [Test]
        public void IngresoDeUsuario()
        {
            var usuariosession = new Mock<IUsuarioSession>();
            var faker = new Mock<IUsuario>();
          
            string Username = "Admin";
            string Passsword = "123";
           
            Usuario usuario = new Usuario() {Id = 1, Nombres = "Anais", Password = "123", Username = "Administrador"};
                      

            usuariosession.Setup(a => a.AutenticaUsername(Username, true));
            faker.Setup(x => x.GetUsuario(Username, Passsword)).Returns(usuario);

            var controller = new AuthController(faker.Object, usuariosession.Object);
            var view = controller.Login(Username,Passsword);

            
            Assert.IsNotInstanceOf<ViewResult>(view);
        }






    }
}

