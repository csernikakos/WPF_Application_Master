﻿using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.Commands;

namespace WpfApplication1.ViewModel
{
    class LoginPageViewModel : BaseViewModel
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

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
            //if (Username == null && Password == null)
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
            // DB.GetCredentials(_username, _password);            
            // Console.WriteLine("Is manager: "+DB.IsManager(_selectedPerson));
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