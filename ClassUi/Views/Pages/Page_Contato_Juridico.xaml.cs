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
using ClassModel;
using ClassControle;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para Page_Contato_Juridico.xam
    /// </summary>
    public partial class Page_Contato_Juridico : Page
    {
        #region Variaveis
        private ControleContatoJuridico controleContato = new ControleContatoJuridico();
        private ICollection<Telefone> listTelefone = new List<Telefone>();
        private ICollection<Email> listEmail = new List<Email>();
        private ICollection<ContatoJuridico> auditoria = new List<ContatoJuridico>();
        private ICollection<ContatoJuridico> organizacaoSocial = new List<ContatoJuridico>();

        private List<ContatoJuridico> listAuditoria = new List<ContatoJuridico>();
        private List<ContatoJuridico> listOrganizacaoSocial = new List<ContatoJuridico>();

        private ContatoJuridico contatoJuridico = new ContatoJuridico();

        #endregion

        public Page_Contato_Juridico(bool editar, ContatoJuridico c)
        {
            InitializeComponent();

            cbCategoria.ItemsSource = Enum.GetValues(typeof(Categoria)).Cast<Categoria>();
            cbDepEmail.ItemsSource = Enum.GetValues(typeof(Departamento)).Cast<Departamento>();
            cbDepTelefone.ItemsSource = Enum.GetValues(typeof(Departamento)).Cast<Departamento>();
            auditoria = controleContato.ListarContatoJuridico();

            contatoJuridico = c;

            ControlePagina(editar, contatoJuridico);
        }

        private void ControlePagina(bool editar, ContatoJuridico c)
        {
            cbVinculado.IsEnabled = false;
            cbOrganizacaoSocial.IsEnabled = false;

            if (editar.Equals(true))
            {
                btnGravar.IsEnabled = false;
                btnEditar.IsEnabled = true;

                foreach(ContatoJuridico cj in auditoria)
                {
                    if (cj.Categoria.Equals(Categoria.Auditoria))
                    {
                        cbVinculado.Items.Add(cj);
                    }
                    else if (cj.Categoria.Equals(Categoria.Organização_Social))
                    {
                        cbOrganizacaoSocial.Items.Add(cj);
                    }
                }

                cbCategoria.SelectedItem = c.Categoria;
                txtNome.Text = c.Nome;
                txtDescricao.Text = c.Descricao;

                if (c.Categoria.Equals(Categoria.Unidade_de_Saúde))
                {
                    cbVinculado.IsEnabled = true;
                    cbOrganizacaoSocial.IsEnabled = true;

                    for (int i = 0; i < auditoria.Count; i++)
                    {
                        if (auditoria.ToList()[i].ToString().Equals(c.Auditoria.ToString()))
                        {
                            cbVinculado.SelectedIndex = i;
                        }
                    }

                    for (int i = 0; i < organizacaoSocial.Count; i++)
                    {
                        if (organizacaoSocial.ToList()[i].ToString().Equals(c.OrganizacaoSocial.ToString()))
                        {
                            cbOrganizacaoSocial.SelectedIndex = i;
                        }
                    }
                }

                listEmail = c.Emails;
                listTelefone = c.Telefones;

                DGEmail.ItemsSource = listEmail;
                DGTelefone.ItemsSource = listTelefone;
            }
            else
            {
                btnGravar.IsEnabled = true;
                btnEditar.IsEnabled = false;

                foreach (ContatoJuridico cj in auditoria)
                {
                    if (cj.Categoria.Equals(Categoria.Auditoria))
                    {
                        cbVinculado.Items.Add(cj);
                    }
                    else if (cj.Categoria.Equals(Categoria.Organização_Social))
                    {
                        cbOrganizacaoSocial.Items.Add(cj);
                    }
                }
            }
        }

        private void BtnAddEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (controleContato.validaEmail(txtEmail.Text))
                {
                    if(cbDepEmail.SelectedItem != null || cbDepEmail.SelectedItem.ToString() != "")
                    {
                        Email email = new Email();
                        email.EndEmail = txtEmail.Text;
                        email.Departamento = (Departamento)cbDepEmail.SelectedItem;
                        listEmail.Add(email);
                        DGEmail.ItemsSource = null;

                        DGEmail.ItemsSource = listEmail;
                        limparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Selecione um departamento para o email");
                    }
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
                    if(cbDepTelefone.SelectedItem != null || cbDepTelefone.SelectedItem.ToString() != "")
                    {
                        Telefone telefone = new Telefone();
                        telefone.NumTelefone = txtTelefone.Text;
                        telefone.Departamento = (Departamento)cbDepTelefone.SelectedItem;
                        telefone.Celular = chCelular.IsChecked.Value;
                        telefone.Whatsapp = chWhatsapp.IsChecked.Value;

                        listTelefone.Add(telefone);
                        DGTelefone.ItemsSource = null;

                        DGTelefone.ItemsSource = listTelefone;

                        limparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Selecione uma departamento");
                    }
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

        private void BtnGravar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contatoJuridico.Nome = txtNome.Text;
                contatoJuridico.Descricao = txtDescricao.Text;
                contatoJuridico.Categoria = (Categoria)cbCategoria.SelectedItem;
                contatoJuridico.Tipo = Tipo.Juridica;
                contatoJuridico.Emails = listEmail;
                contatoJuridico.Telefones = listTelefone;
                contatoJuridico.Auditoria = (ContatoJuridico)cbVinculado.SelectedItem;

                controleContato.salvarContatoJuridico(contatoJuridico);

                MessageBox.Show("Novo contato jurídico gravado com sucesso!", "Sucesso");
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
                contatoJuridico.Nome = txtNome.Text;
                contatoJuridico.Descricao = txtDescricao.Text;
                contatoJuridico.Categoria = (Categoria)cbCategoria.SelectedItem;
                contatoJuridico.Tipo = Tipo.Juridica;
                contatoJuridico.Emails = listEmail;
                contatoJuridico.Telefones = listTelefone;
                contatoJuridico.Auditoria = (ContatoJuridico)cbVinculado.SelectedItem;

                controleContato.Modificar(contatoJuridico);

                MessageBox.Show("Novo contato jurídico gravado com sucesso!", "Sucesso");
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
            cbDepEmail.SelectedItem = null;
            cbDepTelefone.SelectedItem = null;
            chCelular.IsChecked = false;
            chWhatsapp.IsChecked = false;
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

        private void CbCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbCategoria.SelectedItem.Equals(Categoria.Unidade_de_Saúde))
                {
                    cbVinculado.IsEnabled = true;
                    cbOrganizacaoSocial.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
