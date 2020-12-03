using System.Collections.Generic;
using System.Xml.Serialization;
using api_sisgen.Models.BoletaElectronica;

namespace api_sisgen.Dtos.Boleta
{
       public class Documento
    {
        public EncabezadoDTO Encabezado { get; set; }

        [XmlElement(ElementName = "Detalle", Type = typeof(DetalleDto))]
        public List<DetalleDto> Detalle { get; set; }
    }
}