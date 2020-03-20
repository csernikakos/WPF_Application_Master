using DB;
using DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.ViewModel;

namespace WpfApplication1.Commands
{
    class AddUserCommand //: ICommand
    {
        //#region ICommand Members  
        /*
        private Person person;
        private IDataQuery dataQuery;

        public AddUserCommand(Person _person, IDataQuery db)
        {
            person = _person;
            dataQuery = db;
        }

        public bool CanExecute(object parameter)
        {
            if (person.Manager!=null && person.LocationID!=null && person.FirstName!=null && person.LastName!=null && person.Username!=null && person.Password!=null && person.Email!=null && person.Position!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            dataQuery.AddNewPerson(person);
        }
        #endregion
    }*/
    }
}
