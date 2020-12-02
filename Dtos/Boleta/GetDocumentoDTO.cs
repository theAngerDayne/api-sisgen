using System.Collections.Generic;


namespace api_sisgen.Dtos.Boleta
{
    public class GetDocumentoDTO
    {       
        public EncabezadoDTO Encabezado { get; set; }      
        public List<DetalleDto> Detalles { get; set; }
    }
}