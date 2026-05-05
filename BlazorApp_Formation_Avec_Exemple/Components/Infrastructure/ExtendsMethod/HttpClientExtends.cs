using BlazorApp_Formation_Avec_Exemple.Components.Infrastructure.Configuration;
using BlazorApp_Formation_Avec_Exemple.Infrastructure.Services;
using BlazorApp_Formation_Avec_Exemple.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace BlazorApp_Formation_Avec_Exemple.Components.Infrastructure.ExtendsMethod
{
    public static class HttpClientExtends
    {
        extension (IServiceCollection services)
        {
            public IServiceCollection AddHttpClientExtends()
            {

                services.AddHttpClient<IWheatherForecastService, HttpWeatherForecastService>((serviceProvider, client) => {
                    var options = serviceProvider.GetRequiredService<IOptions<UrlApi>>();
                    client.BaseAddress = new Uri(options.Value.Url ?? throw new ArgumentNullException("la configuration de l'adresse de l'api est vide."));
                });

                return services;
            }
        }
    }
}
