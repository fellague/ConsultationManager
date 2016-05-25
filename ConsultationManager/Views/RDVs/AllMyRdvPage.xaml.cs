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

namespace ConsultationManager.Views.RDVs
{
    /// <summary>
    /// Interaction logic for AllMyRdvPage.xaml
    /// </summary>
    public partial class AllMyRdvPage : Page
    {
        public AllMyRdvPage()
        {
            InitializeComponent();
            List<RDV> allList = new RdvList().GetData();

            List<RDV> myList = new List<RDV>();

            foreach (RDV element in allList)
            {
                if (element.NomMedecin == "mokrane" && element.PrenomMedecin== "fatiha")
                {
                    myList.Add(element);
                }
            }
            listViewAllMyRdv.ItemsSource = myList;
        }
    }
}
