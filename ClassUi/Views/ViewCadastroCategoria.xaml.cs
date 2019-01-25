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
    /// Lógica interna para ViewCadastroCategoria.xaml
    /// </summary>
    public partial class ViewCadastroCategoria : Window
    {
        public ViewCadastroCategoria()
        {
            InitializeComponent();
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
