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
using System.Collections.ObjectModel;
using ClassModel;
using ClassControle;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para Pagina_Envio_Email.xam
    /// </summary>
    public partial class Pagina_Envio_Email : Page
    {

        private ControleContatoJuridico contatoJuridico = new ControleContatoJuridico();

        public Pagina_Envio_Email()
        {
            InitializeComponent();
            GerarLista();
        }

        private void GerarLista()
        {
            try
            {
                List<ContatoJuridico> listaContatos = new List<ContatoJuridico>();
                listaContatos = contatoJuridico.ListarContatoJuridico();

                foreach(ContatoJuridico c in listaContatos)
                {
                    trViewContatos.Items.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
