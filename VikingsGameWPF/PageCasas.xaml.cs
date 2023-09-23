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
    /// Lógica de interacción para PageCasas.xaml
    /// </summary>
    public partial class PageCasas : Page
    {
        Item choza = new Item("Choza", 0, "Choza barata", 1, 100);
        Item casaPequeña = new Item("Casa pequeña", 100, "Casa pequeña", 30, 500);
        Item mansion = new Item("Mansión", 500, "Mansión normal", 50, 2000);
        Item mansionPiedra = new Item("Mansión de piedra", 1200, "Mansión de piedra", 120, 4000);


        VikingPlayer player;
        public PageCasas(VikingPlayer player)
        {
            InitializeComponent();
            this.player = player;
            HogarActual();
            CasaChoza();

            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));
        }

        public void HogarActual()
        {
            ImageBrush newImageBrush = new ImageBrush();

            if (player.CasaChoza)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/choza.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
                lblReservaVida1.Content = $"Reserva: {choza.ReservaVida}";
            }
            else if (player.CasaPequeña)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/pequeñaCasa.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
                lblReservaVida1.Content = $"Reserva: {casaPequeña.ReservaVida}"; 
            }
            else if (player.CasaMansion)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/Mansion.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
                lblReservaVida1.Content = $"Reserva: {mansion.ReservaVida}";
            }
            else if (player.CasaMansionPiedra)
            {
                newImageBrush.ImageSource = new BitmapImage(new Uri("Img/MansionPiedra.jpg", UriKind.Relative));
                rImgEscudoActual.Fill = newImageBrush;
                lblReservaVida1.Content = $"Reserva: {mansionPiedra.ReservaVida}";
            }
        }

        public void CasaChoza()
        {
            lblNombreCasa.Content = choza.Nombre;
            lblPrecio.Content = $"- {choza.Precio} x Día";
            lblExp.Content = $"+ {choza.XP} x Día";
            lblReservaVida.Content = $"{choza.ReservaVida} De reserva";
            
            rImgChoza.StrokeThickness = 3;
            rImgCasaPequeña.StrokeThickness = 1;
            rImgMansion.StrokeThickness = 1;
            rImgMansionPiedra.StrokeThickness = 1;
        }

        private void rImgChoza_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreCasa.Content.ToString() != choza.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            casaActual = choza.Nombre;

            CasaChoza();
        }
        private void rImgCasaPequeña_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreCasa.Content.ToString() != casaPequeña.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            casaActual = casaPequeña.Nombre;

            lblNombreCasa.Content = casaPequeña.Nombre;
            lblPrecio.Content = $"- {casaPequeña.Precio} x Día";
            lblExp.Content = $"+ {casaPequeña.XP} x Día";
            lblReservaVida.Content = $"{casaPequeña.ReservaVida} De reserva";

            rImgChoza.StrokeThickness = 1;
            rImgCasaPequeña.StrokeThickness = 3;
            rImgMansion.StrokeThickness = 1;
            rImgMansionPiedra.StrokeThickness = 1;
        }
        private void rImgMansion_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreCasa.Content.ToString() != mansion.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            casaActual = mansion.Nombre;

            lblNombreCasa.Content = mansion.Nombre;
            lblPrecio.Content = $"- {mansion.Precio} x Día";
            lblExp.Content = $"+ {mansion.XP} x Día";
            lblReservaVida.Content = $"{mansion.ReservaVida} De reserva";

            rImgChoza.StrokeThickness = 1;
            rImgCasaPequeña.StrokeThickness = 1;
            rImgMansion.StrokeThickness = 3;
            rImgMansionPiedra.StrokeThickness = 1;
        }
        private void rImgMansionPiedra_MouseEnter(object sender, MouseEventArgs e)
        {
            if (lblNombreCasa.Content.ToString() != mansionPiedra.Nombre)
            {
                SonidoCambiarSeleccion();
            }
            casaActual = mansionPiedra.Nombre;

            lblNombreCasa.Content = mansionPiedra.Nombre;
            lblPrecio.Content = $"- {mansionPiedra.Precio} x Día";
            lblExp.Content = $"+ {mansionPiedra.XP} x Día";
            lblReservaVida.Content = $"{mansionPiedra.ReservaVida} De reserva";

            rImgChoza.StrokeThickness = 1;
            rImgCasaPequeña.StrokeThickness = 1;
            rImgMansion.StrokeThickness = 1;
            rImgMansionPiedra.StrokeThickness = 3;
        }
        private string casaActual;
        private void btnUsar_Click(object sender, RoutedEventArgs e)
        {
            if (lblNombreCasa.Content.ToString() == choza.Nombre)
            {
                if (player.Monedas >= choza.Precio)
                {
                    

                    CasaUsada();
                    SonidoClickSi();
                    HogarActual();
                }
                else SonidoClickNo();
            }
            else if (lblNombreCasa.Content.ToString() == casaPequeña.Nombre)
            {
                if (player.Monedas >= casaPequeña.Precio)
                {

                    CasaUsada();
                    SonidoClickSi();
                    HogarActual();
                }
                else SonidoClickNo();
            }
            else if (lblNombreCasa.Content.ToString() == mansion.Nombre)
            {
                if (player.Monedas >= mansion.Precio)
                {

                    CasaUsada();
                    SonidoClickSi();
                    HogarActual();
                }
                else SonidoClickNo();
            }
            else if (lblNombreCasa.Content.ToString() == mansionPiedra.Nombre)
            {
                if (player.Monedas >= mansionPiedra.Precio)
                {
                    CasaUsada();
                    SonidoClickSi();
                    HogarActual();
                    
                }
                else SonidoClickNo();
            }

            FrameSR.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            FrameSR.NavigationService.Navigate(new PageSRElementos(player));
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
        public void CasaUsada()
        {
            if (lblNombreCasa.Content.ToString() == choza.Nombre) 
            {
                player.CasaPequeña = false;
                player.CasaMansion = false;
                player.CasaMansionPiedra = false;

                player.CasaChoza = true;
                player.MaxVida();
            } 
                
            if (lblNombreCasa.Content.ToString() == casaPequeña.Nombre)
            {
                player.CasaChoza = false;
                player.CasaMansion = false;
                player.CasaMansionPiedra = false;

                player.CasaPequeña = true;
                player.MaxVida();
            }
            
            if (lblNombreCasa.Content.ToString() == mansion.Nombre)
            {
                player.CasaChoza = false;
                player.CasaPequeña = false;
                player.CasaMansionPiedra = false;

                player.CasaMansion = true;
                player.MaxVida();
            }
            if (lblNombreCasa.Content.ToString() == mansionPiedra.Nombre)
            {
                player.CasaChoza = false;
                player.CasaPequeña = false;
                player.CasaMansion = false;

                player.CasaMansionPiedra = true;
                player.MaxVida();
            }
        }
    }
}
