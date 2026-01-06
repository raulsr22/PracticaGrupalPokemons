
using ProyectolUWPenBlanco;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace ProyectoUWPenBlanco
{
    public sealed partial class MankeyAGM : UserControl, iPokemon
    {
        public double Vida
        {
            get { return this.ProgressBarVida.Value; }
            set { this.ProgressBarVida.Value = value; }
        }

        public double Energia
        {
            get { return this.ProgressBarEner.Value; }
            set { this.ProgressBarEner.Value = value; }
        }
        
        public string Nombre { get { return "Mankey"; } set { } }
        public string Categoría { get { return "Pokémon mono"; } set { } }
        public string Tipo { get { return "Lucha"; } set { } }
        public double Altura { get { return 0.6; } set { } }
        public double Peso { get { return 28.0; } set { } }
        public string Evolucion { get { return "Mankey evoluciona a Primeape cuando sube de nivel"; } set { } }
        public string Descripcion { get { return "Mankey es un Pokémon pequeño y agresivo que se comporta de forma impulsiva y salvaje. Tiene una gran energía y tiende a pelear con todo lo que se le acerca. Es conocido por su carácter feroz y temperamental."; } set { } }

        public MankeyAGM()
        {
            this.InitializeComponent();
           
        }

        public async void animacionAtaqueFuerte()
        {
            AnimacionAtaqueFuerteMankey.Begin();

            double nuevaEnergia = ProgressBarEner.Value - 20;
            if (nuevaEnergia < 0) nuevaEnergia = 0;
            ProgressBarEner.Value = nuevaEnergia;



            //  Mostrar golpe fuerte visual
            Canvas.SetLeft(EfectoGolpe2, 440);
            Canvas.SetTop(EfectoGolpe2, 230);
            EfectoGolpe2.Width = 100;
            EfectoGolpe2.Height = 100;
            EfectoGolpe2.Visibility = Visibility.Visible;

            // Vibración rápida
            for (int i = 0; i < 2; i++)
            {
                Contenedor_Mankey.RenderTransformOrigin = new Point(0.5, 0.5);
                ((TranslateTransform)((TransformGroup)Contenedor_Mankey.RenderTransform).Children[3]).X += 4;
                await Task.Delay(50);
                ((TranslateTransform)((TransformGroup)Contenedor_Mankey.RenderTransform).Children[3]).X -= 4;
                await Task.Delay(50);
            }

            await Task.Delay(300);
            EfectoGolpe2.Visibility = Visibility.Collapsed;
        }

        public async void animacionAtaqueFlojo()
        {
            AnimacionAtaqueFlojoMankey.Begin();

            // Reducir energía
            double nuevaEnergia = ProgressBarEner.Value - 5;
            if (nuevaEnergia < 0) nuevaEnergia = 0;
            ProgressBarEner.Value = nuevaEnergia;

            // Comprobar fatiga/sudor y KO

            // Mostrar golpe visual
            EfectoGolpe.Visibility = Visibility.Visible;
            await Task.Delay(200);
            EfectoGolpe.Visibility = Visibility.Collapsed;
        }

        public async void animacionDefensa()
        {
            Escudo_Mankey.Visibility = Visibility.Visible;
            AnimacionDefensaMankey.Begin();
            await Task.Delay(1500);
            Escudo_Mankey.Visibility = Visibility.Collapsed;
        }
        
        public async void animacionDescansar()
        {
            IconoZzz.Visibility = Visibility.Visible;
            AnimacionDescansarMankey.Begin();

            int pasos = 8;
            int intervalo = 500;

            for (int i = 0; i < pasos; i++)
            {
                if (ProgressBarEner.Value < 100)
                    ProgressBarEner.Value += 3;
                if (ProgressBarVida.Value < 100)
                    ProgressBarVida.Value += 3;

                await Task.Delay(intervalo);
            }

            IconoZzz.Visibility = Visibility.Collapsed;

        }

        public void activarAniIdle(bool activar)
        {
            if (activar)
            {
                AnimacionIdleMankey.Begin();
            }
            else
            {
                AnimacionIdleMankey.Stop();
                // Asegurar que la posición vuelva a neutro
                ((TranslateTransform)((TransformGroup)Contenedor_Mankey.RenderTransform).Children[3]).Y = 0;
            }
        }

        
        public void animacionHerido()
        {
            Herida_Mankey.Visibility = Visibility.Visible;
        }

      
        public void animacionNoHerido()
        {
            Herida_Mankey.Visibility = Visibility.Collapsed;
        }

        
        public void animacionCansado()
        {
            Sudor_Mankey.Visibility = Visibility.Visible;
        }

        
        public void animacionNoCansado()
        {
            Sudor_Mankey.Visibility = Visibility.Collapsed;
        }

        public void animacionDerrota()
        {
            // Muestra la animación de KO y ojos de KO
            ko.Visibility = Visibility.Visible;
            OjosKO_Mankey.Visibility = Visibility.Visible;

            // Colapsa las animaciones de herido y sudor
            Herida_Mankey.Visibility = Visibility.Collapsed;
            Sudor_Mankey.Visibility = Visibility.Collapsed;
        }

        

        public void verFondo(bool ver)
        {
            Fondo_mankey.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaVida(bool ver)
        {
            ProgressBarVida.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaEnergia(bool ver)
        {
            ProgressBarEner.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionVida(bool ver)
        {
            pocimaVida.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            pocimaEnergia.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verNombre(bool ver)
        {
            NombreMankey.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verEscudo(bool ver)
        {
            Escudo_Mankey.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void animacionDescasar()
        {
            throw new NotImplementedException();
        }
    }
}