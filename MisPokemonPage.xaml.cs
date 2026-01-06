using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.ViewManagement;

namespace ProyectoUWPenBlanco
{
    public sealed partial class MisPokemonPage : Page
    {
        public MisPokemonPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            double width = e.Size.Width;

            if (width < 800)
            {
                // Vertical layout
                AjustarVertical(ucGengar, txtNombreGengar, txtTipoGengar, txtDescGengar);
                AjustarVertical(ucGardevoir, txtNombreGardevoir, txtTipoGardevoir, txtDescGardevoir);
                AjustarVertical(ucBulbasaur, txtNombreBulbasaur, txtTipoBulbasaur, txtDescBulbasaur);
                AjustarVertical(ucCorphish, txtNombreCorphish, txtTipoCorphish, txtDescCorphish);
                AjustarVertical(ucMankey, txtNombreMankey, txtTipoMankey, txtDescMankey);
                AjustarVertical(ucOshawott, txtNombreOshawott, txtTipoOshawott, txtDescOshawott);
                AjustarVertical(ucPachirisu, txtNombrePachirisu, txtTipoPachirisu, txtDescPachirisu);
                AjustarVertical(ucPichu, txtNombrePichu, txtTipoPichu, txtDescPichu);
                AjustarVertical(ucPorygon2, txtNombrePorygon2, txtTipoPorygon2, txtDescPorygon2);
                AjustarVertical(ucRegice, txtNombreRegice, txtTipoRegice, txtDescRegice);
                AjustarVertical(ucSwablu, txtNombreSwablu, txtTipoSwablu, txtDescSwablu);
                AjustarVertical(ucPsyduck, txtNombrePsyduck, txtTipoPsyduck, txtDescPsyduck);
                AjustarVertical(ucVictini, txtNombreVictini, txtTipoVictini, txtDescVictini);
                AjustarVertical(ucWartortle, txtNombreWartortle, txtTipoWartortle, txtDescWartortle);
                AjustarVertical(ucHorsea, txtNombreHorsea, txtTipoHorsea, txtDescHorsea);
            }
            else
            {
                // Horizontal layout
                AjustarHorizontal(ucGengar, txtNombreGengar, txtTipoGengar, txtDescGengar);
                AjustarHorizontal(ucGardevoir, txtNombreGardevoir, txtTipoGardevoir, txtDescGardevoir);
                AjustarHorizontal(ucBulbasaur, txtNombreBulbasaur, txtTipoBulbasaur, txtDescBulbasaur);
                AjustarHorizontal(ucCorphish, txtNombreCorphish, txtTipoCorphish, txtDescCorphish);
                AjustarHorizontal(ucMankey, txtNombreMankey, txtTipoMankey, txtDescMankey);
                AjustarHorizontal(ucOshawott, txtNombreOshawott, txtTipoOshawott, txtDescOshawott);
                AjustarHorizontal(ucPachirisu, txtNombrePachirisu, txtTipoPachirisu, txtDescPachirisu);
                AjustarHorizontal(ucPichu, txtNombrePichu, txtTipoPichu, txtDescPichu);
                AjustarHorizontal(ucPorygon2, txtNombrePorygon2, txtTipoPorygon2, txtDescPorygon2);
                AjustarHorizontal(ucRegice, txtNombreRegice, txtTipoRegice, txtDescRegice);
                AjustarHorizontal(ucSwablu, txtNombreSwablu, txtTipoSwablu, txtDescSwablu);
                AjustarHorizontal(ucPsyduck, txtNombrePsyduck, txtTipoPsyduck, txtDescPsyduck);
                AjustarHorizontal(ucVictini, txtNombreVictini, txtTipoVictini, txtDescVictini);
                AjustarHorizontal(ucWartortle, txtNombreWartortle, txtTipoWartortle, txtDescWartortle);
                AjustarHorizontal(ucHorsea, txtNombreHorsea, txtTipoHorsea, txtDescHorsea);
            }
        }

        private void AjustarVertical(FrameworkElement imagen, FrameworkElement nombre, FrameworkElement tipo, FrameworkElement desc)
        {
            RelativePanel.SetRightOf(nombre, null);
            RelativePanel.SetBelow(nombre, imagen);
            RelativePanel.SetBelow(tipo, nombre);
            RelativePanel.SetBelow(desc, tipo);
        }

        private void AjustarHorizontal(FrameworkElement imagen, FrameworkElement nombre, FrameworkElement tipo, FrameworkElement desc)
        {
            RelativePanel.SetBelow(nombre, null);
            RelativePanel.SetRightOf(nombre, imagen);
            RelativePanel.SetRightOf(tipo, imagen);
            RelativePanel.SetRightOf(desc, imagen);
            RelativePanel.SetBelow(tipo, nombre);
            RelativePanel.SetBelow(desc, tipo);
        }

    }
}
