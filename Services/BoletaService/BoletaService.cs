using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
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
        public async Task<ServiceResponse<GetDocumentoDTO>> CrearBoleta(AddBoletaDto nuevaBoleta)
        {
            ServiceResponse<GetDocumentoDTO> serviceResponse = new ServiceResponse<GetDocumentoDTO>();

            /*crearemos una boleta para luego guardarla en bd, luego de eso, podriamos crear los otros metodos de calculo? y finalmente ir por el xml*/
            Documento boleta = new Documento();

            /*podria obtener rut el emisor desde la bd y ponerlo en la boleta*/

            try
            {

                foreach (var item in nuevaBoleta.Detalles)
                {
                    item.MontoItem = CalcularMontoDetalle(item.PrcItem, item.QtyItem);/*(Precio unitario * cantidad) - monto desc + monto recarg */
                    nuevaBoleta.Encabezado.Totales.MntTotal += item.MontoItem;
                }

                nuevaBoleta.Encabezado.Totales.MntNeto = CalcularNetoBoleta(nuevaBoleta.Encabezado.Totales.MntTotal);
                nuevaBoleta.Encabezado.Totales.IVA = CalcularIvaBoleta(nuevaBoleta.Encabezado.Totales.MntTotal);

                boleta = _mapper.Map<Documento>(nuevaBoleta);
                await _context.Boletas.AddAsync(boleta);

                await _context.SaveChangesAsync();

                //  GenerarXmlBoleta(boleta);

                serviceResponse.Message = string.Format("Boleta eletrónica tipo {0} con folio {1} creada.", boleta.Encabezado.IdDoc.TipoDTE, boleta.Encabezado.IdDoc.Folio);
                serviceResponse.Data = _mapper.Map<GetDocumentoDTO>(boleta);

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

        private void GenerarXmlBoleta(Documento boleta)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";



            /*XmlWriter writer = XmlWriter.Create("PrimeraBoleta.xml", settings);
            writer.WriteStartElement("Documento");
            writer.WriteAttributeString("ID", "Facturador_Sisgen_T39F1");

            writer.WriteStartElement("Encabezado");
            writer.WriteStartElement(nameof(boleta.IdDoc));
            writer.WriteElementString(nameof(boleta.IdDoc.TipoDTE), boleta.IdDoc.TipoDTE.ToString());
            writer.WriteElementString(nameof(boleta.IdDoc.FchVenc), boleta.IdDoc.FchVenc.ToString());
           

            writer.Flush();
            writer.Close();*/


        }

        public async Task<ServiceResponse<List<GetDocumentoDTO>>> GetBoletas()
        {
            /*claramente acá debo enviar por parametro el id de la empresa para q no traiga todo*/
            ServiceResponse<List<GetDocumentoDTO>> serviceResponse = new ServiceResponse<List<GetDocumentoDTO>>();

            /*no creo q sea necesito incluir detalle acá, es como para mostrar en una tabla en un index*/
            var dbBoletas = await _context.Boletas
            .Include(b => b.Encabezado.Emisor)
            .Include(b => b.Encabezado.Receptor)
            .Include(b => b.Encabezado.IdDoc)
            .ToListAsync();
            serviceResponse.Data = (dbBoletas.Select(c => _mapper.Map<GetDocumentoDTO>(c))).ToList();

            return serviceResponse;

        }

        public async Task<ServiceResponse<GetDocumentoDTO>> GetBoletaById(int id)
        {
            ServiceResponse<GetDocumentoDTO> serviceResponse = new ServiceResponse<GetDocumentoDTO>();

            Documento dbBoleta = await _context.Boletas
           .Include(b => b.Encabezado.Emisor)
            .Include(b => b.Encabezado.Receptor)
            .Include(b => b.Encabezado.IdDoc)
            .Include(d => d.Detalles)
            .FirstOrDefaultAsync(b => b.Id == id); //agregar mas  adelante la id de la empresa

            serviceResponse.Data = _mapper.Map<GetDocumentoDTO>(dbBoleta);

            if (dbBoleta == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Boleta no encontrada";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDocumentoDTO>> GetBoletaByFolioTipo(int tipo, int folio)
        {
            ServiceResponse<GetDocumentoDTO> serviceResponse = new ServiceResponse<GetDocumentoDTO>();
            try
            {

                Documento dbBoleta = await _context.Boletas
                 .Include(b => b.Encabezado.Emisor)
            .Include(b => b.Encabezado.Receptor)
            .Include(b => b.Encabezado.IdDoc)
                .Include(d => d.Detalles)
                .FirstOrDefaultAsync(b => b.Encabezado.IdDoc.TipoDTE == tipo && b.Encabezado.IdDoc.Folio == folio); //agregar mas adelante la id de la empresa

                serviceResponse.Data = _mapper.Map<GetDocumentoDTO>(dbBoleta);

                if (dbBoleta == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = string.Format("Boleta con folio {0} y tipo {1} no encontrada", folio, tipo);
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}