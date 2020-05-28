using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUPN.Web.Interfaces
{
    public interface IUsuarioSession
    {
        void SetIdUsuario(Usuario usuario);
        void AutenticaUsername(String Username, bool valor);
    }
}
