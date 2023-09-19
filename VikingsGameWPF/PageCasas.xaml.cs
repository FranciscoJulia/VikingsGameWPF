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
    /// Lógica de interacción para PageCasas.xaml
    /// </summary>
    public partial class PageCasas : Page
    {
        Item choza = new Item("Choza", 5, "Choza barata", 6, 7);
        Item casaPequeña = new Item("Casa pequeña", 6, "Casa pequeña", 7, 8);
        Item mansion = new Item("Mansión", 7, "Mansión normal", 8, 9);
        Item mansionPiedra = new Item("Mansión de piedra", 8, "Mansión de piedra", 9, 10);


        VikingPlayer player;
        public PageCasas(VikingPlayer player)
        {
            InitializeComponent();
            this.player = player;
            HogarActual();
            CasaChoza();
        }

        public void HogarActual()
        {
            ImageBrush newImageBrush = new ImageBrush();

            if (player.CasaChoza)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/choza.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
            else if (player.CasaPequeña)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/pequeñaCasa.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
            else if (player.CasaMansion)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/Mansion.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
            else if (player.CasaMansionPiedra)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/MansionPiedra.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
            }
        }

        public void CasaChoza()
        {
            lblNombreEscudo.Content = choza.Nombre;
            lblPrecio.Content = $"- {choza.Precio} x Día";
            lblExp.Content = $"+ {choza.XP} x Día";
            lblLealtad.Content = $"+ {choza.Lealtad} x Dia";
            
            rImgChoza.StrokeThickness = 3;
            rImgCasaPequeña.StrokeThickness = 1;
            rImgMansion.StrokeThickness = 1;
            rImgMansionPiedra.StrokeThickness = 1;
        }


        private void rImgChoza_MouseEnter(object sender, MouseEventArgs e)
        {
            CasaChoza();
        }
        private void rImgCasaPequeña_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreEscudo.Content = casaPequeña.Nombre;
            lblPrecio.Content = $"- {casaPequeña.Precio} x Día";
            lblExp.Content = $"+ {casaPequeña.XP} x Día";
            lblLealtad.Content = $"+ {casaPequeña.Lealtad} x Dia";

            rImgChoza.StrokeThickness = 1;
            rImgCasaPequeña.StrokeThickness = 3;
            rImgMansion.StrokeThickness = 1;
            rImgMansionPiedra.StrokeThickness = 1;
        }
        private void rImgMansion_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreEscudo.Content = mansion.Nombre;
            lblPrecio.Content = $"- {mansion.Precio} x Día";
            lblExp.Content = $"+ {mansion.XP} x Día";
            lblLealtad.Content = $"+ {mansion.Lealtad} x Dia";

            rImgChoza.StrokeThickness = 1;
            rImgCasaPequeña.StrokeThickness = 1;
            rImgMansion.StrokeThickness = 3;
            rImgMansionPiedra.StrokeThickness = 1;
        }
        private void rImgMansionPiedra_MouseEnter(object sender, MouseEventArgs e)
        {
            lblNombreEscudo.Content = mansionPiedra.Nombre;
            lblPrecio.Content = $"- {mansionPiedra.Precio} x Día";
            lblExp.Content = $"+ {mansionPiedra.XP} x Día";
            lblLealtad.Content = $"+ {mansionPiedra.Lealtad} x Dia";

            rImgChoza.StrokeThickness = 1;
            rImgCasaPequeña.StrokeThickness = 1;
            rImgMansion.StrokeThickness = 1;
            rImgMansionPiedra.StrokeThickness = 3;
        }

        private void btnUsar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
