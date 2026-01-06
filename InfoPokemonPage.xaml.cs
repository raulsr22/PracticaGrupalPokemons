using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProyectoUWPenBlanco
{
    public sealed partial class InfoPokemonPage : Page
    {
        public InfoPokemonPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var pokemon = e.Parameter as Pokemon;
            if (pokemon != null)
            {
                imgPokemon.Source = new BitmapImage(new Uri(pokemon.Imagen));
                txtNombre.Text = pokemon.Nombre;
                txtTipo.Text = $"Tipo: {pokemon.Tipo}";
                txtDesc.Text = pokemon.Descripcion;

                CambiarColorPorTipo(pokemon.Tipo);
            }
        }

        private void CambiarColorPorTipo(string tipo)
        {
            // Elegir color según el tipo principal
            string tipoPrincipal = tipo.Split('/')[0].Trim().ToLower();

            SolidColorBrush colorFondo;

            switch (tipoPrincipal)
            {
                case "agua":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 198, 237, 255)); // Azul suave
                    break;
                case "fuego":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 255, 220, 200)); // Naranja claro
                    break;
                case "planta":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 220, 255, 220)); // Verde claro
                    break;
                case "eléctrico":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 255, 255, 200)); // Amarillo pastel
                    break;
                case "fantasma":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 230, 210, 255)); // Lila suave
                    break;
                case "psíquico":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 255, 200, 240)); // Rosa claro
                    break;
                case "roca":
                case "tierra":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 240, 230, 210)); // Marrón claro
                    break;
                case "hada":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 255, 230, 240)); // Rosa pastel
                    break;
                case "normal":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 240, 240, 240)); // Gris claro
                    break;
                case "lucha":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 255, 230, 210)); // Anaranjado claro
                    break;
                case "hielo":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 220, 250, 255)); // Celeste
                    break;
                case "dragón":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 220, 240, 255)); // Azul grisáceo
                    break;
                case "veneno":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 240, 210, 255)); // Lila
                    break;
                case "volador":
                    colorFondo = new SolidColorBrush(Color.FromArgb(255, 230, 240, 255)); // Azul claro cielo
                    break;
                default:
                    colorFondo = new SolidColorBrush(Colors.White);
                    break;
            }

            borderFicha.Background = colorFondo;
        }


        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

    }
}
