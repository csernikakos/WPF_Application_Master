﻿using DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using WpfApplication1.Commands;
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    public class EditPersonPageViewModel : BaseViewModel
    {
        private Person person;
        public EditPersonPageViewModel(Person _person)
        {
            person = _person;
        }

        #region properties
        public string FirstName
        {
            get
            { return person.FirstName; }
            set 
            {
                if (person.FirstName != value)
                {
                    person.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return person.LastName; }
            set
            {
                if (person.LastName != value)
                {
                    person.LastName = value;
                    OnPropertyChanged("LastName");
                }

            }
        }

        public string Username
        {
            get { return person.Username; }
            set
            {
                if (person.Username != value)
                {
                    person.Username = value;
                    OnPropertyChanged("Username");
                }

            }
        }

        public string Password
        {
            get { return person.Password; }
            set
            {
                if (person.Password != value)
                {
                    person.Password = value;
                    OnPropertyChanged("Password");
                }

            }
        }

        public string Email
        {
            get { return person.Email; }
            set
            {
                if (person.Email != value)
                {
                    person.Email = value;
                    OnPropertyChanged("Email");
                }

            }
        }

        public string Position
        {
            get { return person.Position; }
            set
            {
                if (person.Position != value)
                {
                    person.Position = value;
                    OnPropertyChanged("Position");
                }

            }
        }

        public int LocationID
        {
            get
            {
                return Convert.ToInt32(person.LocationID);
            }
            set
            {
                if (person.LocationID != value)
                {
                    person.LocationID = value;
                    OnPropertyChanged("LocationID");
                }
            }
        }
        

        public List<Location> Locations
        {
            get {
               return DB.GetLocations().ToList();                
            }
            set { OnPropertyChanged("LocationID"); }
        }

        public Location SelectedLocation
        {
            get
            {
                return DB.GetPersonLocation(person);
            }
            set {
                if (person.LocationID != value.LocationID)
                {
                    person.LocationID = value.LocationID;
                    OnPropertyChanged("LocationID");
                }
            }
        }

        public List<Person> Managers
        {
            get { return DB.GetManagers(); }
            set {  }
        }

        public Person SelectedManager
        {
            get {
                Person _person = DB.GetPersonManager(person);
                Console.WriteLine("manager: "+ _person);
                return _person; 
            }
            set
            {
                if (person.Manager != value.PersonID)
                {
                    person.Manager = value.PersonID;
                    OnPropertyChanged("Manager");
                }
            }
        }
        #endregion
        
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater(person, DB);
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private ICommand removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                {
                    removeCommand = new DeletePersonCommand(person, DB);

                }
                return removeCommand;
            }
            set
            {
                removeCommand = value;
            }
        }
    }   


}
