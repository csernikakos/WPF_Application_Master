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
    /// Interaction logic for RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        private readonly RequestPageViewModel _viewModel;
        public RequestPage()
        {
            _viewModel = new RequestPageViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void btnAddNewRequest_Click(object sender, RoutedEventArgs e)
        {
            AddRequestPage addRequestPage = new AddRequestPage();
            NavigationService.Navigate(addRequestPage);
        }

        private void btnDeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            RequestPage requestPage = new RequestPage();
            NavigationService.Navigate(requestPage);
        }
    }
}
