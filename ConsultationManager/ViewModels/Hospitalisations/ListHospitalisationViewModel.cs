using System;
using ConsultationManagerServer.Models;
using System.Collections.ObjectModel;
using ConsultationManagerClient.ViewModels.Authentication;
using ConsultationManagerServer.Models.Hospitalisations;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ConsultationManagerClient.Commands;
using System.Windows;
using ConsultationManager.Views.Hospitalisations;
using ConsultationManager.ServiceReferenceSalle;
using System.ServiceModel.Security;
using ConsultationManagerServer.Models.SerializedModels;
using ConsultationManager.ServiceReferenceHospit;
using ConsultationManager.ViewModels.Hospitalisations;
using ConsultationManager.Views.DossierMedicals;
using ConsultationManager.ServiceReferenceDossierMed;
using ConsultationManager.ServiceReferenceRdv;
using ConsultationManager.ViewModels.DossierMedicals;
using System.Collections.Generic;

namespace ConsultationManagerClient.ViewModels.Hospitalisations
{
    internal class ListHospitalisationViewModel : INotifyPropertyChanged
    {
        private SalleServiceClient ssc = new SalleServiceClient();
        private HospitServiceClient hsc = new HospitServiceClient();
        private RdvServiceClient rsc = new RdvServiceClient();

        private string nomUtilisateur;
        private ObservableCollection<HospitalisationDetail> listAllHospitalisation;
        private ObservableCollection<HospitalisationDetail> listPasseHospitalisation;
        private ObservableCollection<HospitalisationDetail> listActiveHospitalisation;
        private ObservableCollection<HospitalisationDetail> listFuturHospitalisation;
        private ObservableCollection<HospitalisationDetail> listAttenteHospitalisation;
        private ObservableCollection<HospitalisationDetail> listRateHospitalisation;

        private ObservableCollection<Salle> listSalle;

        private ObservableCollection<DemandeHospitDetail> listDemandeHospit;


        private NewSalleWindow dialogNewSalle;
        private Salle newSalle;
        private int selectedNbLit;
        private ObservableCollection<int> listNbLit;
        
        private NewHospitWindow dialogNewHospit;

        private UpdateSalleWindow dialogUpdateSalle;
        private Salle updatedSalle;

        private ConfirmeHospWindow dialogConfirmeHosp;
        private HospitalisationDetail selectHosp;
        private string newTelephone;

        private InfosHospitWindow dialogHospDetail;

        private DossierMedServiceClient psc = new DossierMedServiceClient();
        private DossierMedicalWindow dialoDossierMedical;
        private DossierMedDetail selectedDossier;

        private SuiviHospitWindow dialogSuivi;
        private string mesurePoids;
        private string mesureTA;
        private string mesureTemperature;
        private string mesureGlycemique;
        private Intervention newIntervention;

        private ChartWindow chartsWindow;
        private DetailSuiviWindow detailSuiviWindow;
        private List<Point> pointsPoids;
        private List<Point> pointsTA;
        private List<Point> pointsTemperature;
        private List<Point> pointsGlycemique;

        public ListHospitalisationViewModel()
        {
            ssc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            ssc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            ssc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;
            hsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            hsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            hsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;
            psc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            psc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            psc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;
            rsc.ClientCredentials.UserName.UserName = AuthenticationViewModel.AuthenticatedUser.UserName;
            rsc.ClientCredentials.UserName.Password = AuthenticationViewModel.AuthenticatedUser.Password;
            rsc.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                                X509CertificateValidationMode.None;

            listAllHospitalisation = new ObservableCollection<HospitalisationDetail>();
            listAllHospitalisation = new ObservableCollection<HospitalisationDetail>(hsc.GetHospits(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            listPasseHospitalisation = new ObservableCollection<HospitalisationDetail>();
            listActiveHospitalisation = new ObservableCollection<HospitalisationDetail>();
            listFuturHospitalisation = new ObservableCollection<HospitalisationDetail>();
            listAttenteHospitalisation = new ObservableCollection<HospitalisationDetail>();
            listRateHospitalisation = new ObservableCollection<HospitalisationDetail>();
            ActualiserLists();
            nomUtilisateur = AuthenticationViewModel.AuthenticatedUser.Nom + " " + AuthenticationViewModel.AuthenticatedUser.Prenom;

            listSalle = new ObservableCollection<Salle>(ssc.GetSalles(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            listDemandeHospit = new ObservableCollection<DemandeHospitDetail>(hsc.GetDemandesHospit(AuthenticationViewModel.AuthenticatedUser.ServiceId));

            CancelCommand = new RelayCommand(o => ((Window)o).Close());

            NewHospitDialogCommand = new RelayCommand(param => ShowDialogNewHospit(param));
            ReschedHospitDialogCommand = new RelayCommand(param => ShowDialogReschedHospit(param));
            ConfirmeHospDialogCommand = new RelayCommand(param => ShowDialogConfirmHospit(param));

            NewSalleDialogCommand = new RelayCommand(param => ShowDialogNewSalle());
            UpdateSalleDialogCommand = new RelayCommand(param => this.ShowDialogUpdateSalle(param));
            RemoveSalleCommand = new RelayCommand(param => DeleteSalle(param));

            DetailHospitDialogCommand = new RelayCommand(param => this.ShowDialogDetailHosp(param));

            OpenDialogMedFolderCommand = new RelayCommand(param => ShowDialogDossierMedical(param));

            OpenDialogSuiviCommand = new RelayCommand(param => ShowDialogSuivi(param));

            TerminerHospitCommand = new RelayCommand(param => TerminerHospit(param));
            
            OpenChartCommand = new RelayCommand(param => ShowDialogChart(param));
            OpenDetailHospitCommand = new RelayCommand(param => ShowDialogDetailHospit(param));
        }



        #region PatientsViewModel Variables
        public List<Point> PointsPoids
        {
            get
            {
                return pointsPoids;
            }
            set
            {
                pointsPoids = value;
                OnPropertyChanged("PointsPoids");
            }
        }
        public List<Point> PointsTA
        {
            get
            {
                return pointsTA;
            }
            set
            {
                pointsTA = value;
                OnPropertyChanged("PointsTA");
            }
        }
        public List<Point> PointsTemperature
        {
            get
            {
                return pointsTemperature;
            }
            set
            {
                pointsTemperature = value;
                OnPropertyChanged("PointsTemperature");
            }
        }
        public List<Point> PointsGlycemique
        {
            get
            {
                return pointsGlycemique;
            }
            set
            {
                pointsGlycemique = value;
                OnPropertyChanged("PointsGlycemique");
            }
        }

        public ObservableCollection<HospitalisationDetail> ListAllHospitalisation
        {
            get
            {
                return listAllHospitalisation;
            }
            set
            {
                listAllHospitalisation = value;
                OnPropertyChanged("ListAllHospitalisation");
            }
        }
        public ObservableCollection<HospitalisationDetail> ListPasseHospitalisation
        {
            get
            {
                return listPasseHospitalisation;
            }
            set
            {
                listPasseHospitalisation = value;
                OnPropertyChanged("ListPasseHospitalisation");
            }
        }
        public ObservableCollection<HospitalisationDetail> ListActiveHospitalisation
        {
            get
            {
                return listActiveHospitalisation;
            }
            set
            {
                listActiveHospitalisation = value;
                OnPropertyChanged("ListActiveHospitalisation");
            }
        }
        public ObservableCollection<HospitalisationDetail> ListFuturHospitalisation
        {
            get
            {
                return listFuturHospitalisation;
            }
            set
            {
                listFuturHospitalisation = value;
                OnPropertyChanged("ListFuturHospitalisation");
            }
        }
        public ObservableCollection<HospitalisationDetail> ListAttenteHospitalisation
        {
            get
            {
                return listAttenteHospitalisation;
            }
            set
            {
                listAttenteHospitalisation = value;
                OnPropertyChanged("ListAttenteHospitalisation");
            }
        }
        public ObservableCollection<HospitalisationDetail> ListRateHospitalisation
        {
            get
            {
                return listRateHospitalisation;
            }
            set
            {
                listRateHospitalisation = value;
                OnPropertyChanged("ListRateHospitalisation");
            }
        }

        public ObservableCollection<Salle> ListSalle
        {
            get
            {
                return listSalle;
            }
            set
            {
                listSalle = value;
                OnPropertyChanged("ListSalle");
            }
        }
        public ObservableCollection<DemandeHospitDetail> ListDemandeHospit
        {
            get
            {
                return listDemandeHospit;
            }
            set
            {
                listDemandeHospit = value;
                OnPropertyChanged("ListDemandeHospit");
            }
        }
        public Salle NewSalle
        {
            get
            {
                return newSalle;
            }
            set
            {
                newSalle = value;
                OnPropertyChanged("NewSalle");
            }
        }
        public Salle UpdatedSalle
        {
            get
            {
                return updatedSalle;
            }
            set
            {
                updatedSalle = value;
                OnPropertyChanged("UpdatedSalle");
            }
        }
        public ObservableCollection<int> ListNbLit
        {
            get
            {
                return listNbLit;
            }
            set
            {
                listNbLit = value;
                OnPropertyChanged("ListNbLit");
            }
        }
        public int SelectedNbLit
        {
            get
            {
                return selectedNbLit;
            }
            set
            {
                selectedNbLit = value;
                OnPropertyChanged("SelectedNbLit");
            }
        }
        public string NomUtilisateur
        {
            get
            {
                return nomUtilisateur;
            }
        }

        public HospitalisationDetail SelectHosp
        {
            get
            {
                return selectHosp;
            }
            set
            {
                selectHosp = value;
                OnPropertyChanged("SelectHosp");
            }
        }

        public string NewTelephone
        {
            get
            {
                return newTelephone;
            }
            set
            {
                newTelephone = value;
                OnPropertyChanged("NewTelephone");
            }
        }

        public NewHospitWindow DialogNewHospit
        {
            get
            {
                return dialogNewHospit;
            }
        }
        
        public DossierMedDetail SelectedDossier
        {
            get
            {
                return selectedDossier;
            }
            set
            {
                selectedDossier = value;
                OnPropertyChanged("SelectedDossier");
            }
        }

        public string MesurePoids
        {
            get
            {
                return mesurePoids;
            }
            set
            {
                mesurePoids = value;
                OnPropertyChanged("MesurePoids");
            }
        }
        public string MesureTA
        {
            get
            {
                return mesureTA;
            }
            set
            {
                mesureTA = value;
                OnPropertyChanged("MesureTA");
            }
        }
        public string MesureTemperature
        {
            get
            {
                return mesureTemperature;
            }
            set
            {
                mesureTemperature = value;
                OnPropertyChanged("MesureTemperature");
            }
        }
        public string MesureGlycemique
        {
            get
            {
                return mesureGlycemique;
            }
            set
            {
                mesureGlycemique = value;
                OnPropertyChanged("MesureGlycemique");
            }
        }
        public Intervention NewIntervention
        {
            get
            {
                return newIntervention;
            }
            set
            {
                newIntervention = value;
                OnPropertyChanged("NewIntervention");
            }
        }
        #endregion

        #region PatientsViewModel Commands

        public ICommand NewSalleDialogCommand
        {
            get;
            private set;
        }
        public ICommand NewHospitDialogCommand
        {
            get;
            private set;
        }
        public ICommand ReschedHospitDialogCommand
        {
            get;
            private set;
        }
        public ICommand ConfirmeHospDialogCommand
        {
            get;
            private set;
        }
        public ICommand ConfirmHospitCommand
        {
            get;
            private set;
        }
        public ICommand DetailHospitDialogCommand
        {
            get;
            private set;
        }

        public ICommand UpdateSalleDialogCommand
        {
            get;
            private set;
        }

        public ICommand UpdateSalleCommand
        {
            get;
            private set;
        }
        public ICommand RemoveSalleCommand
        {
            get;
            private set;
        }

        public ICommand AddSalleCommand
        {
            get;
            private set;
        }
        public ICommand AddHospitCommand
        {
            get;
            private set;
        }

        public ICommand CancelCommand
        {
            get;
            private set;
        }

        public ICommand AddTelephoneCommand
        {
            get;
            private set;
        }
        public ICommand RemoveTelephoneCommand
        {
            get;
            private set;
        }

        public ICommand OpenDialogMedFolderCommand
        {
            get;
            private set;
        }

        public ICommand OpenDialogSuiviCommand
        {
            get;
            private set;
        }
        public ICommand UpdateSuiviCommand
        {
            get;
            private set;
        }
        public ICommand TerminerHospitCommand
        {
            get;
            private set;
        }
        public ICommand OpenChartCommand
        {
            get;
            private set;
        }
        public ICommand OpenDetailHospitCommand
        {
            get;
            private set;
        }

        #endregion

        #region PatientsViewModel Methods

        private ObservableCollection<HospitalisationDetail> CreateListPasseHospitalisation()
        {
            ObservableCollection<HospitalisationDetail> allMyList = new ObservableCollection<HospitalisationDetail>();
            foreach (HospitalisationDetail element in listAllHospitalisation)
            {
                if (element.Hospitalisation.DateFinReel.Date.CompareTo(DateTime.Now.Date) <= 0 && element.Hospitalisation.DateFinReel.Date.CompareTo(new DateTime(1,1,1).Date) != 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<HospitalisationDetail> CreateListActiveHospitalisation()
        {
            ObservableCollection<HospitalisationDetail> allMyList = new ObservableCollection<HospitalisationDetail>();
            foreach (HospitalisationDetail element in listAllHospitalisation)
            {
                if (element.Hospitalisation.DateDebutReel.Date.CompareTo(DateTime.Now.Date) <= 0 && element.Hospitalisation.DateDebutReel.Date.CompareTo(new DateTime(1, 1, 1).Date) != 0 && element.Hospitalisation.DateFinReel.Date.CompareTo(new DateTime(1, 1, 1).Date) == 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<HospitalisationDetail> CreateListFuturHospitalisation()
        {
            ObservableCollection<HospitalisationDetail> allMyList = new ObservableCollection<HospitalisationDetail>();
            foreach (HospitalisationDetail element in listAllHospitalisation)
            {
                if (element.Hospitalisation.DateDebutPrevu.Date.CompareTo(DateTime.Now.Date) > 0 && element.Hospitalisation.DateDebutReel.Date.CompareTo(new DateTime(1, 1, 1).Date) == 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<HospitalisationDetail> CreateListAttentHospitalisation()
        {
            ObservableCollection<HospitalisationDetail> allMyList = new ObservableCollection<HospitalisationDetail>();
            foreach (HospitalisationDetail element in listAllHospitalisation)
            {
                if (element.Hospitalisation.DateDebutPrevu.Date.CompareTo(DateTime.Now.Date) == 0 && element.Hospitalisation.DateDebutReel.Date.CompareTo(new DateTime(1, 1, 1).Date) == 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }
        private ObservableCollection<HospitalisationDetail> CreateListRateHospitalisation()
        {
            ObservableCollection<HospitalisationDetail> allMyList = new ObservableCollection<HospitalisationDetail>();
            foreach (HospitalisationDetail element in listAllHospitalisation)
            {
                if (element.Hospitalisation.DateDebutPrevu.Date.CompareTo(DateTime.Now.Date) < 0 && element.Hospitalisation.DateDebutReel.Date.CompareTo(new DateTime(1, 1, 1).Date) == 0)
                {
                    allMyList.Add(element);
                }
            }
            return allMyList;
        }

        public void ShowDialogUpdateSalle(object selectedSalle)
        {
            updatedSalle = selectedSalle as Salle;
            dialogUpdateSalle = new UpdateSalleWindow();
            listNbLit = new ObservableCollection<int>(Enumerable.Range(1, 8));
            dialogUpdateSalle.DataContext = this;
            UpdateSalleCommand = new RelayCommand(param => ModifierSalle());
            dialogUpdateSalle.ShowDialog();
        }
        public void ModifierSalle()
        {
            UpdatedSalle.LitsLibres = new ObservableCollection<int>(Enumerable.Range(1, UpdatedSalle.NbLit));
            ssc.UpdateSalle(UpdatedSalle);
            dialogUpdateSalle.Close();
        }
        public void DeleteSalle(object selectedSalle)
        {
            var deletedSalle = selectedSalle as Salle;

            ssc.DeleteSalle(deletedSalle.Id);
            listSalle.Remove(deletedSalle);
        }
        private void ShowDialogNewSalle()
        {
            dialogNewSalle = new NewSalleWindow();
            dialogNewSalle.DataContext = this;
            newSalle = new Salle();
            ListNbLit = new ObservableCollection<int>(Enumerable.Range(1, 8));
            AddSalleCommand = new RelayCommand(param => AjouterSalle());
            dialogNewSalle.ShowDialog();
        }
        private void AjouterSalle()
        {
            NewSalle.IdService = AuthenticationViewModel.AuthenticatedUser.ServiceId;
            NewSalle.NbLit = SelectedNbLit;
            NewSalle.CreeDans = DateTime.Now;
            NewSalle.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            NewSalle.LitsLibres = new ObservableCollection<int>(Enumerable.Range(1, NewSalle.NbLit));
            ssc.AddSalle(NewSalle);
            listSalle.Add(NewSalle);
            dialogNewSalle.Close();
        }

        private void ShowDialogNewHospit(object selecDemand)
        {
            //SelectedDemande = selecDemand as DemandeHospitDetail;
            dialogNewHospit = new NewHospitWindow();
            dialogNewHospit.DataContext = new NewHospitViewModel(selecDemand as DemandeHospitDetail, this);
            dialogNewHospit.ShowDialog();
        }
        private void ShowDialogReschedHospit(object obj)
        {
            HospitalisationDetail hos = obj as HospitalisationDetail;
            DemandeHospitDetail dem = new DemandeHospitDetail();
            dem.Patient = hos.Patient;
            dem.Medecin = hos.Medecin;
            dem.DemandeHospit = hos.Demande;
            dialogNewHospit = new NewHospitWindow();
            dialogNewHospit.DataContext = new NewHospitViewModel(dem, this);
            dialogNewHospit.ShowDialog();
            listAllHospitalisation = new ObservableCollection<HospitalisationDetail>(hsc.GetHospits(AuthenticationViewModel.AuthenticatedUser.ServiceId));
            ActualiserLists();
        }

        private HospitalisationDetail copie;
        private void ShowDialogConfirmHospit(Object obj)
        {
            selectHosp = obj as HospitalisationDetail;
            copie = selectHosp;
            dialogConfirmeHosp = new ConfirmeHospWindow();
            selectHosp.Hospitalisation.Garde.DateNaiss = new DateTime(1970, 6, 1);
            dialogConfirmeHosp.DataContext = this;
            AddTelephoneCommand = new RelayCommand(param => AjouterTelephone());
            RemoveTelephoneCommand = new RelayCommand(param => DeleteTelephone(param));
            ConfirmHospitCommand = new RelayCommand(param => ConfirmerHospit());
            dialogConfirmeHosp.ShowDialog();
        }
        
        private void ShowDialogDetailHosp(Object obj)
        {
            SelectHosp = obj as HospitalisationDetail;
            dialogHospDetail = new InfosHospitWindow();
            dialogHospDetail.DataContext = this;
            dialogHospDetail.ShowDialog();
        }
        
        private void ShowDialogDossierMedical(object param)
        {
            HospitalisationDetail selHosp = param as HospitalisationDetail;
            SelectedDossier = psc.GetDossierMed(selHosp.Patient.Id);
            dialoDossierMedical = new DossierMedicalWindow();
            //dialoDossierMedical.DataContext = this;

            dialoDossierMedical.DataContext = new DossierMedViewModel(SelectedDossier);
            //newPathologie = new Consultation();
            //AddPathologieCommand = new RelayCommand(param => AjouterPathologie());
            dialoDossierMedical.ShowDialog();
        }
        
        private void ShowDialogSuivi(object param)
        {
            SelectHosp = param as HospitalisationDetail;
            dialogSuivi = new SuiviHospitWindow();
            mesurePoids = "";
            mesureTA = "";
            mesureTemperature = "";
            mesureGlycemique = "";
            newIntervention = new Intervention();
            dialogSuivi.DataContext = this;
            UpdateSuiviCommand = new RelayCommand(par => UpdateSuivi());
            dialogSuivi.ShowDialog();
        }

        private void ShowDialogChart(object param)
        {
            pointsPoids = new List<Point>();
            pointsTA = new List<Point>();
            pointsTemperature = new List<Point>();
            pointsGlycemique = new List<Point>();
            foreach (Mesure item in SelectHosp.FichePoids)
            {
                pointsPoids.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur)});
            }
            foreach (Mesure item in SelectHosp.FicheTA)
            {
                pointsTA.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            foreach (Mesure item in SelectHosp.FicheTemperature)
            {
                pointsTemperature.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            foreach (Mesure item in SelectHosp.FicheGlycemique)
            {
                pointsGlycemique.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            chartsWindow = new ChartWindow();
            chartsWindow.DataContext = this;
            chartsWindow.ShowDialog();
        }

        private void ShowDialogDetailHospit(object param)
        {
            SelectHosp = param as HospitalisationDetail;
            pointsPoids = new List<Point>();
            pointsTA = new List<Point>();
            pointsTemperature = new List<Point>();
            pointsGlycemique = new List<Point>();
            foreach (Mesure item in SelectHosp.FichePoids)
            {
                pointsPoids.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            foreach (Mesure item in SelectHosp.FicheTA)
            {
                pointsTA.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            foreach (Mesure item in SelectHosp.FicheTemperature)
            {
                pointsTemperature.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            foreach (Mesure item in SelectHosp.FicheGlycemique)
            {
                pointsGlycemique.Add(new Point { X = item.CreeDans.ToString(), Y = float.Parse(item.Valeur) });
            }
            detailSuiviWindow = new DetailSuiviWindow();
            detailSuiviWindow.DataContext = this;
            detailSuiviWindow.ShowDialog();
        }

        private void UpdateSuivi()
        {
            Mesure mesure;
            if(MesurePoids != "")
            {
                mesure = new Mesure();
                mesure.Valeur = MesurePoids;
                mesure.IdHospitalisation = SelectHosp.Hospitalisation.Id;
                mesure.CreeDans = DateTime.Now;
                mesure.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;

                mesure = hsc.AddMesurePoids(mesure, selectHosp.Hospitalisation.IdMesuresFichePoids.ToArray());
                SelectHosp.FichePoids.Add(mesure);
                SelectHosp.Hospitalisation.IdMesuresFichePoids.Add(mesure.Id);
            }
            if (MesureTA != "")
            {
                mesure = new Mesure();
                mesure.Valeur = MesureTA;
                mesure.IdHospitalisation = SelectHosp.Hospitalisation.Id;
                mesure.CreeDans = DateTime.Now;
                mesure.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;

                mesure = hsc.AddMesureTa(mesure, selectHosp.Hospitalisation.IdMesuresFicheTA.ToArray());
                SelectHosp.FicheTA.Add(mesure);
                SelectHosp.Hospitalisation.IdMesuresFicheTA.Add(mesure.Id);
            }
            if (MesureTemperature != "")
            {
                mesure = new Mesure();
                mesure.Valeur = MesureTemperature;
                mesure.IdHospitalisation = SelectHosp.Hospitalisation.Id;
                mesure.CreeDans = DateTime.Now;
                mesure.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;

                mesure = hsc.AddMesureTemperature(mesure, selectHosp.Hospitalisation.IdMesuresFicheTemperature.ToArray());
                SelectHosp.FicheTemperature.Add(mesure);
                SelectHosp.Hospitalisation.IdMesuresFicheTemperature.Add(mesure.Id);
            }
            if (MesureGlycemique != "")
            {
                mesure = new Mesure();
                mesure.Valeur = MesureGlycemique;
                mesure.IdHospitalisation = SelectHosp.Hospitalisation.Id;
                mesure.CreeDans = DateTime.Now;
                mesure.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;

                mesure = hsc.AddMesureGlycemique(mesure, selectHosp.Hospitalisation.IdMesuresFicheGlycemique.ToArray());
                SelectHosp.FicheGlycemique.Add(mesure);
                SelectHosp.Hospitalisation.IdMesuresFicheGlycemique.Add(mesure.Id);
            }

            if (NewIntervention.Motif != "" || NewIntervention.Description != "")
            {
                NewIntervention.IdHospitalisation = SelectHosp.Hospitalisation.Id;
                NewIntervention.CreeDans = DateTime.Now;
                NewIntervention.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
                
                newIntervention = hsc.AddIntervention(NewIntervention, selectHosp.Hospitalisation.IdInterventions.ToArray());
                SelectHosp.Inetrventions.Add(newIntervention);
                SelectHosp.Hospitalisation.IdInterventions.Add(newIntervention.Id);
            }
            dialogSuivi.Close();
        }

        private void ConfirmerHospit()
        {
            listAllHospitalisation.Remove(copie);
            SelectHosp.Hospitalisation.DateDebutReel = SelectHosp.Hospitalisation.DateDebutPrevu;
            hsc.UpdateHospit(SelectHosp.Hospitalisation);
            listAllHospitalisation.Add(SelectHosp);
            
            dialogConfirmeHosp.Close();
            ActualiserLists();
        }

        public void AjouterTelephone()
        {
            //var newCsl = csl as string;
            if (newTelephone != "")
            {
                SelectHosp.Hospitalisation.Garde.Telephones.Add(newTelephone);
                NewTelephone = "";
            }
        }
        public void DeleteTelephone(object selectedTelephone)
        {
            var telephone = selectedTelephone as string;
            SelectHosp.Hospitalisation.Garde.Telephones.Remove(telephone);
        }

        private void TerminerHospit(object param)
        {
            SelectHosp = param as HospitalisationDetail;
            copie = SelectHosp;

            RDV rdv = new RDV();
            rdv.PatientId = SelectHosp.Patient.Id;
            rdv.MedecinRespId = SelectHosp.Medecin.Id;
            rdv.DateRdv = new DateTime(1, 1, 1);
            rdv.CreeDans = DateTime.Now;
            rdv.CreePar = AuthenticationViewModel.AuthenticatedUser.Id;
            rdv.ServiceId = SelectHosp.Patient.ServiceId;
            rdv.PathologieId = SelectHosp.Patient.PathologieId;
            rdv.NouvPat = false;

            rsc.AddRdv(rdv);

            listAllHospitalisation.Remove(copie);
            SelectHosp.Hospitalisation.DateFinReel = DateTime.Now;
            hsc.UpdateHospit(SelectHosp.Hospitalisation);
            listAllHospitalisation.Add(SelectHosp);
            
            ActualiserLists();
        }

        public void ActualiserLists()
        {
            ListPasseHospitalisation = CreateListPasseHospitalisation();
            ListActiveHospitalisation = CreateListActiveHospitalisation();
            ListFuturHospitalisation = CreateListFuturHospitalisation();
            ListAttenteHospitalisation = CreateListAttentHospitalisation();
            ListRateHospitalisation = CreateListRateHospitalisation();
        }

        #endregion

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

    public class Point
    {
        public Point()
        {
            X = "";
            Y = 0;
        }
        public string X { get; set; }
        public float Y { get; set; }
    }
}
