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
using ConsultationManagerClient.ViewModels.Employees;

namespace ConsultationManagerClient.Views.Employees
{
    /// <summary>
    /// Interaction logic for AssistantsPage.xaml
    /// </summary>
    public partial class AssistantsPage : Page
    {
        public AssistantsPage()
        {
            InitializeComponent();
            DataContext = new ListEmployeesViewModel();
        }
    }
}
