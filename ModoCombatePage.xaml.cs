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
    public sealed partial class ModoCombatePage : Page
    {
        public ModoCombatePage()
        {
            this.InitializeComponent();
        }

        private void Combate1vs1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SeleccionCombatePage), "modo1vs1");
        }

        private void CombateIA_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SeleccionCombateIAPage));
        }

    }
}

