using System.Windows.Controls;
using ConsultationManagerClient.ViewModels.RDVs;

namespace ConsultationManagerClient.Views.RDVs
{
    /// <summary>
    /// Interaction logic for AllRdvPage.xaml
    /// </summary>
    public partial class AllRdvPage : Page
    {
        internal AllRdvPage(ListRvdViewModel rdvVM)
        {
            InitializeComponent();
            DataContext = rdvVM;
        }
    }
}
