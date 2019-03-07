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
    /// Lógica interna para ViewContatoJuridico.xaml
    /// </summary>
    public partial class ViewContatoJuridico : Window
    {
        public ViewContatoJuridico()
        {
            InitializeComponent();

            Pages.Page_Contatos PaginaContatos = new Pages.Page_Contatos();
            AbrirDeUmaPagina(PaginaContatos);
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
