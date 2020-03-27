using DB;
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
    /// Interaction logic for LocationManagerRequestPage.xaml
    /// </summary>
    public partial class LocationManagerRequestPage : Page
    {
        private readonly LocManagerRequestPageViewModel _viewModel;
        private Person _person;
        public LocationManagerRequestPage(Person person)
        {
            _person = person;

            InitializeComponent();
            _viewModel = new LocManagerRequestPageViewModel(person);
            DataContext = _viewModel;

            lblName.Content = person.ToString();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
            // tabControl.SelectedItem = approvalTab;
            //  approvalTab.IsSelected = true;
        }

        private void RefreshPage()
        {
            ManagerRequestPage managerRequestPage = new ManagerRequestPage(_person);
            NavigationService.Navigate(managerRequestPage);
        }
    }
}
