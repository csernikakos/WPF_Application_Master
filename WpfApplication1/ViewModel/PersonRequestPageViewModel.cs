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
    class PersonRequestPageViewModel : BaseViewModel
    {

        private Request _newRequest = new Request();
        private Person _person = new Person();
        public PersonRequestPageViewModel(Person person)
        {
            _person = person;
            _newRequest.Person = person;

            // set default date
            _newRequest.ValidityStart = DateTime.Now;
            _newRequest.ValidityEnd = DateTime.Now.AddDays(1);
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
                    OnPropertyChanged("Role");
                }
            }
        }
        /*
        public List<RequestType> RequestTypes
        {
            get
            {
                return DB.GetRequestTypes();
            }
        }

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
                    OnPropertyChanged("RequestType");
                }
            }
        }*/

        private Request _selectedRequest;
        public Request SelectedRequest
        {
            get
            {
                return _selectedRequest;
            }
            set
            {
                if (_selectedRequest != value)
                {
                    _selectedRequest = value;
                    OnPropertyChanged("SelectedRequest");
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
                if (_newRequest.ValidityStart != value)
                {
                    _newRequest.ValidityStart = value;
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
                if (_newRequest.ValidityStart != value)
                {
                    _newRequest.ValidityEnd = value;
                    OnPropertyChanged("ValidityEnd");
                }
            }
        }

        public IEnumerable<Request> Requests
        {
            get
            {
                return DB.GetPersonRequests(_person);
            }
        }

       /* public string DecisionLevelStatus
        {
            get
            {
                DB.GetRequestStatus();
            }
        }*/

        private bool CanAddRequest(object parameter)
        {
            if (SelectedRole != null)
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
            if (DB.CheckDateValidation(ValidityStart,ValidityEnd))
            {
                if (DB.CheckPersonRole(_person, SelectedRole))
                {
                    MessageBoxResult result = MessageBox.Show("The selected " + SelectedRole + " role is already ordered!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    DB.AddNewRequest(_newRequest);
                    DB.AddNewDecision(_person, _newRequest);
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("The validity start date must be before the validity end date!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private ICommand _addRequestCommand;
        public ICommand AddRequestCommand
        {
            get
            {
                return _addRequestCommand ?? (_addRequestCommand = new RelayCommand(x => { AddRequest(); }, CanAddRequest));
            }
        }

        // unsubscribe

        private bool CanUnsubscribe(object parameter)
        {
            if (SelectedRequest!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Unsubscribe()
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to delete the "+SelectedRequest.Role+" role permanently?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result==MessageBoxResult.Yes)
            {
                DB.UnsubscribeRequest(SelectedRequest);
            }
        }

        private ICommand _unsubscribeCommand;
        public ICommand UnsubscribeCommand
        {
            get
            {
                return _unsubscribeCommand ?? (_unsubscribeCommand = new RelayCommand(x => { Unsubscribe(); }, CanUnsubscribe));
            }
        }


        // renew

        private bool CanRenew(object parameter)
        {
            if (SelectedRequest != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Renew()
        {
            
        }

        private ICommand _renewCommand;
        public ICommand RenewCommand
        {
            get
            {
                return _renewCommand ?? (_renewCommand = new RelayCommand(x => { Renew(); }, CanRenew));
            }
        }

        // history

        private bool CanHistory(object parameter)
        {
            if (SelectedRequest != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ViewHistory()
        {

        }

        private ICommand _viewHistoryCommand;
        public ICommand ViewHistoryCommand
        {
            get
            {
                return _viewHistoryCommand ?? (_viewHistoryCommand = new RelayCommand(x => { ViewHistory(); }, CanHistory));
            }
        }
    }

}

