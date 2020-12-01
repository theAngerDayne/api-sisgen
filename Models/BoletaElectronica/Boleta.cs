using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sisgen.Models.BoletaElectronica
{
    public class Boleta
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MntNeto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MntExe { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal IVA { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MntTotal { get; set; }      

        public virtual IdDoc IdDoc { get; set; }
        public virtual Emisor Emisor { get; set; }
        public virtual Receptor Receptor { get; set; } 
        
        public ICollection<Detalle> Detalles { get; set; }
    }
}