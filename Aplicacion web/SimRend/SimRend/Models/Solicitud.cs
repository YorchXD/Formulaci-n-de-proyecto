using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SimRend.Models
{
    public class Solicitud
    {
        public int Id { get; set; }
        public int RefProceso { get; set; }

        public string NombreEvento { get; set; }

        public string LugarEvento { get; set; }

        public int Monto { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicioEvento { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaTerminoEvento { get; set; }

        public int IdResponsable { get; set; }

        public string TipoEvento { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFinPdf { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaModificacion { get; set; }

        public string NombreResponsable { get; set; }
        
        public string FechaPdf {get; set;}

        public int MontoPorPersona { get; set; }
       
       /*Esta variable se utiliza para colocar la fecha de inicio y termino del evento en un solo string*/
        public string FechaEvento { get; set; }

        public List<Categoria> Categorias { get; set; }

        public List<Persona> Participantes { get; set; }

        public string CategoriasConcatenadas
        {
            get
            {
                if (Categorias != null && Categorias.Count() > 0)
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
