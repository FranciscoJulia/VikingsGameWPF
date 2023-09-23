using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Lógica de interacción para PageEspadas.xaml
    /// </summary>
    public partial class PageEspadas : Page
    {
        Item espadaBronce = new Item("Espada de bronce", 0, "Espada de bronce", 1, 10, 0, 0);
        Item espadaHierro = new Item("Espada de Hierro", 40, "Espada de Hierro", 20, 30, 0, 0);
        Item espadaAcero = new Item("Espada de Acero", 100, "Espada de Acero", 45, 100, 0, 0);

        VikingPlayer player;

        public PageEspadas(VikingPlayer player)
        {
            InitializeComponent();

            EspadaBronce();
            this.player = player;

            EspadaActual();

            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));
        }

        public void EspadaActual()
        {
            ImageBrush newImageBrush = new ImageBrush();

            if (player.EspadaBronce == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/espadaBronce.png", UriKind.Relative));
                rImgEspadaActual.Fill = newImageBrush;
            }
            else if (player.EspadaHierro == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/espadaHierro.png", UriKind.Relative));
                rImgEspadaActual.Fill = newImageBrush;
            }
            else if (player.EspadaAcero == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/espadaAcero.png", UriKind.Relative));
                rImgEspadaActual.Fill = newImageBrush;
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
        public void EspadaBronce()
        {
            lblNombreEspada.Content = espadaBronce.Nombre;
            lblPrecio.Content = $"- {espadaBronce.Precio} x Día";
            lblExp.Content = $"+ {espadaBronce.XP} x Día";
            lblPoder.Content = $"+ {espadaBronce.Poder}";
            MostrarElementos();
            rImgEspadaBronce.StrokeThickness = 3;
            rImgEspadaHierro.StrokeThickness = 1;
            rImgEspadaAcero.StrokeThickness = 1;
        }


        public void MostrarElementos()
        {
            btnUsar.Visibility = Visibility.Visible;
            lblNombreEspada.Visibility = Visibility.Visible;
            labelPrecio.Visibility = Visibility.Visible;
            lblPrecio.Visibility = Visibility.Visible;
        }

        private string espadaActual;
        private void rImgEspadaBronce_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreEspada.Content.ToString() != espadaBronce.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            espadaActual = espadaBronce.Nombre;
            EspadaBronce();
        }

        private void rImgEspadaHierro_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreEspada.Content.ToString() != espadaHierro.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            espadaActual = espadaHierro.Nombre;

            lblNombreEspada.Content = espadaHierro.Nombre;
            lblPrecio.Content = $"- {espadaHierro.Precio} x Día";
            lblExp.Content = $"+ {espadaHierro.XP} x Día";
            lblPoder.Content = $"+ {espadaHierro.Poder}";
            MostrarElementos();
            rImgEspadaBronce.StrokeThickness = 1;
            rImgEspadaHierro.StrokeThickness = 3;
            rImgEspadaAcero.StrokeThickness = 1;

        }

        private void rImgEspadaAcero_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreEspada.Content.ToString() != espadaAcero.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            espadaActual = espadaAcero.Nombre;

            lblNombreEspada.Content = espadaAcero.Nombre;
            lblPrecio.Content = $"- {espadaAcero.Precio} x Día";
            lblExp.Content = $"+ {espadaAcero.XP} x Día";
            lblPoder.Content = $"+ {espadaAcero.Poder}";
            MostrarElementos();
            rImgEspadaBronce.StrokeThickness = 1;
            rImgEspadaHierro.StrokeThickness = 1;
            rImgEspadaAcero.StrokeThickness = 3;

        }

        private void btnUsar_Click(object sender, RoutedEventArgs e)
        {
            if (lblNombreEspada.Content.ToString() == espadaBronce.Nombre)
            {
                if (player.Monedas >= espadaBronce.Precio)
                {
                    player.EspadaBronce = true;
                    player.EspadaHierro = false;
                    player.EspadaAcero = false;

                    SonidoClickSi();
                    EspadaActual();
                }
                else SonidoClickNo();
            }
            else if (lblNombreEspada.Content.ToString() == espadaHierro.Nombre)
            {
                if (player.Monedas >= espadaHierro.Precio)
                {
                    player.EspadaBronce = false;
                    player.EspadaHierro = true;
                    player.EspadaAcero = false;

                    SonidoClickSi();
                    EspadaActual();
                }
                else SonidoClickNo();
            }
            else if (lblNombreEspada.Content.ToString() == espadaAcero.Nombre)
            {
                if (player.Monedas >= espadaAcero.Precio)
                {
                    player.EspadaBronce = false;
                    player.EspadaHierro = false;
                    player.EspadaAcero = true;

                    SonidoClickSi();
                    EspadaActual();
                }
                else SonidoClickNo();
            }

            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));
        }
    }
}
