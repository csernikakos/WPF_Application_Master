using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.Commands;

namespace WpfApplication1.ViewModel
{
    class AddRequestsPageViewModel : BaseViewModel
    {
        /// <summary>
        /// TODO:
        ///     Removenál ne legyen enabled a validity
        ///     Update/Add-nál csekkolni a dátumokat
        /// </summary>
        private Request _newRequest = new Request();

        public AddRequestsPageViewModel()
        {
            // set default date
            _newRequest.ValidityStart = DateTime.Now;
            _newRequest.ValidityEnd = DateTime.Now.AddDays(1);
        }

        public List<Person> People
        {
            get
            {
                return DB.GetPeople();
            }
        }
        public Person SelectedPerson
        {
            get
            {
                return _newRequest.Person;
            }
            set
            {
                if (_newRequest.Person != value)
                {
                    _newRequest.Person = value;
                    Console.WriteLine(_newRequest.Person+ " Selected person");
                    OnPropertyChanged("Person");
                }
            }
        }

        public List<Role> Roles
        {
            get
            {
                return DB.GetRoles();
            }
        }
        public Role SelectedRole
        {
            get
            {
                return _newRequest.Role;
            }
            set
            {
                if (_newRequest.Role != value)
                {
                    _newRequest.Role = value;
                    Console.WriteLine(_newRequest.Role + " Selected Role");
                    OnPropertyChanged("Role");
                }
            }
        }

        public List<RequestType> RequestTypes
        {
            get
            {
                return DB.GetRequestTypes();
            }
        }
        /*
        public int RequestTypeID
        {
            get
            {
                return _newRequest.RequestTypeID;
            }
            set
            {
                if (_newRequest.RequestTypeID != value)
                {
                    _newRequest.RequestTypeID = value;
                    OnPropertyChanged("RequestTypeID");
                }
            }
        }
        */
        public RequestType SelectedRequestType
        {
            get
            {
                return _newRequest.RequestType;
            }
            set
            {
                if (_newRequest.RequestType != value)
                {
                    _newRequest.RequestType = value;
                    Console.WriteLine(_newRequest.RequestType + " SelectedRequestType");
                    OnPropertyChanged("RequestType");
                }
            }        
        }

        public DateTime ValidityStart
        {
            get
            { 
                return _newRequest.ValidityStart;
            }
            set
            {
                if(_newRequest.ValidityStart != value)
                {
                    _newRequest.ValidityStart = value;
                    Console.WriteLine(_newRequest.ValidityStart);
                    OnPropertyChanged("ValidityStart");
                }
            }

        }

        public DateTime ValidityEnd
        {
            get
            {
                return _newRequest.ValidityEnd;
            }
            set
            {
                if(_newRequest.ValidityStart != value)
                {
                    _newRequest.ValidityEnd = value;
                    Console.WriteLine(_newRequest.ValidityEnd);
                    OnPropertyChanged("ValidityEnd");
                }
            }

        }

        
        private bool CanAddRequest(object parameter)
        {
            if (SelectedPerson != null && SelectedRole != null && SelectedRequestType != null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void AddRequest()
        {
            DB.AddNewRequest(_newRequest);
        }

        private ICommand _addRequestCommand;
        public ICommand AddRequestCommand
        {
            get
            {
                return _addRequestCommand ?? (_addRequestCommand = new RelayCommand(x => { AddRequest();}, CanAddRequest));
            }
        }
    }
}
