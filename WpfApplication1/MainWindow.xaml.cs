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
            var DB = new DataQuery();
            _mainWindowViewModel = new MainWindowViewModel(Main);
            DataContext = _mainWindowViewModel;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPeople(object sender, RoutedEventArgs e)
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
        }

    }

    /*
     
    region
    DB solutionbe minden osztályt - db meghívások ide
    WPF app - Databinding - módosítás figyelés
    Frame Page ? 

    INTERFACE!

     */
}
