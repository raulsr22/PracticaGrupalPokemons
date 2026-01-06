// CombatePage.xaml.cs - recibe UserControls seleccionados y ejecuta animaciones
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoUWPenBlanco
{
    public sealed partial class CombatePage : Page
    {
        private int vida1 = 100;
        private int vida2 = 100;
        private int energia1 = 100;
        private int energia2 = 100;
        private bool defiende1 = false;
        private bool defiende2 = false;
        private bool contraIA = false;
        private Random rnd = new Random();

        private dynamic pokemon1;
        private dynamic pokemon2;

        public CombatePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Tuple<List<UserControl>, bool> datos)
            {
                var seleccionados = datos.Item1;
                contraIA = datos.Item2;

                pokemon1 = seleccionados[0];
                pokemon2 = seleccionados[1];

                contenedor1.Content = pokemon1;
                contenedor2.Content = pokemon2;

                txtNombre1.Text = pokemon1.GetType().Name;
                txtNombre2.Text = pokemon2.GetType().Name;

                vida1 = vida2 = 100;
                energia1 = energia2 = 100;
                defiende1 = defiende2 = false;

                barraVida1.Value = barraVida2.Value = 100;
                barraEnergia1.Value = barraEnergia2.Value = 100;

                pokemon1.activarAniIdle(true);
                pokemon2.activarAniIdle(true);

                txtNarrador.Text = "¡El combate está por comenzar!";
            }
        }

        private async void EjecutarTurnoIA()
        {
            await Task.Delay(1000);
            int decision = rnd.Next(0, 3);
            switch (decision)
            {
                case 0: Atacar_Click_J2(null, null); break;
                case 1: Especial_Click_J2(null, null); break;
                case 2: Descansar_Click_J2(null, null); break;
            }
        }

        private void Atacar_Click_J1(object sender, RoutedEventArgs e)
        {
            if (energia1 < 10)
            {
                txtNarrador.Text = $"{txtNombre1.Text} no tiene suficiente energía para atacar.";
                return;
            }

            energia1 -= 10;
            barraEnergia1.Value = energia1;

            if (defiende2)
            {
                txtNarrador.Text = $"{txtNombre2.Text} bloqueó el ataque de {txtNombre1.Text}!";
            }
            else
            {
                int daño = rnd.Next(10, 20);
                vida2 = Math.Max(0, vida2 - daño);
                barraVida2.Value = vida2;
                txtNarrador.Text = $"{txtNombre1.Text} usó Ataque Flojo e hizo {daño} de daño.";
            }

            pokemon1.animacionAtaqueFlojo();
            defiende2 = false;
            VerificarGanador();
            if (contraIA && vida2 > 0) EjecutarTurnoIA();
        }

        private void Especial_Click_J1(object sender, RoutedEventArgs e)
        {
            if (energia1 < 25)
            {
                txtNarrador.Text = $"{txtNombre1.Text} no tiene suficiente energía para ataque especial.";
                return;
            }

            energia1 -= 25;
            barraEnergia1.Value = energia1;

            if (defiende2)
            {
                txtNarrador.Text = $"{txtNombre2.Text} bloqueó el ataque especial de {txtNombre1.Text}!";
            }
            else
            {
                int daño = rnd.Next(20, 35);
                vida2 = Math.Max(0, vida2 - daño);
                barraVida2.Value = vida2;
                txtNarrador.Text = $"{txtNombre1.Text} lanzó un Ataque Especial e hizo {daño} de daño.";
            }

            pokemon1.animacionAtaqueFuerte();
            defiende2 = false;
            VerificarGanador();
            if (contraIA && vida2 > 0) EjecutarTurnoIA();
        }

        private void Descansar_Click_J1(object sender, RoutedEventArgs e)
        {
            energia1 = Math.Min(100, energia1 + 30);
            barraEnergia1.Value = energia1;

            vida1 = Math.Min(100, vida1 + 10);
            barraVida1.Value = vida1;

            pokemon1.animacionDescasar();
            defiende1 = false;
            txtNarrador.Text = $"{txtNombre1.Text} está descansando y recuperó energía y algo de vida.";
            if (contraIA && vida2 > 0) EjecutarTurnoIA();
        }

        private void Descansar_Click_J2(object sender, RoutedEventArgs e)
        {
            energia2 = Math.Min(100, energia2 + 30);
            barraEnergia2.Value = energia2;

            vida2 = Math.Min(100, vida2 + 10);
            barraVida2.Value = vida2;

            pokemon2.animacionDescasar();
            defiende2 = false;
            txtNarrador.Text = $"{txtNombre2.Text} está descansando y recuperó energía y algo de vida.";
        }

        private void Atacar_Click_J2(object sender, RoutedEventArgs e)
        {
            if (energia2 < 10)
            {
                txtNarrador.Text = $"{txtNombre2.Text} no tiene suficiente energía para atacar.";
                return;
            }

            energia2 -= 10;
            barraEnergia2.Value = energia2;

            if (defiende1)
            {
                txtNarrador.Text = $"{txtNombre1.Text} bloqueó el ataque de {txtNombre2.Text}!";
            }
            else
            {
                int daño = rnd.Next(10, 20);
                vida1 = Math.Max(0, vida1 - daño);
                barraVida1.Value = vida1;
                txtNarrador.Text = $"{txtNombre2.Text} usó Ataque Flojo e hizo {daño} de daño.";
            }

            pokemon2.animacionAtaqueFlojo();
            defiende1 = false;
            VerificarGanador();
        }

        private void Especial_Click_J2(object sender, RoutedEventArgs e)
        {
            if (energia2 < 25)
            {
                txtNarrador.Text = $"{txtNombre2.Text} no tiene suficiente energía para ataque especial.";
                return;
            }

            energia2 -= 25;
            barraEnergia2.Value = energia2;

            if (defiende1)
            {
                txtNarrador.Text = $"{txtNombre1.Text} bloqueó el ataque especial de {txtNombre2.Text}!";
            }
            else
            {
                int daño = rnd.Next(20, 35);
                vida1 = Math.Max(0, vida1 - daño);
                barraVida1.Value = vida1;
                txtNarrador.Text = $"{txtNombre2.Text} lanzó un Ataque Especial e hizo {daño} de daño.";
            }

            pokemon2.animacionAtaqueFuerte();
            defiende1 = false;
            VerificarGanador();
        }

        private void Idle_Click_J1(object sender, RoutedEventArgs e)
        {
            pokemon1.activarAniIdle(true);
            defiende1 = false;
            txtNarrador.Text = $"{txtNombre1.Text} está en posición de espera.";
        }

        private void Idle_Click_J2(object sender, RoutedEventArgs e)
        {
            pokemon2.activarAniIdle(true);
            defiende2 = false;
            txtNarrador.Text = $"{txtNombre2.Text} está en posición de espera.";
        }

        private void Defensa_Click_J1(object sender, RoutedEventArgs e)
        {
            pokemon1.animacionDefensa();
            defiende1 = true;
            txtNarrador.Text = $"{txtNombre1.Text} se está defendiendo.";
        }

        private void Defensa_Click_J2(object sender, RoutedEventArgs e)
        {
            pokemon2.animacionDefensa();
            defiende2 = true;
            txtNarrador.Text = $"{txtNombre2.Text} se está defendiendo.";
        }

        private void VerificarGanador()
        {
            if (vida1 == 0)
            {
                pokemon1.animacionDerrota();
                pokemon1.activarAniIdle(false);
                txtNarrador.Text = "¡Jugador 2 gana el combate!";
                MostrarMensaje("¡Jugador 2 gana!");
            }
            else if (vida2 == 0)
            {
                pokemon2.animacionDerrota();
                pokemon2.activarAniIdle(false);
                txtNarrador.Text = "¡Jugador 1 gana el combate!";
                MostrarMensaje("¡Jugador 1 gana!");
            }
        }

        private async void MostrarMensaje(string mensaje)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Fin del combate",
                Content = mensaje,
                CloseButtonText = "Aceptar"
            };
            await dialog.ShowAsync();
        }
    }
}
