using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWCFRest
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Direccion { get; set; }
    }
}