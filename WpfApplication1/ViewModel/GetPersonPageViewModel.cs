﻿using DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    class GetPersonPageViewModel : BaseViewModel
    {

        List<Person> filteredPeople;
        // DataQuery dataQuery = new DataQuery();
        //IDataQuery dataQuery;

        public GetPersonPageViewModel()
        {

        }

        public IEnumerable<Person> People
        {
            get
            {
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
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    OnPropertyChanged("SelectedPerson");
                }
            }
        }

        public void GetSearchbarText(string textBoxText)
        {
            filteredPeople = DB.QueryPeople(textBoxText);
        }

        public List<Person> ListedPeople
        {
            get {
                return filteredPeople;
            }

        }

        
    }
}
