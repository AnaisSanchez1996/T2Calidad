using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUPN.Web.Interfaces
{
    public interface IBiblioteca
    {
        List<Biblioteca> GetBibliotecas(Usuario usuario);
        void agregarBibLIOTECA(int libro, Usuario usuario);
        void agregarBi(int libroId, Usuario usuario);
        void marcarComoTerminado(int libroId, Usuario usuario);
    }
}

