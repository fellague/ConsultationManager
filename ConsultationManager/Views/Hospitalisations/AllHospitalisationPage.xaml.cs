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
using ConsultationManagerClient.ViewModels.Hospitalisations;

namespace ConsultationManagerClient.Views.Hospitalisations
{
    /// <summary>
    /// Interaction logic for AllHospitalisationPage.xaml
    /// </summary>
    public partial class AllHospitalisationPage : Page
    {
        internal AllHospitalisationPage(ListHospitalisationViewModel hospitVM)
        {
            InitializeComponent();

            DataContext = hospitVM;
        }
    }
}
