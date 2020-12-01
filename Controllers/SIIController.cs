using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace api_sisgen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SIIController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<double> GetAction()
        {
            client.DefaultRequestHeaders.Accept.Clear();        

            var stringTask = client.GetStringAsync("https://apicert.sii.cl/recursos/v1/boleta.electronica.semilla");

            var msg = await stringTask;
            XDocument xDoc = XDocument.Parse(msg);
            double semilla = double.Parse(xDoc.Descendants("SEMILLA").FirstOrDefault().Value);

            return semilla;
        }
    }
}