using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaJOIN.Models {
    public class UsuarioXCiudadCE {
        //public string Observaciones;

        //public string Obervaciones { get { return Observaciones; } set { Observaciones = value; } }
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdCiudad { get; set; }

        [Required]
        [Display(Name ="Ingresa la observación")]
        public string Obervaciones { get; set; }

        
        public virtual Ciudad Ciudad { get; set; }
        
        public virtual Usuario Usuario { get; set; }

        [Required]
        [Display(Name = "Ingresa la Ciudad")]
        public string NombreCiudad { get; set; }
        [Required]
        [Display(Name = "Ingresa el Usuario")]
        public string NombreUsuario { get; set; }
    }

    [MetadataType(typeof(UsuarioXCiudadCE))]
    public partial class UsuarioXCiudad {

        public string IdCiudadObersaciones { get { return IdCiudad + "" + Obervaciones; } }
    }
}