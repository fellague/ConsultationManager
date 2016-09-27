using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ConsultationManagerServer.Models
{
    [DataContract]
    public class DossierMed : INotifyPropertyChanged
    {
        private string idPatient;
        private string idMedecin;
        private string serviceId;
        private string pathologieId;
        private string identifiant;

        private string poids;
        private string ta;
        private string motif;
        private string histoire;
        private ObservableCollection<AntecedentPersonel> antecedPers;
        private ObservableCollection<AntecedentFamilial> antecedFamil;
        private string composeIode;
        private string trtsHorm;
        private string ast;
        private string chirurgie;
        private string iratherapie;
        private string autre;

        private bool asthenie;
        private bool psychisme;
        private bool evoltionPond;
        private bool developPsychoMot;
        private bool morphotype;

        private bool diffus;
        private bool uninodulaire;
        private bool multinodulaire;
        private bool elastique;
        private bool ferme;
        private bool indure;
        private bool renitent;
        private bool vasculaire;
        private bool compressif;
        private bool douloureux;
        private bool adenopathies;

        private string signesOculaire;
        private string signesCutaneomuqueux;

        private bool dyspnee;
        private bool ausculation;
        private bool precordialogies;
        private bool palpitations;

        private bool tremblement;
        private bool reflexesOT;
        private bool myasthenies;
        private bool autres;

        private bool appetit;
        private bool obdomen;
        private bool transit;

        private bool boissons;
        private bool developpementGenital;
        private bool diurese;
        private bool ddr;

        private string signesOsseux;
        private string signesLumphoGanglionnaires;

        private string conclusionClinique;

        private string tsh;
        private string ft3;
        private string ft4;
        private string tg;
        private string actg;
        private string actpo;
        private string tct;
        private string t41;
        private string t31;
        private string t4;

        private ObservableCollection<string> idInterviews;
        private ObservableCollection<string> idHospits;
        private ObservableCollection<string> idChirurgies;

        private DateTime creeDans;
        private string creePar;

        public DossierMed()
        {
            idPatient = "";
            idMedecin = "";
            serviceId = "";
            pathologieId = "";
            identifiant = "";

            poids = "";
            ta = "";
            motif = "";
            histoire = "";
            antecedPers = new ObservableCollection<AntecedentPersonel>();
            antecedFamil = new ObservableCollection<AntecedentFamilial>();
            composeIode = "";
            trtsHorm = "";
            ast = "";
            chirurgie = "";
            iratherapie = "";
            autre = "";

            asthenie = false;
            psychisme = false;
            evoltionPond = false;
            developPsychoMot = false;
            morphotype = false;

            diffus = false;
            uninodulaire = false;
            multinodulaire = false;
            elastique = false;
            ferme = false;
            indure = false;
            renitent = false;
            vasculaire = false;
            compressif = false;
            douloureux = false;
            adenopathies = false;

            signesOculaire = "";
            signesCutaneomuqueux = "";

            dyspnee = false;
            ausculation = false;
            precordialogies = false;
            palpitations = false;

            tremblement = false;
            reflexesOT = false;
            myasthenies = false;
            autres = false;

            appetit = false;
            obdomen = false;
            transit = false;

            boissons = false;
            developpementGenital = false;
            diurese = false;
            ddr = false;

            signesOsseux = "";
            signesLumphoGanglionnaires = "";

            conclusionClinique = "";

            tsh = "";
            ft3 = "";
            ft4 = "";
            tg = "";
            actg = "";
            actpo = "";
            tct = "";
            t41 = "";
            t31 = "";
            t4 = "";

            idInterviews = new ObservableCollection<string>();
            idHospits = new ObservableCollection<string>();
            idChirurgies = new ObservableCollection<string>();

            creeDans = new DateTime();
            creePar = "";
        }

        [BsonId]
        public ObjectId _id { get; set; }

        [DataMember]
        public string Id
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }

        [DataMember]
        public string IdPatient
        {
            get
            {
                return idPatient;
            }
            set
            {
                idPatient = value;
                OnPropertyChanged("IdPatient");
            }
        }

        [DataMember]
        public string IdMedecin
        {
            get
            {
                return idMedecin;
            }
            set
            {
                idMedecin = value;
                OnPropertyChanged("IdMedecin");
            }
        }
        
        [DataMember]
        public string ServiceId
        {
            get
            {
                return serviceId;
            }
            set
            {
                serviceId = value;
                OnPropertyChanged("ServiceId");
            }
        }
        [DataMember]
        public string PathologieId
        {
            get
            {
                return pathologieId;
            }
            set
            {
                pathologieId = value;
                OnPropertyChanged("PathologieId");
            }
        }

        [DataMember]
        public string Identifiant
        {
            get
            {
                return identifiant;
            }
            set
            {
                identifiant = value;
                OnPropertyChanged("Identifiant");
            }
        }

        [DataMember]
        public string Poids
        {
            get
            {
                return poids;
            }
            set
            {
                poids = value;
                OnPropertyChanged("Poids");
            }
        }

        [DataMember]
        public string TA
        {
            get
            {
                return ta;
            }
            set
            {
                ta = value;
                OnPropertyChanged("TA");
            }
        }

        [DataMember]
        public string Motif
        {
            get
            {
                return motif;
            }
            set
            {
                motif = value;
                OnPropertyChanged("Motif");
            }
        }

        [DataMember]
        public string Histoire
        {
            get
            {
                return histoire;
            }
            set
            {
                histoire = value;
                OnPropertyChanged("Histoire");
            }
        }

        [DataMember]
        public ObservableCollection<AntecedentPersonel> AntecedPers
        {
            get
            {
                return antecedPers;
            }
            set
            {
                antecedPers = value;
                OnPropertyChanged("AntecedPers");
            }
        }

        [DataMember]
        public ObservableCollection<AntecedentFamilial> AntecedFamil
        {
            get
            {
                return antecedFamil;
            }
            set
            {
                antecedFamil = value;
                OnPropertyChanged("AntecedFamil");
            }
        }

        [DataMember]
        public string ComposeIode
        {
            get
            {
                return composeIode;
            }
            set
            {
                composeIode = value;
                OnPropertyChanged("ComposeIode");
            }
        }

        [DataMember]
        public string TrtsHorm
        {
            get
            {
                return trtsHorm;
            }
            set
            {
                trtsHorm = value;
                OnPropertyChanged("TrtsHorm");
            }
        }

        [DataMember]
        public string AST
        {
            get
            {
                return ast;
            }
            set
            {
                ast = value;
                OnPropertyChanged("AST");
            }
        }

        [DataMember]
        public string Chirurgie
        {
            get
            {
                return chirurgie;
            }
            set
            {
                chirurgie = value;
                OnPropertyChanged("Chirurgie");
            }
        }

        [DataMember]
        public string Iratherapie
        {
            get
            {
                return iratherapie;
            }
            set
            {
                iratherapie = value;
                OnPropertyChanged("Iratherapie");
            }
        }

        [DataMember]
        public string Autre
        {
            get
            {
                return autre;
            }
            set
            {
                autre = value;
                OnPropertyChanged("Autre");
            }
        }

        [DataMember]
        public bool Asthenie
        {
            get
            {
                return asthenie;
            }
            set
            {
                asthenie = value;
                OnPropertyChanged("Asthenie");
            }
        }

        [DataMember]
        public bool Psychisme
        {
            get
            {
                return psychisme;
            }
            set
            {
                psychisme = value;
                OnPropertyChanged("Psychisme");
            }
        }

        [DataMember]
        public bool EvoltionPond
        {
            get
            {
                return evoltionPond;
            }
            set
            {
                evoltionPond = value;
                OnPropertyChanged("EvoltionPond");
            }
        }
        [DataMember]
        public bool DevelopPsychoMot
        {
            get
            {
                return developPsychoMot;
            }
            set
            {
                developPsychoMot = value;
                OnPropertyChanged("DevelopPsychoMot");
            }
        }
        [DataMember]
        public bool Morphotype
        {
            get
            {
                return morphotype;
            }
            set
            {
                morphotype = value;
                OnPropertyChanged("Morphotype");
            }
        }

        [DataMember]
        public bool Diffus
        {
            get
            {
                return diffus;
            }
            set
            {
                diffus = value;
                OnPropertyChanged("Diffus");
            }
        }
        [DataMember]
        public bool Uninodulaire
        {
            get
            {
                return uninodulaire;
            }
            set
            {
                uninodulaire = value;
                OnPropertyChanged("Uninodulaire");
            }
        }
        [DataMember]
        public bool Multinodulaire
        {
            get
            {
                return multinodulaire;
            }
            set
            {
                multinodulaire = value;
                OnPropertyChanged("Multinodulaire");
            }
        }
        [DataMember]
        public bool Elastique
        {
            get
            {
                return elastique;
            }
            set
            {
                elastique = value;
                OnPropertyChanged("Elastique");
            }
        }
        [DataMember]
        public bool Ferme
        {
            get
            {
                return ferme;
            }
            set
            {
                ferme = value;
                OnPropertyChanged("Ferme");
            }
        }
        [DataMember]
        public bool Indure
        {
            get
            {
                return indure;
            }
            set
            {
                indure = value;
                OnPropertyChanged("Indure");
            }
        }
        [DataMember]
        public bool Renitent
        {
            get
            {
                return renitent;
            }
            set
            {
                renitent = value;
                OnPropertyChanged("Renitent");
            }
        }
        [DataMember]
        public bool Vasculaire
        {
            get
            {
                return vasculaire;
            }
            set
            {
                vasculaire = value;
                OnPropertyChanged("Vasculaire");
            }
        }
        [DataMember]
        public bool Compressif
        {
            get
            {
                return compressif;
            }
            set
            {
                compressif = value;
                OnPropertyChanged("Compressif");
            }
        }
        [DataMember]
        public bool Douloureux
        {
            get
            {
                return douloureux;
            }
            set
            {
                douloureux = value;
                OnPropertyChanged("Douloureux");
            }
        }
        [DataMember]
        public bool Adenopathies
        {
            get
            {
                return adenopathies;
            }
            set
            {
                adenopathies = value;
                OnPropertyChanged("Adenopathies");
            }
        }

        [DataMember]
        public string SignesOculaire
        {
            get
            {
                return signesOculaire;
            }
            set
            {
                signesOculaire = value;
                OnPropertyChanged("SignesOculaire");
            }
        }
        [DataMember]
        public string SignesCutaneomuqueux
        {
            get
            {
                return signesCutaneomuqueux;
            }
            set
            {
                signesCutaneomuqueux = value;
                OnPropertyChanged("SignesCutaneomuqueux");
            }
        }

        [DataMember]
        public bool Dyspnee
        {
            get
            {
                return dyspnee;
            }
            set
            {
                dyspnee = value;
                OnPropertyChanged("Dyspnee");
            }
        }
        [DataMember]
        public bool Ausculation
        {
            get
            {
                return ausculation;
            }
            set
            {
                ausculation = value;
                OnPropertyChanged("Ausculation");
            }
        }
        [DataMember]
        public bool Precordialogies
        {
            get
            {
                return precordialogies;
            }
            set
            {
                precordialogies = value;
                OnPropertyChanged("Precordialogies");
            }
        }
        [DataMember]
        public bool Palpitations
        {
            get
            {
                return palpitations;
            }
            set
            {
                palpitations = value;
                OnPropertyChanged("Palpitations");
            }
        }

        [DataMember]
        public bool Tremblement
        {
            get
            {
                return tremblement;
            }
            set
            {
                tremblement = value;
                OnPropertyChanged("Tremblement");
            }
        }
        [DataMember]
        public bool ReflexesOT
        {
            get
            {
                return reflexesOT;
            }
            set
            {
                reflexesOT = value;
                OnPropertyChanged("ReflexesOT");
            }
        }
        [DataMember]
        public bool Myasthenies
        {
            get
            {
                return myasthenies;
            }
            set
            {
                myasthenies = value;
                OnPropertyChanged("Myasthenies");
            }
        }
        [DataMember]
        public bool Autres
        {
            get
            {
                return autres;
            }
            set
            {
                autres = value;
                OnPropertyChanged("Autres");
            }
        }

        [DataMember]
        public bool Appetit
        {
            get
            {
                return appetit;
            }
            set
            {
                appetit = value;
                OnPropertyChanged("Appetit");
            }
        }
        [DataMember]
        public bool Obdomen
        {
            get
            {
                return obdomen;
            }
            set
            {
                obdomen = value;
                OnPropertyChanged("Obdomen");
            }
        }
        [DataMember]
        public bool Transit
        {
            get
            {
                return transit;
            }
            set
            {
                transit = value;
                OnPropertyChanged("Transit");
            }
        }

        [DataMember]
        public bool Boissons
        {
            get
            {
                return boissons;
            }
            set
            {
                boissons = value;
                OnPropertyChanged("Boissons");
            }
        }
        [DataMember]
        public bool DeveloppementGenital
        {
            get
            {
                return developpementGenital;
            }
            set
            {
                developpementGenital = value;
                OnPropertyChanged("DeveloppementGenital");
            }
        }
        [DataMember]
        public bool Diurese
        {
            get
            {
                return diurese;
            }
            set
            {
                diurese = value;
                OnPropertyChanged("Diurese");
            }
        }
        [DataMember]
        public bool DDR
        {
            get
            {
                return ddr;
            }
            set
            {
                ddr = value;
                OnPropertyChanged("DDR");
            }
        }

        [DataMember]
        public string SignesOsseux
        {
            get
            {
                return signesOsseux;
            }
            set
            {
                signesOsseux = value;
                OnPropertyChanged("SignesOsseux");
            }
        }
        [DataMember]
        public string SignesLumphoGanglionnaires
        {
            get
            {
                return signesLumphoGanglionnaires;
            }
            set
            {
                signesLumphoGanglionnaires = value;
                OnPropertyChanged("SignesLumphoGanglionnaires");
            }
        }

        [DataMember]
        public string ConclusionClinique
        {
            get
            {
                return conclusionClinique;
            }
            set
            {
                conclusionClinique = value;
                OnPropertyChanged("ConclusionClinique");
            }
        }

        [DataMember]
        public string TSH
        {
            get
            {
                return tsh;
            }
            set
            {
                tsh = value;
                OnPropertyChanged("TSH");
            }
        }
        [DataMember]
        public string FT3
        {
            get
            {
                return ft3;
            }
            set
            {
                ft3 = value;
                OnPropertyChanged("FT3");
            }
        }
        [DataMember]
        public string FT4
        {
            get
            {
                return ft4;
            }
            set
            {
                ft4 = value;
                OnPropertyChanged("FT4");
            }
        }
        [DataMember]
        public string TG
        {
            get
            {
                return tg;
            }
            set
            {
                tg = value;
                OnPropertyChanged("TG");
            }
        }
        [DataMember]
        public string ACTG
        {
            get
            {
                return actg;
            }
            set
            {
                actg = value;
                OnPropertyChanged("ACTG");
            }
        }
        [DataMember]
        public string ACTPO
        {
            get
            {
                return actpo;
            }
            set
            {
                actpo = value;
                OnPropertyChanged("ACTPO");
            }
        }
        [DataMember]
        public string TCT
        {
            get
            {
                return tct;
            }
            set
            {
                tct = value;
                OnPropertyChanged("TCT");
            }
        }
        [DataMember]
        public string T41
        {
            get
            {
                return t41;
            }
            set
            {
                t41 = value;
                OnPropertyChanged("T41");
            }
        }
        [DataMember]
        public string T31
        {
            get
            {
                return t31;
            }
            set
            {
                t31 = value;
                OnPropertyChanged("T31");
            }
        }
        [DataMember]
        public string T4
        {
            get
            {
                return t4;
            }
            set
            {
                t4 = value;
                OnPropertyChanged("T4");
            }
        }

        [DataMember]
        public ObservableCollection<string> IdInterviews
        {
            get
            {
                return idInterviews;
            }
            set
            {
                idInterviews = value;
                OnPropertyChanged("IdInterviews");
            }
        }
        [DataMember]
        public ObservableCollection<string> IdIntervHospits
        {
            get
            {
                return idHospits;
            }
            set
            {
                idHospits = value;
                OnPropertyChanged("IdIntervHospits");
            }
        }
        [DataMember]
        public ObservableCollection<string> IdChirurgies
        {
            get
            {
                return idChirurgies;
            }
            set
            {
                idChirurgies = value;
                OnPropertyChanged("IdChirurgies");
            }
        }

        [DataMember]
        public DateTime CreeDans
        {
            get
            {
                return creeDans;
            }
            set
            {
                creeDans = value;
                OnPropertyChanged("CreeDans");
            }
        }

        [DataMember]
        public string CreePar
        {
            get
            {
                return creePar;
            }
            set
            {
                creePar = value;
                OnPropertyChanged("CreePar");
            }
        }

        #region InotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}