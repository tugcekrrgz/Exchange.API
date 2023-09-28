using Exchange.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Exchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly HttpClient _client;

        public ExchangeController(HttpClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrency()
        
        {
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";

            List<ExchangeDTO> exchanges = new List<ExchangeDTO>();

            var result=await _client.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var xmlContent = await result.Content.ReadAsStringAsync();
                XDocument xml = XDocument.Parse(xmlContent);
                var currencies = xml.Descendants("Currency");

                foreach (var currency in currencies)
                {
                    ExchangeDTO exchangeDTO = new ExchangeDTO();

                    exchangeDTO.CurrencyCode=currency.Element("CurrencyName")?.Value;
                    exchangeDTO.CurrencyName = currency.Element("Isim")?.Value;

                    if (!string.IsNullOrEmpty(currency.Element("ForexBuying")?.Value)){
                        exchangeDTO.ForexBuying = decimal.Parse(currency.Element("ForexBuying")?.Value.Replace('.', ','));
                    }
                    if (!string.IsNullOrEmpty(currency.Element("ForexSelling")?.Value))
                    {
                        exchangeDTO.ForexSelling = decimal.Parse(currency.Element("ForexSelling")?.Value.Replace('.', ','));
                    }                  


                    exchanges.Add(exchangeDTO);                 
                }
                return Ok(exchanges);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
