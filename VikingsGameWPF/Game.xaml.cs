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

            Datos();


            
        }

        



        VikingPlayer player = new VikingPlayer();
        

        public void Datos()
        {
            SRVIDA();

            player.Nombre = nombrePlayer;
            lblNombre.Content = player.Nombre.ToString();
            lblMonedas.Content = player.Monedas.ToString();
            lblXP.Content = player.Experiencia.ToString();
            lblLealtad.Content = player.Poder.ToString(); 
            lblTipo.Content = player.Tipo.ToString();
            lblDias.Content = $"Día {player.Dia}";
            lblVida.Content = player.Vida.ToString();

            lblVidaSuma.Content = player.sumaVida.ToString();
            //lblVidaResta.Content = player.restaVida.ToString();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //ARMAMENTO
        private void rImgArmamento_MouseDown(object sender, MouseButtonEventArgs e)
        {
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
            player.Dia++;
            Datos();
        }
        public void SRVIDA()
        {
            player.SumaVidaElementos();
            player.SumaVida();
            player.RestaVida();
        }
    }
}
