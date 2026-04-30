using BlazorApp_Formation_Avec_Exemple.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp_Formation_Avec_Exemple.Components.Layout
{
    public class TableWeatherCastsBase : ComponentBase
    {
        /// <summary>
        ///  pour binder une propriété il faut créer 
        /// 2 parameters un sur la propertie et l'autre sur un delegate Action ave le nom de la propertie + Changed
        /// @bind-Forecasts
        /// </summary>

        #region public properties
        [Parameter]
        public WeatherForecast[]? Forecasts { get; set; }
        #endregion

        #region public properties parameter
        //public IEnumerable<WeatherForecast>? Forecasts { get; set; }
        [Parameter]
        public EventCallback<WeatherForecast[]?> ForecastsChanged { get; set; }
        #endregion

        #region protected method view
        protected void Clear()
        {
            Forecasts = null;
            ForecastsChanged.InvokeAsync(Forecasts); // - method qui repasse la data vers le parent
        }
        #endregion

    }
}
