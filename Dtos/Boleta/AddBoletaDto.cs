
using System.Collections.Generic;

namespace api_sisgen.Dtos.Boleta
{
    public class AddBoletaDto
    {      
        public api_sisgen.Models.BoletaElectronica.Encabezado Encabezado { get; set; }
        public List<api_sisgen.Models.BoletaElectronica.Detalle> Detalle { get; set; }

    }


}