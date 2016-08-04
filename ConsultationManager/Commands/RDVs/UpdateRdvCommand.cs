using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConsultationManagerClient.Models;
using ConsultationManagerClient.ViewModels.RDVs;

namespace ConsultationManagerClient.Commands.RDVs
{
    class UpdateRdvCommand: ICommand
    {
        private ListRvdViewModel vmList;
        private UpdateRdvViewModel vmUpdate;

        public UpdateRdvCommand(UpdateRdvViewModel vmUp, ListRvdViewModel vmLi)
        {
            this.vmUpdate = vmUp;
            this.vmList = vmLi;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            //return _ViewModel.CanUpdate;
            //return String.IsNullOrWhiteSpace(viewModel.Customer.Error);
            return true;
        }

        public void Execute(object parameter)
        {
            //Console.WriteLine("Update RDV command has executed");
            var selectedRDV = parameter as RDV;
            
            //Console.WriteLine("parameter " + selectedRDV.NomPatient);
            bool isUpadted = vmUpdate.UpdateRvd();
            if (isUpadted)
            {
                //vmList.SelectedRDV = selectedRDV;
                vmList.CloseDialogUpdateRvd(selectedRDV);
            }
        }

        #endregion
    }
}
