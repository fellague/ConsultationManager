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
using MaterialDesignColors;
using MaterialDesignThemes;
using ConsultationManagerClient.Models;
using ConsultationManagerClient.ViewModels.RDVs;

namespace ConsultationManagerClient.Views.RDVs
{
    /// <summary>
    /// Interaction logic for AllMyRdvPage.xaml
    /// </summary>
    public partial class AllMyRdvPage : Page
    {
        internal AllMyRdvPage(ListRvdViewModel rdvVM)
        {
            InitializeComponent();
            DataContext = rdvVM;
        }
    }
}
