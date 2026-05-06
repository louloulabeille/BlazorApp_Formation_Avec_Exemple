using BlazorApp_Formation_Avec_Exemple.Models.Configuration;
using BlazorApp_Formation_Avec_Exemple.Interfaces.Services;
using BlazorApp_Formation_Avec_Exemple.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BlazorApp_Formation_Avec_Exemple.Infrastructure.Services
{
    //public class HttpWeatherForecastService(HttpClient client, IOptions<UrlApi> options) : IWheatherForecastService, IDisposable
    public class HttpWeatherForecastService(HttpClient client) : IWheatherForecastService, IDisposable
    {
        #region private properties
        private readonly HttpClient _httpClient = client;
        private readonly JsonSerializerOptions _optionsJson = new() {
            PropertyNameCaseInsensitive = true,
        };
        //private readonly IOptions<UrlApi> _options = options;
        #endregion

        /// <summary>
        /// Conmunication http vers une web api pour récupérer les données ou datas
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        public async Task<WeatherForecast[]> GetForecastAsync(DateTime now)
        {
            try
            {
                //int retry = 0;
                using var result = await _httpClient.GetAsync("WeatherForecast?date="+now.ToString("yyyy-MM-dd"));
                //result.EnsureSuccessStatusCode(); // -- leve une exception si la réponse Http est false

                /*while (!result.IsSuccessStatusCode && retry < _options.Value.MaxRetries)
                {
                    await Task.Delay(_options.Value.Delay);
                    result = await _httpClient.GetAsync("WeatherForecast?date=" + now.ToString("yyyy-MM-dd"));
                    retry++;
                }
                result.EnsureSuccessStatusCode();*/

                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<WeatherForecast[]>(response, _optionsJson) ?? [];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetForecastAsync - {ex.Message}");
                
            }
            return [];
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
