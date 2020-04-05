using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DB;
using System.Data.Entity;
using WpfApplication1.ViewModel;
using DB.Interfaces;
using WpfApplication1.Pages;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainWindowViewModel = new MainWindowViewModel(Main);
            DataContext = _mainWindowViewModel;


            Main.Source = new Uri("Pages/LoginPage.xaml", UriKind.Relative);
            //HideButtons();
            //btnLogin.Visibility = Visibility.Hidden;
        }
               
      /*  private void BtnPeople(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.GoToGetUsersPage();
            
        }
        private void BtnLocations(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.GoToLocationsPage();
        }
        private void BtnRequests(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.GoToRequestsPage();
        }
        private void BtnLogin(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.GoToLoginPage();
            HideButtons();
            button.Visibility = Visibility.Visible;
        }
        */
     /*   private void button_Click(object sender, RoutedEventArgs e)
        {
            ShowButtons();
            _mainWindowViewModel.GoToGetUsersPage();
            button.Visibility = Visibility.Hidden;
        }

        private void HideButtons()
        {
            btnPeople.Visibility = Visibility.Hidden;
            btnLocations.Visibility = Visibility.Hidden;
            btnRequests.Visibility = Visibility.Hidden;
        }

        private void ShowButtons()
        {
            btnPeople.Visibility = Visibility.Visible;
            btnLocations.Visibility = Visibility.Visible;
            btnRequests.Visibility = Visibility.Visible;
        }
        */
        private void Open_Click(object sender, RoutedEventArgs e)
        {

            Open.Visibility = Visibility.Collapsed;
            Close.Visibility = Visibility.Visible;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Open.Visibility = Visibility.Visible;
            Close.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
