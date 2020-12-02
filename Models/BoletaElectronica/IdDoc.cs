using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sisgen.Models.BoletaElectronica
{
    public class IdDoc
    {
        [Key]
        [ForeignKey("Encabezado")]
        public int EncabezadoId { get; set; }
        public int TipoDTE { get; set; }
        public int Folio { get; set; }
        public string FchEmis { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public int IndServicio { get; set; } = 3;
        public int IndMntNeto { get; set; }
        public string PeriodoDesde { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public string PeriodoHasta { get; set; }= DateTime.Now.ToString("yyyy-MM-dd");
        public string FchVenc { get; set; }
        public Encabezado Encabezado { get; set; }



    }
}