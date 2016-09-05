﻿using ConsultationManager.Views;
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
        public Home()
        {
            InitializeComponent();
        }
        public List<EducationContent> EducationContents { get { return ConsultationManagerClient.Views.EducationContents.DataSource; } }
        public List<EmployeeContent> EmployeeContents { get { return ConsultationManagerClient.Views.EmployeeContents.DataSource; } }

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

        private void showPathologies(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new MenuConsultationWindow();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }

    public class EducationContent
    {
        public string HeaderCont { get; set; }
        public string TextCont { get; set; }
        public string Photo { get; set; }
        public ImageSource PhotoSource
        {
            get
            {
                return string.IsNullOrEmpty(Photo) ? null : new BitmapImage(new Uri(Photo, UriKind.Relative));
            }
        }
    }
    public static class EducationContents
    {
        public static readonly List<EducationContent> DataSource =
            new List<EducationContent> {
                new EducationContent { HeaderCont = "Education thérapeutique", TextCont = "Visualiser tous les rapport d'éducation thérapeutique", Photo = "/ConsultationManager;component/Imgs/Home/education.png" },
                new EducationContent { HeaderCont = "Education thérapeutique", TextCont = "Editer un rapport d'éducation thérapeutique", Photo = "/ConsultationManager;component/Imgs/Home/education-rapport.png" }
            };
    }

    public class EmployeeContent
    {
        public string HeaderCont { get; set; }
        public string TextCont { get; set; }
        public string Photo { get; set; }
        public ImageSource PhotoSource
        {
            get
            {
                return string.IsNullOrEmpty(Photo) ? null : new BitmapImage(new Uri(Photo, UriKind.Relative));
            }
        }
    }
    public static class EmployeeContents
    {
        public static readonly List<EmployeeContent> DataSource =
            new List<EmployeeContent> {
                new EmployeeContent { HeaderCont = "Utilisateurs", TextCont = "Afficher et modifier la liste des utilisateurs", Photo = "/ConsultationManager;component/Imgs/Home/staff.jpg" },
                new EmployeeContent { HeaderCont = "Accès", TextCont = "Controller les droits d'accès des utilisateurs", Photo = "/ConsultationManager;component/Imgs/Home/roles.png" }
            };
    }

}
