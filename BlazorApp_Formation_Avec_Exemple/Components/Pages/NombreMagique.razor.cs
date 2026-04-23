using Microsoft.AspNetCore.Components;

namespace BlazorApp_Formation_Avec_Exemple.Components.Pages
{
    public class NombreMagiqueBase : ComponentBase
    {
        #region protected properties
        protected int EntryNbMagique { get; set; }  = 0;
        protected List<string> Life = [];
        protected bool IsGameOver => Life.Count == 0;
        protected bool IsGameWin => EntryNbMagique == NbMagique;
        protected int NbMagique;
        #endregion

        #region private properties
        private const int _nbLifeDefault = 5;
        private const int _nbMax = 21;
        #endregion

        #region protected method

        /// <summary>
        /// method qui teste le nombre magique , si le nombre est incorrecte on retire une vie
        /// </summary>
        protected void TesterNbMagique()
        {
            try
            {
                if (EntryNbMagique < 0 || EntryNbMagique > 20 ) {
                    EntryNbMagique = 0;
                    return;
                } 
                if (EntryNbMagique == NbMagique) { return; }
                Life.RemoveAt(Life.Count - 1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// re-initalise leu magiques 
        /// </summary>
        protected void ReinitialiserJeu()
        {
            EntryNbMagique = 0;
            NbMagique = GenereMagicNumber();
            InitNbLife();
        }

        /// <summary>
        /// method ovveride qui va être lancé lors de l'initialisation
        /// </summary>
        protected override void OnInitialized()
        {
            ReinitialiserJeu();
            base.OnInitialized();
        }

        #endregion


        #region private method 
        /// <summary>
        /// méthode qui retourne un nombre random entre 1 & 20
        /// </summary>
        /// <returns></returns>
        private static int GenereMagicNumber()
        {
            Random random = new ();
            return random.Next(0, _nbMax); // Génère un nombre aléatoire entre 0 et 20
        }

        /// <summary>
        /// initialise le nombre de vie pour le jeux Nombre magique
        /// </summary>
        private void InitNbLife()
        {
            Life.Clear();
            for (int i = 0; i < _nbLifeDefault; i++)
            {
                Life.Add("lib/img/icons8-red-heart-48.png");
            }
        }

        #endregion
    }
}
