using BlazorApp_Formation_Avec_Exemple.Models.Configuration;

namespace BlazorApp_Formation_Avec_Exemple.Components.Infrastructure.ExtendsMethod
{
    public static class OptionExtends
    {
        extension(IServiceCollection services)
        {
            /// <summary>
            /// method d'extension de classe qui ajoute les IOptions de configuration en injection dans l'application
            /// </summary>
            /// <param name="config"></param>
            /// <returns></returns>
            public IServiceCollection AddOptionsConfigure(IConfiguration config)
            {
                services.AddOptions();
                services.Configure<UrlApi>(config.GetSection("Api"));

                return services;
            }
        }
    }
}
