using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Threading;
using ClassControle;
using ClassModel;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para Page_Contato_Fisica.xam
    /// </summary>
    public partial class Page_Contato_Fisica : Page
    {
        #region Variaveis

        private ControleContato controleContato = new ControleContato();
        private ControleContatoJuridico controleJuridico = new ControleContatoJuridico();
        private ICollection<Telefone> listTelefone = new List<Telefone>();
        private ICollection<Email> listEmail = new List<Email>();
        private Contato contato = new Contato();
        private DispatcherTimer timer;

        #endregion

        public Page_Contato_Fisica(bool editar, Contato c)
        {
            InitializeComponent();
            Init();

            this.contato = c;
            ControlePagina(editar, contato);
        }

        private void Init()
        {
            try
            {
                cbDepartamento.ItemsSource = Enum.GetValues(typeof(Departamento)).Cast<Departamento>();
                cbVinculado.ItemsSource = controleJuridico.ListarContatoJuridico();

                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.IsEnabled = true;

                timer.Tick += new EventHandler(timer_Tick);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (chCelular.IsChecked.Equals(true))
            {
                chWhatsapp.IsEnabled = true;
            }
            else
            {
                chWhatsapp.IsEnabled = false;
            }
        }

        private void ControlePagina(bool editar, Contato c)
        {
            if (editar.Equals(true))
            {
                btnGravar.IsEnabled = false;
                btnEditar.IsEnabled = true;
                chWhatsapp.IsEnabled = false;

                listEmail = c.Emails;
                listTelefone = c.Telefones;

                txtNome.Text = c.Nome;
                txtDescricao.Text = c.Descricao;
                DGEmail.ItemsSource = listEmail;
                DGTelefone.ItemsSource = listTelefone;
                cbDepartamento.SelectedItem = c.Departamento;

                for (int i = 0; i < cbVinculado.Items.Count; i++)
                {
                    if (c.ContatoJuridico.ToString().Equals(cbVinculado.Items[i].ToString()))
                    {
                        cbVinculado.SelectedIndex = i;
                    }
                }
            }
            else
            {
                btnGravar.IsEnabled = true;
                btnEditar.IsEnabled = false;
                chWhatsapp.IsEnabled = false;
            }
        }

        private void BtnGravar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool bnome = false;
                bool bemail = false;
                bool btelefone = false;
              
                contato = new Contato();

                if(txtNome.Text != null || txtNome.Text != "")
                {
                    bnome = true;
                    contato.Nome = txtNome.Text;
                }

                
                contato.Descricao = txtDescricao.Text;

                if(cbDepartamento.SelectedItem != null)
                {
                    contato.Departamento = (Departamento)cbDepartamento.SelectedItem;
                }
                else
                {
                    contato.Departamento = 0;
                }
                
                contato.Tipo = Tipo.Fisica;

                if(listEmail != null || listEmail.Count != 0)
                {
                    bemail = true;
                    contato.Emails = listEmail;
                }

                if (listTelefone != null || listTelefone.Count != 0)
                {
                    btelefone = true;
                    contato.Telefones = listTelefone;
                }
                

                if(cbVinculado.SelectedItem != null)
                {
                    contato.ContatoJuridico = (ContatoJuridico)cbVinculado.SelectedItem;
                }
                
                if(bemail.Equals(false) && btelefone.Equals(false))
                {
                    MessageBox.Show("Informe um endereço de email ou número de telefone para este contato.");
                }
                else
                {
                    if (bnome.Equals(false))
                    {
                        MessageBox.Show("Por favor, informe um nome para este contato.");
                    }
                    else
                    {
                        controleContato.salvarContato(contato);
                        MessageBox.Show("Novo contato pessoa fisica cadasatrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        limparCampos();
                    }
                }
                
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool bnome = false;
                bool bemail = false;
                bool btelefone = false;

                if (txtNome.Text != null || txtNome.Text != "")
                {
                    bnome = true;
                    contato.Nome = txtNome.Text;
                }


                contato.Descricao = txtDescricao.Text;

                if (cbDepartamento.SelectedItem != null)
                {
                    contato.Departamento = (Departamento)cbDepartamento.SelectedItem;
                }
                else
                {
                    contato.Departamento = 0;
                }

                contato.Tipo = Tipo.Fisica;

                if (listEmail != null || listEmail.Count != 0)
                {
                    bemail = true;
                    contato.Emails = listEmail;
                }

                if (listTelefone != null || listTelefone.Count != 0)
                {
                    btelefone = true;
                    contato.Telefones = listTelefone;
                }


                if (cbVinculado.SelectedItem != null)
                {
                    contato.ContatoJuridico = (ContatoJuridico)cbVinculado.SelectedItem;
                }

                if (bemail.Equals(false) && btelefone.Equals(false))
                {
                    MessageBox.Show("Informe um endereço de email ou número de telefone para este contato.");
                }
                else
                {
                    if (bnome.Equals(false))
                    {
                        MessageBox.Show("Por favor, informe um nome para este contato.");
                    }
                    else
                    {
                        controleContato.Modificar(contato);
                        MessageBox.Show("Contato pessoa fisica alterado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        limparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAddEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                if (controleContato.validaEmail(txtEmail.Text))
                {
                    Email email = new Email();
                    email.EndEmail = txtEmail.Text;
                    email.Departamento = 0;
                    listEmail.Add(email);
                    DGEmail.ItemsSource = null;

                    DGEmail.ItemsSource = listEmail;
                    limparCamposEmail();
                }
                else
                {
                    MessageBox.Show("Um ou mais caracteres inválidos para email!", "Email Inválido");
                }
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
                if (controleContato.ValidarTelefone(txtTelefone.Text))
                {
                    Telefone telefone = new Telefone();
                    telefone.NumTelefone = txtTelefone.Text;
                    telefone.Celular = chCelular.IsChecked.Value;
                    telefone.Whatsapp = chWhatsapp.IsChecked.Value;
                    telefone.Departamento = 0;

                    listTelefone.Add(telefone);
                    DGTelefone.ItemsSource = null;

                    DGTelefone.ItemsSource = listTelefone;

                    limparCamposTelefone();
                }
                else
                {
                    MessageBox.Show("Um ou mais caracteres inválidos para telefone!", "Telefone Inválido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExcluirTel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Telefone dataGridRow = DGTelefone.SelectedItem as Telefone;

                if (dataGridRow != null)
                {
                    listTelefone.Remove(dataGridRow);

                    DGTelefone.ItemsSource = null;

                    DGTelefone.ItemsSource = listTelefone;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExcluirEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Email dataGridRow = DGEmail.SelectedItem as Email;

                if (dataGridRow != null)
                {
                    listEmail.Remove(dataGridRow);

                    DGEmail.ItemsSource = null;

                    DGEmail.ItemsSource = listEmail;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limparCamposEmail()
        {
            txtEmail.Text = "";
        }

        private void limparCamposTelefone()
        {
            txtTelefone.Text = "";
            chCelular.IsChecked = false;
            chWhatsapp.IsChecked = false;
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";

            if(cbDepartamento.SelectedItem != null)
            {
                cbDepartamento.SelectedItem = null;
            }
            if(cbVinculado.SelectedItem != null)
            {
                cbVinculado.SelectedItem = null;
            }
            if(DGEmail.ItemsSource != null)
            {
                DGEmail.ItemsSource = null;
            }
            if(DGTelefone.ItemsSource != null)
            {
                DGTelefone.ItemsSource = null;
            }
            
            listEmail = null;
            listTelefone = null;
            chWhatsapp.IsChecked = false;
            chCelular.IsChecked = false;
        }

        private void ChCelular_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chCelular.IsChecked.Equals(true))
                {
                    chWhatsapp.IsEnabled = true;
                }
                else
                {
                    chWhatsapp.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
