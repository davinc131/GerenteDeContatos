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

        private ControleContatoJuridico controleContatoJuridico = new ControleContatoJuridico();
        private ControleContato controleContato = new ControleContato();
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

                listaContatos = controleContatoJuridico.ListarContatoJuridico();

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

                if (emails.Count > 0)
                {
                    if (txtAssunto.Text != "" || txtAssunto.Text != null)
                    {
                        if(range.Text != "" || range.Text != null)
                        {
                            List<string> anexos = new List<string>();

                            foreach (Anexos s in listAnexos)
                            {
                                anexos.Add(s.Caminho);
                            }

                            Send.EnviaEmail(emails, anexos, txtAssunto.Text, range.Text);
                            MessageBox.Show("Mensagens enviadas com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Informe uma mensagem para ser enviada no email!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Informe um assunto para o email!");
                    }
                }
                else
                {
                    MessageBox.Show("Não há emails selecionados para envio de mensagens!");
                }
                
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

                    cc = controleContatoJuridico.consultar(cc.Id);

                    foreach (Email em in cc.Emails)
                    {
                        emails.Add(em);
                    }

                    MessageBox.Show($"Você selecionou o item {cc.ToString()}");
                }
                else
                {
                    Contato cc = trViewContatos.SelectedItem as Contato;

                    cc = controleContato.consultar(cc.Id);

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

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(cbAnexos.SelectedItem != null)
                {
                    Anexos a = new Anexos();

                    foreach(Anexos an in listAnexos)
                    {
                        if (an.NomeDoArquivo.Equals(cbAnexos.SelectedItem))
                        {
                            a = an;
                        }
                    }

                    cbAnexos.Items.Remove(cbAnexos.SelectedItem);
                    listAnexos.Remove(a);
                    MessageBox.Show("Removido com sucesso!");
                }
                else
                {
                    MessageBox.Show("Selecione um anexo para remover da lista");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
