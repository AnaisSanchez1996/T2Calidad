using BibliotecaUPN.Web.Constantes;
using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.Servicios
{
    public class IBibliotecaServicio: IBiblioteca
    {

        private AppContext Context;
    public IBibliotecaServicio(AppContext Context)
    {
        this.Context = Context;
    }

    public void agregarBi(int libroId, Usuario usuario)
    {
        var libro = Context.Bibliotecas
          .Where(o => o.LibroId == libroId && o.UsuarioId == usuario.Id)
          .FirstOrDefault();


        libro.Estado = ESTADO.LEYENDO;
        Context.SaveChanges();

    }

    public void agregarBibLIOTECA(int libro, Usuario usuario)
    {
        var biblioteca = new Biblioteca
        {
            LibroId = libro,
            UsuarioId = usuario.Id,
            Estado = ESTADO.POR_LEER
        };

        Context.Bibliotecas.Add(biblioteca);
        Context.SaveChanges();

    }

    public List<Biblioteca> GetBibliotecas(Usuario usuario)
    {

        var model = Context.Bibliotecas
          .Include(o => o.Libro.Autor)
          .Include(o => o.Usuario)
          .Where(o => o.UsuarioId == usuario.Id)
          .ToList();

        return model;
    }

    public void marcarComoTerminado(int libroId, Usuario usuario)
    {
        var libro = Context.Bibliotecas
         .Where(o => o.LibroId == libroId && o.UsuarioId == usuario.Id)
         .FirstOrDefault();

        libro.Estado = ESTADO.TERMINADO;
        Context.SaveChanges();
    }
}
}