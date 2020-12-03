using System.Collections.Generic;
using System.Threading.Tasks;
using api_sisgen.Dtos.Boleta;
using api_sisgen.Models;

namespace api_sisgen.Services.BoletaService
{
    public interface IBoletaService
    {
        Task<ServiceResponse<GetBoletaDTO>> CrearBoleta(AddBoletaDto nuevaBoleta);
        Task<ServiceResponse<List<GetBoletaDTO>>> GetBoletas();
        Task<ServiceResponse<GetBoletaDTO>> GetBoletaById(int id);
        Task<ServiceResponse<GetBoletaDTO>> GetBoletaByFolioTipo(int tipo, int folio);


    }
}