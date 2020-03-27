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
            if (DB.CheckPersonRole(_person, SelectedRole))
            {
                MessageBoxResult result = MessageBox.Show("The selected  " + SelectedRole + "role is already ordered!", "Error", MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else
            {
                DB.AddNewRequest(_newRequest);
                DB.AddNewDecision(_person, _newRequest);
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
    }

}

