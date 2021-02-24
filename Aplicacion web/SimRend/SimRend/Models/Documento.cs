using System;

namespace SimRend.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public String CodigoDocumento { get; set; }
        public String Proveedor { get; set; }
        public DateTime FechaDocumento { get; set; }
        public int Monto { get; set; }
        public String DescripcionDocumento { get; set; }
        public Categoria Categoria { get; set; }
        public String TipoDocumento { get; set; }
        public String CopiaDoc { get; set; }
        public int Estado { get; set; }
    }
}