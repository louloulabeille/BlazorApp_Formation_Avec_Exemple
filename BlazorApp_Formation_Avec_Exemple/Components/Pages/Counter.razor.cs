using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

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
    public class CounterBase: ComponentBase, IDisposable // IAsyncDisposable
    {

        #region properties protected view
        protected int CurrentCount = 0;
        protected bool Loading { get; private set; }
        protected string? Color { get; private set; }
        #endregion

        /*[Parameter]
        public int InitialCount { get => currentCount; set => currentCount = value; }*/
        #region properties passé en paramètre au niveau du lien html https://localhost:7280/Counter/5

        [CascadingParameter(Name ="Count")]
        public int Value { get; set; }
        #endregion

        #region method protected view
        /// <summary>
        /// method de onclick du btn d'incrementation
        /// il est possible d'avoir de rajouter un MouseEventArgs en paramètre pour récupérer les infos de l'évènement,
        /// comme la touche alt du clavier
        /// </summary>
        /// <param name="args"></param>
        protected void IncrementCount(MouseEventArgs args)
        {
            if (args.AltKey) // -- si on appuie sur la touche alt du clavier, on incrémente de 2
            {
                CurrentCount += 2;
            }
            else
            {
                CurrentCount++;
            }
            
            if (CurrentCount <= 10)
                Color = "white";
            else
                Color = "red";
        }

        #endregion

        // ce qu'il faut savoir c'est que dans Blazor le constructeur on ne peut pas passer de composant par le constructeur

        #region method override OnInitialized ou async / sync
        /// <summary>
        /// méthod qui est appelé très tot avant meme le rendu des composants
        /// par exemple pour faire les intialisations de data
        /// </summary>
        protected override void OnInitialized()
        {
            Console.WriteLine("-- OnInitialized Begin --");
            Loading = true;
            // - StateHasChanged() demande au systeme de visualisation de se rafraichir
            // en utilisant le InvokeAsync pour que le rafraichissement se fasse dans le bon contexte de thread
            _ = Task.Delay(5000).ContinueWith(_=> { Loading = false; InvokeAsync(StateHasChanged); });

            base.OnInitialized();
            Console.WriteLine("-- OnInitialized End --");
        }
        #endregion

        #region method override OnParameterSet async ou sync
        /// <summary>
        /// début de la phase de rendu du composant, c'est ici que l'on peut récupérer les paramètres passés au composant
        /// il est appelé chaque fois que les paramètres du composant sont définis ou modifiés.
        /// </summary>
        protected override void OnParametersSet()
        {
            Console.WriteLine("-- OnParametersSet begin --");
            CurrentCount = Value;
            base.OnParametersSet();
            Console.WriteLine("-- OnParametersSet End --");
        }
        #endregion 

        #region method override OnAfterRender Async ou sync & ShouldRender
        /// <summary>
        /// cette  method est appelé lorsque les composants ont leur rendu final,
        /// c'est ici que l'on peut effectuer des opérations après le rendu du composant, comme l'appel d'API ou la manipulation du DOM.
        /// on peut utiliser le paramètre firstRender pour savoir si c'est le premier rendu du composant ou non.
        /// et on peut faire appel de javascript interop pour manipuler le DOM ou appeler des fonctions JavaScript.
        /// </summary>
        /// <param name="firstRender"></param>
        protected override void OnAfterRender(bool firstRender)
        {
            Console.WriteLine("-- OnAfterRender begin --");
            base.OnAfterRender(firstRender);
            Console.WriteLine("-- OnAfterRender begin --");
        }

        /// <summary>
        /// retourne si un composant doit rendre ou non, par défaut il retourne true,
        /// mais on peut le surcharger pour retourner false si on ne veut pas que le composant se rende.
        /// a chaque modification de l'état du composant, le framework appelle cette méthode pour déterminer si le composant doit être rendu ou non.
        /// </summary>
        /// <returns></returns>
        protected override bool ShouldRender()
        {
            Console.WriteLine("-- ShouldRender begin --");
            Console.WriteLine("-- ShouldRender End --");
            return base.ShouldRender();
            //return false;
        }

        #endregion

        #region method public override SetParametersAsync
        /// <summary>
        /// Définit les paramètres fournis par le parent du composant dans l’arborescence de rendu.
        /// Très dangereux à modifier.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            Console.WriteLine("-- SetParametersAsync begin --");
            await base.SetParametersAsync(parameters);
            Console.WriteLine("-- SetParametersAsync End --");
        }
        #endregion

        #region method override Dispose
        /// <summary>
        /// method qui implémente l'interface IDisposable, qui est appelée lorsque le composant est détruit.
        /// il existe aussi IAsyncDispose pour le faire Async
        /// obligatoire à cause des fuites mémoires
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine("Dispose");
            GC.SuppressFinalize(this);
;        }

        /*public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }*/
        #endregion

        #region method override BuildRenderTree
        /// <summary>
        /// créer l'arbre de rendu des composant HTML,
        /// c'est ici que l'on peut créer dynamiquement le contenu du composant en utilisant le RenderTreeBuilder.
        /// dans ce cas cela ne marche pas car il est hérité dans la page razor et la page a dont son propre systeme de rendu
        /// qui n'est pas celui-ci. Pour se faire ajouter une classe cs qui hérite de ComponentBase et qui ne contient pas de fichier razor associé.
        /// <nomdelaclasse></nomdelaclasse> pour l'afficher
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /*protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0,"a");
            builder.AddAttribute(1,"href", "https://www.biathlonworld.com/fr/results/BT2526SWRLCP08SWPU");
            builder.AddContent(2,"Résultats de biathlon !");
            builder.CloseElement();
            // => <a href="https://www.biathlonworld.com/fr/results/BT2526SWRLCP08SWPU">Résultats de biathlon !</a>
            //base.BuildRenderTree(builder);
        }*/
        #endregion
    }
}
