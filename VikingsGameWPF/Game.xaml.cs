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


            //SACAR BORDES BOTONES
            rImgMonedas.StrokeThickness = 0;
            rImgXP.StrokeThickness = 0;
            rImgLealtad.StrokeThickness = 0;
        }


        



        VikingPlayer player = new VikingPlayer();
        

        public void Datos()
        {
            player.Nombre = nombrePlayer;
            lblNombre.Content = player.Nombre.ToString();
            lblMonedas.Content = player.Monedas.ToString();
            lblXP.Content = player.Experiencia.ToString();
            lblLealtad.Content = player.Lealtad.ToString(); 
            lblTipo.Content = player.Tipo.ToString();
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
            MyFrame.NavigationService.Navigate(new PageAlimento());
        }
        private void rImgAlimento_MouseEnter(object sender, MouseEventArgs e)
        {
            rImgAlimento.StrokeThickness = 6;
            lblAlimento.FontSize = 50;
        }
        private void rImgAlimento_MouseLeave(object sender, MouseEventArgs e)
        {
            rImgAlimento.StrokeThickness = 1;
            lblAlimento.FontSize = 48;
        }

        //HOGAR
        private void rImgHogar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new PageHogar());    
        }
        private void rImgHogar_MouseEnter(object sender, MouseEventArgs e)
        {
            rImgHogar.StrokeThickness = 6;
            lblHogar.FontSize = 50;
        }
        private void rImgHogar_MouseLeave(object sender, MouseEventArgs e)
        {
            rImgHogar.StrokeThickness = 1;
            lblHogar.FontSize = 48;
        }



        

    }
}
