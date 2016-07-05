using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultationManager.Models;

namespace ConsultationManager.ViewModels.Consultations
{
    internal class FirstConsultationViewModel
    {
        private RDV rdvConsult;

        public FirstConsultationViewModel(RDV rdv)
        {
            rdvConsult = rdv;
        }

        public RDV RdvConsult
        {
            get
            {
                return rdvConsult;
            }
        }
    }
}
