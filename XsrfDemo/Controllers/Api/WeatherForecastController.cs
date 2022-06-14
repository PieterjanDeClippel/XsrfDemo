using Microsoft.AspNetCore.Mvc;
using XsrfDemo.Stores;

namespace XsrfDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastStore weatherForecastStore;
        public WeatherForecastController(IWeatherForecastStore weatherForecastStore)
        {
            this.weatherForecastStore = weatherForecastStore;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var forecasts = await weatherForecastStore.GetForecastsAsync();
            return forecasts;
        }

        [HttpGet("{id}")]
        public async Task<WeatherForecast> Get(int id)
        {
            var forecast = await weatherForecastStore.GetForecastAsync(id);
            return forecast;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<WeatherForecast> Create([FromBody] WeatherForecast forecast)
        {
            var newForecast = await weatherForecastStore.CreateForecastAsync(forecast);
            return newForecast;
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<WeatherForecast> Update([FromBody] WeatherForecast forecast)
        {
            var updatedForecast = await weatherForecastStore.UpdateForecastAsync(forecast);
            return updatedForecast;
        }

        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task Delete(int id)
        {
            await weatherForecastStore.DeleteForecastAsync(id);
        }
    }
}