
using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace ProyectoUWPenBlanco
{
    public sealed partial class BulbasaurRH : UserControl 

    {
        DispatcherTimer dtTime; 
        private bool estaHerido = false;
        private bool estaCansado = false;
        private bool estaDerrotado = false;


        public BulbasaurRH()
        {
            this.InitializeComponent();
            this.Loaded += Page_Loaded;
            this.KeyDown += ControlTeclas;
            this.IsTabStop = true;

        }

        public double Vida
        {
            get => pbHealth.Value;
            set => pbHealth.Value = value;
        }

        public double Energia
        {
            get => pbEnergy.Value;
            set => pbEnergy.Value = value;
        }

        public string Nombre
        {
            get => pokemonNombre.Text;
            set => pokemonNombre.Text = value;
        }

        public string Categoría { get; set; }
        public string Tipo { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Evolucion { get; set; }
        public string Descripcion { get; set; }

        public void verFondo(bool ver)
        {
            imFondo.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaVida(bool ver)
        {
            pbHealth.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verFilaEnergia(bool ver)
        {
            pbEnergy.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionVida(bool ver)
        {
            imgPotionRed.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verPocionEnergia(bool ver)
        {
            imgPotionYellow.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verNombre(bool ver)
        {
            pokemonNombre.Visibility = ver ? Visibility.Visible : Visibility.Collapsed;
        }

        public void verEscudo(bool ver)
        {

        }


        public void activarAniIdle(bool activar)
        {
            var sb = this.FindName("animacion") as Storyboard;
            if (sb != null)
            {
                if (activar) sb.Begin();
                else sb.Stop();
            }
        }

        public void animacionAtaqueFlojo()
        {
            EjecutarAtaqueDebil();
        }

        public void animacionAtaqueFuerte()
        {
            EjecutarAtaqueFuerte();
        }

        public void animacionDefensa()
        {
            Escudo();
        }

        public void animacionDescasar()
        {
            IniciarAnimacionDescanso(true);
        }

        public void animacionCansado()
        {
            AnimarCansado();
        }

        public void animacionNoCansado()
        {
            AnimarRecuperarEnergia();
        }

        public void animacionHerido()
        {
            AnimarHerido();
        }

        public void animacionNoHerido()
        {
            AnimarCurarHerida();
        }

        public void animacionDerrota()
        {
            AnimarDerrotado();
        }


        public void UsePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += IncreaseHealth;
            dtTime.Start();
            imgPotionRed.Visibility = Visibility.Collapsed;

            IniciarAnimacionDescanso(false); 
        }


        public void UsePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += IncreaseEnergy;
            dtTime.Start();
            imgPotionYellow.Visibility = Visibility.Collapsed;

            IniciarAnimacionDescanso(false); 
        }




        public void IncreaseHealth(object sender, object e)
        {
            if (pbHealth.Value < 100) 
            {
                pbHealth.Value += 2;
                ReproducirSonido("Curación.mp3");
            }

            if (pbHealth.Value >= 100)
            {
                pbHealth.Value = 100; 

                if (dtTime != null)
                {
                    dtTime.Stop();
                    dtTime = null;
                }

                DetenerAnimacionDescanso();
            }

            estaHerido = false;
            estaCansado = false;
        }




        public void IncreaseEnergy(object sender, object e)
        {
            if (pbEnergy.Value < 100) 
            {
                pbEnergy.Value += 2;
                ReproducirSonido("Curación.mp3");
            }

            if (pbEnergy.Value >= 100)
            {
                pbEnergy.Value = 100; 

                if (dtTime != null)
                {
                    dtTime.Stop();
                    dtTime = null;
                }

                DetenerAnimacionDescanso();
            }


            estaHerido = false;
            estaCansado = false;
        }
        private bool descansoPorTecla = false; 

        private void IniciarAnimacionDescanso(bool activadoPorTecla)
        {
            descansoPorTecla = activadoPorTecla;
            if (estaDerrotado) return;

            Storyboard sb = this.FindName("Descanso") as Storyboard;
            if (sb != null)
            {
                sb.Stop();
                ReproducirSonido("Bostezo.mp3");
                sb.Begin();
                Debug.WriteLine("🎬 Animación de Descanso activada.");
            }
            else
            {
                Debug.WriteLine("⚠️ Storyboard 'Descanso' no encontrado.");
            }

            if (descansoPorTecla)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(4); 
                timer.Tick += (s, args) =>
                {
                    timer.Stop(); 
                    ActivarRecuperarDescanso(); 
                };
                timer.Start();
            }
        }


        private async void ActivarRecuperarDescanso()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Storyboard sb = this.FindName("QuitarAnimacionDescanso") as Storyboard;
                if (sb != null)
                {
                    sb.Stop();
                    sb.Begin();
                    Debug.WriteLine("✨ Se ha activado la animación de RecuperarDescanso.");
                }
                else
                {
                    Debug.WriteLine("⚠️ Storyboard 'RecuperarDescanso' no encontrado.");
                }
            });
        }




        public async void DetenerAnimacionDescanso()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Storyboard sb = this.FindName("Descanso") as Storyboard;
                if (sb != null)
                {
                    sb.Stop(); 
                }
            });

            estaHerido = false;
            estaCansado = false;
        }

        public async void AnimarHerido()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Storyboard sb = this.FindName("Herido") as Storyboard;
                if (sb != null)
                {
                    ReproducirSonido("Herido.mp3");
                    sb.Stop(); 
                    sb.Begin();
                }
            });
        }



        public async void AnimarDerrotado()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
         
                Storyboard sbHerido = this.FindName("Herido") as Storyboard;
                if (sbHerido != null)
                {
                    sbHerido.Stop();
                }


                Storyboard sbDerrotado = this.FindName("Derrotado") as Storyboard;
                if (sbDerrotado != null)
                {
                    ReproducirSonido("Derrota.mp3");
                    sbDerrotado.Stop(); 
                    sbDerrotado.Begin();
                }
            });
        }

        public void pbHealth_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (pbHealth.Value == 0)
            {
                if (!estaDerrotado)
                {
                    estaDerrotado = true;
                    AnimarDerrotado();
                }
                return; 
            }

            if (estaDerrotado && pbHealth.Value > 0)
            {
                estaDerrotado = false;
                ResetearEstado();
                return;
            }

            if (pbHealth.Value <= 30)
            {
                if (!estaHerido)
                {
                    estaHerido = true;
                    AnimarHerido();
                }
            }
            else if (pbHealth.Value > 30 && estaHerido)
            {
                estaHerido = false;
                AnimarCurarHerida();
            }

            if (pbHealth.Value > 100)
            {
                pbHealth.Value = 100;
            }
        }




        public async void AnimarCurarHerida()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Storyboard sb = this.FindName("CurarHerida") as Storyboard;
                if (sb != null)
                {
                    sb.Stop();
                    sb.Begin();
                    Debug.WriteLine("✨ Pokémon se ha curado de herida.");
                }
                else
                {
                    Debug.WriteLine("⚠️ Storyboard 'CurarHerida' no encontrado");
                }
            });
        }


        public async void AnimarRecuperarEnergia()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Storyboard sb = this.FindName("RecuperarEnergia") as Storyboard;
                if (sb != null)
                {
                    sb.Stop();
                    sb.Begin();
                    Debug.WriteLine("⚡ Pokémon ha recuperado energía.");
                }
                else
                {
                    Debug.WriteLine("⚠️ Storyboard 'RecuperarEnergia' no encontrado");
                }
            });
        }

        public void pbEnergy_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (pbEnergy.Value >= 100)
            {
                pbEnergy.Value = 100; 
                ResetearEstado(); 
            }

            if (pbEnergy.Value <= 30)
            {
                if (!estaCansado)
                {
                    AnimarCansado();
                    estaCansado = true;
                }
            }
            else if (pbEnergy.Value > 30 && estaCansado)
            {
                AnimarRecuperarEnergia();
                estaCansado = false;
            }
        }

        public async void AnimarCansado()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Storyboard sb = this.FindName("Cansado") as Storyboard;
                if (sb != null)
                {
                    ReproducirSonido("Cansado.mp3");
                    sb.Stop();
                    sb.Begin();
                }
            });
        }



        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.FindName("animacion") as Storyboard;
            if (sb != null)
            {
                sb.Begin();
            }
        }


        public void ControlTeclas(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1:
                    EjecutarAtaqueDebil();
                    break;
                case Windows.System.VirtualKey.Number2:
                    EjecutarAtaqueFuerte();
                    break;
                case Windows.System.VirtualKey.Number3:
                    Escudo();
                    break;
                case Windows.System.VirtualKey.Number4: 
                    IniciarAnimacionDescanso(true);
                    break;
                case Windows.System.VirtualKey.Number5:
                    AnimarHerido();
                    break;
                case Windows.System.VirtualKey.Number6:
                    AnimarCansado();
                    break;
                case Windows.System.VirtualKey.Number7:
                    AnimarDerrotado();
                    break;
            }
        }



        public void EjecutarAtaqueFuerte()
        {
            
            Storyboard sb = this.FindName("AtaqueFuerte1") as Storyboard;
            if (sb != null)
            {
                
                sb.Stop();

                
                sb.Begin();

                
                ReproducirSonido("bulbasaur.mp3");

                
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1.5); 
                timer.Tick += (s, args) =>
                {
                    timer.Stop(); 
                    ReproducirSonido("Golpe.mp3"); 
                };
                timer.Start();
            }
            else
            {
                
                Debug.WriteLine("No se encontró el Storyboard 'AtaqueFuerte1'.");
            }
        }


        public Windows.Media.Playback.MediaPlayer mpSonidos = new Windows.Media.Playback.MediaPlayer();

        public void EjecutarAtaqueDebil()
        {
            Storyboard sb = this.FindName("AtaqueDebil") as Storyboard;
            if (sb != null)
            {
                ReproducirSonido("latigo.mp3");
                sb.Stop();
                sb.Begin();
            }
        }


        public void ReproducirSonido(string nombreArchivo)
        {
            mpSonidos.Source = Windows.Media.Core.MediaSource.CreateFromUri(new Uri($"ms-appx:///Assets/{nombreArchivo}"));
            mpSonidos.Play();
        }

        public void Escudo()
        {
            Storyboard sb = this.FindName("ActivarEscudo") as Storyboard;
            if (sb != null)
            {
                ReproducirSonido("Escudo.mp3");
                sb.Stop();
                sb.Begin();
            }
        }

        public void ResetearEstado()
        {
            if (estaDerrotado) return;

            
            Debug.WriteLine("🔄 Resetando el estado del Pokémon...");

            Storyboard sbHerido = this.FindName("Herido") as Storyboard;
            Storyboard sbCansado = this.FindName("Cansado") as Storyboard;
            Storyboard sbDescanso = this.FindName("Descanso") as Storyboard;
            Storyboard sbDerrotado = this.FindName("Derrotado") as Storyboard;
            Storyboard sbIdle = this.FindName("animacion") as Storyboard; 

            if (sbHerido != null) sbHerido.Stop();
            if (sbCansado != null) sbCansado.Stop();
            if (sbDescanso != null) sbDescanso.Stop();
            if (sbDerrotado != null) sbDerrotado.Stop();


            estaHerido = false;
            estaCansado = false;

            if (dtTime != null)
            {
                dtTime.Stop();
                dtTime = null;
            }


            this.Focus(FocusState.Programmatic);


            if (sbIdle != null)
            {
                sbIdle.Stop();
                sbIdle.Begin();
                Debug.WriteLine("🔄 El Pokémon ha vuelto a su estado inicial.");
            }
            else
            {
                Debug.WriteLine("⚠️ No se encontró la animación inicial.");
            }
        }





    }
}
