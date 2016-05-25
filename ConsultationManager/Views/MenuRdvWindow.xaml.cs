using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ConsultationManager.Views.RDVs;

namespace ConsultationManager.Views
{
    /// <summary>
    /// Interaction logic for MenuRdvWindow.xaml
    /// </summary>
    public partial class MenuRdvWindow : Window
    {
        public MenuRdvWindow()
        {
            InitializeComponent();
            _frameRdv.Navigate(new AllRdvPage());
            AllRdvBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            AllMyRdvBtn.Background = Brushes.Transparent;
            MyTodayRdvBtn.Background = Brushes.Transparent;
            NewRdvBtn.Background = Brushes.Transparent;

            AllRdvBtn.Foreground = Brushes.White;
            AllMyRdvBtn.Foreground = Brushes.Black;
            MyTodayRdvBtn.Foreground = Brushes.Black;
            NewRdvBtn.Foreground = Brushes.Black;
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new AllRdvPage());
            AllRdvBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            AllMyRdvBtn.Background = Brushes.Transparent;
            MyTodayRdvBtn.Background = Brushes.Transparent;
            NewRdvBtn.Background = Brushes.Transparent;

            AllRdvBtn.Foreground = Brushes.White;
            AllMyRdvBtn.Foreground = Brushes.Black;
            MyTodayRdvBtn.Foreground = Brushes.Black;
            NewRdvBtn.Foreground = Brushes.Black;
        }

        private void button_click_tout_mes(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new AllMyRdvPage());
            AllRdvBtn.Background = Brushes.Transparent;
            AllMyRdvBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            MyTodayRdvBtn.Background = Brushes.Transparent;
            NewRdvBtn.Background = Brushes.Transparent;

            AllRdvBtn.Foreground = Brushes.Black;
            AllMyRdvBtn.Foreground = Brushes.White;
            MyTodayRdvBtn.Foreground = Brushes.Black;
            NewRdvBtn.Foreground = Brushes.Black;
        }

        private void button_click_ajourd(object sender, RoutedEventArgs e)
        {
            _frameRdv.Navigate(new MyTodayRdvPage());
            AllRdvBtn.Background = Brushes.Transparent;
            AllMyRdvBtn.Background = Brushes.Transparent;
            MyTodayRdvBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            NewRdvBtn.Background = Brushes.Transparent;

            AllRdvBtn.Foreground = Brushes.Black;
            AllMyRdvBtn.Foreground = Brushes.Black;
            MyTodayRdvBtn.Foreground = Brushes.White;
            NewRdvBtn.Foreground = Brushes.Black;
        }

        private void button_click_nouveau(object sender, RoutedEventArgs e)
        {
            //_mainFrame.Navigate(new NewPatientPage());
            //AllPatBtn.Background = Brushes.Transparent;
            //MyPatBtn.Background = Brushes.Transparent;
            //NewPatBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            //NewPatBtn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#DDFFFFFF"));

            //AllPatBtn.Foreground = Brushes.Black;
            //MyPatBtn.Foreground = Brushes.Black;
            //NewPatBtn.Foreground = Brushes.White;
        }

        private void button_click_home(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var form2 = new Home();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button_click_about(object sender, RoutedEventArgs e)
        {

        }

        private void button_click_logout(object sender, RoutedEventArgs e)
        {

        }
    }

    public class RdvList
    {
        public List<RDV> GetData()
        {
            return CreateRDVs();
        }
        private List<RDV> CreateRDVs()
        {
            List<RDV> list = new List<RDV>();
            list.Add(new RDV()
            {
                NomPatient = "Nick",
                PrenomPatient = "White",
                NomMedecin = "mokrane",
                PrenomMedecin = "fatiha",
                DateRdv = new DateTime(2016, 10, 13, 8, 30, 0),
                CreeDans = DateTime.Today,
                CreePar = "tebibell saliha"
            });
            list.Add(new RDV()
            {
                NomPatient = "Jack",
                PrenomPatient = "Rodman",
                NomMedecin = "bellal",
                PrenomMedecin = "kader",
                DateRdv = new DateTime(2017, 3, 23, 9, 45, 0),
                CreeDans = new DateTime(2016, 5, 10),
                CreePar = "mokrane fatiha"
            });
            list.Add(new RDV()
            {
                NomPatient = "Sandra",
                PrenomPatient = "Sherry",
                NomMedecin = "fellague",
                PrenomMedecin = "halim",
                DateRdv = new DateTime(2016, 11, 10, 11, 0, 0),
                CreeDans = new DateTime(2008, 12, 22),
                CreePar = "bellal kader"
            });
            list.Add(new RDV()
            {
                NomPatient = "Sabrina",
                PrenomPatient = "Vilk",
                NomMedecin = "mokrane",
                PrenomMedecin = "fatiha",
                DateRdv = new DateTime(2016, 10, 13, 12, 0, 0),
                CreeDans = DateTime.Today,
                CreePar = "fellague halim"
            });
            list.Add(new RDV()
            {
                NomPatient = "Mike",
                PrenomPatient = "Pearson",
                NomMedecin = "bellal",
                PrenomMedecin = "kader",
                DateRdv = new DateTime(2016, 12, 30, 9, 0, 0),
                CreeDans = new DateTime(2008, 10, 18),
                CreePar = "bennouna el khebith"
            });
            list.Add(new RDV()
            {
                NomPatient = "Bill",
                PrenomPatient = "Watson",
                NomMedecin = "fellague",
                PrenomMedecin = "halim",
                DateRdv = new DateTime(2017, 4, 20, 10, 15, 0),
                CreeDans = new DateTime(2016, 1, 18),
                CreePar = "fellague halim"
            });
            list.Add(new RDV()
            {
                NomPatient = "Christiano",
                PrenomPatient = "Ronaldo",
                NomMedecin = "bellal",
                PrenomMedecin = "kader",
                DateRdv = new DateTime(2017, 3, 10, 14, 0, 0),
                CreeDans = new DateTime(2014, 7, 10),
                CreePar = "bennouna el khebith"
            });
            list.Add(new RDV()
            {
                NomPatient = "Maria",
                PrenomPatient = "Klara",
                NomMedecin = "mokrane",
                PrenomMedecin = "fatiha",
                DateRdv = new DateTime(2016, 10, 13, 15, 0, 0),
                CreeDans = new DateTime(2012, 2, 20),
                CreePar = "bellal kader"
            });
            list.Add(new RDV()
            {
                NomPatient = "Amaouri",
                PrenomPatient = "Benjamen",
                NomMedecin = "mokrane",
                PrenomMedecin = "fatiha",
                DateRdv = new DateTime(2017, 1, 1, 8, 45, 0),
                CreeDans = new DateTime(2003, 7, 1),
                CreePar = "fellague halim"
            });
            list.Add(new RDV()
            {
                NomPatient = "Bouraoui",
                PrenomPatient = "ElMerioul",
                NomMedecin = "fellague",
                PrenomMedecin = "halim",
                DateRdv = new DateTime(2017, 6, 12, 11, 0, 0),
                CreeDans = DateTime.Today,
                CreePar = "tebibell saliha"
            });
            list.Add(new RDV()
            {
                NomPatient = "Henni",
                PrenomPatient = "El Alia",
                NomMedecin = "mokrane",
                PrenomMedecin = "fatiha",
                DateRdv = new DateTime(2016, 10, 13, 13, 0, 0),
                CreeDans = new DateTime(2005, 10, 18),
                CreePar = "fellague halim"
            });
            list.Add(new RDV()
            {
                NomPatient = "Keyta",
                PrenomPatient = "Ben yamina",
                NomMedecin = "mokrane",
                PrenomMedecin = "fatiha",
                DateRdv = new DateTime(2017, 1, 1, 8, 45, 0),
                CreeDans = new DateTime(2012, 12, 22),
                CreePar = "bellal kader"
            });
            list.Add(new RDV()
            {
                NomPatient = "Gabriel",
                PrenomPatient = "Pepe",
                NomMedecin = "fellague",
                PrenomMedecin = "halim",
                DateRdv = new DateTime(2016, 11, 16, 10, 0, 0),
                CreeDans = new DateTime(2011, 7, 10),
                CreePar = "bennouna el khebith"
            });
            list.Add(new RDV()
            {
                NomPatient = "Khoukhi",
                PrenomPatient = "Doukkich",
                NomMedecin = "mokrane",
                PrenomMedecin = "fatiha",
                DateRdv = new DateTime(2017, 1, 1, 9, 45, 0),
                CreeDans = new DateTime(2009, 4, 8),
                CreePar = "fellague halim"
            });
            return list;
        }
    }

    public class RDV
    {
        public string NomPatient { get; set; }
        public string PrenomPatient { get; set; }
        public string NomMedecin { get; set; }
        public string PrenomMedecin { get; set; }
        public DateTime DateRdv { get; set; }
        public DateTime CreeDans { get; set; }
        public string CreePar { get; set; }
    }
}
