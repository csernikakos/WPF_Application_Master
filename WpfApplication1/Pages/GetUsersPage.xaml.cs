using DB;
using DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    public partial class GetUsersPage : Page
    {
        private readonly GetPersonPageViewModel _viewModel;

        private IDataQuery DB
        {
            get
            {
                return Classes.Configs.GetContext;
            }
        }

        public GetUsersPage()
        {            
            InitializeComponent();
            _viewModel = new GetPersonPageViewModel();
            DataContext = _viewModel;
            
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetSearchbarText(txtName.Text);
            foreach (var item in _viewModel.ListedPeople)
            {
                Console.WriteLine(item);
            }

            //refresh page
            DataContext = null;
            DataContext = _viewModel;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = new Person();
            if (lstPeople.SelectedItem != null)
            {
                foreach (var item in _viewModel.ListedPeople)
                {       
                    if (item == lstPeople.SelectedItem)
                    {
                        selectedPerson = item;
                    }
                }
                EditPersonPage editPersonPage = new EditPersonPage(selectedPerson);
                NavigationService.Navigate(editPersonPage);
            }            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPersonPage addPersonPage = new AddPersonPage();
            NavigationService.Navigate(addPersonPage);
        }
    }
}
