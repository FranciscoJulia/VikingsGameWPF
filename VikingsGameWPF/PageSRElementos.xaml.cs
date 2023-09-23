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
    /// Lógica de interacción para PageSRElementos.xaml
    /// </summary>
    public partial class PageSRElementos : Page
    {
        VikingPlayer player;

        public PageSRElementos(VikingPlayer player)
        {
            InitializeComponent();
            this.player = player;


            //SRVIDA
            player.sumaExp = 0;
            player.sumaVida = 0;

            SRVIDA();
            lblVidaSuma.Content = player.sumaVida.ToString();
            //lblVidaResta.Content = player.restaVida.ToString();
            //SREXP
            SREXP();
            lblExpSuma.Content = player.sumaExp.ToString();

            //SRPODER
            //player.sumaPoder = 0;
            //SRPODER();
            //lblPoderSuma.Content = player.sumaPoder.ToString();
        }


        public void SRVIDA()
        {
            player.SumaVidaElementos();
            player.SumaVida();
            player.RestaVida();
        }
        public void SREXP()
        {
            player.SumaExpElementos();
            player.SumaExp();
            player.RestaExp();
        }

        //public void SRPODER()
        //{
        //    player.SumaPoderElementos();
        //    player.SumaPoder();
        //    player.RestaPoder();
        //}
    }
}
