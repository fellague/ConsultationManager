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
using ConsultationManagerClient.Views.Consultations;
using ConsultationManagerClient.ViewModels.Consultations;

namespace ConsultationManagerClient.Views
{
    /// <summary>
    /// Interaction logic for MenuPathologieWindow.xaml
    /// </summary>
    public partial class MenuConsultationWindow : Window
    {
        ConsultationsViewModel pathologieVM;

        public MenuConsultationWindow()
        {
            InitializeComponent();
            pathologieVM = new ConsultationsViewModel();
            this.DataContext = pathologieVM;

            _framePathologies.Navigate(new ServiceDetailsPage(pathologieVM));
            coloringTabs(PathologiesBtn, ApdateServiceDetailBtn);
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _framePathologies.Navigate(new ServiceDetailsPage(pathologieVM));
            coloringTabs(PathologiesBtn, ApdateServiceDetailBtn);
        }

        private void button_click_update_service(object sender, RoutedEventArgs e)
        {
            _framePathologies.Navigate(new UpdateServicePage(pathologieVM));
            coloringTabs(ApdateServiceDetailBtn, PathologiesBtn);
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

        private void coloringTabs(Button puprpleBtn, Button transparantBtn1)
        {
            puprpleBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            transparantBtn1.Background = Brushes.Transparent;

            puprpleBtn.Foreground = Brushes.White;
            transparantBtn1.Foreground = Brushes.Black;
        }
    }
}
