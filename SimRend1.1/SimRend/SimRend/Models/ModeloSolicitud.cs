using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimRend.Models
{
    public class ModeloSolicitud
    {
        public SimRend.Models.Solicitud Solicitud { get; set; }
        public IEnumerable<SimRend.Models.Responsable> Responsables{ get; set; }
        public IEnumerable<SimRend.Models.Categoria> Categorias { get; set; }
        public IEnumerable<SimRend.Models.Persona> Participantes { get; set; }
        public SimRend.Models.Responsable Responsable { get; set; }
        public SimRend.Models.Organizacion Organizacion { get; set; }
        public SimRend.Models.CAA CAA { get; set; }
        public SimRend.Models.Federacion Federacion { get; set; }

        public string CategoriasConcatenadas { get {
                if (Categorias.Count() > 0)
                {
                    string categorias = "";
                    if (Categorias.Count() == 1)
                    {
                        return Categorias.ElementAt(0).Nombre;
                    }
                    else
                    {
                        for (int i = 0; i < Categorias.Count(); i++)
                        {
                            if (i == 0)
                            {
                                categorias = Categorias.ElementAt(i).Nombre;
                            }
                            else if (i < Categorias.Count() - 1)
                            {
                                categorias = categorias + ", " + Categorias.ElementAt(i).Nombre;
                            }
                            else
                            {
                                categorias = categorias + " y/o " + Categorias.ElementAt(i).Nombre;
                            }
                        }
                        return categorias;
                    }
                }
                return null;
            }
        }
    }
   
}
