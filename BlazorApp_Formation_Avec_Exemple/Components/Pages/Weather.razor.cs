using BlazorApp_Formation_Avec_Exemple.Interfaces.Services;
using BlazorApp_Formation_Avec_Exemple.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp_Formation_Avec_Exemple.Components.Pages
{
    public class WeatherBase : ComponentBase
    {
        #region injection de dépendance par propriété 
        [Inject]
        public IWheatherForecastService? WheatherForecastService { get; set; }
        #endregion

        #region protected properties view
        protected WeatherForecast[]? Forecasts { get; set; }

        protected DateTime DateSaisie { get; set; } = DateTime.Today;
        #endregion


        #region method override redifinition
        protected override async Task OnInitializedAsync()
        {

            await InitializeForecasts();

            await base.OnInitializedAsync();
        }
        #endregion

        #region method public view 

        protected async Task DateClicked()
        {
            await InitializeForecasts();
        }

        #endregion


        #region private method
        private async Task InitializeForecasts()
        {
            // -- appel de la class par injection pour retourner les datas

            if (WheatherForecastService is not null)
                Forecasts = await WheatherForecastService.GetForecastAsync(DateSaisie);
        }
        #endregion
    }
}
