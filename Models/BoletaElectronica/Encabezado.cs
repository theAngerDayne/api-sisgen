using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sisgen.Models.BoletaElectronica
{
    public class Encabezado
    {
        [Key]
        [ForeignKey("Documento")]
        public int DocumentoId { get; set; }
        public Totales Totales { get; set; }
        public virtual IdDoc IdDoc { get; set; }
        public virtual Emisor Emisor { get; set; }
        public virtual Receptor Receptor { get; set; } 

        public Documento Documento { get; set; }
    }
}