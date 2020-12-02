using api_sisgen.Dtos.Boleta;
using api_sisgen.Dtos.Detalle;
using api_sisgen.Dtos.Emisor;
using api_sisgen.Dtos.IdDoc;
using api_sisgen.Dtos.Receptor;
using api_sisgen.Models.BoletaElectronica;
using AutoMapper;
using System.Linq;
namespace api_sisgen.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddBoletaDto, Boleta>();
            CreateMap<Receptor, GetReceptorDto>();
            CreateMap<Emisor, GetEmisorDto>();
            CreateMap<IdDoc, GetIdDocDto>();
            CreateMap<Detalle, DetalleDto>();
            CreateMap<Boleta, GetBoletaDto>().IncludeAllDerived();               
        }

    }
}