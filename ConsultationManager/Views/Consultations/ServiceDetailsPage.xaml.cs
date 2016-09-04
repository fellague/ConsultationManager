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
using ConsultationManagerClient.ViewModels.Consultations;

namespace ConsultationManagerClient.Views.Consultations
{
    /// <summary>
    /// Interaction logic for PathologiesPage.xaml
    /// </summary>
    public partial class ServiceDetailsPage : Page
    {
        internal ServiceDetailsPage(ConsultationsViewModel patholVM)
        {
            InitializeComponent();
            DataContext = patholVM;
        }
    }
}
