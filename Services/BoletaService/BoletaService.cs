using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_sisgen.Data;
using api_sisgen.Dtos.Boleta;
using api_sisgen.Models;
using api_sisgen.Models.BoletaElectronica;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_sisgen.Services.BoletaService
{
    public class BoletaService : IBoletaService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public BoletaService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<List<GetBoletaDto>>> CrearBoleta(AddBoletaDto nuevaBoleta)
        {
            ServiceResponse<List<GetBoletaDto>> serviceResponse = new ServiceResponse<List<GetBoletaDto>>();

            /*crearemos una boleta para luego guardarla en bd, luego de eso, podriamos crear los otros metodos y finalmente ir por el xml*/
            Boleta boleta = new Boleta();
           
            Emisor emisor = new Emisor(); /*deberia obtener rut el emisor desde la bd y ponerlo en la boleta*/
            
            boleta.MntNeto = CalcularNetoBoleta(nuevaBoleta.MntTotal);
            boleta.IVA = CalcularIvaBoleta(nuevaBoleta.MntTotal);

            

            boleta = _mapper.Map<Boleta>(nuevaBoleta);

       
            await _context.Boletas.AddAsync(boleta);

            await _context.SaveChangesAsync();

            serviceResponse.Message = "Boleta eletrónica creada";
            serviceResponse.Data = (_context.Boletas.Select(c => _mapper.Map<GetBoletaDto>(c))).ToList();
            return serviceResponse;

        }

        private decimal CalcularNetoBoleta(decimal mntTotal)
        {
            return Math.Round( mntTotal / 1.19m );
        }

        private decimal CalcularIvaBoleta(decimal montoTotal)
        {
            return Math.Round( montoTotal - (montoTotal / 1.19m ), MidpointRounding.AwayFromZero);
        }

        public async Task<ServiceResponse<List<GetBoletaDto>>> GetBoletas()
        {

            var serviceResponse = new ServiceResponse<List<GetBoletaDto>>();
            var dbBoletas = await _context.Boletas.ToListAsync();
            // serviceResponse.Data = await (dbBoletas.Select(c => _mapper.Map<GetBoletaDto>(c))).ToList();

            return serviceResponse;

        }
    }
}