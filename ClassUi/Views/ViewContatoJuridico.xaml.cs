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
    /// Lógica interna para ViewContatoJuridico.xaml
    /// </summary>
    public partial class ViewContatoJuridico : Window
    {
        public ViewContatoJuridico()
        {
            InitializeComponent();
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pages.Page_Listar_Contato_Juridico PaginaListarContatoFisico = new Pages.Page_Listar_Contato_Juridico();
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
                ClassModel.ContatoJuridico c = new ClassModel.ContatoJuridico();
                c = null;
                Pages.Page_Contato_Juridico PaginaContatoFisico = new Pages.Page_Contato_Juridico(false, c);
                FrameContatoFisico.Content = PaginaContatoFisico;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
