namespace XsrfDemo.Stores;

public interface IWeatherForecastStore
{
    Task SeedWithRandomForecasts();
    Task<IEnumerable<WeatherForecast>> GetForecastsAsync();
    Task<WeatherForecast?> GetForecastAsync(int id);
    Task<WeatherForecast> CreateForecastAsync(WeatherForecast weatherForecast);
    Task<WeatherForecast> UpdateForecastAsync(WeatherForecast weatherForecast);
    Task DeleteForecastAsync(int id);
}

internal class WeatherForecastStore : IWeatherForecastStore
{
    private readonly List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
    public WeatherForecastStore()
    {
    }

    public Task SeedWithRandomForecasts()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecasts = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            });

        weatherForecasts.AddRange(forecasts);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<WeatherForecast>> GetForecastsAsync()
    {
        return Task.FromResult<IEnumerable<WeatherForecast>>(weatherForecasts);
    }

    public Task<WeatherForecast?> GetForecastAsync(int id)
    {
        var forecast = weatherForecasts.FirstOrDefault(f => f.Id == id);
        return Task.FromResult(forecast);
    }

    public Task<WeatherForecast> CreateForecastAsync(WeatherForecast weatherForecast)
    {
        var id = weatherForecasts.Any() ? weatherForecasts.Max(w => w.Id) : 1;
        weatherForecast.Id = id;
        weatherForecasts.Add(weatherForecast);
        return Task.FromResult(weatherForecast);
    }

    public Task<WeatherForecast> UpdateForecastAsync(WeatherForecast weatherForecast)
    {
        var index = weatherForecasts.FindIndex(f => f.Id == weatherForecast.Id);
        if (index >= 0)
        {
            weatherForecasts[index] = weatherForecast;
        }

        return Task.FromResult(weatherForecast);
    }

    public Task DeleteForecastAsync(int id)
    {
        var index = weatherForecasts.FindIndex(f => f.Id == id);
        weatherForecasts.RemoveAt(index);
        return Task.CompletedTask;
    }
}
