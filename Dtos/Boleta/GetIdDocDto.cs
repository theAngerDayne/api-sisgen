namespace api_sisgen.Dtos.Boleta
{
    public class GetIdDocDto
    {
        public int TipoDTE { get; set; }
        public int Folio { get; set; }
        public string FchEmis { get; set; }
        public int IndServicio { get; set; } = 3;
        public int IndMntNeto { get; set; }
        public string PeriodoDesde { get; set; } /*AAAA-MM-DD*/
        public string PeriodoHasta { get; set; }
        public string FchVenc { get; set; } 
    }
}