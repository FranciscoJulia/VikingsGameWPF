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
    /// Lógica de interacción para PageAlimento.xaml
    /// </summary>
    public partial class PageAlimento : Page
    {
        VikingPlayer player;

        public PageAlimento(VikingPlayer player)
        {
            InitializeComponent();
            this.player = player;   
        }


        //HOGARES
        private void rImgHogares_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameArmamento.NavigationService.Navigate(new PageCasas(player));
        }
        private void rImgHogares_MouseEnter(object sender, MouseEventArgs e)
        {
            rImgHogares.StrokeThickness = 5;
        }
        private void rImgHogares_MouseLeave(object sender, MouseEventArgs e)
        {
            rImgHogares.StrokeThickness = 1;
        }

        //COMIDAS
        private void rImgAlimento_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameArmamento.NavigationService.Navigate(new PageComidas(player));
        }
        private void rImgAlimento_MouseEnter(object sender, MouseEventArgs e)
        {
            rImgAlimento.StrokeThickness = 5;
        }
        private void rImgAlimento_MouseLeave(object sender, MouseEventArgs e)
        {
            rImgAlimento.StrokeThickness = 1;
        }
    }
}
