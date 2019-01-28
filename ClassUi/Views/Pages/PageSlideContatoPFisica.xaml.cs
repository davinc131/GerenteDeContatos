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
using System.Windows.Threading;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para PageContatoPFisica.xam
    /// </summary>
    public partial class PageSlideContatoPFisica : Page
    {

        List<Uri> uris = new List<Uri>();
        DispatcherTimer timer;
        int cont = 0;

        public PageSlideContatoPFisica()
        {
            InitializeComponent();

            uris.Add(new Uri("\\RecursosImagens\\backgroundRecurso1.jpg", UriKind.Relative));
            uris.Add(new Uri("\\RecursosImagens\\backgroundRecurso2.jpg", UriKind.Relative));
            uris.Add(new Uri("\\RecursosImagens\\backgroundRecurso3.jpg", UriKind.Relative));
            uris.Add(new Uri("\\RecursosImagens\\backgroundRecurso4.jpg", UriKind.Relative));

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (cont > 3)
            {
                cont = 0;
            }

            ScriptSlideShow();
        }

        private void ScriptSlideShow()
        {
            try
            {
                Image1.Source = new BitmapImage(uris[cont] as Uri);

                if (cont == 0)
                {
                    timer.Interval = new TimeSpan(0, 0, 5);
                }

                cont++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAvancar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cont++;

                if (cont > 3)
                {
                    cont = 0;
                }
                else if (cont < 0)
                {
                    cont = 3;
                }

                Image1.Source = new BitmapImage(uris[cont] as Uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRetroceder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cont--;

                if (cont > 3)
                {
                    cont = 0;
                }
                else if (cont < 0)
                {
                    cont = 3;
                }

                Image1.Source = new BitmapImage(uris[cont] as Uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
