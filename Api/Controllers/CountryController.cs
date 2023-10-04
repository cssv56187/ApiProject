using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;

namespace ApiProject.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly HttpClient client;
        private readonly string apiKey = "634bd03f2e596e94b9c3e4568703dc6a";

        public CountryController()
        {
            client = new HttpClient { BaseAddress = new Uri("https://api.openweathermap.org") };
        }

        [HttpGet]
        public async Task<List<CountrySelector>> Get(string city, string countryCode)
        {
            var url = $"geo/1.0/direct?q={city},{countryCode}&limit={1}&appid={apiKey}";
            try
            {
                var countries = await client.GetFromJsonAsync<List<CountrySelector>>(url);
                if (countries != null)
                {
                    return countries;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

    }
}
