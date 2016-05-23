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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConsultationManager.Views.Patients
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AllPatientsPage : Page
    {
        public AllPatientsPage()
        {
            InitializeComponent();
            List<Account> allList = new AccountList().GetData();
            listViewAcount.ItemsSource = allList;
        }
    }

    public class AccountList
    {
        public List<Account> GetData()
        {
            return CreateAccounts();
        }
        private List<Account> CreateAccounts()
        {
            List<Account> list = new List<Account>();
            list.Add(new Account()
            {
                Nom = "Nick",
                Prenom = "White",
                DateNaiss = new DateTime(1975, 7, 13),
                Raison = "un kis zza doic sdz zdlkd sdndk sdcioz sdijd",
                Adresse = "chlef hay essalem n 3",
                Telephone = "06 98 75 65 90",
                CreeDans = DateTime.Today,
                Mariee = true,
                CreePar = "tebibell saliha"
            });
            list.Add(new Account()
            {
                Nom = "Jack",
                Prenom = "Rodman",
                DateNaiss = new DateTime(1965, 3, 23),
                Raison = "un malle dans la tete qsjsd cjqs ketipaliss",
                Adresse = "blida hay el amal n 98",
                Telephone = "07 99 87 54 76",
                CreeDans = new DateTime(2009, 5, 10),
                Mariee = false,
                CreePar = "mokrane fatiha"
            });
            list.Add(new Account()
            {
                Nom = "Sandra",
                Prenom = "Sherry",
                DateNaiss = new DateTime(1967, 1, 10),
                Raison = "unkjd cdkd dlkdc clksd elkd lksd k sdksdc lkcd kc",
                Adresse = "alger harrach bouraoui A 33",
                Telephone = "05 87 09 54 34",
                CreeDans = new DateTime(2008, 12, 22),
                Mariee = false,
                CreePar = "bellal kader"
            });
            list.Add(new Account()
            {
                Nom = "Sabrina",
                Prenom = "Vilk",
                DateNaiss = new DateTime(1987, 7, 8),
                Raison = "unjkc djkjklsdm klsd lkcd lksd lqos cx,s cj",
                Adresse = "tyaret hay essaada nu 381",
                Telephone = "07 98 65 34 98",
                CreeDans = DateTime.Today,
                Mariee = true,
                CreePar = "fellague halim"
            });
            list.Add(new Account()
            {
                Nom = "Mike",
                Prenom = "Pearson",
                DateNaiss = new DateTime(1952, 8, 30),
                Raison = "mpqxn ckjqs xc ydc jwx wdckjqsd xwjwxc kjxw kjcqs cjksd ,jwx",
                Adresse = "oran la korniche nup 929",
                Telephone = "07 87 87 98 09",
                CreeDans = new DateTime(2008, 10, 18),
                Mariee = true,
                CreePar = "bennouna el khebith"
            });
            list.Add(new Account()
            {
                Nom = "Bill",
                Prenom = "Watson",
                DateNaiss = new DateTime(1978, 4, 20),
                Raison = "fcef rvfrf rfv tgv wqw zsxsx zxszsd cedcvf rf tb tynh,uj ujkol pmsd",
                Adresse = "Khenchla bouhmema nu 098",
                Telephone = "06 65 34 23 87",
                CreeDans = new DateTime(2016, 1, 18),
                Mariee = true,
                CreePar = "fellague halim"
            });
            list.Add(new Account()
            {
                Nom = "Christiano",
                Prenom = "Ronaldo",
                DateNaiss = new DateTime(1987, 3, 10),
                Raison = "unjkc djkjklsdm klsd lkcd lksd lqos cx,s cj",
                Adresse = "Purtugal hay el amal 054",
                Telephone = "05 34 53 23 24",
                CreeDans = new DateTime(2014, 7, 10),
                Mariee = true,
                CreePar = "bennouna el khebith"
            });
            list.Add(new Account()
            {
                Nom = "Maria",
                Prenom = "Klara",
                DateNaiss = new DateTime(1962, 1, 10),
                Raison = "unkjd cdkd dlkdc clksd elkd lksd k sdksdc lkcd kc",
                Adresse = "alger harrach bouraoui A 33",
                Telephone = "05 87 09 54 34",
                CreeDans = new DateTime(2012, 2, 20),
                Mariee = false,
                CreePar = "bellal kader"
            });
            list.Add(new Account()
            {
                Nom = "Amaouri",
                Prenom = "Benjamen",
                DateNaiss = new DateTime(1978, 3, 23),
                Raison = "un malle dans la tete qsjsd cjqs ketipaliss",
                Adresse = "blida hay el amal n 98",
                Telephone = "07 99 87 54 76",
                CreeDans = new DateTime(2003, 7, 1),
                Mariee = false,
                CreePar = "fellague halim"
            });
            list.Add(new Account()
            {
                Nom = "Bouraoui",
                Prenom = "ElMerioul",
                DateNaiss = new DateTime(1955, 6, 12),
                Raison = "un kis zza doic sdz zdlkd sdndk sdcioz sdijd",
                Adresse = "Herrach hay essalem n 3",
                Telephone = "06 97 75 65 89",
                CreeDans = DateTime.Today,
                Mariee = true,
                CreePar = "tebibell saliha"
            });
            list.Add(new Account()
            {
                Nom = "Henni",
                Prenom = "El Alia",
                DateNaiss = new DateTime(1982, 8, 3),
                Raison = "mpqxn ckqs sckqs ckjqs xc ydc jwx wdckjqsd xwjwxc kjxw kjcqs cjksd ,jwx",
                Adresse = "Betna la korniche nup 929",
                Telephone = "07 89 76 76 54",
                CreeDans = new DateTime(2005, 10, 18),
                Mariee = true,
                CreePar = "fellague halim"
            });
            list.Add(new Account()
            {
                Nom = "Keyta",
                Prenom = "Ben yamina",
                DateNaiss = new DateTime(1954, 1, 1),
                Raison = "unkjd cdkd dlkdc clksd elkd lksd k sdksdc lkcd kc",
                Adresse = "Chlef hey essalem A 33",
                Telephone = "05 65 87 98 65",
                CreeDans = new DateTime(2012, 12, 22),
                Mariee = false,
                CreePar = "bellal kader"
            });
            list.Add(new Account()
            {
                Nom = "Gabriel",
                Prenom = "Pepe",
                DateNaiss = new DateTime(1943, 11, 16),
                Raison = "unjkc djkjklsdm klsd lkcd lksd lqos cx,s cj",
                Adresse = "Anaba hay el amal 054",
                Telephone = "05 87 33 21 24",
                CreeDans = new DateTime(2011, 7, 10),
                Mariee = true,
                CreePar = "bennouna el khebith"
            });
            list.Add(new Account()
            {
                Nom = "Khoukhi",
                Prenom = "Doukkich",
                DateNaiss = new DateTime(1990, 4, 20),
                Raison = "fcef rvfrf rfv tgv wqw zsxsx zxszsd cedcvf rf tb tynh,uj ujkol pmsd",
                Adresse = "Chlef hay essalem nu 098",
                Telephone = "07 76 98 09 54",
                CreeDans = new DateTime(2009, 4, 8),
                Mariee = false,
                CreePar = "fellague halim"
            });
            return list;
        }
    }

    public class Account
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaiss { get; set; }
        public string Raison { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public bool Mariee { get; set; }
        public DateTime CreeDans { get; set; }
        public string CreePar { get; set; }
    }
}
