using System.Collections.Generic;

namespace api_sisgen.Models.BoletaElectronica
{
    public class Boleta
    {
        public int Id { get; set; }
        public Encabezado Encabezado { get; set; }        
        public List<Detalle> Detalle { get; set; }
    }
}