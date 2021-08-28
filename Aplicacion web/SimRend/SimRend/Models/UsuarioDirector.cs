using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class UsuarioDirector:Usuario
    {
        public string Estado { get; set; }
        public Organizacion Organizacion { get; set; }
        public String Cargo { get; set; }
        public int FonoAnexo { get; set; }
    }
}
