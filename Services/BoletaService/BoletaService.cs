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
        public async Task<ServiceResponse<GetBoletaDto>> CrearBoleta(AddBoletaDto nuevaBoleta)
        {
            ServiceResponse<GetBoletaDto> serviceResponse = new ServiceResponse<GetBoletaDto>();

            /*crearemos una boleta para luego guardarla en bd, luego de eso, podriamos crear los otros metodos de calculo? y finalmente ir por el xml*/
            Boleta boleta = new Boleta();

            Emisor emisor = new Emisor(); /*deberia obtener rut el emisor desde la bd y ponerlo en la boleta*/

            try
            {              

                foreach (var item in nuevaBoleta.Detalles)
                {
                    item.MontoItem = CalcularMontoDetalle(item.PrcItem, item.QtyItem);/*(Precio unitario * cantidad) - monto desc + monto recarg */
                    nuevaBoleta.MntTotal += item.MontoItem;
                }
                
                nuevaBoleta.MntNeto = CalcularNetoBoleta(nuevaBoleta.MntTotal);
                nuevaBoleta.IVA = CalcularIvaBoleta(nuevaBoleta.MntTotal);

                boleta = _mapper.Map<Boleta>(nuevaBoleta);
                await _context.Boletas.AddAsync(boleta);

                await _context.SaveChangesAsync();

                serviceResponse.Message = string.Format("Boleta eletrónica tipo {0} con folio {1} creada.", boleta.IdDoc.TipoDTE, boleta.IdDoc.Folio);
                serviceResponse.Data = _mapper.Map<GetBoletaDto>(boleta);

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        private decimal CalcularMontoDetalle(decimal prcItem, int qtyItem)
        {
            return Math.Round(prcItem * qtyItem, MidpointRounding.AwayFromZero);
        }

        private decimal CalcularNetoBoleta(decimal mntTotal)
        {
            return Math.Round(mntTotal / 1.19m);
        }

        private decimal CalcularIvaBoleta(decimal montoTotal)
        {
            return Math.Round(montoTotal - (montoTotal / 1.19m), MidpointRounding.AwayFromZero);
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