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
    public class ILibrosServicio : ILibros
    {
        
        private AppContext context;
        public ILibrosServicio(AppContext context)
        {
            this.context = context;
        }

        public Libro GetLibroId(int id)
        {
            var model = context.Libros.Include(o => o.Autor)
                  .Include(o => o.Comentarios.Select(x => x.Usuario))
                  .Where(o => o.Id == id)
                  .FirstOrDefault();
            return model;
        }

        public List<Libro> GetLibros()
        {
            var libros = context.Libros.Include(a => a.Autor).ToList();

            return libros;
        }
    }
}