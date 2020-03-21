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
    public partial class PersonRequestPage : Page
    {
        private Person _person;
        private readonly PersonRequestPageViewModel _viewModel;
        public PersonRequestPage(Person person)
        {
            _person = person;

            InitializeComponent();
            _viewModel = new PersonRequestPageViewModel(person);
            DataContext = _viewModel;

            lblName.Content = person.ToString();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
           // cmbRoles.SelectedItem = null;
            // cmbRequestTypes.SelectedItem = null;
        }
    }
}
