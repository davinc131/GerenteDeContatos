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
using ClassModel;
using ClassControle;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para Page_Contato_Juridico.xam
    /// </summary>
    public partial class Page_Contato_Juridico : Page
    {
        public Page_Contato_Juridico()
        {
            InitializeComponent();

            cbCategoria.ItemsSource = Enum.GetValues(typeof(Categoria)).Cast<Categoria>();
        }

        private void BtnAddEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAddTelefone_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGravar_Click(object sender, RoutedEventArgs e)
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
