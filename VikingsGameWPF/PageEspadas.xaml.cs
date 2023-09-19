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
    /// Lógica de interacción para PageEspadas.xaml
    /// </summary>
    public partial class PageEspadas : Page
    {
        Item espadaBronce = new Item("Espada de bronce", 5, "Espada de bronce",6,7);
        Item espadaHierro = new Item("Espada de Hierro", 6, "Espada de Hierro", 7, 8);
        Item espadaAcero = new Item("Espada de Acero", 7, "Espada de Acero", 8, 9);

        VikingPlayer player;

        public PageEspadas(VikingPlayer player)
        {
            InitializeComponent();

            EspadaBronce();
            this.player = player;

            EspadaActual();
        }

        public void EspadaActual()
        {
            ImageBrush newImageBrush = new ImageBrush();

            if (player.EscudoMadera == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/normalAxe.png", UriKind.Relative));
                rImgEspadaActual.Fill = newImageBrush;
            }
            else if (player.EscudoReforzado == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/hachaPico.png", UriKind.Relative));
                rImgEspadaActual.Fill = newImageBrush;
            }
            else if (player.EscudoUltimum == true)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/doubleAxe.png", UriKind.Relative));
                rImgEspadaActual.Fill = newImageBrush;
            }
        }


        public void EspadaBronce()
        {
            lblNombreEspada.Content = espadaBronce.Nombre;
            lblPrecio.Content = $"- {espadaBronce.Precio} x Día";
            lblExp.Content = $"+ {espadaBronce.XP} x Día";
            lblLealtad.Content = $"+ {espadaBronce.Lealtad} x Dia";
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

        private void rImgEspadaBronce_MouseEnter(object sender, MouseEventArgs e)
        {
            EspadaBronce();
        }

        private void rImgEspadaHierro_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreEspada.Content = espadaHierro.Nombre;
            lblPrecio.Content = $"- {espadaHierro.Precio} x Día";
            lblExp.Content = $"+ {espadaHierro.XP} x Día";
            lblLealtad.Content = $"+ {espadaHierro.Lealtad} x Dia";
            MostrarElementos();
            rImgEspadaBronce.StrokeThickness = 1;
            rImgEspadaHierro.StrokeThickness = 3;
            rImgEspadaAcero.StrokeThickness = 1;
        }

        private void rImgEspadaAcero_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreEspada.Content = espadaAcero.Nombre;
            lblPrecio.Content = $"- {espadaAcero.Precio} x Día";
            lblExp.Content = $"+ {espadaAcero.XP} x Día";
            lblLealtad.Content = $"+ {espadaAcero.Lealtad} x Dia";
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
                }
                else MessageBox.Show("No tienes suficientes monedas...");
            }
            else if (lblNombreEspada.Content.ToString() == espadaHierro.Nombre)
            {
                if (player.Monedas >= espadaHierro.Precio)
                {
                    player.EspadaBronce = false;
                    player.EspadaHierro = true;
                    player.EspadaAcero = false;
                }
                else MessageBox.Show("No tienes suficientes monedas...");
            }
            else if (lblNombreEspada.Content.ToString() == espadaAcero.Nombre)
            {
                if (player.Monedas >= espadaAcero.Precio)
                {
                    player.EspadaBronce = false;
                    player.EspadaHierro = false;
                    player.EspadaAcero = true;
                }
                else MessageBox.Show("No tienes suficientes monedas...");
            }
        }
    }
}
