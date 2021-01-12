using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string RUN { get; set; }
        public string Sexo { get; set; }
        public int Matricula { get; set; }
        public string Carrera { get; set; }
        public string Estado { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public int IdOrganizacionEstudiantil { get; set; }
        public string NombreOrganizacionEstudiantil { get; set; }
        public string CrearSolicitud { get; set; }
    }
}
