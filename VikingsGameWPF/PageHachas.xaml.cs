using System;
using System.Collections.Generic;
using System.Linq;
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

        Item hachaNormal = new Item("Hacha", 5, "Hacha normal", 5, 5);
        Item hachaPico = new Item("Hacha pico", 6, "Hacha y pico a la vez", 6, 6);
        Item hachaDoble = new Item("Hacha doble", 7, "Hacha por ambos lados", 7, 7);



        VikingPlayer player;
        public PageHachas(VikingPlayer player)
        {

            InitializeComponent();
            HachaNormal();
            this.player = player;

            HachaActual();
        }

        public void HachaActual()
        {
            ImageBrush newImageBrush = new ImageBrush();

            if (player.EscudoMadera == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/normalAxe.png", UriKind.Relative));
                rImgHachaActual.Fill = newImageBrush;
            }
            else if (player.EscudoReforzado == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/hachaPico.png", UriKind.Relative));
                rImgHachaActual.Fill = newImageBrush;
            }
            else if (player.EscudoUltimum == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/doubleAxe.png", UriKind.Relative));
                rImgHachaActual.Fill = newImageBrush;
            }
        }




        //HACHA NORMAL
        public void HachaNormal()
        {
            lblNombreHacha.Content = hachaNormal.Nombre;
            lblPrecio.Content = $"- {hachaNormal.Precio} x Día";
            lblExp.Content = $"+ {hachaNormal.XP} x Día";
            lblLealtad.Content = $"+ {hachaNormal.Lealtad} x Dia";
            MostrarElementos();
            rImgHachaPico.StrokeThickness = 1;
            rImgHachaNormal.StrokeThickness = 3;
            rImgHachaDoble.StrokeThickness = 1;
        }
        private void rImgHachaNormal_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //lblNombreHacha.Content = hachaNormal.Nombre;
            //lblPrecio.Content = $"{hachaNormal.Precio} x Día";
            //MostrarElementos();
            //rImgHachaNormal.StrokeThickness = 3;
        }
        private void rImgHachaNormal_MouseEnter(object sender, MouseEventArgs e)
        {
            HachaNormal();
        }
        private void rImgHachaNormal_MouseLeave(object sender, MouseEventArgs e)
        {
            //rImgHachaNormal.StrokeThickness = 1;
        }

        //HACHA PICO
        private void rImgHachaPico_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //lblNombreHacha.Content = hachaPico.Nombre;
            //lblPrecio.Content = $"{hachaPico.Precio} x Día";
            //MostrarElementos();
            //rImgHachaPico.StrokeThickness = 3;
        }
        private void rImgHachaPico_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreHacha.Content = hachaPico.Nombre;
            lblPrecio.Content = $"- {hachaPico.Precio} x Día";
            lblExp.Content = $"+ {hachaPico.XP} x Día";
            lblLealtad.Content = $"+ {hachaPico.Lealtad} x Dia";
            MostrarElementos();
            rImgHachaPico.StrokeThickness = 3;
            rImgHachaNormal.StrokeThickness = 1;
            rImgHachaDoble.StrokeThickness = 1;

        }
        private void rImgHachaPico_MouseLeave(object sender, MouseEventArgs e)
        {
            //rImgHachaPico.StrokeThickness = 1;
        }

        //HACHA DOBLE
        private void rImgHachaDoble_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //lblNombreHacha.Content = hachaDoble.Nombre;
            //lblPrecio.Content = $"{hachaDoble.Precio} x Día";
            //MostrarElementos();
            //rImgHachaDoble.StrokeThickness = 3;
        }
        private void rImgHachaDoble_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreHacha.Content = hachaDoble.Nombre;
            lblPrecio.Content = $"- {hachaDoble.Precio} x Día";
            lblExp.Content = $"+ {hachaDoble.XP} x Día";
            lblLealtad.Content = $"+ {hachaDoble.Lealtad} x Dia";
            MostrarElementos();
            rImgHachaPico.StrokeThickness = 1;
            rImgHachaNormal.StrokeThickness = 1;
            rImgHachaDoble.StrokeThickness = 3;
        }
        private void rImgHachaDoble_MouseLeave(object sender, MouseEventArgs e)
        {
           // rImgHachaDoble.StrokeThickness = 1;
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
                }
                else MessageBox.Show("No tienes suficientes monedas...");
            }
            else if (lblNombreHacha.Content.ToString() == hachaPico.Nombre)
            {
                if (player.Monedas >= hachaPico.Precio)
                {
                    player.HachaNormal = false;
                    player.HachaPico = true;
                    player.HachaDoble = false;
                }
                else MessageBox.Show("No tienes suficientes monedas...");
            }
            else if (lblNombreHacha.Content.ToString() == hachaDoble.Nombre)
            {
                if (player.Monedas >= hachaDoble.Precio)
                {
                    player.HachaNormal = false;
                    player.HachaPico = false;
                    player.HachaDoble = true;
                }
                else MessageBox.Show("No tienes suficientes monedas...");
            }
        }
    }
}
