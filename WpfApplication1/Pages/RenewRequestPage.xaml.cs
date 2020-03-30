using DB;
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
    /// <summary>
    /// Interaction logic for RenewRequestPage.xaml
    /// </summary>
    public partial class RenewRequestPage : Page
    {
        private Person _person;
        private Request _request;
        private readonly RenewRequestPageViewModel _viewModel;

        public RenewRequestPage(Person person, Request request)
        {
            _person = person;
            _request = request;

            InitializeComponent();
            _viewModel = new RenewRequestPageViewModel(_person,_request);
            this.DataContext = _viewModel;

            lblName.Content = _person.ToString();
            lblRole.Content = _request.Role.ToString();
        }

        private IDataQuery DB
        {
            get
            {
                return Classes.Configs.GetContext;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
          /*  PersonRequestPage personRequestPage = new PersonRequestPage(_person);
            NavigationService.Navigate(personRequestPage);*/

            if (DB.IsManager(_person) == false)
            {
                PersonRequestPage personRequestPage = new PersonRequestPage(_person);
                NavigationService.Navigate(personRequestPage);
            }
            if (DB.IsManager(_person) == true)
            {
                ManagerRequestPage managerRequestPage = new ManagerRequestPage(_person);
                NavigationService.Navigate(managerRequestPage);
            }
            if (DB.IsLocationManager(_person) == true)
            {
                LocationManagerRequestPage locationManagerRequestPage = new LocationManagerRequestPage(_person);
                NavigationService.Navigate(locationManagerRequestPage);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            PersonRequestPage personRequestPage = new PersonRequestPage(_person);
            NavigationService.Navigate(personRequestPage);
        }
    }
}
