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
using ClassControle;
using ClassModel;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para Page_Listar_Contatos.xam
    /// </summary>
    public partial class Page_Listar_Contatos : Page
    {
        #region Variáveis

        ControleContatoJuridico controleContato = new ControleContatoJuridico();
        ControleContato controle = new ControleContato();

        #endregion

        #region Construtor

        public Page_Listar_Contatos(bool contatoJuridico)
        {
            InitializeComponent();

            ControlePagina(contatoJuridico);
            CarregarGridPJuridico(controleContato.ListarContatoJuridico());
            CarregarGridPFisica(controle.ListarContatos());
        }

        #endregion

        private void ControlePagina(bool b)
        {
            try
            {
                if (b.Equals(true))
                {
                    tcContatos.SelectedItem = tabPJuridica;
                }
                else
                {
                    tcContatos.SelectedItem = tabPFisica;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Pessoa Física

        private void CarregarGridPFisica(List<Contato> listaContatos)
        {
            DgContatoPFisica.ItemsSource = null;
            DgContatoPFisica.ItemsSource = listaContatos;
        }

        private void TxtConsultaNomePFisica_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtConsultaNomePFisica.Text != "")
                {
                    CarregarGridPFisica(controle.ListarPorParametro(txtConsultaNomePFisica.Text));
                }
                else
                {
                    CarregarGridPFisica(controle.ListarContatos());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCriarDemoPFisica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contato c = (Contato)DgContatoPFisica.SelectedItem;

                ViewDetalhes view = new ViewDetalhes();
                view.DetalhesContatoFisico(c);
                view.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditarContatoPFiisica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contato c = new Contato();
                c = (Contato)DgContatoPFisica.SelectedItem;

                Page_Contatos p = new Page_Contatos(true, c);

                ViewContatoFisico v = new ViewContatoFisico();

                v.AbrirDeUmaPagina(p);
                v.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExcluirContatoPFisica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Tem certeza que deseja deletar este registro.", "Excluir", MessageBoxButton.YesNoCancel);

                if (result.Equals(MessageBoxResult.Yes))
                {
                    Contato c = new Contato();
                    c = (Contato)DgContatoPFisica.SelectedItem;

                    controle.Excluir(c.Id);

                    MessageBox.Show("Registro Excluído com sucesso!");

                    DgContatoPFisica.ItemsSource = null;
                    DgContatoPFisica.ItemsSource = controle.ListarContatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Pessoa Juridica

        private void CarregarGridPJuridico(List<ContatoJuridico> listaContatos)
        {
            DgContatoPJuridica.ItemsSource = null;
            DgContatoPJuridica.ItemsSource = listaContatos;
        }

        private void TxtConsultaNomePJuridica_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtConsultaNomePJuridica.Text != "")
                {
                    CarregarGridPJuridico(controleContato.ListarPorParametro(txtConsultaNomePJuridica.Text));
                }
                else
                {
                    CarregarGridPJuridico(controleContato.ListarContatoJuridico());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void BtnEditarContatoPJuridica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContatoJuridico c = new ContatoJuridico();
                c = (ContatoJuridico)DgContatoPJuridica.SelectedItem;

                c = controleContato.ListarPorParametro(c.Nome)[0];

                Page_Contatos p = new Page_Contatos(true, c);

                ViewContatoJuridico v = new ViewContatoJuridico();

                //GetWindowInstance(typeof(ViewContatoJuridico));
                v.AbrirDeUmaPagina(p);
                v.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private Window GetWindowInstance(Type winType)
        //{
        //    Window win;
        //    win = Application.Current.Windows
        //           .OfType<Window>()
        //           .SingleOrDefault(w => w.GetType() == winType);
        //    if (win == null)
        //    {
        //        win = (Window)Activator.CreateInstance(winType);
        //    }
        //    return win;
        //}

        private void GetWindowInstance(Type winType)
        {
            Window win;
            win = Application.Current.Windows
                   .OfType<Window>()
                   .SingleOrDefault(w => w.GetType() == winType);
            if (win != null)
            {
                win.Close();
            }
        }

        private void BtnCriarDemoPJuridica_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ContatoJuridico c = (ContatoJuridico)DgContatoPJuridica.SelectedItem;
                ViewDetalhes view = new ViewDetalhes();
                view.DetalheContatoJuridico(c);
                view.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
