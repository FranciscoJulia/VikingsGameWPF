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
    /// Lógica de interacción para PageComidas.xaml
    /// </summary>
    public partial class PageComidas : Page
    {
        Item pan = new Item("Pan", 5, "Pan duro", 6, 7);
        Item pescado = new Item("Pescado", 6, "Salmoncito", 7, 8);
        Item pollo = new Item("Pollo", 7, "Pollo", 8, 9);
        Item Festin = new Item("Festín", 8, "Chancho con otras cosas", 9, 10);


        VikingPlayer player;
        public PageComidas(VikingPlayer player)
        {
            InitializeComponent();
            this.player = player;

            ComidaActual();
            ComidaPan();
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

        public void ComidaPan()
        {
            lblNombreEscudo.Content = pan.Nombre;
            lblPrecio.Content = $"- {pan.Precio} x Día";
            lblExp.Content = $"+ {pan.XP} x Día";
            lblLealtad.Content = $"+ {pan.Lealtad} x Dia";

            rImgPan.StrokeThickness = 3;
            rImgPescado.StrokeThickness = 1;
            rImgPollo.StrokeThickness = 1;
            rImgFestin.StrokeThickness = 1;
        }

        private void rImgPan_MouseEnter(object sender, MouseEventArgs e)
        {
            ComidaPan();
        }
        private void rImgPescado_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreEscudo.Content = pescado.Nombre;
            lblPrecio.Content = $"- {pescado.Precio} x Día";
            lblExp.Content = $"+ {pescado.XP} x Día";
            lblLealtad.Content = $"+ {pescado.Lealtad} x Dia";

            rImgPan.StrokeThickness = 1;
            rImgPescado.StrokeThickness = 3;
            rImgPollo.StrokeThickness = 1;
            rImgFestin.StrokeThickness = 1;
        }
        private void rImgPollo_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreEscudo.Content = pollo.Nombre;
            lblPrecio.Content = $"- {pollo.Precio} x Día";
            lblExp.Content = $"+ {pollo.XP} x Día";
            lblLealtad.Content = $"+ {pollo.Lealtad} x Dia";

            rImgPan.StrokeThickness = 1;
            rImgPescado.StrokeThickness = 1;
            rImgPollo.StrokeThickness = 3;
            rImgFestin.StrokeThickness = 1;
        }
        private void rImgFestin_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreEscudo.Content = Festin.Nombre;
            lblPrecio.Content = $"- {Festin.Precio} x Día";
            lblExp.Content = $"+ {Festin.XP} x Día";
            lblLealtad.Content = $"+ {Festin.Lealtad} x Dia";

            rImgPan.StrokeThickness = 1;
            rImgPescado.StrokeThickness = 1;
            rImgPollo.StrokeThickness = 1;
            rImgFestin.StrokeThickness = 3;
        }

        private void btnUsar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
