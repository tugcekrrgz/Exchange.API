using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCurrency()
        {
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
        }
    }
}
