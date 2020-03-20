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
    class Updater// : ICommand
    {
       /* #region ICommand Members  

        public Person person { get; set; }
        private IDataQuery dataQuery;

       // DataQuery dataQuery = new DataQuery();

        public Updater(Person _person, IDataQuery db)
        {
            person = _person;
            dataQuery = db;
        }

        public bool CanExecute(object parameter)
        {
            return true;            
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            // Console.WriteLine("execute -!");
            dataQuery.UpdatePerson(person);
            //Your Code
        }
        #endregion*/
    }
}
