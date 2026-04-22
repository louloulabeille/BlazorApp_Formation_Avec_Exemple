using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorApp_Formation_Avec_Exemple.Components.Infrastructure.Components
{
    public class BiathlonLink : ComponentBase
    {
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "a");
            builder.AddAttribute(1, "href", "https://www.biathlonworld.com/fr/results/BT2526SWRLCP08SWPU");
            builder.AddAttribute(2, "target", "_blank");
            builder.AddContent(3, "Résultats de biathlon !");
            builder.CloseElement();
            // => <a href="https://www.biathlonworld.com/fr/results/BT2526SWRLCP08SWPU">Résultats de biathlon !</a>
            //base.BuildRenderTree(builder);
        }
    }
}
