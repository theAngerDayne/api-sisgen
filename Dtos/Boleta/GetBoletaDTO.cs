using System.Collections.Generic;
using System.Xml.Serialization;
using api_sisgen.Models.BoletaElectronica;

namespace api_sisgen.Dtos.Boleta
{
    public class GetBoletaDTO
    {
        public EncabezadoDTO Encabezado { get; set; }
        public List<DetalleDto> Detalle { get; set; }
    }    

}