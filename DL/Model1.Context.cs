﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SGomezBibliotecaEntities : DbContext
    {
        public SGomezBibliotecaEntities()
            : base("name=SGomezBibliotecaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Genero> Generoes { get; set; }
        public virtual DbSet<libro> libroes { get; set; }
    
        public virtual int LibroAdd(string libro, string editorial, string autor, Nullable<int> numeroPaginas, Nullable<int> idGenero)
        {
            var libroParameter = libro != null ?
                new ObjectParameter("Libro", libro) :
                new ObjectParameter("Libro", typeof(string));
    
            var editorialParameter = editorial != null ?
                new ObjectParameter("Editorial", editorial) :
                new ObjectParameter("Editorial", typeof(string));
    
            var autorParameter = autor != null ?
                new ObjectParameter("Autor", autor) :
                new ObjectParameter("Autor", typeof(string));
    
            var numeroPaginasParameter = numeroPaginas.HasValue ?
                new ObjectParameter("NumeroPaginas", numeroPaginas) :
                new ObjectParameter("NumeroPaginas", typeof(int));
    
            var idGeneroParameter = idGenero.HasValue ?
                new ObjectParameter("IdGenero", idGenero) :
                new ObjectParameter("IdGenero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroAdd", libroParameter, editorialParameter, autorParameter, numeroPaginasParameter, idGeneroParameter);
        }
    
        public virtual int LibroDelete(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroDelete", idLibroParameter);
        }
    
        public virtual ObjectResult<LibroGetAll_Result> LibroGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetAll_Result>("LibroGetAll");
        }
    
        public virtual ObjectResult<LibroGetById_Result> LibroGetById(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetById_Result>("LibroGetById", idLibroParameter);
        }
    
        public virtual int LibroUpdate(Nullable<int> idLibro, string libro, string editorial, string autor, Nullable<int> numeroPaginas, Nullable<int> idGenero)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            var libroParameter = libro != null ?
                new ObjectParameter("Libro", libro) :
                new ObjectParameter("Libro", typeof(string));
    
            var editorialParameter = editorial != null ?
                new ObjectParameter("Editorial", editorial) :
                new ObjectParameter("Editorial", typeof(string));
    
            var autorParameter = autor != null ?
                new ObjectParameter("Autor", autor) :
                new ObjectParameter("Autor", typeof(string));
    
            var numeroPaginasParameter = numeroPaginas.HasValue ?
                new ObjectParameter("NumeroPaginas", numeroPaginas) :
                new ObjectParameter("NumeroPaginas", typeof(int));
    
            var idGeneroParameter = idGenero.HasValue ?
                new ObjectParameter("IdGenero", idGenero) :
                new ObjectParameter("IdGenero", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroUpdate", idLibroParameter, libroParameter, editorialParameter, autorParameter, numeroPaginasParameter, idGeneroParameter);
        }
    }
}
