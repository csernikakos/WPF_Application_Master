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
        private Person _person;
        private readonly ManagerRequestPageViewModel _viewModel;
        public ManagerRequestPage(Person person)
        {
            _person = person;

            InitializeComponent();
            _viewModel = new ManagerRequestPageViewModel();
            DataContext = _viewModel;

            lblName.Content = person.ToString();
        }
    }
}
