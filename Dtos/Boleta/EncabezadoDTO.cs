namespace api_sisgen.Dtos.Boleta
{
    public class EncabezadoDTO
    {
        public IdDocDTO IdDoc { get; set; }
        public EmisorDTO Emisor { get; set; }
        public ReceptorDTO Receptor { get; set; } 
        public TotalesDTO Totales { get; set; }
    }
}