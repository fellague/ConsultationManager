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
using ConsultationManagerClient.ViewModels.Users;

namespace ConsultationManagerClient.Views.Users
{
    /// <summary>
    /// Interaction logic for NewEmployeePage.xaml
    /// </summary>
    public partial class NewUserPage : Page
    {
        internal NewUserPage(UsersViewModel UsersVM)
        {
            InitializeComponent();
            DataContext = UsersVM;
        }
    }
}
