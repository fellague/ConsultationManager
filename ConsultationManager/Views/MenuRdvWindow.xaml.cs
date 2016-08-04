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
using ConsultationManagerClient.Views.RDVs;
using ConsultationManagerClient.Models;

namespace ConsultationManagerClient.Views
{
    /// <summary>
    /// Interaction logic for MenuRdvWindow.xaml
    /// </summary>
    public partial class MenuRdvWindow : Window
    {
        public MenuRdvWindow()
        {
            InitializeComponent();
            _frameRdv.Navigate(new AllRdvPage());
            coloringTabs(AllRdvBtn, AllMyRdvBtn, MyTodayRdvBtn, FirstRdvBtn, NewRdvBtn);
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new AllRdvPage());
            coloringTabs(AllRdvBtn, AllMyRdvBtn, MyTodayRdvBtn, FirstRdvBtn, NewRdvBtn);
        }

        private void button_click_tout_mes(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new AllMyRdvPage());
            coloringTabs(AllMyRdvBtn, AllRdvBtn, MyTodayRdvBtn, FirstRdvBtn, NewRdvBtn);
        }

        private void button_click_ajourd(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new MyTodayRdvPage());
            coloringTabs(MyTodayRdvBtn, AllRdvBtn, AllMyRdvBtn, FirstRdvBtn, NewRdvBtn);
        }

        private void button_click_first(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new FirstRdvPage());
            coloringTabs(FirstRdvBtn, MyTodayRdvBtn, AllRdvBtn, AllMyRdvBtn, NewRdvBtn);
        }

        private void button_click_nouveau(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new NewRdvPage());
            coloringTabs(NewRdvBtn, MyTodayRdvBtn, AllRdvBtn, AllMyRdvBtn, FirstRdvBtn);
        }

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

        }

        private void coloringTabs(Button puprpleBtn, Button transparantBtn1, Button transparantBtn2, Button transparantBtn3, Button transparantBtn4)
        {
            puprpleBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            transparantBtn1.Background = Brushes.Transparent;
            transparantBtn2.Background = Brushes.Transparent;
            transparantBtn3.Background = Brushes.Transparent;
            transparantBtn4.Background = Brushes.Transparent;

            puprpleBtn.Foreground = Brushes.White;
            transparantBtn1.Foreground = Brushes.Black;
            transparantBtn2.Foreground = Brushes.Black;
            transparantBtn3.Foreground = Brushes.Black;
            transparantBtn4.Foreground = Brushes.Black;
        }
    }
}
