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
using ConsultationManager.ViewModels.RDVs;

namespace ConsultationManager.Views.RDVs
{
    /// <summary>
    /// Interaction logic for AllRdvPage.xaml
    /// </summary>
    public partial class AllRdvPage : Page
    {
        public AllRdvPage()
        {
            InitializeComponent();
            DataContext = new ListRvdViewModel();
        }
    }
}
