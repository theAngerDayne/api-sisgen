using System.Collections.Generic;
using System.Threading.Tasks;
using api_sisgen.Dtos.Boleta;
using api_sisgen.Models;

namespace api_sisgen.Services.BoletaService
{
    public interface IBoletaService
    {
        Task<ServiceResponse<GetDocumentoDTO>> CrearBoleta(AddBoletaDto nuevaBoleta);
        Task<ServiceResponse<List<GetDocumentoDTO>>> GetBoletas();
        Task<ServiceResponse<GetDocumentoDTO>> GetBoletaById(int id);
        Task<ServiceResponse<GetDocumentoDTO>> GetBoletaByFolioTipo(int tipo, int folio);


    }
}