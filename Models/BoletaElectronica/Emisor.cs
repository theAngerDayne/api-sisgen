using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sisgen.Models.BoletaElectronica
{
    public class Emisor
    {
        [Key]
        [ForeignKey("Boleta")]
        public int BoletaId { get; set; }
        public string RUTEmisor { get; set; }
        public string RznSoc { get; set; }
        public string GiroEmis { get; set; }
        public int Acteco { get; set; }
        public int CdgSIISucur { get; set; }
        public string DirOrigen { get; set; }
        public string CmnaOrigen { get; set; }
        public string CiudadOrigen { get; set; }
        public Boleta Boleta { get; set; }


    }
}