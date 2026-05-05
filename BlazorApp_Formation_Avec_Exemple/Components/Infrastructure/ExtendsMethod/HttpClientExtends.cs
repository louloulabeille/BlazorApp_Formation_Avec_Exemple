using BlazorApp_Formation_Avec_Exemple.Models.Configuration;
using BlazorApp_Formation_Avec_Exemple.Infrastructure.Services;
using BlazorApp_Formation_Avec_Exemple.Interfaces.Services;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace BlazorApp_Formation_Avec_Exemple.Components.Infrastructure.ExtendsMethod
{
    public static class HttpClientExtends
    {
        extension (IServiceCollection services)
        {
            /// <summary>
            /// mise en place de l'injection de dépendance pour le HttpClient
            /// </summary>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            public IServiceCollection AddHttpClientExtends()
            {

                services.AddHttpClient<IWheatherForecastService, HttpWeatherForecastService>((serviceProvider, client) => {
                    var options = serviceProvider.GetRequiredService<IOptions<UrlApi>>();
                    client.BaseAddress = new Uri(options.Value.Url ?? throw new ArgumentNullException("la configuration de l'adresse de l'api est vide."));
                })
                    .AddPolicyHandler(GetPolicyPollyError());
                    // - mise en place de polly au niveau de cette connexion HttpClient
                    /*.AddTransientHttpErrorPolicy(policyBuilder =>policyBuilder
                    .WaitAndRetryAsync(5, retryNumber => TimeSpan.FromMilliseconds(200 + (retryNumber * 150))));
*/
                return services;
            }

        }

        /// /// Mise en place de la résiliance pour les connexions HttpClient
        /// 5 tentatives & 200ms + (200*150) qui vont s'ajouter à chaque tentatives
        /// https://learn.microsoft.com/fr-fr/aspnet/core/fundamentals/http-requests?view=aspnetcore-10.0#use-polly-based-handlers
        /// HttpRequestException
        /// HTTP 5xx
        /// HTTP 408
        private static AsyncRetryPolicy<HttpResponseMessage> GetPolicyPollyError()
        {
            return HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(5, retry => TimeSpan.FromMilliseconds(200 + (retry * 150)));
        }
    }
}
