using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
    }
}
