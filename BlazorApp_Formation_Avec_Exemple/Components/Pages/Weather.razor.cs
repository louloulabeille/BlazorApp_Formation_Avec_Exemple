using BlazorApp_Formation_Avec_Exemple.Interfaces.Services;
using BlazorApp_Formation_Avec_Exemple.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp_Formation_Avec_Exemple.Components.Pages
{
    public class WeatherBase : ComponentBase
    {
        #region private properties
        //private WeatherForecast[]? _forecasts;
        #endregion

        #region injection de dépendance par propriété 
        [Inject]
        public IWheatherForecastService? WheatherForecastService { get; set; }
        #endregion

        #region protected properties view
        /*protected WeatherForecast[]? Forecasts { get { return _forecasts; } set {
                _forecasts = value;
                Console.WriteLine($"il est bien mis à jour {_forecasts?.Count()}");
            } }*/
        protected WeatherForecast[]? Forecasts;

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
        /// <summary>
        /// initialisation des data à afficher
        /// </summary>
        /// <returns></returns>
        private async Task InitializeForecasts()
        {
            // -- appel de la class par injection pour retourner les datas
            //await Task.Delay(5000);
            if (WheatherForecastService is not null)
            {
                Forecasts = await WheatherForecastService.GetForecastAsync(DateSaisie);
                // - rafraichi la page
                //await this.InvokeAsync(StateHasChanged);
            }
                    
            

        }
        #endregion
    }
}
