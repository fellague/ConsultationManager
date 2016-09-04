﻿using System;
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
using ConsultationManagerClient.ViewModels.Patients;

namespace ConsultationManagerClient.Views.Patients
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AllPatientsPage : Page
    {
        internal AllPatientsPage(PatientsViewModel patientsVM)
        {
            InitializeComponent();
            //DataContext = new ListPatientViewModel();
            DataContext = patientsVM;
        }
    }
}
