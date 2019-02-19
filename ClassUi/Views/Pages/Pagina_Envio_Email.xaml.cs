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
using System.Windows;
using System.IO;
using Microsoft.Win32;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para Pagina_Envio_Email.xam
    /// </summary>
    public partial class Pagina_Envio_Email : Page
    {

        private ControleContatoJuridico contatoJuridico = new ControleContatoJuridico();
        private static List<Email> emails = new List<Email>();
        private static List<Anexos> listAnexos = new List<Anexos>();
        private SendEmail Send = new SendEmail();
        private ControleAnexos controleAnexos = new ControleAnexos();

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
                //List<ContatoJuridicoChecked> listaContatosChecked = new List<ContatoJuridicoChecked>();

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
                TextRange range;
                range = new TextRange(mainRTB.Document.ContentStart, mainRTB.Document.ContentEnd);

                Email email = new Email();
                email.EndEmail = "davinc131@hotmail.com";
                emails.Add(email);

                List<string> anexos = new List<string>();
                anexos.Add(@"C:\Users\BRGAAP\Documents\Certificado Presença 1.pdf");
                anexos.Add(@"C:\Users\BRGAAP\Documents\Recibo de Aluguel.pdf");

                //Send.EnviaEmail(emails);
                Send.EnviaEmail(emails, anexos);
                MessageBox.Show("Mensagens enviadas com sucesso!");
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
                HierarchicalDataTemplate h = new HierarchicalDataTemplate();
                TreeViewItem t = new TreeViewItem();
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

        public string SelecionarAnexo()
        {
            string caminho = "";
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //caminho = File.ReadAllText(openFileDialog.FileName);
                caminho = openFileDialog.FileName;
            }

            return caminho;
        }

        private void BtnAnexos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Anexos a = controleAnexos.anexo(SelecionarAnexo());
                listAnexos.Add(a);
                cbAnexos.Items.Add(a.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
