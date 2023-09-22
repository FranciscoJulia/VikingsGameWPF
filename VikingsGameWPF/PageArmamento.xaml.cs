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
    /// Lógica de interacción para PageArmamento.xaml
    /// </summary>
    public partial class PageArmamento : Page
    {

        VikingPlayer player;
        public PageArmamento(VikingPlayer player)
        {
            InitializeComponent();
            this.player = player;

            FrameArmamento.NavigationService.Navigate(new PageHachas(player));
            rImgHachas.StrokeThickness = 5;
        }



        //HACHAS
        private void rImgHachas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SonidoClickSi();
            FrameArmamento.NavigationService.Navigate(new PageHachas(player));
        }
        private void rImgHachas_MouseEnter(object sender, MouseEventArgs e)
        {
            rImgHachas.StrokeThickness = 5;
        }
        private void rImgHachas_MouseLeave(object sender, MouseEventArgs e)
        {
            rImgHachas.StrokeThickness = 1;
        }



        //ESPADAS
        private void rImgEspadas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SonidoClickSi();
            FrameArmamento.NavigationService.Navigate(new PageEspadas(player));
        }
        private void rImgEspadas_MouseEnter(object sender, MouseEventArgs e)
        {
            rImgEspadas.StrokeThickness = 5;
        }
        private void rImgEspadas_MouseLeave(object sender, MouseEventArgs e)
        {
            rImgEspadas.StrokeThickness = 1;
        }


        //ESCUDOS
        private void rImgEscudos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SonidoClickSi();
            FrameArmamento.NavigationService.Navigate(new PageEscudos(player));
        }
        private void rImgEscudos_MouseEnter(object sender, MouseEventArgs e)
        {
            rImgEscudos.StrokeThickness = 5;
        }
        private void rImgEscudos_MouseLeave(object sender, MouseEventArgs e)
        {
            rImgEscudos.StrokeThickness = 1;
        }


        
        public void SonidoClickSi()
        {
            SoundPlayer sonido = new SoundPlayer("Sonidos/ClickSi.wav");
            sonido.Play();
        }
    }
}
