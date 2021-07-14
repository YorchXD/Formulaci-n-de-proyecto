using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class Institucion
    {
        public int Id { get; set; }
        public String Abreviacion { get; set; }
        public String Nombre { get; set; }
        public String Estado { get; set; }
        public String EstadoEliminacion { get; set; }
    }
}
