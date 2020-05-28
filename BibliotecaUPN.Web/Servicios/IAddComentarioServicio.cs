using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.Servicios
{
    public class IAddComentarioServicio : IAddComentario
    {
        private AppContext Context;

        public IAddComentarioServicio(AppContext Context)
        {
            this.Context = Context;

        }

        public void addComentario(Comentario comentario, Usuario usuario)
        {
            comentario.UsuarioId = usuario.Id;
            comentario.Fecha = DateTime.Now;
            Context.Comentarios.Add(comentario);

            var libro = Context.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            Context.SaveChanges();
        }

    }
}