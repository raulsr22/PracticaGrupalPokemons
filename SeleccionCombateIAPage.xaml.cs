using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238


namespace ProyectoUWPenBlanco
{
    public sealed partial class SeleccionCombateIAPage : Page
    {
        public List<Pokemon> ListaJugador1 { get; set; }
        public List<Pokemon> ListaJugador2 { get; set; }

        private Pokemon pokemonJugador;
        private Pokemon pokemonIA;
        private Random rnd = new Random();

        public SeleccionCombateIAPage()
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
            pokemonJugador = e.ClickedItem as Pokemon;
            gvJugador1.SelectedItem = pokemonJugador;

            // La máquina elige aleatoriamente
            pokemonIA = ListaJugador2[rnd.Next(ListaJugador2.Count)];

            btnComenzar.IsEnabled = pokemonJugador != null;
        }

        private void btnComenzar_Click(object sender, RoutedEventArgs e)
        {
            var seleccionados = new List<UserControl>();

            var uc1 = CrearUserControlPorNombre(pokemonJugador?.Nombre);
            var uc2 = CrearUserControlPorNombre(pokemonIA?.Nombre);

            if (uc1 != null && uc2 != null)
            {
                seleccionados.Add(uc1);
                seleccionados.Add(uc2);
                Frame.Navigate(typeof(CombatePage), Tuple.Create(seleccionados, true));
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

    }
}


