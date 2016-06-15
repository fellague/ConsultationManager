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
using ConsultationManager.Models;

namespace ConsultationManager.Views.RDVs
{
    /// <summary>
    /// Interaction logic for MyTodayRdvPage.xaml
    /// </summary>
    public partial class MyTodayRdvPage : Page
    {
        public MyTodayRdvPage()
        {
            InitializeComponent();
            List<RDV> allList = new RdvList().GetData();

            List<RDV> myList = new List<RDV>();
            DateTime today = new DateTime(2016, 10, 13);

            foreach (RDV element in allList)
            {
                if (element.NomMedecin == "mokrane" && element.PrenomMedecin == "fatiha" && element.DateRdv == today)
                {
                    myList.Add(element);
                }
            }
            listViewMyTodayRdv.ItemsSource = myList;
        }
    }
}
