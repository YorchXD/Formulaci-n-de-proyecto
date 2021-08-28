using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class UsuarioRepresentante: Usuario
    {
        public string Estado { get; set; }
        public Organizacion Organizacion { get; set; }
        public String CrearSolicitud { get; set; }
        public int Matricula { get; set; }
        public String RUN { get; set; }
        public Institucion Institucion { get; set; }
    }
}
