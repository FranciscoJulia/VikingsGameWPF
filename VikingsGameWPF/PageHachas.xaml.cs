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
    /// Lógica de interacción para PageHachas.xaml
    /// </summary>
    public partial class PageHachas : Page
    {

        Item hachaNormal = new Item("Hacha", 0, "Hacha normal", 1, 10, 0, 0);
        Item hachaPico = new Item("Hacha pico", 40, "Hacha y pico a la vez", 20, 30, 0, 0);
        Item hachaDoble = new Item("Hacha doble", 100, "Hacha por ambos lados", 45, 100, 0, 0);



        VikingPlayer player;
        public PageHachas(VikingPlayer player)
        {

            InitializeComponent();
            HachaNormal();
            this.player = player;

            HachaActual();

            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));
        }

        public void HachaActual()
        {
            ImageBrush newImageBrush = new ImageBrush();

            if (player.HachaNormal == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/normalAxe.png", UriKind.Relative));
                rImgHachaActual.Fill = newImageBrush;
            }
            else if (player.HachaPico == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/hachaPico.png", UriKind.Relative));
                rImgHachaActual.Fill = newImageBrush;
            }
            else if (player.HachaDoble == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/doubleAxe.png", UriKind.Relative));
                rImgHachaActual.Fill = newImageBrush;
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


        //HACHA NORMAL
        public void HachaNormal()
        {
            lblNombreHacha.Content = hachaNormal.Nombre;
            lblPrecio.Content = $"- {hachaNormal.Precio} x Día";
            lblExp.Content = $"+ {hachaNormal.XP} x Día";
            lblPoder.Content = $"+ {hachaNormal.Poder}";
            MostrarElementos();
            rImgHachaPico.StrokeThickness = 1;
            rImgHachaNormal.StrokeThickness = 3;
            rImgHachaDoble.StrokeThickness = 1;
        }

        private string hachaActual;
        
        private void rImgHachaNormal_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreHacha.Content.ToString() != hachaNormal.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            hachaActual = hachaNormal.Nombre;

            HachaNormal();
        }
        

        //HACHA PICO
        
        private void rImgHachaPico_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreHacha.Content.ToString() != hachaPico.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            hachaActual = hachaPico.Nombre;

            lblNombreHacha.Content = hachaPico.Nombre;
            lblPrecio.Content = $"- {hachaPico.Precio} x Día";
            lblExp.Content = $"+ {hachaPico.XP} x Día";
            lblPoder.Content = $"+ {hachaPico.Poder}";
            MostrarElementos();
            rImgHachaPico.StrokeThickness = 3;
            rImgHachaNormal.StrokeThickness = 1;
            rImgHachaDoble.StrokeThickness = 1;

        }
        

        //HACHA DOBLE
        
        private void rImgHachaDoble_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreHacha.Content.ToString() != hachaDoble.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            hachaActual = hachaDoble.Nombre;

            lblNombreHacha.Content = hachaDoble.Nombre;
            lblPrecio.Content = $"- {hachaDoble.Precio} x Día";
            lblExp.Content = $"+ {hachaDoble.XP} x Día";
            lblPoder.Content = $"+ {hachaDoble.Poder}";
            MostrarElementos();
            rImgHachaPico.StrokeThickness = 1;
            rImgHachaNormal.StrokeThickness = 1;
            rImgHachaDoble.StrokeThickness = 3;
        }
        

        public void MostrarElementos()
        {
            btnUsar.Visibility = Visibility.Visible;
            lblNombreHacha.Visibility = Visibility.Visible;
            labelPrecio.Visibility = Visibility.Visible;
            lblPrecio.Visibility = Visibility.Visible;
        }

        private void btnUsar_Click(object sender, RoutedEventArgs e)
        {
            if (lblNombreHacha.Content.ToString() == hachaNormal.Nombre)
            {
                if (player.Monedas >= hachaNormal.Precio)
                {
                    player.HachaNormal = true;
                    player.HachaPico = false;
                    player.HachaDoble = false;

                    SonidoClickSi();

                    HachaActual();
                }
                else SonidoClickNo();
            }
            else if (lblNombreHacha.Content.ToString() == hachaPico.Nombre)
            {
                if (player.Monedas >= hachaPico.Precio)
                {
                    player.HachaNormal = false;
                    player.HachaPico = true;
                    player.HachaDoble = false;

                    SonidoClickSi();

                    HachaActual();
                }
                else SonidoClickNo();
            }
            else if (lblNombreHacha.Content.ToString() == hachaDoble.Nombre)
            {
                if (player.Monedas >= hachaDoble.Precio)
                {
                    player.HachaNormal = false;
                    player.HachaPico = false;
                    player.HachaDoble = true;

                    SonidoClickSi();

                    HachaActual();
                }
                else SonidoClickNo();
            }


            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));

        }
    }
}
