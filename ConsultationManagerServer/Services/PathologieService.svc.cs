using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models;
using System.ServiceModel.Activation;
using System.Collections.ObjectModel;
using MongoDB.Bson;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PathologieService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PathologieService.svc or PathologieService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PathologieService : IPathologieService
    {

        public Service GetAllPathologies()
        {
            Service service = new Service();
            service.Id = "";
            service.Nom = "Endochrinoe";
            service.DateOuverture = DateTime.Now;
            service.Domaine = "dkjsc sdlksc sdlksc sdlksd lksd dlk sdlksd sdlksd sdlksd sdclksd lksd sdlksd sdlkn cdlksd dlkze sdlkn sdsdnd sdlk";
            service.Adresse = "Chlef hay essalem n 3";
            service.Telephones.Add("021 87 54 43");
            service.Telephones.Add("021 27 53 43");
            service.Pathologies = CreatePathologies();

            return service;
        }

        public Pathologie GetPathologie(string id)
        {
            ObservableCollection<Pathologie> pathologs = CreatePathologies();
            Pathologie patholog = pathologs.Where(w => w.Id.Equals(id)).First();
            return patholog;
        }

        public bool AddPathologie(Pathologie pathologie)
        {
            return true;
        }

        public void UpdatePathologie(string id, Pathologie pathologie)
        {
            throw new NotImplementedException();
        }
        
        public void DeletePathologie(string id)
        {
            throw new NotImplementedException();
        }

        private ObservableCollection<Pathologie> CreatePathologies()
        {
            ObservableCollection<Pathologie> list = new ObservableCollection<Pathologie>();
            list.Add(new Pathologie("1", "Thyroide", "c'est une patholgie qui tklcs lj djlsjd sdflkjds lskdjns clkcd cdkljcd sdlk"));
            list.Add(new Pathologie("2", "Cancer", "lkqskxc okqsxl qslkqskl xkl,xs xlkx xlk poqpx qsozaf sdzeed"));
            list.Add(new Pathologie("3", "Diabetre", "zsdef sdlk sdcl,k cdmlksd epoied ioue oiusd diou"));
            list.Add(new Pathologie("4", "Cardiologue", "oeuzi ezioefz eoiuef epfoize fpoiezpo zefoizef ezofioe zefoiuez zefiouez"));
            list.Add(new Pathologie("5", "Poumon", "efzke eoizef zefoief zeoif zelfe zeflkeff zeklef elkjef zeflkj"));
            return list;
        }
    }
}
