using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Models;
using static System.Net.WebRequestMethods;

namespace OpenWeatherApi.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StormglassController : ControllerBase
    {
        private readonly HttpClient client;

        public StormglassController()
        {
            client = new HttpClient { BaseAddress = new Uri("https://api.stormglass.io") };
            client.DefaultRequestHeaders.Add("Authorization", "03292c62-6289-11ee-86b2-0242ac130002-03292d02-6289-11ee-86b2-0242ac130002");
        }

        [HttpGet]
        public async Task<StormglassData> Get()
        {
            var url = "/v2/weather/point?lat=55.395833&lng=10.388611&params=waveHeight,wavePeriod";
            try
            {
                var weatherData = await client.GetFromJsonAsync<StormglassData>(url);
                if (weatherData != null)
                {
                    return weatherData;
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
