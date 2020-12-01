
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using api_sisgen.Dtos.Receptor;
using api_sisgen.Dtos.Emisor;

namespace api_sisgen.Dtos.Boleta
{
    public class AddBoletaDto
    {    
        public decimal MntTotal { get; set; }

        public api_sisgen.Models.BoletaElectronica.Receptor Receptor {get;set;}
        //
        public api_sisgen.Models.BoletaElectronica.Emisor Emisor {get;set;}
        public api_sisgen.Models.BoletaElectronica.IdDoc IdDoc {get;set;}

        
        //public List<DetalleDto> DetallesDto { get; set; } = new List<DetalleDto>();

    }

    public class DetalleDto
    {
        public int NroLinDet { get; set; }
        public string NmbItem { get; set; }
        public int QtyItem { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrcItem { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoItem { get; set; }
    }
}