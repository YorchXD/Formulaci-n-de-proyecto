using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string EstadoEliminacion { get; set; }
        public Rol Rol { get; set; }
    }
}
