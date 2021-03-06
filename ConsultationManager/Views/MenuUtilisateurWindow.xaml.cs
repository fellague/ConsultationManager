﻿using System;
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
using ConsultationManagerClient.Views.Users;
using ConsultationManagerClient.ViewModels.Users;

namespace ConsultationManagerClient.Views
{
    /// <summary>
    /// Interaction logic for MenuEmployeeWindow.xaml
    /// </summary>
    public partial class MenuUserWindow : Window
    {
        UsersViewModel UsersVM;

        public MenuUserWindow()
        {
            InitializeComponent();
            UsersVM = new UsersViewModel();
            this.DataContext = UsersVM;

            _mainFrame.Navigate(new AllUsersPage(UsersVM));
            coloringTabs(AllEmplBtn, chefServiceBtn, medecinsBtn, infirmierBtn, assistantBtn, NewEmplBtn);
        }

        private void button_click_tout(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AllUsersPage(UsersVM));
            coloringTabs(AllEmplBtn, chefServiceBtn, medecinsBtn, infirmierBtn, assistantBtn, NewEmplBtn);
        }

        private void button_click_chefServ(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new ChefServicePage(UsersVM));
            coloringTabs(chefServiceBtn, AllEmplBtn, medecinsBtn, infirmierBtn, assistantBtn, NewEmplBtn);
        }
        private void button_click_medecin(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new MedecinsPage(UsersVM));
            coloringTabs(medecinsBtn, AllEmplBtn, chefServiceBtn, infirmierBtn, assistantBtn, NewEmplBtn);
        }
        private void button_click_infirmier(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new InfirmiersPage(UsersVM));
            coloringTabs(infirmierBtn, AllEmplBtn, chefServiceBtn, medecinsBtn, assistantBtn, NewEmplBtn);
        }
        private void button_click_assistant(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AssistantsPage(UsersVM));
            coloringTabs(assistantBtn, AllEmplBtn, chefServiceBtn, medecinsBtn, infirmierBtn, NewEmplBtn);
        }

        private void button_click_nouveau(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new NewUserPage(UsersVM));
            coloringTabs(NewEmplBtn, AllEmplBtn, chefServiceBtn, medecinsBtn, infirmierBtn, assistantBtn);
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
        private void coloringTabs(Button puprpleBtn, Button transparantBtn1, Button transparantBtn2, Button transparantBtn3, Button transparantBtn4, Button transparantBtn5)
        {
            puprpleBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF945BF9"));
            transparantBtn1.Background = Brushes.Transparent;
            transparantBtn2.Background = Brushes.Transparent;
            transparantBtn3.Background = Brushes.Transparent;
            transparantBtn4.Background = Brushes.Transparent;
            transparantBtn5.Background = Brushes.Transparent;

            puprpleBtn.Foreground = Brushes.White;
            transparantBtn1.Foreground = Brushes.Black;
            transparantBtn2.Foreground = Brushes.Black;
            transparantBtn3.Foreground = Brushes.Black;
            transparantBtn4.Foreground = Brushes.Black;
            transparantBtn5.Foreground = Brushes.Black;
        }
    }
}
