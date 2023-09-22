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
    /// Lógica de interacción para PageComidas.xaml
    /// </summary>
    public partial class PageComidas : Page
    {
        Item pan = new Item("Pan", 0, "Pan duro", 5);
        Item pescado = new Item("Pescado", 70, "Salmoncito", 25);
        Item pollo = new Item("Pollo", 120, "Pollo", 60);
        Item Festin = new Item("Festín", 250, "Chancho con otras cosas", 150);


        VikingPlayer player;
        public PageComidas(VikingPlayer player)
        {
            InitializeComponent();
            this.player = player;

            ComidaActual();
            ComidaPan();

            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));
        }

        public void ComidaActual()
        {
            ImageBrush newImageBrush = new ImageBrush();

            if (player.ComidaPan)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/pan.png", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
            else if (player.ComidaPescado)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/Pescado.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
            else if (player.ComidaPollo)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/Pollo.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
            else if (player.ComidaFestin)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/Festin.jpg", UriKind.Relative));
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
        public void ComidaPan()
        {
            lblNombreComida.Content = pan.Nombre;
            lblPrecio.Content = $"- {pan.Precio} x Día";
            lblVida.Content = $"+ {pan.SVida} x Día";

            rImgPan.StrokeThickness = 3;
            rImgPescado.StrokeThickness = 1;
            rImgPollo.StrokeThickness = 1;
            rImgFestin.StrokeThickness = 1;
            
        }

        private string comidaActual;

        private void rImgPan_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreComida.Content.ToString() != pan.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            comidaActual = pan.Nombre;
            ComidaPan();
        }
        private void rImgPescado_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreComida.Content.ToString() != pescado.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            comidaActual = pescado.Nombre;

            lblNombreComida.Content = pescado.Nombre;
            lblPrecio.Content = $"- {pescado.Precio} x Día";
            lblVida.Content = $"+ {pescado.SVida} x Día";

            rImgPan.StrokeThickness = 1;
            rImgPescado.StrokeThickness = 3;
            rImgPollo.StrokeThickness = 1;
            rImgFestin.StrokeThickness = 1;

        }
        private void rImgPollo_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreComida.Content.ToString() != pollo.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            comidaActual = pollo.Nombre;    

            lblNombreComida.Content = pollo.Nombre;
            lblPrecio.Content = $"- {pollo.Precio} x Día";
            lblVida.Content = $"+ {pollo.SVida} x Día";

            rImgPan.StrokeThickness = 1;
            rImgPescado.StrokeThickness = 1;
            rImgPollo.StrokeThickness = 3;
            rImgFestin.StrokeThickness = 1;
        }
        private void rImgFestin_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreComida.Content.ToString() != Festin.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            comidaActual = Festin.Nombre;

            lblNombreComida.Content = Festin.Nombre;
            lblPrecio.Content = $"- {Festin.Precio} x Día";
            lblVida.Content = $"+ {Festin.SVida} x Día";

            rImgPan.StrokeThickness = 1;
            rImgPescado.StrokeThickness = 1;
            rImgPollo.StrokeThickness = 1;
            rImgFestin.StrokeThickness = 3;

        }

        private void btnUsar_Click(object sender, RoutedEventArgs e)
        {


            if (lblNombreComida.Content.ToString() == comidaActual)
            {
                SonidoClickNo();
            }
            else if (lblNombreComida.Content.ToString() == pan.Nombre)
            {
                if (player.Monedas >= pan.Precio)
                {
                    SonidoClickSi();
                    ComidaUsada();
                }
                else
                {
                    SonidoClickNo();
                }
            }
            else if (lblNombreComida.Content.ToString() == pescado.Nombre)
            {
                if (player.Monedas >= pescado.Precio)
                {
                    SonidoClickSi();
                    ComidaUsada();
                }
                else
                {
                    SonidoClickNo();
                }
            }
            else if (lblNombreComida.Content.ToString() == pollo.Nombre)
            {
                if (player.Monedas >= pollo.Precio)
                {
                    SonidoClickSi();
                    ComidaUsada();
                }
                else
                {
                    SonidoClickNo();
                }
            }
            else if (lblNombreComida.Content.ToString() == Festin.Nombre)
            {
                if (player.Monedas >= Festin.Precio)
                {
                    SonidoClickSi();
                    ComidaUsada();
                }
                else 
                {
                    SonidoClickNo();
                }
            }

            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));
        }

        public void ComidaUsada()
        {
            if (lblNombreComida.Content.ToString() == pan.Nombre) player.ComidaPan = true;
            if (lblNombreComida.Content.ToString() == pescado.Nombre) player.ComidaPescado = true;
            if (lblNombreComida.Content.ToString() == pollo.Nombre) player.ComidaPollo = true;
            if (lblNombreComida.Content.ToString() == Festin.Nombre) player.ComidaFestin = true;
        }
    }
}
