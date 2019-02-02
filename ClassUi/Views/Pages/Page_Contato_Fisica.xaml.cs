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
        
        #endregion

        public Page_Contato_Fisica(bool editar, Contato c)
        {
            InitializeComponent();
            
            cbDepartamento.ItemsSource = Enum.GetValues(typeof(Departamento)).Cast<Departamento>();
            cbVinculado.ItemsSource = controleJuridico.ListarContatoJuridico();

            this.contato = c;

            ControlePagina(editar, contato);
        }

        private void ControlePagina(bool editar, Contato c)
        {
            if (editar.Equals(true))
            {
                btnGravar.IsEnabled = false;
                btnEditar.IsEnabled = true;

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
            }
        }

        private void BtnGravar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contato.Nome = txtNome.Text;
                contato.Descricao = txtDescricao.Text;
                contato.Departamento = (Departamento)cbDepartamento.SelectedItem;
                contato.Tipo = Tipo.Fisica;
                contato.Emails = listEmail;
                contato.Telefones = listTelefone;
                contato.ContatoJuridico = (ContatoJuridico)cbVinculado.SelectedItem;

                controleContato.salvarContato(contato);

                MessageBox.Show("Novo contato pessoa fisica cadasatrado com sucesso!", "Sucesso");
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
                contato.Nome = txtNome.Text;
                contato.Descricao = txtDescricao.Text;
                contato.Departamento = (Departamento)cbDepartamento.SelectedItem;
                contato.Tipo = Tipo.Fisica;
                contato.Emails = listEmail;
                contato.Telefones = listTelefone;
                contato.ContatoJuridico = (ContatoJuridico)cbVinculado.SelectedItem;

                controleContato.Modificar(contato);

                MessageBox.Show("Novo contato pessoa fisica cadasatrado com sucesso!", "Sucesso");
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
                    limparCampos();
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

                    limparCampos();
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

        private void limparCampos()
        {
            txtEmail.Text = "";
            txtTelefone.Text = "";
            chCelular.IsChecked = false;
            chWhatsapp.IsChecked = false;
        }
    }
}
