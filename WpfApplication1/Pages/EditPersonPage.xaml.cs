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
using WpfApplication1.Commands;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : Page
    {
        private readonly EditPersonPageViewModel _viewModel;

        GetUsersPage getUsersPage = new GetUsersPage();

        private IDataQuery DB
        {
            get
            {
                return Classes.Configs.GetContext;
            }
        }

        public EditPersonPage(Person person)
        {
            InitializeComponent();
            _viewModel = new EditPersonPageViewModel(person);
            DataContext = _viewModel;

            // -------- TEMP ----------------------------------------------
            cmbLocation.ItemsSource = DB.GetLocations();
            var personLoc = DB.GetPersonLocation(person).ToString();
            foreach (var item in cmbLocation.Items)
            {
                if (item.ToString() == personLoc)
                {
                    cmbLocation.SelectedIndex = cmbLocation.Items.IndexOf(item);
                }
            }

            cmbManager.ItemsSource = DB.GetManagers();
            var personManager = DB.GetPersonManager(person).ToString();
            foreach (var item in cmbManager.Items)
            {
                if (item.ToString() == personManager)
                {
                    cmbManager.SelectedIndex = cmbManager.Items.IndexOf(item);
                }
            }

            //--------------------------------------------------------------            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(getUsersPage);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {            
           NavigationService.Navigate(getUsersPage);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(getUsersPage);
        }
    }
}
