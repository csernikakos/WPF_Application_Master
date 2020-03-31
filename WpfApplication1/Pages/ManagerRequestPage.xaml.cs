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
    public partial class ManagerRequestPage : Page
    {
        private readonly ManagerRequestPageViewModel _viewModel;
        private Person _person;
        public ManagerRequestPage(Person person)
        {
            _person = person;

            InitializeComponent();
            _viewModel = new ManagerRequestPageViewModel(person);
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

        private void btnUnsubscribe_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        private void btnRenew_Click(object sender, RoutedEventArgs e)
        {
            RenewRequestPage renewRequestPage = new RenewRequestPage(_person, _viewModel.SelectedRequest);
            NavigationService.Navigate(renewRequestPage);
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            RequestHistoryPage requestHistoryPage = new RequestHistoryPage(_person, _viewModel.SelectedRequest);
            NavigationService.Navigate(requestHistoryPage);
        }
    }
}
