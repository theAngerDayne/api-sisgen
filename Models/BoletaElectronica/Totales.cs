using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sisgen.Models.BoletaElectronica
{
    public class Totales
    {
        [Key]
        [ForeignKey("Encabezado")]
        public int EncabezadoId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MntNeto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MntExe { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal IVA { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MntTotal { get; set; }
        public Encabezado Encabezado { get; set; }
    }
}