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
using ConsultationManager.ViewModels.Hospitalisations;

namespace ConsultationManager.Views.Hospitalisations
{
    /// <summary>
    /// Interaction logic for NewHospitalisationPage.xaml
    /// </summary>
    public partial class NewDemandHospitalisationPage : Page
    {
        public NewDemandHospitalisationPage()
        {
            InitializeComponent();

            DataContext = new NewDemandHospitalisationViewModel();
        }
    }
}
