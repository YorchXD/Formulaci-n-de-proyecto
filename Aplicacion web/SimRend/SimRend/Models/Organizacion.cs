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
        public Campus Campus { get; set; }
        public TipoOE TipoOE { get; set; }
        public Institucion Institucion { get; set; }
        public String Estado { get; set; }
        public String EstadoEliminacion { get; set; }
    }
}

