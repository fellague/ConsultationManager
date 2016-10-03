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
using ConsultationManagerClient.Views.Patients;
using ConsultationManagerClient.ViewModels.Patients;
using ConsultationManager.Views.Patients;
using ConsultationManager.ViewModels.BtnsVisibility;
using ConsultationManagerClient.ViewModels.Authentication;

namespace ConsultationManagerClient.Views
{
    /// <summary>
    /// Interaction logic for NavBarWindow.xaml
    /// </summary>
    public partial class MenuPatientWindow : Window
    {
        PatientsViewModel patientsVM;

        public MenuPatientWindow(string tab)
        {
            InitializeComponent();
            patientsVM = new PatientsViewModel();
            this.DataContext = new VisibPatientVM();
            if (tab == "all")
            {
                if(AuthenticationViewModel.AuthenticatedUser.Role == "Administrateur")
                {
                    _mainFrame.Navigate(new AllPatientsPage(patientsVM));
                    coloringTabs(AllPatBtn, MyPatBtn, ListNewPatBtn, NewPatBtn, ConsultPatBtn);
                }
                else
                {
                    _mainFrame.Navigate(new ConsultPatientsPage(patientsVM));
                    coloringTabs(ConsultPatBtn, AllPatBtn, MyPatBtn, ListNewPatBtn, NewPatBtn);
                }
            }
            if (tab == "my")
            {
                _mainFrame.Navigate(new MyPatientsPage(patientsVM));
                coloringTabs(MyPatBtn, AllPatBtn, ListNewPatBtn, NewPatBtn, ConsultPatBtn);
            }
            
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AllPatientsPage(patientsVM));
            coloringTabs(AllPatBtn, MyPatBtn, ListNewPatBtn, NewPatBtn, ConsultPatBtn);
        }

        private void button_click_consult(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ConsultPatientsPage(patientsVM));
            coloringTabs(ConsultPatBtn, AllPatBtn, MyPatBtn, ListNewPatBtn, NewPatBtn);
        }

        private void button_click_mes(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new MyPatientsPage(patientsVM));
            coloringTabs(MyPatBtn, AllPatBtn, ListNewPatBtn, NewPatBtn, ConsultPatBtn);
        }

        private void button_click_list_new(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ListNewPatientsPage(patientsVM));
            coloringTabs(ListNewPatBtn, MyPatBtn, AllPatBtn, NewPatBtn, ConsultPatBtn);
        }

        private void button_click_nouveau(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new NewPatientPage(patientsVM));
            coloringTabs(NewPatBtn, AllPatBtn, MyPatBtn, ListNewPatBtn, ConsultPatBtn);
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
