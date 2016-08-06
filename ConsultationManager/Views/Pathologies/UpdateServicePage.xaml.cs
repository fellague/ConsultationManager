using ConsultationManagerClient.ViewModels.Pathologies;
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

namespace ConsultationManagerClient.Views.Pathologies
{
    /// <summary>
    /// Interaction logic for UpdateServicePage.xaml
    /// </summary>
    public partial class UpdateServicePage : Page
    {
        internal UpdateServicePage(PathologiesViewModel patholVM)
        {
            InitializeComponent();
            DataContext = patholVM;
        }
    }
}
