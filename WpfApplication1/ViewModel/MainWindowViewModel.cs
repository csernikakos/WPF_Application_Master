using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApplication1.Commands;
using WpfApplication1.Pages;

namespace WpfApplication1.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        Frame frame;

        public MainWindowViewModel(Frame mainFrame)
        {
            frame = mainFrame;
        }

        public void GoToGetUsersPage()
        {
            frame.Content = new GetUsersPage();
        }

        public void GoToLocationsPage()
        {
            frame.Content = new LocationsPage();
        }

        public void GoToRequestsPage()
        {
            frame.Content = new RequestPage();
        }

        public void GoToLoginPage()
        {
            frame.Content = new LoginPage();
        }

        private bool CanGetPerson(object parameter)
        {
            return true;
        }

        public void GetPerson()
        {
            frame.Content = new GetUsersPage();
        }


        private ICommand _getpersonCommand;
        public ICommand GetPersonCommand
        {
            get
            {
                return _getpersonCommand ?? (_getpersonCommand = new RelayCommand(x => { GetPerson(); }, CanGetPerson));
            }
        }


        private bool CanGetLocations(object parameter)
        {
            return true;
        }

        public void GetLocations()
        {
            frame.Content = new LocationsPage();
        }


        private ICommand _getLocationsCommand;
        public ICommand GetLocationsCommand
        {
            get
            {
                return _getLocationsCommand ?? (_getLocationsCommand = new RelayCommand(x => { GetLocations(); }, CanGetLocations));
            }
        }


        private bool CanGetRequest(object parameter)
        {
            return true;
        }

        public void GetRequest()
        {
            frame.Content = new RequestPage();
        }


        private ICommand _getRequestCommand;
        public ICommand GetRequestCommand
        {
            get
            {
                return _getRequestCommand ?? (_getRequestCommand = new RelayCommand(x => { GetRequest(); }, CanGetRequest));
            }
        }


        private bool CanLogout(object parameter)
        {
            return true;
        }

        public void Logout()
        {
            frame.Content = new LoginPage();
        }


        private ICommand _logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                return _logoutCommand ?? (_logoutCommand = new RelayCommand(x => { Logout(); }, CanLogout));
            }
        }
    }
}
