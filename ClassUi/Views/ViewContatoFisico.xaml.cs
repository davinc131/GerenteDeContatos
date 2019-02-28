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
using ClassModel;

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
            Pages.Page_Contato_Fisica pageContatoFisico = new Pages.Page_Contato_Fisica(false, new Contato());
            AbrirDeUmaPagina(pageContatoFisico);
            btnNovo.IsEnabled = false;
            btnListar.IsEnabled = true;
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pages.Page_Listar_Contato_Fisico PaginaListarContatoFisico = new Pages.Page_Listar_Contato_Fisico();
                FrameContatoFisico.Content = PaginaListarContatoFisico;
                btnNovo.IsEnabled = true;
                btnListar.IsEnabled = false;
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
                ClassModel.Contato c = new ClassModel.Contato();
                c = null;
                Pages.Page_Contato_Fisica PaginaContatoFisico = new Pages.Page_Contato_Fisica(false, c);
                AbrirDeUmaPagina(PaginaContatoFisico);
                btnNovo.IsEnabled = false;
                btnListar.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AbrirDeUmaPagina(Page p)
        {
            try
            {
                this.FrameContatoFisico.Content = p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
