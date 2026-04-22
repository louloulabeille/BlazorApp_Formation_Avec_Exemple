using BlazorApp_Formation_Avec_Exemple.Models;

namespace BlazorApp_Formation_Avec_Exemple.Services.Infrastructure
{
    public class WheatherForecastService : IWheatherForecastService
    {
        public async Task<WeatherForecast[]> GetForecastAsync(DateTime now)
        {
            await Task.Delay(500);

            var startDate = DateOnly.FromDateTime(now);
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            WeatherForecast[] forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToArray();

            return forecasts;
        }
    }
}
