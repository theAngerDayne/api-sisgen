using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sisgen.Models.BoletaElectronica
{
    public class IdDoc
    {
        [Key]
        [ForeignKey("Boleta")]
        public int BoletaId { get; set; }
        public int TipoDTE { get; set; }
        public int Folio { get; set; }
        public string FchEmis { get; set; }
        public int IndServicio { get; set; } = 3;
        public int IndMntNeto { get; set; }
        public string PeriodoDesde { get; set; } /*AAAA-MM-DD*/
        public string PeriodoHasta { get; set; }
        public string FchVenc { get; set; }
        public Boleta Boleta { get; set; }



    }
}