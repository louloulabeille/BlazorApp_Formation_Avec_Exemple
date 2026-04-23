using BlazorApp_Formation_Avec_Exemple.Interfaces.Services;
using BlazorApp_Formation_Avec_Exemple.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp_Formation_Avec_Exemple.Components.Pages
{
    public class WeatherBase : ComponentBase
    {
        [Inject]
        public IWheatherForecastService? WheatherForecastService { get; set; }

        protected WeatherForecast[]? Forecasts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (WheatherForecastService is not null)
                Forecasts = await WheatherForecastService.GetForecastAsync(DateTime.Now);
            
            await base.OnInitializedAsync();
        }
    }
}
