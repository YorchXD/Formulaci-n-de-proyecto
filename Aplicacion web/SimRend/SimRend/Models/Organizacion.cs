using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class Organizacion
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public String Campus { get; set; }
        public String Tipo { get; set; }
        public String Estado { get; set; }
        public String EstadoEliminacion { get; set; }
    }
}

