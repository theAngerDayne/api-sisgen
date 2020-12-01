using System.ComponentModel.DataAnnotations.Schema;
using api_sisgen.Dtos.Emisor;
using api_sisgen.Dtos.Receptor;

namespace api_sisgen.Dtos.Boleta
{
    public class GetBoletaDto
    {
        
        public decimal MntNeto { get; set; }
        
        public decimal MntExe { get; set; }
        
        public decimal IVA { get; set; }
        
        public decimal MntTotal { get; set; }
        public GetEmisorDto Emisor { get; set; }
        public GetReceptorDto Receptor { get;set;}
        public GetIdDocDto IdDoc{get;set;}
    }
}