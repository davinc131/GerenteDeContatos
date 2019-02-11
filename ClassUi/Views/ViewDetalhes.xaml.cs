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
using System.Windows.Shapes;
using ClassModel;

namespace ClassUi.Views
{
    /// <summary>
    /// Lógica interna para ViewDetalhes.xaml
    /// </summary>
    public partial class ViewDetalhes : Window
    {
        public ViewDetalhes()
        {
            InitializeComponent();
        }

        public void DetalhesContatoFisico(Contato b)
        {
            try
            {
                if(b != null)
                {
                    #region Nome

                    Label lbRotuloNome = new Label();
                    lbRotuloNome.Content = "Nome:";
                    lbRotuloNome.Width = 100;
                    lbRotuloNome.FontWeight = FontWeights.UltraBold;
                    lbRotuloNome.FontSize = 16;
                    lbRotuloNome.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbRotuloNome, 0);
                    Grid.SetRow(lbRotuloNome, 0);
                    Grid.SetRowSpan(lbRotuloNome, 1);
                    Grid.SetColumnSpan(lbRotuloNome, 2);

                    Label lbNome = new Label();
                    lbNome.Background = Brushes.Azure;
                    lbNome.Content = b.Nome;
                    lbNome.Width = 300;
                    lbNome.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbNome, 2);
                    Grid.SetRow(lbNome, 0);
                    Grid.SetRowSpan(lbNome, 1);
                    Grid.SetColumnSpan(lbNome, 5);

                    #endregion

                    #region Descrição

                    Label lbRotuloDecricao = new Label();
                    lbRotuloDecricao.Content = "Descrição:";
                    lbRotuloDecricao.Width = 100;
                    lbRotuloDecricao.FontWeight = FontWeights.UltraBold;
                    lbRotuloDecricao.FontSize = 16;
                    lbRotuloDecricao.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbRotuloDecricao, 0);
                    Grid.SetRow(lbRotuloDecricao, 1);
                    Grid.SetRowSpan(lbRotuloDecricao, 1);
                    Grid.SetColumnSpan(lbRotuloDecricao, 2);

                    TextBlock txtbDescricao = new TextBlock();
                    txtbDescricao.Background = Brushes.Azure;
                    txtbDescricao.Text = b.Descricao;
                    txtbDescricao.Width = 300;
                    txtbDescricao.IsEnabled = false;
                    txtbDescricao.TextWrapping = TextWrapping.Wrap;
                    Grid.SetColumn(txtbDescricao, 2);
                    Grid.SetRow(txtbDescricao, 1);
                    Grid.SetRowSpan(txtbDescricao, 1);
                    Grid.SetColumnSpan(txtbDescricao, 5);

                    #endregion

                    #region Vinculo

                    Label lbRotuloVinculo = new Label();
                    lbRotuloVinculo.Content = "Vinculado a:";
                    lbRotuloVinculo.Width = 100;
                    lbRotuloVinculo.FontWeight = FontWeights.UltraBold;
                    lbRotuloVinculo.FontSize = 16;
                    lbRotuloVinculo.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbRotuloVinculo, 0);
                    Grid.SetRow(lbRotuloVinculo, 2);
                    Grid.SetRowSpan(lbRotuloVinculo, 1);
                    Grid.SetColumnSpan(lbRotuloVinculo, 2);


                    Label lbVinculo = new Label();
                    lbVinculo.Background = Brushes.Azure;
                    if(b.ContatoJuridico != null)
                    {
                        lbVinculo.Content = b.ContatoJuridico.ToString();
                    }
                    else
                    {
                        lbVinculo.Content = "Sem Vinculo";
                    }
                    lbVinculo.Width = 300;
                    lbVinculo.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbVinculo, 2);
                    Grid.SetRow(lbVinculo, 2);
                    Grid.SetRowSpan(lbVinculo, 1);
                    Grid.SetColumnSpan(lbVinculo, 5);

                    #endregion

                    #region Departamento

                    Label lbRotuloDepartamento = new Label();
                    lbRotuloDepartamento.Content = "Departamento:";
                    lbRotuloDepartamento.Width = 100;
                    lbRotuloDepartamento.FontWeight = FontWeights.UltraBold;
                    lbRotuloDepartamento.FontSize = 13;
                    lbRotuloDepartamento.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbRotuloDepartamento, 0);
                    Grid.SetRow(lbRotuloDepartamento, 3);
                    Grid.SetRowSpan(lbRotuloDepartamento, 1);
                    Grid.SetColumnSpan(lbRotuloDepartamento, 2);

                    Label lbDepartamento = new Label();
                    lbDepartamento.Background = Brushes.Azure;
                    if(b.Departamento != 0)
                    {
                        lbDepartamento.Content = b.Departamento;
                    }
                    else
                    {
                        lbDepartamento.Content = "Nenhum";
                    }
                    lbDepartamento.Width = 300;
                    lbDepartamento.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbDepartamento, 2);
                    Grid.SetRow(lbDepartamento, 3);
                    Grid.SetRowSpan(lbDepartamento, 1);
                    Grid.SetColumnSpan(lbDepartamento, 5);

                    #endregion

                    #region Telefone

                    Label lbRotuloTelefone = new Label();
                    lbRotuloTelefone.Content = "Telefones:";
                    lbRotuloTelefone.Width = 100;
                    lbRotuloTelefone.FontWeight = FontWeights.UltraBold;
                    lbRotuloTelefone.FontSize = 16;
                    lbRotuloTelefone.HorizontalContentAlignment = HorizontalAlignment.Center;
                    lbRotuloTelefone.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetColumn(lbRotuloTelefone, 0);
                    Grid.SetRow(lbRotuloTelefone, 4);
                    Grid.SetRowSpan(lbRotuloTelefone, 1);
                    Grid.SetColumnSpan(lbRotuloTelefone, 2);

                    StackPanel stackTelefone = new StackPanel();
                    stackTelefone.Background = Brushes.Azure;
                    Grid.SetColumn(stackTelefone, 2);
                    Grid.SetRow(stackTelefone, 4);
                    Grid.SetRowSpan(stackTelefone, 1);
                    Grid.SetColumnSpan(stackTelefone, 5);

                    string telefone = "";

                    List<Telefone> telefones = b.Telefones.ToList();

                    for(int i = 0; i < telefones.Count; i++)
                    {
                        telefone = "lbTelefone_" + i;
                        Label lb = new Label();
                        lb.Name = telefone;
                        lb.Content = telefones[i];
                        stackTelefone.Children.Add(lb);
                    }

                    #endregion

                    #region Email

                    Label lbRotuloEmail = new Label();
                    lbRotuloEmail.Content = "Emails:";
                    lbRotuloEmail.Width = 100;
                    lbRotuloEmail.FontWeight = FontWeights.UltraBold;
                    lbRotuloEmail.FontSize = 16;
                    lbRotuloEmail.HorizontalContentAlignment = HorizontalAlignment.Center;
                    lbRotuloEmail.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetColumn(lbRotuloEmail, 0);
                    Grid.SetRow(lbRotuloEmail, 5);
                    Grid.SetRowSpan(lbRotuloEmail, 1);
                    Grid.SetColumnSpan(lbRotuloEmail, 2);

                    StackPanel stackEmail = new StackPanel();
                    var converter = new System.Windows.Media.BrushConverter();
                    stackEmail.Background = (Brush)converter.ConvertFromString("#7cffd4");
                    Grid.SetColumn(stackEmail, 2);
                    Grid.SetRow(stackEmail, 5);
                    Grid.SetRowSpan(stackEmail, 1);
                    Grid.SetColumnSpan(stackEmail, 5);
                    string email = "";
                    List<Email> emails = b.Emails.ToList();
                    for (int i = 0; i < emails.Count; i++)
                    {
                        email = "lbTelefone_" + i;
                        Label lbc = new Label();
                        lbc.Name = email;
                        lbc.Content = emails[i];
                        stackEmail.Children.Add(lbc);
                    }

                    #endregion

                    GridConteudo.Children.Add(lbRotuloNome);
                    GridConteudo.Children.Add(lbNome);
                    GridConteudo.Children.Add(lbRotuloDecricao);
                    GridConteudo.Children.Add(txtbDescricao);
                    GridConteudo.Children.Add(lbRotuloVinculo);
                    GridConteudo.Children.Add(lbVinculo);
                    GridConteudo.Children.Add(lbRotuloDepartamento);
                    GridConteudo.Children.Add(lbDepartamento);
                    GridConteudo.Children.Add(lbRotuloTelefone);
                    GridConteudo.Children.Add(stackTelefone);
                    GridConteudo.Children.Add(lbRotuloEmail);
                    GridConteudo.Children.Add(stackEmail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DetalheContatoJuridico(ContatoJuridico b)
        {
            try
            {
                #region Nome
                
                Label lbRotuloNome = new Label();
                lbRotuloNome.Content = "Nome:";
                lbRotuloNome.Width = 100;
                lbRotuloNome.FontWeight = FontWeights.UltraBold;
                lbRotuloNome.FontSize = 16;
                lbRotuloNome.HorizontalContentAlignment = HorizontalAlignment.Left;
                Grid.SetColumn(lbRotuloNome, 0);
                Grid.SetRow(lbRotuloNome, 0);
                Grid.SetRowSpan(lbRotuloNome, 1);
                Grid.SetColumnSpan(lbRotuloNome, 2);

                Label lbNome = new Label();
                lbNome.Background = Brushes.Azure;
                lbNome.Content = b.Nome;
                lbNome.Width = 300;
                lbNome.HorizontalContentAlignment = HorizontalAlignment.Left;
                Border borderNome = new Border();
                borderNome.BorderThickness = new Thickness(1);
                borderNome.BorderBrush = Brushes.Black;
                borderNome.Child = lbNome;
                Grid.SetColumn(borderNome, 2);
                Grid.SetRow(borderNome, 0);
                Grid.SetRowSpan(borderNome, 1);
                Grid.SetColumnSpan(borderNome, 5);

                #endregion

                #region Descrição

                Label lbRotuloDecricao = new Label();
                lbRotuloDecricao.Content = "Descrição:";
                lbRotuloDecricao.Width = 100;
                lbRotuloDecricao.FontWeight = FontWeights.UltraBold;
                lbRotuloDecricao.FontSize = 16;
                lbRotuloDecricao.HorizontalContentAlignment = HorizontalAlignment.Left;
                Grid.SetColumn(lbRotuloDecricao, 0);
                Grid.SetRow(lbRotuloDecricao, 1);
                Grid.SetRowSpan(lbRotuloDecricao, 1);
                Grid.SetColumnSpan(lbRotuloDecricao, 2);

                TextBlock txtbDescricao = new TextBlock();
                txtbDescricao.Background = Brushes.Azure;
                txtbDescricao.Text = b.Descricao;
                txtbDescricao.Width = 300;
                txtbDescricao.IsEnabled = false;
                txtbDescricao.TextWrapping = TextWrapping.Wrap;
                Border borderDescricao = new Border();
                borderDescricao.BorderThickness = new Thickness(1);
                borderDescricao.BorderBrush = Brushes.Black;
                borderDescricao.Child = txtbDescricao;
                Grid.SetColumn(borderDescricao, 2);
                Grid.SetRow(borderDescricao, 1);
                Grid.SetRowSpan(borderDescricao, 1);
                Grid.SetColumnSpan(borderDescricao, 5);

                #endregion

                #region Categoria

                Label lbRotuloCategoria = new Label();
                lbRotuloCategoria.Content = "Categoria:";
                lbRotuloCategoria.Width = 100;
                lbRotuloCategoria.FontWeight = FontWeights.UltraBold;
                lbRotuloCategoria.FontSize = 16;
                lbRotuloCategoria.HorizontalContentAlignment = HorizontalAlignment.Left;
                Grid.SetColumn(lbRotuloCategoria, 0);
                Grid.SetRow(lbRotuloCategoria, 2);
                Grid.SetRowSpan(lbRotuloCategoria, 1);
                Grid.SetColumnSpan(lbRotuloCategoria, 2);

                TextBlock txtbCategoria = new TextBlock();
                txtbCategoria.Background = Brushes.Azure;
                txtbCategoria.Text = b.Categoria.ToString();
                txtbCategoria.Width = 300;
                txtbCategoria.IsEnabled = false;
                txtbCategoria.TextWrapping = TextWrapping.Wrap;
                Border borderCategoria = new Border();
                borderCategoria.BorderThickness = new Thickness(1);
                borderCategoria.BorderBrush = Brushes.Black;
                borderCategoria.Child = txtbCategoria;
                Grid.SetColumn(borderCategoria, 2);
                Grid.SetRow(borderCategoria, 2);
                Grid.SetRowSpan(borderCategoria, 1);
                Grid.SetColumnSpan(borderCategoria, 5);

                #endregion

                #region Vinculo

                Label lbRotuloAuditoria = new Label();
                Label lbAuditoria = new Label();
                Label lbRotuloOrgSocial = new Label();
                Label lbOrgSocial = new Label();

                if (b.Categoria.Equals(Categoria.Unidade_de_Saúde))
                {
                    #region Auditoria

                    lbRotuloAuditoria.Content = "Auditoria:";
                    lbRotuloAuditoria.Width = 100;
                    lbRotuloAuditoria.FontWeight = FontWeights.UltraBold;
                    lbRotuloAuditoria.FontSize = 16;
                    lbRotuloAuditoria.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbRotuloAuditoria, 0);
                    Grid.SetRow(lbRotuloAuditoria, 4);
                    Grid.SetRowSpan(lbRotuloAuditoria, 1);
                    Grid.SetColumnSpan(lbRotuloAuditoria, 2);

                    lbAuditoria.Background = Brushes.Azure;
                    if (b.Auditoria != null)
                    {
                        lbAuditoria.Content = b.Auditoria.ToString();
                    }
                    else
                    {
                        lbAuditoria.Content = "Sem Vinculo";
                    }
                    lbAuditoria.Width = 300;
                    lbAuditoria.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbAuditoria, 2);
                    Grid.SetRow(lbAuditoria, 4);
                    Grid.SetRowSpan(lbAuditoria, 1);
                    Grid.SetColumnSpan(lbAuditoria, 5);

                    #endregion

                    #region Organização Social

                    lbRotuloOrgSocial.Content = "Organização Social:";
                    lbRotuloOrgSocial.Width = 100;
                    lbRotuloOrgSocial.FontWeight = FontWeights.UltraBold;
                    lbRotuloOrgSocial.FontSize = 16;
                    lbRotuloOrgSocial.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbRotuloOrgSocial, 0);
                    Grid.SetRow(lbRotuloOrgSocial, 3);
                    Grid.SetRowSpan(lbRotuloOrgSocial, 1);
                    Grid.SetColumnSpan(lbRotuloOrgSocial, 2);

                    lbOrgSocial.Background = Brushes.Azure;
                    if (b.OrganizacaoSocial != null)
                    {
                        lbOrgSocial.Content = b.OrganizacaoSocial.ToString();
                    }
                    else
                    {
                        lbOrgSocial.Content = "Sem Vinculo";
                    }
                    lbOrgSocial.Width = 300;
                    lbOrgSocial.HorizontalContentAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbOrgSocial, 2);
                    Grid.SetRow(lbOrgSocial, 3);
                    Grid.SetRowSpan(lbOrgSocial, 1);
                    Grid.SetColumnSpan(lbOrgSocial, 5);

                    #endregion
                }

                #endregion

                #region Telefone

                Label lbRotuloTelefone = new Label();
                lbRotuloTelefone.Content = "Telefones:";
                lbRotuloTelefone.Width = 100;
                lbRotuloTelefone.FontWeight = FontWeights.UltraBold;
                lbRotuloTelefone.FontSize = 16;
                lbRotuloTelefone.HorizontalContentAlignment = HorizontalAlignment.Left;
                lbRotuloTelefone.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetColumn(lbRotuloTelefone, 0);
                Grid.SetRow(lbRotuloTelefone, 5);
                Grid.SetRowSpan(lbRotuloTelefone, 1);
                Grid.SetColumnSpan(lbRotuloTelefone, 2);

                StackPanel stackTelefone = new StackPanel();
                stackTelefone.Background = Brushes.Azure;
                Grid.SetColumn(stackTelefone, 2);
                Grid.SetRow(stackTelefone, 5);
                Grid.SetRowSpan(stackTelefone, 1);
                Grid.SetColumnSpan(stackTelefone, 5);

                string telefone = "";

                List<Telefone> telefones = b.Telefones.ToList();

                for (int i = 0; i < telefones.Count; i++)
                {
                    telefone = "lbTelefone_" + i;
                    Label lb = new Label();
                    lb.Name = telefone;
                    lb.Content = telefones[i].ToDetalhes();
                    stackTelefone.Children.Add(lb);
                }

                #endregion

                #region Email

                Label lbRotuloEmail = new Label();
                lbRotuloEmail.Content = "Emails:";
                lbRotuloEmail.Width = 100;
                lbRotuloEmail.FontWeight = FontWeights.UltraBold;
                lbRotuloEmail.FontSize = 16;
                lbRotuloEmail.HorizontalContentAlignment = HorizontalAlignment.Left;
                lbRotuloEmail.HorizontalAlignment = HorizontalAlignment.Left;
                Grid.SetColumn(lbRotuloEmail, 0);
                Grid.SetRow(lbRotuloEmail, 6);
                Grid.SetRowSpan(lbRotuloEmail, 1);
                Grid.SetColumnSpan(lbRotuloEmail, 2);

                StackPanel stackEmail = new StackPanel();
                var converter = new System.Windows.Media.BrushConverter();
                stackEmail.Background = (Brush)converter.ConvertFromString("#7cffd4");
                Grid.SetColumn(stackEmail, 2);
                Grid.SetRow(stackEmail, 6);
                Grid.SetRowSpan(stackEmail, 1);
                Grid.SetColumnSpan(stackEmail, 5);
                string email = "";
                List<Email> emails = b.Emails.ToList();
                for (int i = 0; i < emails.Count; i++)
                {
                    email = "lbTelefone_" + i;
                    Label lbc = new Label();
                    lbc.Name = email;
                    lbc.Content = emails[i].ToDetalhes();
                    stackEmail.Children.Add(lbc);
                }

                #endregion

                #region Contatos

                Label lbRotuloContatos = new Label();
                lbRotuloContatos.Content = "Contatos:";
                lbRotuloContatos.Width = 100;
                lbRotuloContatos.FontWeight = FontWeights.UltraBold;
                lbRotuloContatos.FontSize = 16;
                lbRotuloContatos.HorizontalContentAlignment = HorizontalAlignment.Left;
                lbRotuloContatos.HorizontalAlignment = HorizontalAlignment.Left;
                lbRotuloContatos.VerticalAlignment = VerticalAlignment.Center;
                lbRotuloContatos.VerticalContentAlignment = VerticalAlignment.Center;
                Grid.SetColumn(lbRotuloContatos, 0);
                Grid.SetRow(lbRotuloContatos, 7);
                Grid.SetRowSpan(lbRotuloContatos, 1);
                Grid.SetColumnSpan(lbRotuloContatos, 2);

                StackPanel stackContato = new StackPanel();
                var converter1 = new System.Windows.Media.BrushConverter();
                stackContato.Background = (Brush)converter1.ConvertFromString("#7affd4");
                Grid.SetColumn(stackContato, 2);
                Grid.SetRow(stackContato, 7);
                Grid.SetRowSpan(stackContato, 1);
                Grid.SetColumnSpan(stackContato, 5);
                string contato = "";
                List<Contato> contatos = b.Contatos.ToList();
                for (int i = 0; i < contatos.Count; i++)
                {
                    contato = "lbContatos_" + i;
                    Label lcd = new Label();
                    lcd.Name = contato;
                    lcd.Content = contatos[i];
                    stackEmail.Children.Add(lcd);
                }

                #endregion

                #region Juridicos

                Label lbRotuloJuridicos = new Label();
                StackPanel stackJuridicos = new StackPanel();

                if (b.Categoria.Equals(Categoria.Auditoria) || b.Categoria.Equals(Categoria.Organização_Social))
                {
                    lbRotuloJuridicos.Content = "Jurídicos:";
                    lbRotuloJuridicos.Width = 100;
                    lbRotuloJuridicos.FontWeight = FontWeights.UltraBold;
                    lbRotuloJuridicos.FontSize = 16;
                    lbRotuloJuridicos.HorizontalContentAlignment = HorizontalAlignment.Left;
                    lbRotuloJuridicos.HorizontalAlignment = HorizontalAlignment.Left;
                    Grid.SetColumn(lbRotuloJuridicos, 0);
                    Grid.SetRow(lbRotuloJuridicos, 8);
                    Grid.SetRowSpan(lbRotuloJuridicos, 1);
                    Grid.SetColumnSpan(lbRotuloJuridicos, 2);

                    var converter2 = new System.Windows.Media.BrushConverter();
                    stackJuridicos.Background = (Brush)converter2.ConvertFromString("#77ffd4");
                    Grid.SetColumn(stackJuridicos, 2);
                    Grid.SetRow(stackJuridicos, 8);
                    Grid.SetRowSpan(stackJuridicos, 1);
                    Grid.SetColumnSpan(stackJuridicos, 5);
                    string juridico = "";
                    List<ContatoJuridico> juridicos = b.Juridicos.ToList();
                    for (int i = 0; i < juridicos.Count; i++)
                    {
                        juridico = "lbContatos_" + i;
                        Label lbj = new Label();
                        lbj.Name = juridico;
                        lbj.Content = juridicos[i];
                        stackEmail.Children.Add(lbj);
                    }
                }

                #endregion

                GridConteudo.Children.Add(lbRotuloNome);
                GridConteudo.Children.Add(borderNome);
                GridConteudo.Children.Add(lbRotuloDecricao);
                GridConteudo.Children.Add(borderDescricao);
                GridConteudo.Children.Add(lbRotuloAuditoria);
                GridConteudo.Children.Add(lbAuditoria);
                GridConteudo.Children.Add(lbRotuloOrgSocial);
                GridConteudo.Children.Add(lbOrgSocial);
                GridConteudo.Children.Add(lbRotuloTelefone);
                GridConteudo.Children.Add(stackTelefone);
                GridConteudo.Children.Add(lbRotuloEmail);
                GridConteudo.Children.Add(stackEmail);
                GridConteudo.Children.Add(lbRotuloCategoria);
                GridConteudo.Children.Add(borderCategoria);
                GridConteudo.Children.Add(lbRotuloContatos);
                GridConteudo.Children.Add(stackContato);
                GridConteudo.Children.Add(lbRotuloJuridicos);
                GridConteudo.Children.Add(stackJuridicos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnFechar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
