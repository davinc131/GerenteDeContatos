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
using System.Windows.Shapes;

namespace ClassUi.Views
{
    /// <summary>
    /// Lógica interna para ViewContatoFisico.xaml
    /// </summary>
    public partial class ViewContatoFisico : Window
    {
        public ViewContatoFisico()
        {
            InitializeComponent();
            Pages.PageSlideContatoPFisica pageSlide = new Pages.PageSlideContatoPFisica();
            FrameContatoFisico.Content = pageSlide;
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pages.Page_Listar_Contato_Fisico PaginaListarContatoFisico = new Pages.Page_Listar_Contato_Fisico();
                FrameContatoFisico.Content = PaginaListarContatoFisico;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pages.Page_Contato_Fisica PaginaContatoFisico = new Pages.Page_Contato_Fisica(false);
                FrameContatoFisico.Content = PaginaContatoFisico;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
