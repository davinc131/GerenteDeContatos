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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClassUi.Views.Pages
{
    /// <summary>
    /// Interação lógica para PageSlideEmail.xam
    /// </summary>
    public partial class PageSlideEmail : Page
    {
        List<Uri> uris = new List<Uri>();
        DispatcherTimer timer;
        int cont = 0;

        public PageSlideEmail()
        {
            InitializeComponent();

            init();
        }

        private void init()
        {
            try
            {
                uris.Add(new Uri("\\RecursosImagens\\Email\\imgContatoEnvioEmail01.png", UriKind.Relative));
                uris.Add(new Uri("\\RecursosImagens\\Email\\imgContatoEnvioEmail02.png", UriKind.Relative));
                uris.Add(new Uri("\\RecursosImagens\\Email\\imgContatoEnvioEmail03.png", UriKind.Relative));
                uris.Add(new Uri("\\RecursosImagens\\Email\\imgContatoEnvioEmail04.png", UriKind.Relative));
                uris.Add(new Uri("\\RecursosImagens\\Email\\imgContatoEnvioEmail05.png", UriKind.Relative));
                uris.Add(new Uri("\\RecursosImagens\\Email\\imgContatoEnvioEmail06.png", UriKind.Relative));

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
            if (cont > uris.Count -1)
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

                controleProgressBar();
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
                controleProgressBar();
                cont++;

                if (cont > uris.Count - 1)
                {
                    cont = 0;
                }
                else if (cont < 0)
                {
                    cont = uris.Count - 1;
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
                controleProgressBar();
                cont--;

                if (cont > uris.Count - 1)
                {
                    cont = 0;
                }
                else if (cont < 0)
                {
                    cont = uris.Count - 1;
                }

                Image1.Source = new BitmapImage(uris[cont] as Uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void controleProgressBar()
        {
            proStatus.Maximum = timer.Interval.TotalSeconds;
            proStatus.Minimum = 0;
            proStatus.BeginAnimation(ProgressBar.ValueProperty, null);

            Duration dur = new Duration(TimeSpan.FromSeconds(timer.Interval.TotalSeconds));
            DoubleAnimation dblAnim = new DoubleAnimation(5.0, dur);
            proStatus.BeginAnimation(ProgressBar.ValueProperty, dblAnim);
        }
    }
}
