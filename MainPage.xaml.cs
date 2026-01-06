using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;
using Windows.UI.Notifications;
           


namespace ProyectoUWPenBlanco
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            fmMain.Navigate(typeof(InicioPage));


            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += OpcionVolver;

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

            // Tile pequeño con 2 líneas
            var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text02);
            var tileTextAttributes = tileXml.GetElementsByTagName("text");
            tileTextAttributes[0].InnerText = "IPOkemon";
            tileTextAttributes[1].InnerText = "IPO2";

            // Tile ancho con 1 línea
            var wideTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150Text03);
            var wideTextAttributes = wideTileXml.GetElementsByTagName("text");
            wideTextAttributes[0].InnerText = "Una app sobre Pokémon hecha con UWP";

            // Tile grande con 3 líneas
            var largeTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare310x310TextList03);
            var largeTextAttributes = largeTileXml.GetElementsByTagName("text");
            largeTextAttributes[0].InnerText = "IPOkemon";
            largeTextAttributes[1].InnerText = "Un Proyecto de IPO2";
            largeTextAttributes[2].InnerText = "Tecnología UWP";

            // Fusionar los tres tamaños en uno
            var visual = tileXml.GetElementsByTagName("visual").Item(0);
            var wideNode = tileXml.ImportNode(wideTileXml.GetElementsByTagName("binding").Item(0), true);
            var largeNode = tileXml.ImportNode(largeTileXml.GetElementsByTagName("binding").Item(0), true);
            visual.AppendChild(wideNode);
            visual.AppendChild(largeNode);

            // Crear la notificación final
            var tileNotification = new TileNotification(tileXml);
            tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddMinutes(1);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);


        }

        private void OpcionVolver(object sender, BackRequestedEventArgs e)
        {
            if (fmMain.CanGoBack)
            {
                fmMain.GoBack();
                e.Handled = true;
            }
        }

        private void MainPage_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            var width = ApplicationView.GetForCurrentView().VisibleBounds.Width;

            if (width >= 720)
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactInline;
                sView.IsPaneOpen = true;
            }
            else if (width >= 360)
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                sView.IsPaneOpen = false;
            }
            else
            {
                sView.DisplayMode = SplitViewDisplayMode.Overlay;
                sView.IsPaneOpen = false;
            }
        }

        private void ToggleMenu(object sender, RoutedEventArgs e)
        {
            sView.IsPaneOpen = !sView.IsPaneOpen;
        }

        private void irInicio(object sender, RoutedEventArgs e) => fmMain.Navigate(typeof(InicioPage));
        private void irAmispokemon(object sender, RoutedEventArgs e) => fmMain.Navigate(typeof(MisPokemonPage));
        private void irPokeDex(object sender, RoutedEventArgs e) => fmMain.Navigate(typeof(PokedexPage));
        private void irCombate(object sender, RoutedEventArgs e) => fmMain.Navigate(typeof(ModoCombatePage));
        private void irAcercaDe(object sender, RoutedEventArgs e) => fmMain.Navigate(typeof(AcercaDePage));
    }
}
