using System.Collections.Generic;
using System.Threading.Tasks;
using api_sisgen.Dtos.Boleta;
using api_sisgen.Models;
using api_sisgen.Models.BoletaElectronica;

namespace api_sisgen.Services.BoletaService
{
    public interface IBoletaService
    {
        Task<ServiceResponse<GetBoletaDto>> CrearBoleta(AddBoletaDto nuevaBoleta);
        Task<ServiceResponse<List<GetBoletaDto>>> GetBoletas();
    }
}