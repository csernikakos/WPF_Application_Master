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

namespace WpfApplication1
{
    public partial class LocationsPage : Page
    {

        private readonly LocationsPageViewModel _viewModel;
        private IDataQuery DB
        {
            get
            {
                return Classes.Configs.GetContext;
            }
        }

        public LocationsPage()
        {
            _viewModel = new LocationsPageViewModel();
            DataContext = _viewModel;
            InitializeComponent();

            cmbManagers.ItemsSource = DB.GetManagers();

            btn_Save.IsEnabled = false;
            txtLocationName.IsEnabled = false;
            cmbManagers.IsEnabled = false;
            dtgLocationPeople.IsEnabled = false;
        }

        private void lstLocations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Save.IsEnabled = true;
            txtLocationName.IsEnabled = true;
            cmbManagers.IsEnabled = true;
            dtgLocationPeople.IsEnabled = true;

            Location selectedLocation = _viewModel.SelectedLocation;
            var manager = DB.GetLocationManager(selectedLocation); 
            var people = DB.GetLocationPeople(selectedLocation);

            foreach (var item in cmbManagers.Items)
            {
                if (item.ToString()==manager.ToString())
                {
                    cmbManagers.SelectedItem = item;
                }
            }
            dtgLocationPeople.ItemsSource = people;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            /*
            var selectedManager = _viewModel.LocationManager;
            var selectedLocation = _viewModel.SelectedLocation;
            DB.UpdateLocation(selectedLocation, selectedManager);
            */
            //refresh page
            LocationsPage locationsPage = new LocationsPage();
            NavigationService.Navigate(locationsPage);
        }
    }
}
