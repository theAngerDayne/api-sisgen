using api_sisgen.Dtos.Boleta;
using api_sisgen.Models.BoletaElectronica;
using AutoMapper;

namespace api_sisgen.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddBoletaDto, Boleta>();

            CreateMap<Encabezado, EncabezadoDTO>(); 
            CreateMap<Emisor, EmisorDTO>();   
            CreateMap<Receptor, ReceptorDTO>();   
            CreateMap<Totales, TotalesDTO>();              
            CreateMap<IdDoc, IdDocDTO>();   
            CreateMap<Detalle, DetalleDto>();

            CreateMap<Boleta, GetBoletaDTO>().IncludeAllDerived();    
               CreateMap<Boleta, Documento>().IncludeAllDerived();              

        }

    }
}