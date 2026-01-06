using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ProyectoUWPenBlanco
{
    public sealed partial class SeleccionCombatePage : Page
    {
        public List<Pokemon> ListaJugador1 { get; set; }
        public List<Pokemon> ListaJugador2 { get; set; }

        private Pokemon pokemonJugador1;
        private Pokemon pokemonJugador2;

        public SeleccionCombatePage()
        {
            this.InitializeComponent();

            ListaJugador1 = new List<Pokemon>
            {
                new Pokemon { Nombre = "Regice", Imagen = "AssetsGrupal/Regice.png" },
                new Pokemon { Nombre = "Wartortle", Imagen = "AssetsGrupal/Wartortle.png" },
                new Pokemon { Nombre = "ManKey", Imagen = "AssetsGrupal/mankey.png" },
                new Pokemon { Nombre = "Gardevoir", Imagen = "AssetsGrupal/Gardevoir.png" }
            };

            ListaJugador2 = new List<Pokemon>
            {
                new Pokemon { Nombre = "Bulbasaur", Imagen = "AssetsGrupal/bulbasaur.png" },
                new Pokemon { Nombre = "Corphish", Imagen = "AssetsGrupal/Corphish.png" },
                new Pokemon { Nombre = "Gengar", Imagen = "AssetsGrupal/Gengar2.png" },
                new Pokemon { Nombre = "Oshawott", Imagen = "AssetsGrupal/Oshawott.png" },
                new Pokemon { Nombre = "Pachirisu", Imagen = "AssetsGrupal/Pachirisu.png" },
                new Pokemon { Nombre = "Pichu", Imagen = "AssetsGrupal/Pichu.png" },
                new Pokemon { Nombre = "Psyduck", Imagen = "AssetsGrupal/Psyduck.png" },
                new Pokemon { Nombre = "Victini", Imagen = "AssetsGrupal/Victini.png" },
                new Pokemon { Nombre = "Porygon2", Imagen = "AssetsGrupal/porygon2.jpg" },
                new Pokemon { Nombre = "Swablu", Imagen = "AssetsGrupal/Swablu.png" }

            };

            this.DataContext = this;
        }

        private void SeleccionJugador1_Click(object sender, ItemClickEventArgs e)
        {
            pokemonJugador1 = e.ClickedItem as Pokemon;
            gvJugador1.SelectedItem = pokemonJugador1;
            ActualizarBotonComenzar();
        }

        private void SeleccionJugador2_Click(object sender, ItemClickEventArgs e)
        {
            pokemonJugador2 = e.ClickedItem as Pokemon;
            gvJugador2.SelectedItem = pokemonJugador2;
            ActualizarBotonComenzar();
        }


        private void ActualizarBotonComenzar()
        {
            btnComenzar.IsEnabled = pokemonJugador1 != null && pokemonJugador2 != null;
        }

        private void btnComenzar_Click(object sender, RoutedEventArgs e)
        {
            var seleccionados = new List<UserControl>();

            var uc1 = CrearUserControlPorNombre(pokemonJugador1?.Nombre);
            var uc2 = CrearUserControlPorNombre(pokemonJugador2?.Nombre);

            if (uc1 != null && uc2 != null)
            {
                seleccionados.Add(uc1);
                seleccionados.Add(uc2);
                Frame.Navigate(typeof(CombatePage), Tuple.Create(seleccionados, false));
            }
        }

        private UserControl CrearUserControlPorNombre(string nombre)
        {
            switch (nombre.ToLower())
            {
                case "bulbasaur": return new BulbasaurRH();
                case "corphish": return new CorphishJFV();
                case "gengar": return new GengarRSR();
                case "mankey": return new MankeyAGM();
                case "oshawott": return new OshawottHAM();
                case "pachirisu": return new PachirisuNSL();
                case "pichu": return new PichuJMG();
                case "psyduck": return new PsyduckERP();
                case "regice": return new RegiceVVG();
                case "wartortle": return new WartortleAAA();
                case "gardevoir": return new GardevoirAPM();
                case "porygon2": return new Porygon2DAR();
                case "swablu": return new SwabluSCP();
                case "victini": return new VictiniLDM();
                default: return null;
            }
        }

        // Utilidad para recorrer elementos visuales
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T t)
                        yield return t;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
    }
}
