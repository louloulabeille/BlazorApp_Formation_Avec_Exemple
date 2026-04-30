using Microsoft.AspNetCore.Components;

namespace BlazorApp_Formation_Avec_Exemple.Components.Layout
{
    public class LoaderBase : ComponentBase
    {
        #region public properties parameter
        // - pour faire passer du code html directement en parametre
        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;
        // - delay d'affichage du message en miliseconde
        [Parameter]
        public int DelayInt { get; set; } = 1000;
        #endregion

        #region protected properties view
        protected bool ShowLoaderMessage { get; set; } = false;
        #endregion


        #region protected override method
        /// <summary>
        /// après rendu du loader 
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _ = Task.Delay(DelayInt).ContinueWith(async _ => {
                    ShowLoaderMessage = true;
                    await this.InvokeAsync(StateHasChanged);
                });
            }
             await base.OnAfterRenderAsync(firstRender);
        }
        #endregion
    }
}
