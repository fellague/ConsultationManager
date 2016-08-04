using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerClient.ViewModels.Hospitalisations
{
    internal class NewDemandHospitalisationViewModel
    {
        IList<int> listJours;
        IList<string> listPatient;

        public NewDemandHospitalisationViewModel()
        {
            listPatient = new List<string>();
            listPatient.Add("Mickel Jacson");
            listPatient.Add("Will Smith");
            listPatient.Add("Bennouna El Khebith");
            listPatient.Add("Kayta Kader");
            listPatient.Add("Kader Ejjappouni");
            listPatient.Add("Will Pharel");

            listJours = new List<int>(Enumerable.Range(1, 100));
        }

        public IList<string> ListPatient
        {
            get
            {
                return listPatient;
            }
        }
        public IList<int> ListJours
        {
            get
            {
                return listJours;
            }
        }

    }
}
