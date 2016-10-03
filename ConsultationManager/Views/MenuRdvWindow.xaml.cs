using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ConsultationManagerClient.Views.RDVs;
using ConsultationManagerClient.ViewModels.RDVs;
using ConsultationManager.Views.RDVs;

namespace ConsultationManagerClient.Views
{
    /// <summary>
    /// Interaction logic for MenuRdvWindow.xaml
    /// </summary>
    public partial class MenuRdvWindow : Window
    {
        ListRvdViewModel rdvVM;

        public MenuRdvWindow()
        {
            InitializeComponent();
            rdvVM = new ListRvdViewModel();
            this.DataContext = rdvVM;

            _frameRdv.Navigate(new ListMyTodayRdvPage(rdvVM));
            coloringTabs(MyTodayRdvBtn, AllRdvBtn, PasseRdvBtn, RateRdvBtn, FirstRdvBtn, HospitRdvBtn, FuturRdvBtn, GridRdvBtn);
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new AllRdvPage(rdvVM));
            coloringTabs(AllRdvBtn, PasseRdvBtn, RateRdvBtn, MyTodayRdvBtn, FirstRdvBtn, HospitRdvBtn, FuturRdvBtn, GridRdvBtn);
        }
        private void button_click_passe(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new ListPasseRdvPage(rdvVM));
            coloringTabs(PasseRdvBtn, AllRdvBtn, RateRdvBtn, MyTodayRdvBtn, FirstRdvBtn, HospitRdvBtn, FuturRdvBtn, GridRdvBtn);
        }
        private void button_click_rate(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new ListRateRdvPage(rdvVM));
            coloringTabs(RateRdvBtn, AllRdvBtn, PasseRdvBtn, MyTodayRdvBtn, FirstRdvBtn, HospitRdvBtn, FuturRdvBtn, GridRdvBtn);
        }

        private void button_click_ajourd(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new ListMyTodayRdvPage(rdvVM));
            coloringTabs(MyTodayRdvBtn, AllRdvBtn, PasseRdvBtn, RateRdvBtn, FirstRdvBtn, HospitRdvBtn, FuturRdvBtn, GridRdvBtn);
        }

        private void button_click_first(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new ListFirstRdvPage(rdvVM));
            coloringTabs(FirstRdvBtn, AllRdvBtn, PasseRdvBtn, RateRdvBtn, MyTodayRdvBtn, HospitRdvBtn, FuturRdvBtn, GridRdvBtn);
        }
        private void button_click_hosp(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new ListHospitRdvPage(rdvVM));
            coloringTabs(HospitRdvBtn, FirstRdvBtn, AllRdvBtn, PasseRdvBtn, RateRdvBtn, MyTodayRdvBtn, FuturRdvBtn, GridRdvBtn);
        }
        private void button_click_futur(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new ListFuturRdvPage(rdvVM));
            coloringTabs(FuturRdvBtn, FirstRdvBtn, AllRdvBtn, PasseRdvBtn, RateRdvBtn, MyTodayRdvBtn, HospitRdvBtn, GridRdvBtn);
        }
        private void button_click_grid(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new GridRdvsPage(rdvVM));
            coloringTabs(GridRdvBtn, FuturRdvBtn, FirstRdvBtn, AllRdvBtn, PasseRdvBtn, RateRdvBtn, MyTodayRdvBtn, HospitRdvBtn);
        }

        //private void button_click_nouveau(object sender, RoutedEventArgs e)
        //{
        //    _frameRdv.Navigate(new NewRdvPage());
        //    coloringTabs(NewRdvBtn, MyTodayRdvBtn, AllRdvBtn, AllMyRdvBtn, FirstRdvBtn);
        //}

        private void button_click_home(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var form2 = new Home();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button_click_about(object sender, RoutedEventArgs e)
        {

        }

        private void button_click_logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var form2 = new MainWindow();
            form2.Closed += (s, args) => this.Close();
            form2.Show();//////////////////////////////////////////////////////////////////////////::::
            //Application.Current.MainWindow.Hide();
            //var form2 = new MainWindow();
            //form2.Closed += (s, args) => Application.Current.MainWindow.Close();
            //form2.Show();
            //MainWindow signIn = new MainWindow();
            //signIn.Tag = "sign";
            //signIn.Show();
        }

        private void coloringTabs(Button puprpleBtn, Button transparantBtn1, Button transparantBtn2, Button transparantBtn3, Button transparantBtn4, Button transparantBtn5, Button transparantBtn6, Button transparantBtn7)
        {
            puprpleBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            transparantBtn1.Background = Brushes.Transparent;
            transparantBtn2.Background = Brushes.Transparent;
            transparantBtn3.Background = Brushes.Transparent;
            transparantBtn4.Background = Brushes.Transparent;
            transparantBtn5.Background = Brushes.Transparent;
            transparantBtn6.Background = Brushes.Transparent;
            transparantBtn7.Background = Brushes.Transparent;

            puprpleBtn.Foreground = Brushes.White;
            transparantBtn1.Foreground = Brushes.Black;
            transparantBtn2.Foreground = Brushes.Black;
            transparantBtn3.Foreground = Brushes.Black;
            transparantBtn4.Foreground = Brushes.Black;
            transparantBtn5.Foreground = Brushes.Black;
            transparantBtn6.Foreground = Brushes.Black;
            transparantBtn7.Foreground = Brushes.Black;
        }
    }
}
