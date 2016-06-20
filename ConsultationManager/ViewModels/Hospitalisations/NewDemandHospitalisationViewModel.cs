using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManager.ViewModels.Hospitalisations
{
    internal class NewDemandHospitalisationViewModel
    {
        IList<int> listInt;
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

            listInt = new List<int>(Enumerable.Range(0, 100));
        }

        public IList<string> ListPatient
        {
            get
            {
                return listPatient;
            }
        }
        public IList<int> ListInt
        {
            get
            {
                return listInt;
            }
        }

    }
}
