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
using ClassControle;
using ClassModel;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para Page_Listar_Contato_Fisico.xam
    /// </summary>
    public partial class Page_Listar_Contato_Fisico : Page
    {
        ControleContato controle = new ControleContato();

        public Page_Listar_Contato_Fisico()
        {
            InitializeComponent();
            DgContato.ItemsSource = controle.ListarContatos();
        }

        private void BtnExcluirContato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Tem certeza que deseja deletar este registro.", "Excluir", MessageBoxButton.YesNoCancel);

                if (result.Equals(MessageBoxResult.Yes))
                {
                    Contato c = new Contato();
                    c = (Contato)DgContato.SelectedItem;

                    controle.Excluir(c.Id);

                    MessageBox.Show("Registro Excluído com sucesso!");

                    DgContato.ItemsSource = null;
                    DgContato.ItemsSource = controle.ListarContatos();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditarContato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contato c = new Contato();
                c = (Contato)DgContato.SelectedItem;

                Page_Contato_Fisica p = new Page_Contato_Fisica(true, c);

                ViewContatoFisico v = new ViewContatoFisico();

                v.AbrirDeUmaPagina(p);
                v.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCriarDemo_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
