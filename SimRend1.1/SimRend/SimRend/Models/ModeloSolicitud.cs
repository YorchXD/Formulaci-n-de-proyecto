using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class ModeloSolicitud
    {
        public SimRend.Models.Solicitud Solicitud { get; set; }
        public List<Categoria> Categorias { get; set; }

        public ModeloSolicitud()
        {
            Categorias = new List<Categoria>();
        }
    }
}
