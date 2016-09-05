using ConsultationManager.ViewModels.Plannings;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConsultationManager.Views.Plannings
{
    /// <summary>
    /// Interaction logic for UpdatePlanningPage.xaml
    /// </summary>
    public partial class UpdatePlanningPage : Page
    {
        internal UpdatePlanningPage(PlanningsViewModel planningVM)
        {
            InitializeComponent();
            DataContext = planningVM;
        }
    }
}
