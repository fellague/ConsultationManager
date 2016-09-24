using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ConsultationManagerClient.Views.RDVs;
using ConsultationManagerClient.ViewModels.RDVs;

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

            _frameRdv.Navigate(new AllRdvPage(rdvVM));
            coloringTabs(AllRdvBtn, AllMyRdvBtn, MyTodayRdvBtn, FirstRdvBtn);
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new AllRdvPage(rdvVM));
            coloringTabs(AllRdvBtn, AllMyRdvBtn, MyTodayRdvBtn, FirstRdvBtn);
        }

        private void button_click_tout_mes(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new AllMyRdvPage(rdvVM));
            coloringTabs(AllMyRdvBtn, AllRdvBtn, MyTodayRdvBtn, FirstRdvBtn);
        }

        private void button_click_ajourd(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new MyTodayRdvPage(rdvVM));
            coloringTabs(MyTodayRdvBtn, AllRdvBtn, AllMyRdvBtn, FirstRdvBtn);
        }

        private void button_click_first(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new FirstRdvPage(rdvVM));
            coloringTabs(FirstRdvBtn, MyTodayRdvBtn, AllRdvBtn, AllMyRdvBtn);
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
            //////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////::::
            Application.Current.MainWindow.Hide();
            var form2 = new MainWindow();
            form2.Closed += (s, args) => Application.Current.MainWindow.Close();
            form2.Show();
        }

        private void coloringTabs(Button puprpleBtn, Button transparantBtn1, Button transparantBtn2, Button transparantBtn3)
        {
            puprpleBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            transparantBtn1.Background = Brushes.Transparent;
            transparantBtn2.Background = Brushes.Transparent;
            transparantBtn3.Background = Brushes.Transparent;

            puprpleBtn.Foreground = Brushes.White;
            transparantBtn1.Foreground = Brushes.Black;
            transparantBtn2.Foreground = Brushes.Black;
            transparantBtn3.Foreground = Brushes.Black;
        }
    }
}
