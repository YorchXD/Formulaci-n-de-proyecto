using System.Collections;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimRend.Models
{
    public class Documento
    {
        public int NumDoc { get; set; }
        public String Categoria{ get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }
        public string Descripcion { get; set; }
        public string DirecDocumento { get; set; }
        public string Proveedor { get; set; }
        public string TipoDocumento { get; set; }

    }
}