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

namespace ClassUi
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Application.Current.MainWindow.WindowState = WindowState.Maximized;
            //ImageBrush myBrush = new ImageBrush();
            //myBrush.ImageSource = new BitmapImage(new Uri(@"Imagens\\background4.png", UriKind.Absolute));
            //this.Background = myBrush;
        }

        private void BtnFisico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Views.ViewContatoFisico contatoFisico = new Views.ViewContatoFisico();
                contatoFisico.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnJuridico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Views.ViewContatoJuridico contatoJuridico = new Views.ViewContatoJuridico();
                contatoJuridico.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnWhatsapp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Views.ViewWhatsapp viewWhatsapp = new Views.ViewWhatsapp();
                viewWhatsapp.ShowDialog();

                //Views.WindowTeste teste = new Views.WindowTeste();
                //teste.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Views.ViewEmail viewEmail = new Views.ViewEmail();
                viewEmail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
