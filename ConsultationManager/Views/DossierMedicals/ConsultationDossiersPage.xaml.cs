using ConsultationManager.ViewModels.DossierMedicals;
using ConsultationManagerClient.ViewModels.Patients;
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

namespace ConsultationManager.Views.DossierMedicals
{
    /// <summary>
    /// Interaction logic for ConsultationDossiersPage.xaml
    /// </summary>
    public partial class ConsultationDossiersPage : Page
    {
        internal ConsultationDossiersPage(DossierMedicalViewModel dossiersVM)
        {
            InitializeComponent();
            DataContext = dossiersVM;
        }
    }
}
