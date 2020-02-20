﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaJOIN.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PruebaJOINEntities_Context : DbContext
    {
        public PruebaJOINEntities_Context()
            : base("name=PruebaJOINEntities_Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioXCiudad> UsuarioXCiudad { get; set; }
    
        public virtual int CrearUserCiu(string observaciones, string nombreCiudad, string nombreUsuario)
        {
            var observacionesParameter = observaciones != null ?
                new ObjectParameter("Observaciones", observaciones) :
                new ObjectParameter("Observaciones", typeof(string));
    
            var nombreCiudadParameter = nombreCiudad != null ?
                new ObjectParameter("NombreCiudad", nombreCiudad) :
                new ObjectParameter("NombreCiudad", typeof(string));
    
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("NombreUsuario", nombreUsuario) :
                new ObjectParameter("NombreUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CrearUserCiu", observacionesParameter, nombreCiudadParameter, nombreUsuarioParameter);
        }
    
        public virtual int CrearUserCiu1(string nombreCiudad, string nombreUsuario)
        {
            var nombreCiudadParameter = nombreCiudad != null ?
                new ObjectParameter("NombreCiudad", nombreCiudad) :
                new ObjectParameter("NombreCiudad", typeof(string));
    
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("NombreUsuario", nombreUsuario) :
                new ObjectParameter("NombreUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CrearUserCiu1", nombreCiudadParameter, nombreUsuarioParameter);
        }
    
        public virtual int InsertarUserCiu(Nullable<int> idCiudad, Nullable<int> idUsuario, string observaciones, string nombreCiudad, string nombreUsuario)
        {
            var idCiudadParameter = idCiudad.HasValue ?
                new ObjectParameter("idCiudad", idCiudad) :
                new ObjectParameter("idCiudad", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var observacionesParameter = observaciones != null ?
                new ObjectParameter("Observaciones", observaciones) :
                new ObjectParameter("Observaciones", typeof(string));
    
            var nombreCiudadParameter = nombreCiudad != null ?
                new ObjectParameter("nombreCiudad", nombreCiudad) :
                new ObjectParameter("nombreCiudad", typeof(string));
    
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("nombreUsuario", nombreUsuario) :
                new ObjectParameter("nombreUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarUserCiu", idCiudadParameter, idUsuarioParameter, observacionesParameter, nombreCiudadParameter, nombreUsuarioParameter);
        }
    }
}