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
using System.Media;

namespace VikingsGameWPF
{
    /// <summary>
    /// Lógica de interacción para Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        string nombrePlayer;
        public Game(string nombre)
        {

            nombrePlayer = nombre;
            InitializeComponent();

            MyFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            MyFrame.NavigationService.Navigate(new PageArmamento(player));
            rImgArmamento.StrokeThickness = 6;
            lblArmamento.FontSize = 50;

            Datos();

        }

        



        VikingPlayer player = new VikingPlayer();
        

        public void Datos()
        {
            player.Nombre = nombrePlayer;
            lblNombre.Content = player.Nombre.ToString();
            lblMonedas.Content = player.Monedas.ToString();
            lblXP.Content = player.Experiencia.ToString();
            lblPoder.Content = player.Poder.ToString(); 
            lblTipo.Content = player.Tipo.ToString();
            lblDias.Content = $"Día {player.Dia}";
            lblVida.Content = player.Vida.ToString();

            player.CantPoder();
            lblPoder.Content = player.cantPoder.ToString();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void SonidoClickSi()
        {
            SoundPlayer sonido = new SoundPlayer("Sonidos/ClickSi.wav");
            sonido.Play();
        }

        //ARMAMENTO
        private void rImgArmamento_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SonidoClickSi();
            MyFrame.NavigationService.Navigate(new PageArmamento(player));
        }
        private void rImgArmamento_MouseEnter(object sender, MouseEventArgs e)
        {
            rImgArmamento.StrokeThickness = 6;
            lblArmamento.FontSize = 50;
        }
        private void rImgArmamento_MouseLeave(object sender, MouseEventArgs e)
        {
            rImgArmamento.StrokeThickness = 1;
            lblArmamento.FontSize = 48;
        }


        //ALIMENTO
        private void rImgAlimento_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SonidoClickSi();
            MyFrame.NavigationService.Navigate(new PageAlimento(player));
        }
        private void rImgAlimento_MouseEnter(object sender, MouseEventArgs e)
        {
            rImgAlimento.StrokeThickness = 6;
            lblAlimento.FontSize = 48;
            lblHogar.FontSize = 48;
        }
        private void rImgAlimento_MouseLeave(object sender, MouseEventArgs e)
        {
            rImgAlimento.StrokeThickness = 1;
            lblAlimento.FontSize = 46;
            lblHogar.FontSize = 46;
        }

        


        private void btnDormir_Click(object sender, RoutedEventArgs e)
        {
            player.SumaVidaElementos();
            player.SumaVida();
            player.GanarVida(player.sumaVida);
            

            player.SumaExpElementos();
            player.SumaExp();
            player.GanarExp(player.sumaExp);


            player.RestaMonedasElementos();
            player.RestaMonedas();
            player.PerderMonedas(player.restaMonedas);


            player.Dia++;
            Datos();

           
        }
        

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
