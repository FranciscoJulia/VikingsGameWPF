using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VikingsGameWPF
{
    /// <summary>
    /// Lógica de interacción para PageEscudos.xaml
    /// </summary>
    public partial class PageEscudos : Page
    {
        Item escudoMadera = new Item("Escudo de madera", 0, "Escudo de madera", 1, 10, 0, 0);
        Item escudoReforzado = new Item("Escudo reforzado", 40, "Escudo reforzado", 20, 30, 0, 0);
        Item escudoUltimum = new Item("Escudo Ultimum", 100, "Escudo Legendario", 45, 100, 0, 0);

        VikingPlayer player;

        public PageEscudos(VikingPlayer player)
        {
            InitializeComponent();
            EscudoMadera();
            this.player = player;
            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));

            EscudoActual();
        }

        private string escudoActual = "Escudo de madera";
        public void EscudoActual()
        {
            ImageBrush newImageBrush = new ImageBrush();

            if (player.EscudoMadera == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/escudoMadera.png", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
            else if (player.EscudoReforzado == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/escudoReforzado.png", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
            else if (player.EscudoUltimum == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/escudoReforzadoMejorado.png", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
        }

        public void SonidoCambiarSeleccion()
        {
            SoundPlayer sonido = new SoundPlayer("Sonidos/CambiarSeleccion.wav");
            sonido.Play();
        }
        public void SonidoClickNo()
        {
            SoundPlayer sonido = new SoundPlayer("Sonidos/clickBotones.wav");
            sonido.Play();
        }
        public void SonidoClickSi()
        {
            SoundPlayer sonido = new SoundPlayer("Sonidos/ClickSi.wav");
            sonido.Play();
        }

        public void EscudoMadera()
        {
            lblNombreEscudo.Content = escudoMadera.Nombre;
            lblPrecio.Content = $"- {escudoMadera.Precio} x Día";
            lblExp.Content = $"+ {escudoMadera.XP} x Día";
            lblPoder.Content = $"+ {escudoMadera.Poder}";
            MostrarElementos();
            rImgEscudoMadera.StrokeThickness = 3;
            rImgEscudoReforzado.StrokeThickness = 1;
            rImgEscudoUltimum.StrokeThickness = 1;
        }


        public void MostrarElementos()
        {
            btnUsar.Visibility = Visibility.Visible;
            lblNombreEscudo.Visibility = Visibility.Visible;
            labelPrecio.Visibility = Visibility.Visible;
            lblPrecio.Visibility = Visibility.Visible;
        }

        private void rImgEscudoMadera_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreEscudo.Content.ToString() != escudoMadera.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            escudoActual = escudoMadera.Nombre;
            EscudoMadera();
        }

        private void rImgEscudoReforzado_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreEscudo.Content.ToString() != escudoReforzado.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            escudoActual = escudoReforzado.Nombre;

            lblNombreEscudo.Content = escudoReforzado.Nombre;
            lblPrecio.Content = $"- {escudoReforzado.Precio} x Día";
            lblExp.Content = $"+ {escudoReforzado.XP} x Día";
            lblPoder.Content = $"+ {escudoReforzado.Poder}";
            MostrarElementos();
            rImgEscudoMadera.StrokeThickness = 1;
            rImgEscudoReforzado.StrokeThickness = 3;
            rImgEscudoUltimum.StrokeThickness = 1;
        }

        private void rImgEscudoUltimum_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreEscudo.Content.ToString() != escudoUltimum.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            escudoActual = escudoUltimum.Nombre;

            lblNombreEscudo.Content = escudoUltimum.Nombre;
            lblPrecio.Content = $"- {escudoUltimum.Precio} x Día";
            lblExp.Content = $"+ {escudoUltimum.XP} x Día";
            lblPoder.Content = $"+ {escudoUltimum.Poder}";
            MostrarElementos();
            rImgEscudoMadera.StrokeThickness = 1;
            rImgEscudoReforzado.StrokeThickness = 1;
            rImgEscudoUltimum.StrokeThickness = 3;

        

        }

        private void btnUsar_Click(object sender, RoutedEventArgs e)
        {
            if (lblNombreEscudo.Content.ToString() == escudoActual)
            {
                SonidoClickNo();
            }
            else if (lblNombreEscudo.Content.ToString() == escudoMadera.Nombre)
            {
                if (player.Monedas >= escudoMadera.Precio)
                {
                    player.EscudoMadera = true;
                    player.EscudoReforzado = false;
                    player.EscudoUltimum = false;

                    SonidoClickSi();

                    EscudoActual();
                }
                else SonidoClickNo();
            }
            else if (lblNombreEscudo.Content.ToString() == escudoReforzado.Nombre)
            {
                if(player.Monedas >= escudoReforzado.Precio)
                {
                    player.EscudoMadera = false;
                    player.EscudoReforzado = true;
                    player.EscudoUltimum = false;

                    SonidoClickSi();

                    EscudoActual();
                }
                else SonidoClickNo();
            }
            else if (lblNombreEscudo.Content.ToString() == escudoUltimum.Nombre)
            {
                if (player.Monedas >= escudoUltimum.Precio)
                {
                    player.EscudoMadera = false;
                    player.EscudoReforzado = false;
                    player.EscudoUltimum = true;

                    SonidoClickSi();

                    EscudoActual();
                }
                else SonidoClickNo();
            }

            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));

        }
    }
}
