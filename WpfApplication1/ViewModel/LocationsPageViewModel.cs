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
    class LocationsPageViewModel : BaseViewModel
    {

        private Location _location = new Location();
        
        public IEnumerable<Location> Locations
        {
            get
            {
                return DB.GetLocations();
            }
        }

        private Location _selectedLocation = new Location();
        private Person _locationManager = new Person();
        
        public Location SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                if (_selectedLocation != value)
                {
                    _selectedLocation = value;
                    OnPropertyChanged("SelectedLocation");
                }
            }
        }    

        public Person LocationManager
        {            
            get
            {
                return _locationManager; 
            }
            set
            {
                if (_locationManager != value)
                {
                    _locationManager = value;
                    OnPropertyChanged("LocationManager");
                }
            }
        }
        
        private int _locationManagerID;
        public int LocationManagerID
        {

            get
            {
                return _locationManagerID;
            }
            set
            {
                if (_locationManagerID != value)
                {
                    _locationManagerID = value;
                    OnPropertyChanged("LocationManagerID");
                }
            }
        }


        public List<Person> Managers
        {
            get { return DB.GetManagers(); }
            set { }
        }

        private bool CanSaveLocation(object parameter)
        {
            if (SelectedLocation == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UpdateLocation()
        {
            DB.UpdateLocation(SelectedLocation, LocationManager);
        }

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(x => { UpdateLocation(); }, CanSaveLocation));
            }

        }
    }
}
