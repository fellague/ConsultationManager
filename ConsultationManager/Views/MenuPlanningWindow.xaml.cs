using ConsultationManager.ViewModels.Plannings;
using ConsultationManager.Views.Plannings;
using ConsultationManagerClient.Views;
using ConsultationManagerClient.Views.Plannings;
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
    /// Interaction logic for MenuPlanningWindow.xaml
    /// </summary>
    public partial class MenuPlanningWindow : Window
    {
        private PlanningsViewModel planningVM;
        public MenuPlanningWindow()
        {
            InitializeComponent();

            planningVM = new PlanningsViewModel();
            this.DataContext = planningVM;

            _mainFrame.Navigate(new AllPlanningsPage(planningVM));
            coloringTabs(PlanningsBtn, UpdatePlanningBtn);
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AllPlanningsPage(planningVM));
            coloringTabs(PlanningsBtn, UpdatePlanningBtn);
        }

        private void button_click_update(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new UpdatePlanningPage(planningVM));
            coloringTabs(UpdatePlanningBtn, PlanningsBtn);
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
