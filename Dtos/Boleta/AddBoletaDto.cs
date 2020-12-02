
using System.Collections.Generic;

namespace api_sisgen.Dtos.Boleta
{
    public class AddBoletaDto
    {
        public decimal MntNeto { get; set; }
        public decimal MntExe { get; set; }

        public decimal IVA { get; set; }

        public decimal MntTotal { get; set; }
        public api_sisgen.Models.BoletaElectronica.Receptor Receptor { get; set; }
        public api_sisgen.Models.BoletaElectronica.Emisor Emisor { get; set; }
        public api_sisgen.Models.BoletaElectronica.IdDoc IdDoc { get; set; }
        public List<api_sisgen.Models.BoletaElectronica.Detalle> Detalles { get; set; }

    }


}