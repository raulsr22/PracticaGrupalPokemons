using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static ProyectoUWPenBlanco.PokemonHorsea;

namespace ProyectoUWPenBlanco
{
    public sealed partial class PokemonHorsea : UserControl, IPokemon
    {
        public PokemonHorsea()
        {
            this.InitializeComponent();
        }

        public void ActivarAniIdle(bool activar)
        {
            if (activar)
            {
                Cansado.Stop();
                Accion_de_descanso.Begin();
                Herido.Stop();
                Moviemiento_Escudo.Stop();
            }
            else
                Accion_de_descanso.Stop();
        }

        public void ActivarCansado(bool activar)
        {
            if (activar)
            {
                Accion_de_descanso.Stop();
                Cansado.Begin();
                Herido.Stop();
                Moviemiento_Escudo.Stop();
            }
            else
            {
                Cansado.Stop();
            }

        }

        public void ActivarHerido(bool activar)
        {
            if (activar)
            {

                Accion_de_descanso.Stop();
                Cansado.Stop();
                Herido.Begin();
                Moviemiento_Escudo.Stop();
            }
            else
            {

                Herido.Stop();
            }

        }

        public void ActivarEscudo(bool activar)
        {
            if (activar)
            {
                Accion_de_descanso.Stop();
                Cansado.Stop();
                Herido.Stop();


                Moviemiento_Escudo.Begin();
            }
            else
            {
                Moviemiento_Escudo.Stop();
            }

        }

        public void EjecutarAtaqueFuerte()
        {

            Accion_de_descanso.Stop();
            Cansado.Stop();
            Herido.Stop();
            Moviemiento_Escudo.Stop();
            Ataque_debil.Stop();


            Ataque_fuerte.Begin();
        }

        public void EjecutarAtaqueFlojo()
        {
            Accion_de_descanso.Stop();
            Cansado.Stop();
            Herido.Stop();
            Moviemiento_Escudo.Stop();
            Ataque_fuerte.Stop();
            Ataque_debil.Begin();
        }

        public void EjecutarDefensa()
        {
            Accion_de_descanso.Stop();
            Cansado.Stop();
            Herido.Stop();
            Moviemiento_Escudo.Stop();
            Moviemiento_Escudo.Begin();
            Ataque_debil.Stop();
            Ataque_fuerte.Stop();
        }

        public void EjecutarDescansar()
        {
            Accion_de_descanso.Begin();
            Cansado.Stop();
            Herido.Stop();
            Moviemiento_Escudo.Stop();
            Ataque_debil.Stop();
            Ataque_fuerte.Stop();
        }

        public double Vida
        {
            get { return pbHealth.Value; }
            set { pbHealth.Value = value; }
        }

        public double Energia
        {
            get { return pbEnergy.Value; }
            set { pbEnergy.Value = value; }
        }

        private async void imgRedPotion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgRedPotion.Visibility = Visibility.Collapsed;
            await IncrementarBarra(pbHealth, 100, 10);
        }

        private async void imgYellowPotion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgYellowPotion.Visibility = Visibility.Collapsed;
            await IncrementarBarra(pbEnergy, 100, 10);
        }

        private async Task IncrementarBarra(ProgressBar barra, double valorMaximo, double incremento)
        {
            while (barra.Value < valorMaximo)
            {
                barra.Value += incremento;
                await Task.Delay(100);
            }
        }


        public void verFilaVida()
        {
            pbHealth.Visibility = Visibility.Visible;
            imgCorazon.Visibility = Visibility.Visible;
            imgRedPotion.Visibility = Visibility.Visible;
        }

        public void noVerFilaVida()
        {
            pbHealth.Visibility = Visibility.Collapsed;
            imgCorazon.Visibility = Visibility.Collapsed;
            imgRedPotion.Visibility = Visibility.Collapsed;
        }
        public void verFilaEnergia()
        {
            pbEnergy.Visibility = Visibility.Visible;
            imgRayo.Visibility = Visibility.Visible;
            imgYellowPotion.Visibility = Visibility.Visible;

        }

        public void noVerFilaEnergia()
        {
            pbEnergy.Visibility = Visibility.Collapsed;
            imgRayo.Visibility = Visibility.Collapsed;
            imgYellowPotion.Visibility = Visibility.Collapsed;
        }

        public void verPocimaVida()
        {
            imgRedPotion.Visibility = Visibility.Visible;
        }

        public void noVerPocimaVida()
        {
            imgRedPotion.Visibility = Visibility.Collapsed;
        }

        public void verPocimaEnergia()
        {
            imgYellowPotion.Visibility = Visibility.Visible;
        }

        public void noVerPocimaEnergia()
        {
            imgYellowPotion.Visibility = Visibility.Collapsed;
        }

        public void verNombrePokemon()
        {
            Nombre_Pokemon.Visibility = Visibility.Visible;
        }

        public void noVerNombrePokemon()
        {
            Nombre_Pokemon.Visibility = Visibility.Collapsed;
        }

        public void PokemonMuerto()
        {
            Muerto.Begin();

        }


        internal interface IPokemon
        {

        }
    }
}