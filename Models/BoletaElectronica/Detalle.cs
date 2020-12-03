using System.ComponentModel.DataAnnotations.Schema;

namespace api_sisgen.Models.BoletaElectronica
{
    public class Detalle
    {
        public int Id { get; set; }

        [NotMapped]
        public int NroLinDet { get; set; }
        public string NmbItem { get; set; }
        public string UnmdItem { get; set; }
        public int QtyItem { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrcItem { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoItem { get; set; }

    }
}