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
    class ManagerRequestPageViewModel : BaseViewModel
    {
        private Request _newRequest = new Request();
        private Person _person = new Person();
        private Decision _newDecision = new Decision();
        public ManagerRequestPageViewModel(Person person)
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

        public string Reason
        {
            get { return _newDecision.Reason; }
            set
            {
                if (_newDecision.Reason!=value)
                {
                    _newDecision.Reason = value;
                    OnPropertyChanged("Reason");
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

        public IEnumerable<Request> ApproveList
        {
            get
            {
                return DB.GetApprovableRequest(_person);
            }
        }

        public IEnumerable<DB.Action> GetActions
        {
            get
            {
                return DB.GetActions();
            }
        }

        private DB.Action _selectedAction;
        public DB.Action SelectedAction
        {
            get
            {
                return _selectedAction;
            }
            set
            {
                if (_selectedAction != value)
                {
                    _selectedAction = value;
                    OnPropertyChanged("SelectedAction");
                }
            }
        }

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

        private bool CanAddRequest(object parameter)
        {
            if (SelectedRole != null && SelectedRequestType != null)
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
            DB.AddNewDecision(_person, _newRequest);
        }

        private ICommand _addRequestCommand;
        public ICommand AddRequestCommand
        {
            get
            {
                return _addRequestCommand ?? (_addRequestCommand = new RelayCommand(x => { AddRequest(); }, CanAddRequest));
            }
        }


        private bool CanAddDecision(object parameter)
        {
            if (SelectedAction!=null && Reason!=null && SelectedRequest!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddDecision()
        {
            //public void RaiseDecisionLevel(Request request, Decision decision, Action action, Person approver, string reason)

            DB.RaiseDecisionLevelToLocationManager(SelectedRequest, SelectedAction, _person, Reason);
        }

        private ICommand _addDecisionCommand;
        public ICommand AddDecisionCommand
        {
            get
            {
                return _addDecisionCommand ?? (_addDecisionCommand = new RelayCommand(x => { AddDecision(); }, CanAddDecision));
            }
        }

    }
}

