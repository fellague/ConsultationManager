using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using System.Runtime.CompilerServices;

namespace ConsultationManager.Views.RDVs
{
    //public class NewRdvViewModel : INotifyPropertyChanged
    //{
    //    private string _name;

    //    public string Name { get; set; }
    //    //public string Name
    //    //{
    //    //    get { return _name; }
    //    //    set
    //    //    {
    //    //        this.MutateVerbose(ref _name, value, RaisePropertyChanged());
    //    //    }
    //    //}

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private Action<PropertyChangedEventArgs> RaisePropertyChanged()
    //    {
    //        return args => PropertyChanged?.Invoke(this, args);
    //    }
    //}
    public class NewRdvViewModel : INotifyPropertyChanged
    {
        public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);

        private async void ExecuteRunDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new NewRdvUserControl
            {
                DataContext = new NewRdvViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        //public ICommand RunDialogCommand { get; }

        //private ResourceDictionary DialogDictionary = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Dialogs.xaml") };

        //public NewRdvViewModel()
        //{
        //    RunDialogCommand = new AnotherCommandImplementation(_ => InputDialog());
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        //private async void InputDialog()
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


        //    //var metroDialogSettings = new MetroDialogSettings
        //    //{
        //    //    CustomResourceDictionary = DialogDictionary,
        //    //    NegativeButtonText = "CANCEL",
        //    //    SuppressDefaultResources = true
        //    //};

        //    //DialogCoordinator.Instance.ShowInputAsync(this, "MahApps Dialog", "Using Material Design Themes", metroDialogSettings);
        //}

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
