using System.Windows.Controls;
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
