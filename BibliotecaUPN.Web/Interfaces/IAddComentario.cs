using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUPN.Web.Interfaces
{
    public interface IAddComentario
    {
        void addComentario(Comentario comentario,Usuario usuario);
    }
}
