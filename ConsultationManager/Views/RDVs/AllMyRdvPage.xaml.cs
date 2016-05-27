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
using MaterialDesignColors;
using MaterialDesignThemes;

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

        //public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);

        //private async void ExecuteRunDialog(object o)
        //{
        //    //let's set up a little MVVM, cos that's what the cool kids are doing:
        //    var view = new NewRdvUserControl
        //    {
        //        DataContext = new NewRdvViewModel()
        //    };

        //    //show the dialog
        //    var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);

        //    //check the result...
        //    Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        //}
    }
}
