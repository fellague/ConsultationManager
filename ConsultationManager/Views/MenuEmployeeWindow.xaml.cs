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
using ConsultationManager.Views.Employees;

namespace ConsultationManager.Views
{
    /// <summary>
    /// Interaction logic for MenuEmployeeWindow.xaml
    /// </summary>
    public partial class MenuEmployeeWindow : Window
    {
        public MenuEmployeeWindow()
        {
            InitializeComponent();

            _mainFrame.Navigate(new AllEmployeePage());
            AllEmplBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            chefServiceBtn.Background = Brushes.Transparent;
            medecinsBtn.Background = Brushes.Transparent;
            infirmierBtn.Background = Brushes.Transparent;
            assistantBtn.Background = Brushes.Transparent;
            NewEmplBtn.Background = Brushes.Transparent;

            AllEmplBtn.Foreground = Brushes.White;
            chefServiceBtn.Foreground = Brushes.Black;
            medecinsBtn.Foreground = Brushes.Black;
            infirmierBtn.Foreground = Brushes.Black;
            assistantBtn.Foreground = Brushes.Black;
            NewEmplBtn.Foreground = Brushes.Black;
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AllEmployeePage());
            AllEmplBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            chefServiceBtn.Background = Brushes.Transparent;
            medecinsBtn.Background = Brushes.Transparent;
            infirmierBtn.Background = Brushes.Transparent;
            assistantBtn.Background = Brushes.Transparent;
            NewEmplBtn.Background = Brushes.Transparent;

            AllEmplBtn.Foreground = Brushes.White;
            chefServiceBtn.Foreground = Brushes.Black;
            medecinsBtn.Foreground = Brushes.Black;
            infirmierBtn.Foreground = Brushes.Black;
            assistantBtn.Foreground = Brushes.Black;
            NewEmplBtn.Foreground = Brushes.Black;
        }

        private void button_click_chefServ(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ChefServicePage());
            AllEmplBtn.Background = Brushes.Transparent;
            chefServiceBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            medecinsBtn.Background = Brushes.Transparent;
            infirmierBtn.Background = Brushes.Transparent;
            assistantBtn.Background = Brushes.Transparent;
            NewEmplBtn.Background = Brushes.Transparent;

            AllEmplBtn.Foreground = Brushes.Black;
            chefServiceBtn.Foreground = Brushes.White;
            medecinsBtn.Foreground = Brushes.Black;
            infirmierBtn.Foreground = Brushes.Black;
            assistantBtn.Foreground = Brushes.Black;
            NewEmplBtn.Foreground = Brushes.Black;
        }
        private void button_click_medecin(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new MedecinsPage());
            AllEmplBtn.Background = Brushes.Transparent;
            chefServiceBtn.Background = Brushes.Transparent;
            medecinsBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            infirmierBtn.Background = Brushes.Transparent;
            assistantBtn.Background = Brushes.Transparent;
            NewEmplBtn.Background = Brushes.Transparent;

            AllEmplBtn.Foreground = Brushes.Black;
            chefServiceBtn.Foreground = Brushes.Black;
            medecinsBtn.Foreground = Brushes.White;
            infirmierBtn.Foreground = Brushes.Black;
            assistantBtn.Foreground = Brushes.Black;
            NewEmplBtn.Foreground = Brushes.Black;
        }
        private void button_click_infirmier(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new InfirmiersPage());
            AllEmplBtn.Background = Brushes.Transparent;
            chefServiceBtn.Background = Brushes.Transparent;
            medecinsBtn.Background = Brushes.Transparent;
            infirmierBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            assistantBtn.Background = Brushes.Transparent;
            NewEmplBtn.Background = Brushes.Transparent;

            AllEmplBtn.Foreground = Brushes.Black;
            chefServiceBtn.Foreground = Brushes.Black;
            medecinsBtn.Foreground = Brushes.Black;
            infirmierBtn.Foreground = Brushes.White;
            assistantBtn.Foreground = Brushes.Black;
            NewEmplBtn.Foreground = Brushes.Black;
        }
        private void button_click_assistant(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AssistantsPage());
            AllEmplBtn.Background = Brushes.Transparent;
            chefServiceBtn.Background = Brushes.Transparent;
            medecinsBtn.Background = Brushes.Transparent;
            infirmierBtn.Background = Brushes.Transparent;
            assistantBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            NewEmplBtn.Background = Brushes.Transparent;

            AllEmplBtn.Foreground = Brushes.Black;
            chefServiceBtn.Foreground = Brushes.Black;
            medecinsBtn.Foreground = Brushes.Black;
            infirmierBtn.Foreground = Brushes.Black;
            assistantBtn.Foreground = Brushes.White;
            NewEmplBtn.Foreground = Brushes.Black;
        }

        private void button_click_nouveau(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new NewEmployeePage());
            AllEmplBtn.Background = Brushes.Transparent;
            chefServiceBtn.Background = Brushes.Transparent;
            medecinsBtn.Background = Brushes.Transparent;
            infirmierBtn.Background = Brushes.Transparent;
            assistantBtn.Background = Brushes.Transparent;
            NewEmplBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));

            AllEmplBtn.Foreground = Brushes.Black;
            chefServiceBtn.Foreground = Brushes.Black;
            medecinsBtn.Foreground = Brushes.Black;
            infirmierBtn.Foreground = Brushes.Black;
            assistantBtn.Foreground = Brushes.Black;
            NewEmplBtn.Foreground = Brushes.White;
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
