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
using ClassControle;

namespace ClassUi.Views
{
    /// <summary>
    /// Lógica interna para ViewEmail.xaml
    /// </summary>
    public partial class ViewEmail : Window
    {
        private ControleContatoJuridico contatoJuridico = new ControleContatoJuridico();

        public ViewEmail()
        {
            InitializeComponent();

            Pages.Pagina_Envio_Email PageEmail = new Pages.Pagina_Envio_Email();
            AbrirDeUmaPagina(PageEmail);
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pages.Pagina_Envio_Email email = new Pages.Pagina_Envio_Email();
                AbrirDeUmaPagina(email);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AbrirDeUmaPagina(Page p)
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
