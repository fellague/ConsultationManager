using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsultationManagerServer.Models;
using ConsultationManagerServer.Models.SerializedModels;

using System.ServiceModel.Activation;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using System.Windows;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

namespace ConsultationManagerServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PathologieService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PathologieService.svc or PathologieService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PathologieService : IPathologieService
    {
        public ServicePathologies GetServiceDetails()
        {
            ServicePathologies servPathol = new ServicePathologies();
            //Service service = new Service();
            
            DataBaseContext db = new DataBaseContext();
            servPathol.Service = db.Services.FindOne();
            if (servPathol.Service  == null)
            {
                MessageBox.Show("There is no service, a new service is initiated... ");
                servPathol.Service = CreateService();
            }
            else
            {
                try
                {
                    //List<Pathologie> pathols = new List<Pathologie>();
                    //servPathol.ListPthologie=db.Pathologies.FindAll()
                    //pathols = db.Pathologies.AsQueryable().Where(p => p.IdService == service.Id).ToList();
                    if (db.Pathologies.Exists())
                    {
                        var pathols = db.Pathologies.AsQueryable().Where(p => p.IdService == servPathol.Service.Id).ToList();
                        //var pathols = db.Pathologies.FindAll().Where(p => p.IdService == service.Id).ToList();
                        if (pathols.Count() > 0)
                            foreach (Pathologie item in pathols)
                                servPathol.ListPthologie.Add(item);
                        else
                        {
                            MessageBox.Show("There is no pathologie for the service... ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Pathologies collection, No pathologie had ever been created... ");
                        return servPathol;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("A Server Exeption has accured" + error.Message);
                }
            }
            return servPathol;
        }

        public Pathologie AddPathologie(Pathologie pathologieSaved)
        {
            Pathologie patholog = new Pathologie();
            ObservableCollection<Pathologie> listPathologies = new ObservableCollection<Pathologie>();


            DataBaseContext db = new DataBaseContext();
            db.Pathologies.Save(pathologieSaved);

            //var pathologExist = db.Pathologies.AsQueryable().Where(p => p.Nom == pathologieSaved.Nom && p.IdService == pathologieSaved.IdService);
            //if (pathologExist.Any() || !db.Pathologies.Exists())
            //{
            //    MessageBox.Show("Pathologie Saved... ");
            //    db.Pathologies.Save(pathologieSaved);
            //}
            //else
            //{
            //    MessageBox.Show("Pathologie Already exist... ");
            //}

            return pathologieSaved;
        }

        public Service UpdateService(string id, Service upService)
        {
            //MessageBox.Show("ServicePathologies service Received an Update request for the service..." + upService.Id);
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", upService.Id);
            var update = Update
                .Set("Nom", upService.Nom)
                .Set("DateOuverture", upService.DateOuverture)
                .Set("Domaine", upService.Domaine)
                .Set("Adresse", upService.Adresse)
                .Set("Telephones", new BsonArray(upService.Telephones));
            var result = db.Services.FindAndModify(query, null, update);
            return upService;
        }

        public Pathologie UpdatePathologie(string id, Pathologie pathologie)
        {
            MessageBox.Show("ServicePathologies service Received an Update request for the pathologie..." + pathologie.Id);
            DataBaseContext db = new DataBaseContext();
            var query = Query.EQ("Id", pathologie.Id);
            var update = Update.Set("Nom", pathologie.Nom).Set("Description", pathologie.Description);
            var result = db.Pathologies.FindAndModify(query, null, update);
            return pathologie;
        }

        public void DeletePathologie(string id)
        {
            DataBaseContext db = new DataBaseContext();
            db.Pathologies.Remove(Query.EQ("Id", id));
        }

        private Service CreateService()
        {
            Service service = new Service();

            service.Nom = "Endochrinologie";
            service.DateOuverture = DateTime.Now;
            service.Domaine = "L’unité d’endocrinologie prend en charge des patients souffrant de maladies endocriniennes et assure le diagnostic, le traitement, le suivi et la prise en charge globale des patients, en mettant à leur disposition compétences, techniques de diagnostic et traitements les plus récents.";
            service.Adresse = "Chlef hay essalem n 3";
            service.Telephones.Add("021 87 54 43");
            service.Telephones.Add("021 27 53 43");
            DataBaseContext db = new DataBaseContext();
            db.Services.Save(service);
            return service;
        }

        //private ObservableCollection<Pathologie> CreatePathologies()
        //{
        //    ObservableCollection<Pathologie> listPathologies = new ObservableCollection<Pathologie>();

        //    listPathologies.Add(new Pathologie { Nom = "Thyroide", Description = "c'est une patholgie qui tklcs lj djlsjd sdflkjds lskdjns clkcd cdkljcd sdlk" });
        //    listPathologies.Add(new Pathologie { Nom = "Cancer", Description = "lkqskxc okqsxl qslkqskl xkl,xs xlkx xlk poqpx qsozaf sdzeed" });
        //    listPathologies.Add(new Pathologie { Nom = "Diabetre", Description = "zsdef sdlk sdcl,k cdmlksd epoied ioue oiusd diou" });
        //    listPathologies.Add(new Pathologie { Nom = "Cardiologue", Description = "oeuzi ezioefz eoiuef epfoize fpoiezpo zefoizef ezofioe zefoiuez zefiouez" });
        //    listPathologies.Add(new Pathologie { Nom = "Poumon", Description = "efzke eoizef zefoief zeoif zelfe zeflkeff zeklef elkjef zeflkj" });
        //    DataBaseContext db = new DataBaseContext();
        //    foreach (Pathologie patholog in listPathologies)
        //        db.Pathologies.Save(patholog);
        //    //db.Services.Save(service);
        //    return listPathologies;
        //}

    }
}
