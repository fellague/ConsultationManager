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
using ConsultationManagerClient.Views.Hospitalisations;
using ConsultationManagerClient.ViewModels.Hospitalisations;
using ConsultationManager.Views.Hospitalisations;
using ConsultationManager.ViewModels.BtnsVisibility;

namespace ConsultationManagerClient.Views
{
    /// <summary>
    /// Interaction logic for MenuHospitalisationWindow.xaml
    /// </summary>
    public partial class MenuHospitalisationWindow : Window
    {
        ListHospitalisationViewModel hospitVM;

        public MenuHospitalisationWindow()
        {
            InitializeComponent();
            hospitVM = new ListHospitalisationViewModel();
            this.DataContext = new VisibHospitVM();

            _mainFrame.Navigate(new ActiveHospitalisationPage(hospitVM));
            coloringTabs(ActiveHospBtn, PasseHospBtn, FuturHospBtn, AttenteHospBtn, RateHospBtn, DemandesHospit, SalleBtn);
        }


        private void button_click_passe(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new PasseHospitalisationPage(hospitVM));
            coloringTabs(PasseHospBtn, ActiveHospBtn, FuturHospBtn, AttenteHospBtn, RateHospBtn, DemandesHospit, SalleBtn);
        }

        private void button_click_active(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ActiveHospitalisationPage(hospitVM));
            coloringTabs(ActiveHospBtn, PasseHospBtn, FuturHospBtn, AttenteHospBtn, RateHospBtn, DemandesHospit, SalleBtn);
        }

        private void button_click_futur(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new FuturHospitalisationPage(hospitVM));
            coloringTabs(FuturHospBtn, ActiveHospBtn, PasseHospBtn, AttenteHospBtn, RateHospBtn, DemandesHospit, SalleBtn);
        }
        private void button_click_attente(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AttenteHospitalisationPage(hospitVM));
            coloringTabs(AttenteHospBtn, FuturHospBtn, ActiveHospBtn, PasseHospBtn, RateHospBtn, DemandesHospit, SalleBtn);
        }
        private void button_click_rate(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new MissedHospitalisationPage(hospitVM));
            coloringTabs(RateHospBtn, AttenteHospBtn, FuturHospBtn, ActiveHospBtn, PasseHospBtn, DemandesHospit, SalleBtn);
        }
        private void button_click_demands(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ListDemandesHospitPage(hospitVM));
            coloringTabs(DemandesHospit, PasseHospBtn, ActiveHospBtn, FuturHospBtn, RateHospBtn, AttenteHospBtn, SalleBtn);
        }
        private void button_click_salles(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ListSallesPage(hospitVM));
            coloringTabs(SalleBtn, DemandesHospit, PasseHospBtn, ActiveHospBtn, FuturHospBtn, AttenteHospBtn, RateHospBtn);
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

        private void coloringTabs(Button puprpleBtn, Button transparantBtn1, Button transparantBtn2, Button transparantBtn3, Button transparantBtn4, Button transparantBtn5, Button transparantBtn6)
        {
            puprpleBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            transparantBtn1.Background = Brushes.Transparent;
            transparantBtn2.Background = Brushes.Transparent;
            transparantBtn3.Background = Brushes.Transparent;
            transparantBtn4.Background = Brushes.Transparent;
            transparantBtn5.Background = Brushes.Transparent;
            transparantBtn6.Background = Brushes.Transparent;

            puprpleBtn.Foreground = Brushes.White;
            transparantBtn1.Foreground = Brushes.Black;
            transparantBtn2.Foreground = Brushes.Black;
            transparantBtn3.Foreground = Brushes.Black;
            transparantBtn4.Foreground = Brushes.Black;
            transparantBtn5.Foreground = Brushes.Black;
            transparantBtn6.Foreground = Brushes.Black;
        }
    }
}
