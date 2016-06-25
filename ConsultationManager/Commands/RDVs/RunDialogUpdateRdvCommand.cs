using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConsultationManager.ViewModels.RDVs;
using ConsultationManager.Models;

namespace ConsultationManager.Commands.RDVs
{
    class RunDialogUpdateRdvCommand : ICommand
    {
        private ListRvdViewModel viewModel;

        public RunDialogUpdateRdvCommand(ListRvdViewModel viewModel)
        {
            this.viewModel = viewModel;
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
            var selectedRDV = parameter as RDV;
            viewModel.ShowDialogUpdateRvd(selectedRDV);
        }

        #endregion
    }
}
