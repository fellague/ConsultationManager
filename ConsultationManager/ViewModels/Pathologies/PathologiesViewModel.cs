using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultationManager.Models;

namespace ConsultationManager.ViewModels.Pathologies
{
    internal class PathologiesViewModel
    {
        private ObservableCollection<Pathologie> listPathologies;

        public PathologiesViewModel()
        {
            listPathologies = CreatePathologies();
        }

        public ObservableCollection<Pathologie> ListPathologies
        {
            get
            {
                return listPathologies;
            }
        }

        private ObservableCollection<Pathologie> CreatePathologies()
        {
            ObservableCollection<Pathologie> list = new ObservableCollection<Pathologie>();
            list.Add(new Pathologie("Thyroide", "c'est une patholgie qui tklcs lj djlsjd sdflkjds lskdjns clkcd cdkljcd sdlk"));
            list.Add(new Pathologie("Cancer", "lkqskxc okqsxl qslkqskl xkl,xs xlkx xlk poqpx qsozaf sdzeed"));
            list.Add(new Pathologie("Diabetre", "zsdef sdlk sdcl,k cdmlksd epoied ioue oiusd diou"));
            list.Add(new Pathologie("Cardiologue", "oeuzi ezioefz eoiuef epfoize fpoiezpo zefoizef ezofioe zefoiuez zefiouez"));
            list.Add(new Pathologie("Poumon", "efzke eoizef zefoief zeoif zelfe zeflkeff zeklef elkjef zeflkj"));
            return list;
        }
    }
}
