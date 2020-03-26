using DB.Interfaces;
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
using WpfApplication1.ViewModel;

namespace WpfApplication1.Pages
{
    public partial class LoginPage : Page
    {
        private readonly LoginPageViewModel _viewModel;
      
        public LoginPage()
        {
            _viewModel = new LoginPageViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private IDataQuery DB
        {
            get
            {
                return Classes.Configs.GetContext;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (DB.IsManager(_viewModel.SelectedPerson)==false)
            {
                PersonRequestPage personRequestPage = new PersonRequestPage(_viewModel.SelectedPerson);
                NavigationService.Navigate(personRequestPage);
            }
            if (DB.IsManager(_viewModel.SelectedPerson)==true)
            {
                ManagerRequestPage managerRequestPage = new ManagerRequestPage(_viewModel.SelectedPerson);
                NavigationService.Navigate(managerRequestPage);
            }
            if (DB.IsLocationManager(_viewModel.SelectedPerson)==true)
            {
                LocationManagerRequestPage locationManagerRequestPage = new LocationManagerRequestPage(_viewModel.SelectedPerson);
                NavigationService.Navigate(locationManagerRequestPage);
            }
        }
    }
}
