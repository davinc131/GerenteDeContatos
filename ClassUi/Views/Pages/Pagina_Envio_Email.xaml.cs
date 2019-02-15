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
        private static List<Email> emails = new List<Email>();

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

                trViewContatos.ItemsSource = listaContatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEnviarEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModeloRodape_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChMaster_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChItem_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TrViewContatos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (trViewContatos.SelectedItem is ContatoJuridico)
                {
                    ContatoJuridico cc = trViewContatos.SelectedItem as ContatoJuridico;

                    foreach (Email em in cc.Emails)
                    {
                        emails.Add(em);
                    }

                    MessageBox.Show($"Você selecionou o item {cc.ToString()}");
                }
                else
                {
                    Contato cc = trViewContatos.SelectedItem as Contato;

                    foreach (Email em in cc.Emails)
                    {
                        emails.Add(em);
                    }

                    MessageBox.Show($"Você selecionou o item {cc.ToString()}");
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
