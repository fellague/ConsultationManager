using ConsultationManager.ViewModels.BtnsVisibility;
using ConsultationManager.Views;
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

namespace ConsultationManagerClient.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private VisibHomeVM homeViewModel;
        public Home()
        {
            InitializeComponent();
            homeViewModel = new VisibHomeVM();
            DataContext = homeViewModel;
            
        }


        private void showAllPatient(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MenuPatientWindow("all");
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
        private void showMyPatient(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MenuPatientWindow("my");
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
        private void showAllHospitalisation(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MenuHospitalisationWindow();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
        private void showAllRdv(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MenuRdvWindow();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void showAllEmployees(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MenuUserWindow();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void showPlannings(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MenuPlanningWindow();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void showMedicalFolders(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MenuDossierMedWindow();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void showPathologies(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MenuConsultationWindow();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }



}
