using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWebMVCRest.Models
{
    public class Empleado
    {
        [Display(Name ="Codigo")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

    }
}