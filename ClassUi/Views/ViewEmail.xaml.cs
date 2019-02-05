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
    /// Lógica interna para ViewEmail.xaml
    /// </summary>
    public partial class ViewEmail : Window
    {
        public ViewEmail()
        {
            InitializeComponent();

            Pages.PageSlideEmail PageSlideEmail = new Pages.PageSlideEmail();
            AbrirDeUmaPagina(PageSlideEmail);
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
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
