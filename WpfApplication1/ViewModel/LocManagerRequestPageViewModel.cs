﻿using DB;
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
    class LocManagerRequestPageViewModel : BaseViewModel
    {
        private Request _newRequest = new Request();
        private Person _person = new Person();
        private Decision _newDecision = new Decision();
        public LocManagerRequestPageViewModel(Person person)
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
                if (_newDecision.Reason != value)
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
                return DB.GetApprovableRequestLocationManager(_person);
            }
        }

        private IEnumerable<DB.Action> filteredActions;
        public IEnumerable<DB.Action> GetActions
        {
            get
            {
                filteredActions = DB.GetActions().Take(2);
                return filteredActions;
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
            if (DB.CheckDateValidation(ValidityStart, ValidityEnd))
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


        private bool CanAddDecision(object parameter)
        {
            if (SelectedAction != null && Reason != null && SelectedRequest != null)
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
            if (SelectedAction.DisplayName=="Approve")
            {
                DB.RaiseDecisionLevelToApproved(SelectedRequest, SelectedAction, _person, Reason);
            }
            if (SelectedAction.DisplayName=="Deny")
            {
                DB.DenyRequest(SelectedRequest, SelectedAction, _person, Reason);
            }
        }

        private ICommand _addDecisionCommand;
        public ICommand AddDecisionCommand
        {
            get
            {
                return _addDecisionCommand ?? (_addDecisionCommand = new RelayCommand(x => { AddDecision(); }, CanAddDecision));
            }
        }


        // unsubscribe

        private bool CanUnsubscribe(object parameter)
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

        private void Unsubscribe()
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to delete the " + SelectedRequest.Role + " role permanently?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
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

