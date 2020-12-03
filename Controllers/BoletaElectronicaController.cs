using System.Threading.Tasks;
using api_sisgen.Dtos.Boleta;
using api_sisgen.Services.BoletaService;
using Microsoft.AspNetCore.Mvc;

namespace api_sisgen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletaElectronicaController : ControllerBase
    {
        private readonly IBoletaService _boletaService;
        public BoletaElectronicaController(IBoletaService boletaService)
        {
            _boletaService = boletaService;

        }

        [HttpPost]
        public async Task<IActionResult> CrearBoleta(AddBoletaDto nuevaBoleta)
        {
            return Ok(await _boletaService.CrearBoleta(nuevaBoleta));
        }

        public async Task<IActionResult> GetBoletas()
        {
            return Ok(await _boletaService.GetBoletas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoletaById(int id)
        {
            return Ok(await _boletaService.GetBoletaById(id));
        }

        [HttpGet("{tipo}/{folio}")]
        public async Task<IActionResult> GetBoletaByFolioTipo(int tipo, int folio)
        {
            return Ok(await _boletaService.GetBoletaByFolioTipo(tipo, folio));
        }
    }
}