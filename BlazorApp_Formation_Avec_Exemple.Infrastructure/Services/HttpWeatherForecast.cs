using BlazorApp_Formation_Avec_Exemple.Interfaces.Services;
using BlazorApp_Formation_Avec_Exemple.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BlazorApp_Formation_Avec_Exemple.Infrastructure.Services
{
    public class HttpWeatherForecast : IWheatherForecastService
    {
        #region private properties
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options = new() {
            PropertyNameCaseInsensitive = true,
        };
        #endregion

        #region constructeur
        public HttpWeatherForecast(IConfiguration configuration)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(configuration.GetSection("AdresseApi").Value?? "https://localhost:7066"),
            };
        }
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
                
                using var result = await _httpClient.GetAsync("WeatherForecast?date="+now.ToString("yyyy-MM-dd"));
                result.EnsureSuccessStatusCode();

                if (result.IsSuccessStatusCode)
                {
                    string response = await result.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<WeatherForecast[]>(response, _options) ?? [];
                }
                return [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetForecastAsync - {ex.Message}");
                return [];
            }

            
        }
    }
}
