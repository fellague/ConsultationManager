using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultationManager.Models;
using ConsultationManager.Commands.RDVs;
using System.Windows.Input;
using System.Windows;

namespace ConsultationManager.ViewModels.RDVs
{
    internal class UpdateRdvViewModel
    {
        private RDV updatedRdv;

        public UpdateRdvViewModel(RDV rdv, ListRvdViewModel vmLi)
        {
            updatedRdv = rdv;
            UpdateRdvCommand = new UpdateRdvCommand(this, vmLi);
        }

        public RDV UpdatedRdv
        {
            get
            {
                return updatedRdv;
            }
        }

        public ICommand UpdateRdvCommand
        {
            get;
            private set;
        }

        public bool UpdateRvd()
        {
            Console.WriteLine("UpdateRdvViewModel : update rdv command executed  " + updatedRdv.DateRdv);
            //some data base code
            return true;
        }
    }
}
