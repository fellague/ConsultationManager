﻿using ConsultationManagerClient.ViewModels.RDVs;
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

namespace ConsultationManager.Views.RDVs
{
    /// <summary>
    /// Interaction logic for ListFuturRdvPage.xaml
    /// </summary>
    public partial class ListFuturRdvPage : Page
    {
        internal ListFuturRdvPage(ListRvdViewModel rdvVM)
        {
            InitializeComponent();
            DataContext = rdvVM;
        }
    }
}
