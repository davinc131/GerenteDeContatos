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
        private List<Telefone> listTelefone = new List<Telefone>();
        private List<Email> listEmail = new List<Email>();
        private ContatoJuridico contato = new ContatoJuridico();
        #endregion

        public Page_Contato_Juridico()
        {
            InitializeComponent();

            cbCategoria.ItemsSource = Enum.GetValues(typeof(Categoria)).Cast<Categoria>();
            cbDepEmail.ItemsSource = Enum.GetValues(typeof(Departamento)).Cast<Departamento>();
            cbDepTelefone.ItemsSource = Enum.GetValues(typeof(Departamento)).Cast<Departamento>();
        }

        private void BtnAddEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (controleContato.validaEmail(txtEmail.Text))
                {
                    Email email = new Email();
                    email.EndEmail = txtEmail.Text;
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

        private void BtnGravar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void limparCampos()
        {
            txtEmail.Text = "";
            txtTelefone.Text = "";
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
    }
}
