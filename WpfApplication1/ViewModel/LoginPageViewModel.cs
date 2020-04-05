using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication1.Commands;

namespace WpfApplication1.ViewModel
{
    class LoginPageViewModel : BaseViewModel
    {
        public List<Person> People
        {
            get {
                return DB.GetPeople();
            }
        }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                if (_selectedPerson!=value)
                {
                    _selectedPerson = value;
                    OnPropertyChanged("SelectedPerson");
                }
            }
        }

        private bool CanLogin(object parameter)
        {
            if(SelectedPerson==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Login()
        {

        }


        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(x => { Login(); }, CanLogin));
            }

        }
    }
}
