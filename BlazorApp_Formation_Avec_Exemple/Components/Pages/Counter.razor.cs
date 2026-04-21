using Microsoft.AspNetCore.Components;

namespace BlazorApp_Formation_Avec_Exemple.Components.Pages
{
    /// <summary>
    /// plusieur facon de dissocié la vue avec le code, ici on a une classe de base pour le code et un fichier .razor pour la vue
    /// ou créer un classe partiel qui prend le meme nom que la classe razor. ex : 
    /// Counter.razor.cs et Counter.razor 
    /// public partial class Counter
    /// 
    /// sinon il y a le MVVM
    /// </summary>
    public class CounterBase: ComponentBase
    {
        protected int currentCount = 0;

        [Parameter]
        public int InitialCount { get => currentCount; set => currentCount = value; }

        protected void IncrementCount()
        {
            currentCount++;
        }
    }
}
