using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interação lógica para Page_Listar_Contato_Juridico.xam
    /// </summary>
    public partial class Page_Listar_Contato_Juridico : Page
    {
        ControleContatoJuridico controleContato = new ControleContatoJuridico();

        public Page_Listar_Contato_Juridico()
        {
            InitializeComponent();
            DgContato.ItemsSource = controleContato.ListarContatoJuridico();

            ICollectionView view = CollectionViewSource.GetDefaultView(DgContato.ItemsSource);

            view.SortDescriptions.Add(new SortDescription("Categoria", ListSortDirection.Ascending));

            view.SortDescriptions.Add(new SortDescription("Categoria", ListSortDirection.Ascending));

            view.GroupDescriptions.Add(new PropertyGroupDescription("Categoria"));
        }

        private void BtnEditarContato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContatoJuridico c = new ContatoJuridico();
                c = (ContatoJuridico)DgContato.SelectedItem;

                Page_Contato_Juridico p = new Page_Contato_Juridico(true, c);

                ViewContatoJuridico v = new ViewContatoJuridico();

                v.AbrirDeUmaPagina(p);
                v.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExcluirContato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Tem certeza que deseja deletar este registro.", "Excluir", MessageBoxButton.YesNoCancel);

                if (result.Equals(MessageBoxResult.Yes))
                {
                    ContatoJuridico c = new ContatoJuridico();
                    c = (ContatoJuridico)DgContato.SelectedItem;
                    controleContato.Excluir(c.Id);

                    MessageBox.Show("Registro Deletado com sucesso!");

                    DgContato.ItemsSource = null;
                    DgContato.ItemsSource = controleContato.ListarContatoJuridico();
                }

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
