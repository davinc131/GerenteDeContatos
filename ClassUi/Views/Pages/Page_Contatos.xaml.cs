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
using System.Windows.Threading;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para Page_Contatos.xam
    /// </summary>
    public sealed partial class Page_Contatos : Page
    {
        #region Variaveis

        private static ControleContato controleContato = new ControleContato();
        private static ControleContatoJuridico controleJuridico = new ControleContatoJuridico();
        private static ICollection<Telefone> listTelefonePFisico = new List<Telefone>();
        private static ICollection<Email> listEmailPFisico = new List<Email>();
        private static Contato contato = new Contato();
        private static ContatoJuridico contatoJ = new ContatoJuridico();

        private static ICollection<Telefone> listTelefonePJuridica = new List<Telefone>();
        private static ICollection<Email> listEmailPJuridica = new List<Email>();
        private static ICollection<ContatoJuridico> auditoriaPJuridica = new List<ContatoJuridico>();
        private static ICollection<ContatoJuridico> organizacaoSocialPJuridica = new List<ContatoJuridico>();

        private static List<ContatoJuridico> listAuditoria = new List<ContatoJuridico>();
        private static List<ContatoJuridico> listOrganizacaoSocial = new List<ContatoJuridico>();

        private static ContatoJuridico contatoJuridico = new ContatoJuridico();

        private DispatcherTimer timer;

        #endregion

        #region Singleton

        private delegate void DelegateInstance(bool editar, ContatoJuridico contato);

        private static Page_Contatos instance;

        public static Page_Contatos Instance()
        {
            lock (typeof(Page_Contatos))
                if (instance == null)
                {
                    instance = new Page_Contatos();
                }

            return instance;
        }

        public static Page_Contatos Instance(bool editar, ContatoJuridico c)
        {
            lock (typeof(Page_Contatos))
                if (instance == null)
                {
                    instance = new Page_Contatos(editar, c);
                }

            return instance;
        }

        public static Page_Contatos Instance(bool editar, Contato c)
        {
            lock (typeof(Page_Contatos))
                if (instance == null)
                {
                    instance = new Page_Contatos(editar, c);
                }

            return instance;
        }

        #endregion

        #region Construtores

        public Page_Contatos(bool editar, ContatoJuridico c)
        {
            InitializeComponent();

            CarregarComboVinculadoOS();
            InitPF();
            InitPJ();
            contatoJ = c;
            ControleAbaPJuridico(editar, c);
        }

        public Page_Contatos(bool editar, Contato c)
        {
            InitializeComponent();

            CarregarComboVinculadoOS();
            InitPF();
            InitPJ();
            contato = c;
            ControleAbaPFisica(editar, contato);
        }

        public Page_Contatos()
        {
            InitializeComponent();

            CarregarComboVinculadoOS();
            InitPF();
            InitPJ();
            ControlePagina();
        }

        public void CarregarFisico(bool editar, Contato c)
        {
            try
            {
                ControleAbaPFisica(editar, c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        public void CarregarJuridico(bool editar, ContatoJuridico ct)
        {
            try
            {
                ControleAbaPJuridico(editar, ct);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
        }

        #endregion

        #region Carregar ComboBox

        private void CarregarComboVinculadoOS()
        {
            try
            {
                List<ContatoJuridico> j = new List<ContatoJuridico>();
                j = controleJuridico.ListarContatoJuridico();

                foreach(ContatoJuridico c in j)
                {
                    if (c.Categoria.Equals(Categoria.Auditoria)){
                        listAuditoria.Add(c);
                    }

                    if (c.Categoria.Equals(Categoria.Organização_Social))
                    {
                        listOrganizacaoSocial.Add(c);
                    }
                }

                cbVinculadoPJuridica.ItemsSource = listAuditoria;
                cbOrganizacaoSocialPJuridica.ItemsSource = listOrganizacaoSocial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Pessoa Física

        private void InitPF()
        {
            try
            {
                cbDepartamentoPFisico.ItemsSource = Enum.GetValues(typeof(Departamento)).Cast<Departamento>();
                cbVinculadoPFisico.ItemsSource = controleJuridico.ListarContatoJuridico();

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

        public void ControleAbaPFisica(bool editar, Contato c)
        {
            if (editar.Equals(true))
            {
                CarregarComboVinculadoOS();
                contato = controleContato.ListarPorParametro(c.Nome)[0];

                btnGravarPFisico.IsEnabled = false;
                btnEditarPFisico.IsEnabled = true;
                chWhatsappPFisico.IsEnabled = false;
                tcContatos.SelectedItem = tabFisica;

                tabPJuridica.IsEnabled = false;

                listEmailPFisico = c.Emails;
                listTelefonePFisico = c.Telefones;

                txtNomePFisico.Text = c.Nome;
                txtDescricaoPFisico.Text = c.Descricao;
                DGEmailPFisico.ItemsSource = listEmailPFisico;
                DGTelefonePFisico.ItemsSource = listTelefonePFisico;
                cbDepartamentoPFisico.SelectedItem = c.Departamento;

                for (int i = 0; i < cbVinculadoPFisico.Items.Count; i++)
                {
                    if (c.ContatoJuridico.ToString().Equals(cbVinculadoPFisico.Items[i].ToString()))
                    {
                        cbVinculadoPFisico.SelectedIndex = i;
                    }
                }
            }
            else
            {
                btnGravarPFisico.IsEnabled = true;
                btnEditarPFisico.IsEnabled = false;
                chWhatsappPFisico.IsEnabled = false;
            }
        }

        private void ChCelularPFisico_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chCelularPFisico.IsChecked.Equals(true))
                {
                    chWhatsappPFisico.IsEnabled = true;
                }
                else
                {
                    chWhatsappPFisico.IsEnabled = false;
                    chWhatsappPFisico.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExcluirTelPFisico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Telefone dataGridRow = DGTelefonePFisico.SelectedItem as Telefone;

                if (dataGridRow != null)
                {
                    listTelefonePFisico.Remove(dataGridRow);

                    DGTelefonePFisico.ItemsSource = null;

                    DGTelefonePFisico.ItemsSource = listTelefonePFisico;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAddTelefonePFisico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (controleContato.ValidarTelefone(txtTelefone.Text))
                {
                    Telefone telefone = new Telefone();
                    telefone.NumTelefone = txtTelefone.Text;
                    telefone.Celular = chCelularPFisico.IsChecked.Value;
                    telefone.Whatsapp = chWhatsappPFisico.IsChecked.Value;
                    telefone.Departamento = 0;

                    listTelefonePFisico.Add(telefone);
                    DGTelefonePFisico.ItemsSource = null;

                    DGTelefonePFisico.ItemsSource = listTelefonePFisico;

                    limparCamposTelefonePFisica();
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

        private void BtnAddEmailPFisico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (controleContato.validaEmail(txtEmail.Text))
                {
                    Email email = new Email();
                    email.EndEmail = txtEmail.Text;
                    email.Departamento = 0;
                    listEmailPFisico.Add(email);
                    DGEmailPFisico.ItemsSource = null;

                    DGEmailPFisico.ItemsSource = listEmailPFisico;
                    limparCamposEmailPFisica();
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

        private void BtnGravarPFisico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (controleContato.ConsultarPorNome(txtNomePFisico.Text) != null)
                {
                    MessageBox.Show("Este nome de contato já existe no banco de dados. Por favor, verifique a listagem.");
                }
                else
                {
                    bool bnome = false;
                    bool bemail = false;
                    bool btelefone = false;

                    contato = new Contato();

                    if (txtNomePFisico.Text != "")
                    {
                        bnome = true;
                        contato.Nome = txtNomePFisico.Text;
                    }


                    contato.Descricao = txtDescricaoPFisico.Text;

                    if (cbDepartamentoPFisico.SelectedItem != null)
                    {
                        contato.Departamento = (Departamento)cbDepartamentoPFisico.SelectedItem;
                    }
                    else
                    {
                        contato.Departamento = 0;
                    }

                    contato.Tipo = Tipo.Fisica;

                    if (listEmailPFisico.Count != 0)
                    {
                        bemail = true;
                        contato.Emails = listEmailPFisico;
                    }

                    if (listTelefonePFisico.Count != 0)
                    {
                        btelefone = true;
                        contato.Telefones = listTelefonePFisico;
                    }


                    if (cbVinculadoPFisico.SelectedItem != null)
                    {
                        contato.ContatoJuridico = (ContatoJuridico)cbVinculadoPFisico.SelectedItem;
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
                            controleContato.salvarContato(contato);
                            MessageBox.Show("Novo contato pessoa fisica cadasatrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                            limparCamposPFisica();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditarPFisico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool bnome = false;
                bool bemail = false;
                bool btelefone = false;

                if (txtNomePFisico.Text != "")
                {
                    bnome = true;
                    contato.Nome = txtNomePFisico.Text;
                }


                contato.Descricao = txtDescricaoPFisico.Text;

                if (cbDepartamentoPFisico.SelectedItem != null)
                {
                    contato.Departamento = (Departamento)cbDepartamentoPFisico.SelectedItem;
                }
                else
                {
                    contato.Departamento = 0;
                }

                contato.Tipo = Tipo.Fisica;

                if (listEmailPFisico.Count != 0)
                {
                    bemail = true;
                    contato.Emails = listEmailPFisico;
                }

                if (listTelefonePFisico.Count != 0)
                {
                    btelefone = true;
                    contato.Telefones = listTelefonePFisico;
                }


                if (cbVinculadoPFisico.SelectedItem != null)
                {
                    contato.ContatoJuridico = (ContatoJuridico)cbVinculadoPFisico.SelectedItem;
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
                        limparCamposPFisica();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnListarPFisico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Page_Listar_Contatos p = Page_Listar_Contatos.Instance();
                p.ControlePagina(false);
                ViewContatoJuridico v = new ViewContatoJuridico();

                v.AbrirDeUmaPagina(p);
                v.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExcluirEmailPFisico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Email dataGridRow = DGEmailPFisico.SelectedItem as Email;

                if (dataGridRow != null)
                {
                    listEmailPFisico.Remove(dataGridRow);

                    DGEmailPFisico.ItemsSource = null;

                    DGEmailPFisico.ItemsSource = listEmailPFisico;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limparCamposEmailPFisica()
        {
            txtEmail.Text = "";
        }

        private void limparCamposTelefonePFisica()
        {
            txtTelefone.Text = "";
            chCelularPFisico.IsChecked = false;
            chWhatsappPFisico.IsChecked = false;
        }

        private void limparCamposPFisica()
        {
            txtNomePFisico.Text = "";
            txtDescricaoPFisico.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";

            if (cbDepartamentoPFisico.SelectedItem != null)
            {
                cbDepartamentoPFisico.SelectedItem = null;
            }
            if (cbVinculadoPFisico.SelectedItem != null)
            {
                cbVinculadoPFisico.SelectedItem = null;
            }
            if (DGEmailPFisico.ItemsSource != null)
            {
                DGEmailPFisico.ItemsSource = null;
            }
            if (DGTelefonePFisico.ItemsSource != null)
            {
                DGTelefonePFisico.ItemsSource = null;
            }

            listEmailPFisico = null;
            listTelefonePFisico = null;
            chWhatsappPFisico.IsChecked = false;
            chCelularPFisico.IsChecked = false;
        }

        #endregion

        #region Pessoa Jurídica

        private void InitPJ()
        {
            try
            {
                cbCategoriaPJuridica.ItemsSource = Enum.GetValues(typeof(Categoria)).Cast<Categoria>();
                cbDepEmailPJuridica.ItemsSource = Enum.GetValues(typeof(Departamento)).Cast<Departamento>();
                cbDepTelefonePJuridica.ItemsSource = Enum.GetValues(typeof(Departamento)).Cast<Departamento>();
                auditoriaPJuridica = controleJuridico.ListarContatoJuridico();
                organizacaoSocialPJuridica = controleJuridico.ListarContatoJuridico();

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

        public void ControleAbaPJuridico(bool editar, ContatoJuridico c)
        {
            CarregarComboVinculadoOS();
            cbVinculadoPJuridica.IsEnabled = false;
            cbOrganizacaoSocialPJuridica.IsEnabled = false;
            chWhatsappPJuridica.IsEnabled = false;
            tcContatos.SelectedItem = tabPJuridica;

            if (editar.Equals(true))
            {
                contatoJuridico = controleJuridico.ConsultarPorNome(c.Nome);

                btnGravarPJuridica.IsEnabled = false;
                btnEditarPJuridica.IsEnabled = true;
                tabFisica.IsEnabled = false;

                cbCategoriaPJuridica.SelectedItem = c.Categoria;
                txtNomePJuridica.Text = c.Nome;
                txtDescricaoPJuridica.Text = c.Descricao;

                if (c.Categoria.Equals(Categoria.Unidade_de_Saúde))
                {
                    cbVinculadoPJuridica.IsEnabled = true;
                    cbOrganizacaoSocialPJuridica.IsEnabled = true;

                    for (int i = 0; i < auditoriaPJuridica.Count; i++)
                    {
                        if (c.Auditoria != null)
                        {
                            if (auditoriaPJuridica.ToList()[i].ToString().Equals(c.Auditoria.ToString()))
                            {
                                cbVinculadoPJuridica.SelectedIndex = i;
                            }
                        }
                    }

                    for (int i = 0; i < organizacaoSocialPJuridica.Count; i++)
                    {
                        if (c.OrganizacaoSocial != null)
                        {
                            if (organizacaoSocialPJuridica.ToList()[i].ToString().Equals(c.OrganizacaoSocial.ToString()))
                            {
                                cbOrganizacaoSocialPJuridica.SelectedIndex = i;
                            }
                        }
                    }
                }

                listEmailPJuridica = c.Emails;
                listTelefonePJuridica = c.Telefones;

                DGEmailPJuridica.ItemsSource = listEmailPJuridica;
                DGTelefonePJuridica.ItemsSource = listTelefonePJuridica;
            }
            else
            {
                btnGravarPJuridica.IsEnabled = true;
                btnEditarPJuridica.IsEnabled = false;
            }
        }

        private void BtnGravarPJuridica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (controleJuridico.ConsultarPorNome(txtNomePJuridica.Text) != null)
                {
                    MessageBox.Show("Este nome de contato já existe no banco de dados. Por favor, verifique a listagem.");
                }
                else
                {
                    contatoJuridico = new ContatoJuridico();

                    bool bnome = false;
                    bool bcategoria = false;
                    bool bemail = false;
                    bool btelefone = false;

                    if (txtNomePJuridica.Text != "")
                    {
                        bnome = true;
                        contatoJuridico.Nome = txtNomePJuridica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Informe um nome!");
                    }

                    if (txtDescricaoPJuridica.Text != "")
                    {
                        contatoJuridico.Descricao = txtDescricaoPJuridica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Informe uma descrição!");
                    }

                    if (cbCategoriaPJuridica.SelectedItem != null)
                    {
                        bcategoria = true;
                        contatoJuridico.Categoria = (Categoria)cbCategoriaPJuridica.SelectedItem;
                    }
                    else
                    {
                        contatoJuridico.Categoria = 0;
                    }

                    contatoJuridico.Tipo = Tipo.Juridica;

                    if (listEmailPJuridica.Count == 0 && listTelefonePJuridica.Count == 0)
                    {
                        MessageBox.Show("Informe um endereço de email ou um número de telefone para continuar com o processo de cadastro");
                    }

                    if (listEmailPJuridica.Count != 0)
                    {
                        bemail = true;
                        contatoJuridico.Emails = listEmailPJuridica;
                    }

                    if (listTelefonePJuridica.Count != 0)
                    {
                        btelefone = true;
                        contatoJuridico.Telefones = listTelefonePJuridica;
                    }

                    if (cbVinculadoPJuridica.SelectedItem != null)
                    {
                        contatoJuridico.Auditoria = (ContatoJuridico)cbVinculadoPJuridica.SelectedItem;
                    }
                    else
                    {
                        contatoJuridico.Auditoria = null;
                    }

                    if (cbOrganizacaoSocialPJuridica.SelectedItem != null)
                    {
                        contatoJuridico.OrganizacaoSocial = (ContatoJuridico)cbOrganizacaoSocialPJuridica.SelectedItem;
                    }
                    else
                    {
                        contatoJuridico.OrganizacaoSocial = null;
                    }


                    if (bnome.Equals(false) || bcategoria.Equals(false) || bemail.Equals(false) && btelefone.Equals(false))
                    {
                        MessageBox.Show("Um ou mais dados obrigatórios estão ausentes (Nome, Categoria, Email ou Telefone).");
                    }
                    else
                    {
                        controleJuridico.salvarContatoJuridico(contatoJuridico);
                        MessageBox.Show("Novo contato jurídico gravado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                        limparCamposPJuridica();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnListarPJuridica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Page_Listar_Contatos p = Page_Listar_Contatos.Instance();
                p.ControlePagina(true);
                ViewContatoJuridico v = ViewContatoJuridico.Instance();
                v.AbrirDeUmaPagina(p);
                v.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditarPJuridica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool bnome = false;
                bool bcategoria = false;
                bool bemail = false;
                bool btelefone = false;

                if (txtNomePJuridica.Text != "")
                {
                    bnome = true;
                    contatoJuridico.Nome = txtNomePJuridica.Text;
                }
                else
                {
                    MessageBox.Show("Informe um nome!");
                }

                if (txtDescricaoPJuridica.Text != "")
                {
                    contatoJuridico.Descricao = txtDescricaoPJuridica.Text;
                }
                else
                {
                    MessageBox.Show("Informe uma descrição!");
                }

                if (cbCategoriaPJuridica.SelectedItem != null)
                {
                    bcategoria = true;
                    contatoJuridico.Categoria = (Categoria)cbCategoriaPJuridica.SelectedItem;
                }
                else
                {
                    contatoJuridico.Categoria = 0;
                }

                contatoJuridico.Tipo = Tipo.Juridica;

                if (listEmailPJuridica.Count == 0 && listTelefonePJuridica.Count == 0)
                {
                    MessageBox.Show("Informe um endereço de email ou um número de telefone para continuar com o processo de cadastro");
                }

                if (listEmailPJuridica.Count != 0)
                {
                    bemail = true;
                    contatoJuridico.Emails = listEmailPJuridica;
                }

                if (listTelefonePJuridica.Count != 0)
                {
                    btelefone = true;
                    contatoJuridico.Telefones = listTelefonePJuridica;
                }

                if (cbVinculadoPJuridica.SelectedItem != null)
                {
                    contatoJuridico.Auditoria = (ContatoJuridico)cbVinculadoPJuridica.SelectedItem;
                }

                if (cbOrganizacaoSocialPJuridica.SelectedItem != null)
                {
                    contatoJuridico.OrganizacaoSocial = (ContatoJuridico)cbOrganizacaoSocialPJuridica.SelectedItem;
                }


                if (bnome.Equals(false) || bcategoria.Equals(false) || bemail.Equals(false) && btelefone.Equals(false))
                {
                    MessageBox.Show("Um ou mais dados obrigatórios estão ausentes (Nome, Categoria, Email ou Telefone).");
                }
                else
                {
                    controleJuridico.Modificar(contatoJuridico);
                    MessageBox.Show("Contato jurídico modificado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    limparCamposPJuridica();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExcluirTelPJuridica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Telefone dataGridRow = DGTelefonePJuridica.SelectedItem as Telefone;

                if (dataGridRow != null)
                {
                    listTelefonePJuridica.Remove(dataGridRow);

                    DGTelefonePJuridica.ItemsSource = null;

                    DGTelefonePJuridica.ItemsSource = listTelefonePJuridica;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAddTelefonePJuridica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (controleJuridico.ValidarTelefone(txtTelefonePJuridica.Text))
                {
                    if (cbDepTelefonePJuridica.SelectedItem != null)
                    {
                        Telefone telefone = new Telefone();
                        telefone.NumTelefone = txtTelefonePJuridica.Text;
                        telefone.Departamento = (Departamento)cbDepTelefonePJuridica.SelectedItem;
                        telefone.Celular = chCelularPJuridica.IsChecked.Value;
                        telefone.Whatsapp = chWhatsappPJuridica.IsChecked.Value;

                        listTelefonePJuridica.Add(telefone);
                        DGTelefonePJuridica.ItemsSource = null;

                        DGTelefonePJuridica.ItemsSource = listTelefonePJuridica;

                        limparCamposTelefonePJuridica();
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

        private void BtnExcluirEmailPJuridica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Email dataGridRow = DGEmailPJuridica.SelectedItem as Email;

                if (dataGridRow != null)
                {
                    listEmailPJuridica.Remove(dataGridRow);

                    DGEmailPJuridica.ItemsSource = null;

                    DGEmailPJuridica.ItemsSource = listEmailPJuridica;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAddEmailPJuridica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (controleJuridico.validaEmail(txtEmailPJuridica.Text))
                {
                    if (cbDepEmailPJuridica.SelectedItem != null)
                    {
                        Email email = new Email();
                        email.EndEmail = txtEmailPJuridica.Text;
                        email.Departamento = (Departamento)cbDepEmailPJuridica.SelectedItem;
                        listEmailPJuridica.Add(email);
                        DGEmailPJuridica.ItemsSource = null;

                        DGEmailPJuridica.ItemsSource = listEmailPJuridica;
                        limparCamposEmailPJuridica();
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

        private void CbCategoriaPJuridica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbCategoriaPJuridica.SelectedItem.Equals(Categoria.Unidade_de_Saúde))
                {
                    cbVinculadoPJuridica.IsEnabled = true;
                    cbOrganizacaoSocialPJuridica.IsEnabled = true;
                }
                else
                {
                    cbVinculadoPJuridica.SelectedItem = null;
                    cbOrganizacaoSocialPJuridica.SelectedItem = null;
                    cbVinculadoPJuridica.IsEnabled = false;
                    cbOrganizacaoSocialPJuridica.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChCelularPJuridica_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chCelularPJuridica.IsChecked.Equals(true))
                {
                    chWhatsappPJuridica.IsEnabled = true;
                }
                else
                {
                    chWhatsappPJuridica.IsEnabled = false;
                    chWhatsappPJuridica.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limparCamposEmailPJuridica()
        {
            txtEmailPJuridica.Text = "";
            cbDepEmailPJuridica.SelectedItem = null;
        }

        private void limparCamposTelefonePJuridica()
        {
            txtTelefonePJuridica.Text = "";
            cbDepTelefonePJuridica.SelectedItem = null;
            chCelularPJuridica.IsChecked = false;
            chWhatsappPJuridica.IsChecked = false;
        }

        private void limparCamposPJuridica()
        {
            txtNomePJuridica.Text = "";
            txtDescricaoPJuridica.Text = "";
            txtEmailPJuridica.Text = "";
            txtNomePJuridica.Text = "";

            if (DGEmailPJuridica.ItemsSource != null)
            {
                DGEmailPJuridica.ItemsSource = null;
            }
            if (DGTelefonePJuridica.ItemsSource != null)
            {
                DGTelefonePJuridica.ItemsSource = null;
            }
            if (cbCategoriaPJuridica.SelectedItem != null)
            {
                cbCategoriaPJuridica.SelectedItem = null;
            }
            if (cbDepEmailPJuridica.SelectedItem != null)
            {
                cbDepEmailPJuridica.SelectedItem = null;
            }
            if (cbDepTelefonePJuridica.SelectedItem != null)
            {
                cbDepTelefonePJuridica.SelectedItem = null;
            }
            if (cbVinculadoPJuridica.SelectedItem != null)
            {
                cbVinculadoPJuridica.SelectedItem = null;
            }
            if (cbOrganizacaoSocialPJuridica.SelectedItem != null)
            {
                cbOrganizacaoSocialPJuridica.SelectedItem = null;
            }
        }
        #endregion

        #region Defaut

        private void ControlePagina()
        {
            btnGravarPFisico.IsEnabled = true;
            btnGravarPJuridica.IsEnabled = true;
            btnEditarPFisico.IsEnabled = false;
            btnEditarPJuridica.IsEnabled = false;
            chWhatsappPFisico.IsEnabled = false;
            cbVinculadoPJuridica.IsEnabled = false;
            cbOrganizacaoSocialPJuridica.IsEnabled = false;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (chCelularPFisico.IsChecked.Equals(true))
            {
                chWhatsappPFisico.IsEnabled = true;
            }
            else
            {
                chWhatsappPFisico.IsEnabled = false;
            }

            if (chCelularPJuridica.IsChecked.Equals(true))
            {
                chWhatsappPJuridica.IsEnabled = true;
            }
            else
            {
                chWhatsappPJuridica.IsEnabled = false;
            }
        }

        #endregion
    }
}
