using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Sexo { get; set; }
        public Institucion Institucion { get; set; }
        public String Cargo { get; set; }
    }
}
