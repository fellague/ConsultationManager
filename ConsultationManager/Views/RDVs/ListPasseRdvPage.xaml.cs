using System.Windows.Controls;
using ConsultationManagerClient.ViewModels.RDVs;

namespace ConsultationManagerClient.Views.RDVs
{
    /// <summary>
    /// Interaction logic for AllMyRdvPage.xaml
    /// </summary>
    public partial class ListPasseRdvPage : Page
    {
        internal ListPasseRdvPage(ListRvdViewModel rdvVM)
        {
            InitializeComponent();
            DataContext = rdvVM;
        }
    }
}
