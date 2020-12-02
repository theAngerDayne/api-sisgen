using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sisgen.Models.BoletaElectronica
{
    public class Documento
    {
        public int Id { get; set; }     
        public Encabezado Encabezado { get; set; }      
        
        public ICollection<Detalle> Detalles { get; set; }
    }
}