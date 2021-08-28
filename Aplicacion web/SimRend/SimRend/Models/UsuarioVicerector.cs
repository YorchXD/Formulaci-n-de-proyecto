using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class UsuarioVicerector:Usuario
    {
        public string Estado { get; set; }
        public String Cargo { get; set; }
        public int FonoAnexo { get; set; }
        public Institucion Institucion { get; set; }
    }
}
