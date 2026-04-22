using BlazorApp_Formation_Avec_Exemple.Models;

namespace BlazorApp_Formation_Avec_Exemple.Interfaces.Services
{
    public interface IWheatherForecastService
    {
        public Task<WeatherForecast[]> GetForecastAsync(DateTime now);
    }
}