using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp_Formation_Avec_Exemple.Components.Pages
{
    public class CounterParentBase : ComponentBase
    {
        protected int InitialCount { get; set; }


        #region protected method view
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected void KeyPress(KeyboardEventArgs args)
        {
            if (args.Key.Equals("+"))
            {
                InitialCount++;
            }
            
            if (args.Key.Equals("-"))
            {
                InitialCount--;
            }
        }
        #endregion
    }
}
