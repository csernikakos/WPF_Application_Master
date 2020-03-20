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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    public partial class AddPersonPage : Page
    {
        private readonly AddPersonPageViewModel _viewModel;
        public AddPersonPage()
        {
            InitializeComponent();
            _viewModel = new AddPersonPageViewModel();
            DataContext = _viewModel;
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            if (_viewModel.isLocationSelected == true)
            {
                if (_viewModel.isManagerSelected==true)
                {
                    GetUsersPage getUsersPage = new GetUsersPage();
                    NavigationService.Navigate(getUsersPage);
                }
                else
                {
                    Console.WriteLine("select manager!");
                }
            }
            else
            {
                Console.WriteLine("SELECT LOCATION!");
            }
        }
    }
}