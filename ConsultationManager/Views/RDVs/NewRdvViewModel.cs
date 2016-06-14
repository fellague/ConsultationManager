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
    public class NewRdvViewModel : INotifyPropertyChanged
    {
        public NewRdvViewModel()
        {
            Console.WriteLine("yow yow");
            RunDialogCommand = new AnotherCommandImplementation(ExecuteRunDialog);
            
        }


        public ICommand RunDialogCommand {
            get;
            private set;
        }

        private async void ExecuteRunDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            Console.WriteLine("yow yow from the command");

            var view = new NewRdvUserControl
            {
                DataContext = new NewRdvViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
