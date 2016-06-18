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
using ConsultationManager.Views.Patients;

namespace ConsultationManager.Views
{
    /// <summary>
    /// Interaction logic for NavBarWindow.xaml
    /// </summary>
    public partial class MenuPatientWindow : Window
    {
        public MenuPatientWindow()
        {
            InitializeComponent();
            //List<Account> list = new AccountList().GetData();
            _mainFrame.Navigate(new AllPatientsPage());
            AllPatBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            MyPatBtn.Background = Brushes.Transparent;
            NewPatBtn.Background = Brushes.Transparent;

            AllPatBtn.Foreground = Brushes.White;
            MyPatBtn.Foreground = Brushes.Black;
            NewPatBtn.Foreground = Brushes.Black;
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AllPatientsPage());
            AllPatBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            MyPatBtn.Background = Brushes.Transparent;
            NewPatBtn.Background = Brushes.Transparent;

            AllPatBtn.Foreground = Brushes.White;
            MyPatBtn.Foreground = Brushes.Black;
            NewPatBtn.Foreground = Brushes.Black;
        }

        private void button_click_mes(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new MyPatientsPage());
            AllPatBtn.Background = Brushes.Transparent;
            MyPatBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            NewPatBtn.Background = Brushes.Transparent;

            AllPatBtn.Foreground = Brushes.Black;
            MyPatBtn.Foreground = Brushes.White;
            NewPatBtn.Foreground = Brushes.Black;
        }

        private void button_click_nouveau(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new NewPatientPage());
            AllPatBtn.Background = Brushes.Transparent;
            MyPatBtn.Background = Brushes.Transparent;
            NewPatBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            NewPatBtn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#DDFFFFFF"));

            AllPatBtn.Foreground = Brushes.Black;
            MyPatBtn.Foreground = Brushes.Black;
            NewPatBtn.Foreground = Brushes.White;
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
    }
}
