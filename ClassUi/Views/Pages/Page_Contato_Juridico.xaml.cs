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
            organizacaoSocial = controleContato.ListarContatoJuridico();

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
                        if(c.Auditoria!= null)
                        {
                            if (auditoria.ToList()[i].ToString().Equals(c.Auditoria.ToString()))
                            {
                                cbVinculado.SelectedIndex = i;
                            }
                        }
                    }

                    for (int i = 0; i < organizacaoSocial.Count; i++)
                    {
                        if(c.OrganizacaoSocial!= null)
                        {
                            if (organizacaoSocial.ToList()[i].ToString().Equals(c.OrganizacaoSocial.ToString()))
                            {
                                cbOrganizacaoSocial.SelectedIndex = i;
                            }
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
                    if(cbDepEmail.SelectedItem != null)
                    {
                        Email email = new Email();
                        email.EndEmail = txtEmail.Text;
                        email.Departamento = (Departamento)cbDepEmail.SelectedItem;
                        listEmail.Add(email);
                        DGEmail.ItemsSource = null;

                        DGEmail.ItemsSource = listEmail;
                        limparCamposEmail();
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
                    if(cbDepTelefone.SelectedItem != null)
                    {
                        Telefone telefone = new Telefone();
                        telefone.NumTelefone = txtTelefone.Text;
                        telefone.Departamento = (Departamento)cbDepTelefone.SelectedItem;
                        telefone.Celular = chCelular.IsChecked.Value;
                        telefone.Whatsapp = chWhatsapp.IsChecked.Value;

                        listTelefone.Add(telefone);
                        DGTelefone.ItemsSource = null;

                        DGTelefone.ItemsSource = listTelefone;

                        limparCamposTelefone();
                    }
                    else
                    {
                        MessageBox.Show("Selecione uma departamento para o telefone");
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
                contatoJuridico = new ContatoJuridico();

                bool bnome = false;
                bool bcategoria = false;
                bool bemail = false;
                bool btelefone = false;

                if(txtNome.Text != null|| txtNome.Text != "")
                {
                    bnome = true;
                    contatoJuridico.Nome = txtNome.Text;
                }
                else
                {
                    MessageBox.Show("Informe um nome!");
                }
                
                if(txtDescricao.Text != null || txtDescricao.Text != "")
                {
                    contatoJuridico.Descricao = txtDescricao.Text;
                }
                else
                {
                    MessageBox.Show("Informe uma descrição!");
                }

                if (cbCategoria.SelectedItem != null)
                {
                    bcategoria = true;
                    contatoJuridico.Categoria = (Categoria)cbCategoria.SelectedItem;
                }
                else
                {
                    contatoJuridico.Categoria = 0;
                }
                
                contatoJuridico.Tipo = Tipo.Juridica;

                if(listEmail.Count == 0 && listTelefone.Count == 0)
                {
                    MessageBox.Show("Informe um endereço de email ou um número de telefone para continuar com o processo de cadastro");
                }

                if(listEmail.Count != 0)
                {
                    bemail = true;
                    contatoJuridico.Emails = listEmail;
                }

                if(listTelefone.Count != 0)
                {
                    btelefone = true;
                    contatoJuridico.Telefones = listTelefone;
                }
                
                if(cbVinculado.SelectedItem != null)
                {
                    contatoJuridico.Auditoria = (ContatoJuridico)cbVinculado.SelectedItem;
                }
                else
                {
                    contatoJuridico.Auditoria = null;
                }

                if (cbOrganizacaoSocial.SelectedItem != null)
                {
                    contatoJuridico.OrganizacaoSocial = (ContatoJuridico)cbOrganizacaoSocial.SelectedItem;
                }
                else
                {
                    contatoJuridico.OrganizacaoSocial = null;
                }


                if (bnome.Equals(false)|| bcategoria.Equals(false) || bemail.Equals(false) && btelefone.Equals(false))
                {
                    MessageBox.Show("Um ou mais dados obrigatórios estão ausentes (Nome, Categoria, Email ou Telefone).");
                }
                else
                {
                    controleContato.salvarContatoJuridico(contatoJuridico);
                    MessageBox.Show("Novo contato jurídico gravado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    limparCampos();
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
                bool bcategoria = false;
                bool bemail = false;
                bool btelefone = false;

                if (txtNome.Text != null || txtNome.Text != "")
                {
                    bnome = true;
                    contatoJuridico.Nome = txtNome.Text;
                }
                else
                {
                    MessageBox.Show("Informe um nome!");
                }

                if (txtDescricao.Text != null || txtDescricao.Text != "")
                {
                    contatoJuridico.Descricao = txtDescricao.Text;
                }
                else
                {
                    MessageBox.Show("Informe uma descrição!");
                }

                if (cbCategoria.SelectedItem != null)
                {
                    bcategoria = true;
                    contatoJuridico.Categoria = (Categoria)cbCategoria.SelectedItem;
                }
                else
                {
                    contatoJuridico.Categoria = 0;
                }

                contatoJuridico.Tipo = Tipo.Juridica;

                if (listEmail.Count == 0 && listTelefone.Count == 0)
                {
                    MessageBox.Show("Informe um endereço de email ou um número de telefone para continuar com o processo de cadastro");
                }

                if (listEmail.Count != 0)
                {
                    bemail = true;
                    contatoJuridico.Emails = listEmail;
                }

                if (listTelefone.Count != 0)
                {
                    btelefone = true;
                    contatoJuridico.Telefones = listTelefone;
                }

                if (cbVinculado.SelectedItem != null)
                {
                    contatoJuridico.Auditoria = (ContatoJuridico)cbVinculado.SelectedItem;
                }

                if (cbOrganizacaoSocial.SelectedItem != null)
                {
                    contatoJuridico.OrganizacaoSocial = (ContatoJuridico)cbOrganizacaoSocial.SelectedItem;
                }


                if (bnome.Equals(false) || bcategoria.Equals(false) || bemail.Equals(false) && btelefone.Equals(false))
                {
                    MessageBox.Show("Um ou mais dados obrigatórios estão ausentes (Nome, Categoria, Email ou Telefone).");
                }
                else
                {
                    controleContato.Modificar(contatoJuridico);
                    MessageBox.Show("Contato jurídico modificado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    limparCampos();
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
            cbDepEmail.SelectedItem = null;
        }

        private void limparCamposTelefone()
        {
            txtTelefone.Text = "";
            cbDepTelefone.SelectedItem = null;
            chCelular.IsChecked = false;
            chWhatsapp.IsChecked = false;
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtEmail.Text = "";
            txtNome.Text = "";

            if(DGEmail.ItemsSource != null)
            {
                DGEmail.ItemsSource = null;
            }
            if(DGTelefone.ItemsSource != null)
            {
                DGTelefone.ItemsSource = null;
            }
            if(cbCategoria.SelectedItem != null)
            {
                cbCategoria.SelectedItem = null;
            }
            if(cbDepEmail.SelectedItem != null)
            {
                cbDepEmail.SelectedItem = null;
            }
            if(cbDepTelefone.SelectedItem != null)
            {
                cbDepTelefone.SelectedItem = null;
            }
            if(cbVinculado.SelectedItem != null)
            {
                cbVinculado.SelectedItem = null;
            }
            if(cbOrganizacaoSocial.SelectedItem != null)
            {
                cbOrganizacaoSocial.SelectedItem = null;
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
                else
                {
                    cbVinculado.SelectedItem = null;
                    cbOrganizacaoSocial.SelectedItem = null;
                    cbVinculado.IsEnabled = false;
                    cbOrganizacaoSocial.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}