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
    /// Interaction logic for AddRequestPage.xaml
    /// </summary>
    public partial class AddRequestPage : Page
    {

        private readonly AddRequestsPageViewModel _viewModel;
        private RequestPage requestPage = new RequestPage();
        public AddRequestPage()
        {
            _viewModel = new AddRequestsPageViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(requestPage);
        }
    }
}
