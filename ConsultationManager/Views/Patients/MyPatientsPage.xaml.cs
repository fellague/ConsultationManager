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

namespace ConsultationManager.Views.Patients
{
    /// <summary>
    /// Interaction logic for MyPatientsPage.xaml
    /// </summary>
    public partial class MyPatientsPage : Page
    {
        public MyPatientsPage()
        {
            InitializeComponent();

            List<Account> allList = new AccountList().GetData();

            List<Account> myList = new List<Account>();

            foreach (Account element in allList)
            {
                if (element.CreePar == "fellague halim")
                {
                    myList.Add(element);
                }
            }
            listViewMyAcount.ItemsSource = myList;
        }
    }
}
