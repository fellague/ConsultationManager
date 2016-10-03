using ConsultationManager.ViewModels.BtnsVisibility;
using ConsultationManager.ViewModels.DossierMedicals;
using ConsultationManager.Views.DossierMedicals;
using ConsultationManager.Views.Patients;
using ConsultationManagerClient.ViewModels.Patients;
using ConsultationManagerClient.Views;
using ConsultationManagerClient.Views.Patients;
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

namespace ConsultationManager.Views
{
    /// <summary>
    /// Interaction logic for MenuDossierMed.xaml
    /// </summary>
    public partial class MenuDossierMedWindow : Window
    {
        ListDossMedViewModel dossiersVM;

        public MenuDossierMedWindow()
        {
            InitializeComponent();

            dossiersVM = new ListDossMedViewModel();
            this.DataContext = new VisibDossierVM();
            _mainFrame.Navigate(new MyDossierPage(dossiersVM));
            coloringTabs(MyPatBtn, AllPatBtn, ListNewPatBtn, GridServiceBtn);
            
        }
        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AllDossiersPage(dossiersVM));
            coloringTabs(AllPatBtn, MyPatBtn, ListNewPatBtn, GridServiceBtn);
        }

        private void button_click_list_consulation(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ConsultationDossiersPage(dossiersVM));
            coloringTabs(ListNewPatBtn, MyPatBtn, AllPatBtn, GridServiceBtn);
        }

        private void button_click_mes(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new MyDossierPage(dossiersVM));
            coloringTabs(MyPatBtn, AllPatBtn, ListNewPatBtn, GridServiceBtn);
        }

        //private void button_click_grid_my(object sender, RoutedEventArgs e)
        //{
        //    _mainFrame.Navigate(new GridMyDossiersPage(dossiersVM));
        //    coloringTabs(GridMyBtn, MyPatBtn, AllPatBtn, ListNewPatBtn, GridConsultBtn, GridServiceBtn);
        //}
        //private void button_click_grid_consult(object sender, RoutedEventArgs e)
        //{
        //    _mainFrame.Navigate(new GridConsultDossierPage(dossiersVM));
        //    coloringTabs(GridConsultBtn, GridMyBtn, MyPatBtn, AllPatBtn, ListNewPatBtn, GridServiceBtn);
        //}
        private void button_click_grid_service(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new GridAllDossierPage(dossiersVM));
            coloringTabs(GridServiceBtn, MyPatBtn, AllPatBtn, ListNewPatBtn);
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
