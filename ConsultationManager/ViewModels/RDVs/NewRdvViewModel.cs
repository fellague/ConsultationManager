using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultationManagerClient.ViewModels.RDVs
{
    internal class NewRdvViewModel
    {
        IList<string> listPatient;
        IList<int> listMois;
        IList<int> listJours;

        public NewRdvViewModel()
        {
            listPatient = new List<string>();
            listPatient.Add("Mickel Jacson");
            listPatient.Add("Will Smith");
            listPatient.Add("Bennouna El Khebith");
            listPatient.Add("Kayta Kader");
            listPatient.Add("Kader Ejjappouni");
            listPatient.Add("Will Pharel");

            listMois = new List<int>(Enumerable.Range(1, 24));
            listJours = new List<int>(Enumerable.Range(1, 30));
        }

        public IList<string> ListPatient
        {
            get
            {
                return listPatient;
            }
        }
        public IList<int> ListMois
        {
            get
            {
                return listMois;
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
