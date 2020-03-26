using DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.Commands;

namespace WpfApplication1.ViewModel
{
    class AddPersonPageViewModel : BaseViewModel
    {
        //DataQuery dataQuery = new DataQuery();
        private Person _newPerson = new Person();
        public bool isManagerSelected = false;
        public bool isLocationSelected = false;
        public AddPersonPageViewModel()
        {
            //addUserCommand.CanExecuteChanged;

        }

        #region properties
        public string FirstName
        {
            get
            {
                return _newPerson.FirstName;
            }
            set
            {
                if (_newPerson.FirstName != value)
                {
                    _newPerson.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return _newPerson.LastName; }
            set
            {
                if (_newPerson.LastName != value)
                {
                    _newPerson.LastName = value;
                    OnPropertyChanged("LastName");
                }

            }
        }

        public string Username
        {
            get { return _newPerson.Username; }
            set
            {
                if (_newPerson.Username != value)
                {
                    _newPerson.Username = value;
                    OnPropertyChanged("Username");
                }

            }
        }

        public string Password
        {
            get { return _newPerson.Password; }
            set
            {
                if (_newPerson.Password != value)
                {
                    _newPerson.Password = value;
                    OnPropertyChanged("Password");
                }

            }
        }

        public string Email
        {
            get { return _newPerson.Email; }
            set
            {
                if (_newPerson.Email != value)
                {
                    _newPerson.Email = value;
                    OnPropertyChanged("Email");
                }

            }
        }

        public string Position
        {
            get { return _newPerson.Position; }
            set
            {
                if (_newPerson.Position != value)
                {
                    _newPerson.Position = value;
                    OnPropertyChanged("Position");
                }

            }
        }
        public List<Location> Locations
        {

            get
            {
                return DB.GetLocations().ToList();

            }
            set { OnPropertyChanged("LocationID"); }
        }

        public Location SelectedLocation
        {
            get
            {
                return DB.GetPersonLocation(_newPerson);
            }
            set
            {
                if (_newPerson.LocationID != value.LocationID)
                {
                    _newPerson.LocationID = value.LocationID;
                    isLocationSelected = true;
                    OnPropertyChanged("LocationID");
                    /*if (isLocationSelected == true && isManagerSelected==true)
                    {
                        addUserCommand.CanExecute(true);
                    }*/
                }
            }
        }

        public IEnumerable<Person> Managers
        {
            get { 
                //return DB.GetManagers(); 
                return DB.GetPeopleWithoutLocManagers();
            }
        }

        public Person SelectedManager
        {
            get {
                return DB.GetPersonManager(_newPerson);
            }
            set
            {
                if (_newPerson.Manager != value.PersonID)
                {
                    _newPerson.Manager = value.PersonID;
                    isManagerSelected = true;
                    OnPropertyChanged("Manager");
                }
            }
        }

        #endregion

        private bool CanAddUser(object parameter)
        {
            if (_newPerson.Manager != null && _newPerson.LocationID != null && _newPerson.FirstName != null && _newPerson.LastName != null && _newPerson.Username != null && _newPerson.Password != null && _newPerson.Email != null && _newPerson.Position != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddUser()
        {
            DB.AddNewPerson(_newPerson);
        }

        private ICommand _addUserCommand;
        public ICommand AddUserCommand
        {
            get
            {
                return _addUserCommand ?? (_addUserCommand = new RelayCommand(x => { AddUser(); }, CanAddUser));
            }
        }
    }
}
