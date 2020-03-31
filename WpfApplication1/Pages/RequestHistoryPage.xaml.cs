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
    /// Interaction logic for RequestHistoryPage.xaml
    /// </summary>
    public partial class RequestHistoryPage : Page
    {
        private readonly RequestHistoryPageViewModel _viewModel;
        private Request request;
        private Person person;
        public RequestHistoryPage(Person _person, Request _request)
        {
            InitializeComponent();
            request = _request;
            person = _person;
            _viewModel = new RequestHistoryPageViewModel(request);
            this.DataContext = _viewModel;

            lblName.Content = person.ToString();
            lblRole.Content = request.Role.Description;
        }

        private IDataQuery DB
        {
            get
            {
                return Classes.Configs.GetContext;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (DB.IsManager(person) == false)
            {
                PersonRequestPage personRequestPage = new PersonRequestPage(person);
                NavigationService.Navigate(personRequestPage);
            }
            if (DB.IsManager(person) == true)
            {
                ManagerRequestPage managerRequestPage = new ManagerRequestPage(person);
                NavigationService.Navigate(managerRequestPage);
            }
            if (DB.IsLocationManager(person) == true)
            {
                LocationManagerRequestPage locationManagerRequestPage = new LocationManagerRequestPage(person);
                NavigationService.Navigate(locationManagerRequestPage);
            }
        }
    }
}
