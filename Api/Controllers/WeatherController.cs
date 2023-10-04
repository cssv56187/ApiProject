using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;

namespace ApiProject.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient client;
        private readonly string apiKey = "634bd03f2e596e94b9c3e4568703dc6a";

        public WeatherController()
        {
            client = new HttpClient { BaseAddress = new Uri("https://api.openweathermap.org") };
        }

        [HttpGet]
        public async Task<OpenWeatherData> Get(double lat, double lon)
        {
            var url = $"data/2.5/forecast?lat={lat}&lon={lon}&appid={apiKey}";
            try
            {
                var weatherData = await client.GetFromJsonAsync<OpenWeatherData>(url);
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
