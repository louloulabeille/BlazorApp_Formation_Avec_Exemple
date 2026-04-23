using BlazorApp_Formation_Avec_Exemple.Components.Infrastructure.DTO;
using Microsoft.AspNetCore.Components;

namespace BlazorApp_Formation_Avec_Exemple.Components.Pages
{
    public class FormBase : ComponentBase
    {

        #region protected properties view
        protected CustomerDTO Client { get; set; } = new ();
        #endregion

        #region private Properties inject
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;
        #endregion


        #region protected methods view
        protected async Task Validate() {
            // si le formulaire est valide , on peut faire un traitement ici sinon il ne passe pas dans cette méthode
            NavigationManager.NavigateTo("/"); // - bool forceLoad = true  / force le rafraichissement de la page
        }

        #endregion
    }
}
