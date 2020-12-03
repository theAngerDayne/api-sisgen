using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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
        public async Task<ServiceResponse<GetBoletaDTO>> CrearBoleta(AddBoletaDto nuevaBoleta)
        {
            ServiceResponse<GetBoletaDTO> serviceResponse = new ServiceResponse<GetBoletaDTO>();

            /*crearemos una boleta para luego guardarla en bd, luego de eso, podriamos crear los otros metodos de calculo? y finalmente ir por el xml*/
            Boleta boleta = new Boleta();

            /*podria obtener rut el emisor desde la bd y ponerlo en la boleta*/

            try
            {
                int linea = 1;
                foreach (var item in nuevaBoleta.Detalle)
                {
                    item.MontoItem = CalcularMontoDetalle(item.PrcItem, item.QtyItem);/*(Precio unitario * cantidad) - monto desc + monto recarg */
                    nuevaBoleta.Encabezado.Totales.MntTotal += item.MontoItem;
                    item.NroLinDet = linea;
                    linea++;

                }

                nuevaBoleta.Encabezado.Totales.MntNeto = CalcularNetoBoleta(nuevaBoleta.Encabezado.Totales.MntTotal);
                nuevaBoleta.Encabezado.Totales.IVA = CalcularIvaBoleta(nuevaBoleta.Encabezado.Totales.MntTotal);

                boleta = _mapper.Map<Boleta>(nuevaBoleta);


                await _context.Boletas.AddAsync(boleta);
                // await _context.SaveChangesAsync();
                var docDto = _mapper.Map<Documento>(boleta);

                GenerarXmlBoleta(docDto);

                serviceResponse.Message = string.Format("Boleta eletrónica tipo {0} con folio {1} creada.", boleta.Encabezado.IdDoc.TipoDTE, boleta.Encabezado.IdDoc.Folio);
                serviceResponse.Data = _mapper.Map<GetBoletaDTO>(boleta);

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


            XmlSerializer serializer = new XmlSerializer(typeof(Documento));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var xml = "";

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww, settings))
                {
                    serializer.Serialize(writer, boleta, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
                    xml = sww.ToString();
                }
            }
           
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            

            XmlAttribute attr = doc.CreateAttribute("ID");
            attr.Value = string.Format("SisGenDTE_{0}F{1}", boleta.Encabezado.IdDoc.TipoDTE, boleta.Encabezado.IdDoc.Folio);
            doc.DocumentElement.SetAttributeNode(attr);
            using (TextWriter sw = new StreamWriter("root.xml", false, Encoding.GetEncoding("ISO-8859-1")))
            {                
                doc.Save(sw);
            }
        
        }

        public async Task<ServiceResponse<List<GetBoletaDTO>>> GetBoletas()
        {
            /*claramente acá debo enviar por parametro el id de la empresa para q no traiga todo*/
            ServiceResponse<List<GetBoletaDTO>> serviceResponse = new ServiceResponse<List<GetBoletaDTO>>();

            /*no creo q sea necesito incluir detalle acá, es como para mostrar en una tabla en un index*/
            var dbBoletas = await _context.Boletas
            .Include(b => b.Encabezado.Emisor)
            .Include(b => b.Encabezado.Receptor)
            .Include(b => b.Encabezado.IdDoc)
            .ToListAsync();
            serviceResponse.Data = (dbBoletas.Select(c => _mapper.Map<GetBoletaDTO>(c))).ToList();

            return serviceResponse;

        }

        public async Task<ServiceResponse<GetBoletaDTO>> GetBoletaById(int id)
        {
            ServiceResponse<GetBoletaDTO> serviceResponse = new ServiceResponse<GetBoletaDTO>();

            Boleta dbBoleta = await _context.Boletas
           .Include(b => b.Encabezado.Emisor)
            .Include(b => b.Encabezado.Receptor)
            .Include(b => b.Encabezado.IdDoc)
            .Include(d => d.Detalle)
            .FirstOrDefaultAsync(b => b.Id == id); //agregar mas  adelante la id de la empresa

            serviceResponse.Data = _mapper.Map<GetBoletaDTO>(dbBoleta);

            if (dbBoleta == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Boleta no encontrada";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBoletaDTO>> GetBoletaByFolioTipo(int tipo, int folio)
        {
            ServiceResponse<GetBoletaDTO> serviceResponse = new ServiceResponse<GetBoletaDTO>();
            try
            {

                Boleta dbBoleta = await _context.Boletas
                .Include(b => b.Encabezado.Emisor)
                .Include(b => b.Encabezado.Receptor)
                .Include(b => b.Encabezado.IdDoc)
                .Include(b => b.Encabezado.Totales)
                .Include(d => d.Detalle)
                .FirstOrDefaultAsync(b => b.Encabezado.IdDoc.TipoDTE == tipo && b.Encabezado.IdDoc.Folio == folio); //agregar mas adelante la id de la empresa

                serviceResponse.Data = _mapper.Map<GetBoletaDTO>(dbBoleta);

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