using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sisgen.Models.BoletaElectronica
{
    public class Receptor
    {
        [Key]
        [ForeignKey("Boleta")]
        public int BoletaId { get; set; }
        public string RUTRecep { get; set; } = "66666666-6";
        public string CdgIntRecep { get; set; }
        public string RznSocRecep { get; set; }
        public string Contacto { get; set; }
        public string DirRecep { get; set; }
        public string CmnaRecep { get; set; }
        public string CiudadRecep { get; set; }
        public string DirPostal { get; set; }
        public string CmnaPostal { get; set; }
        public string CiudadPostal { get; set; }

        public Boleta Boleta{get;set;}
  
      
    }
}