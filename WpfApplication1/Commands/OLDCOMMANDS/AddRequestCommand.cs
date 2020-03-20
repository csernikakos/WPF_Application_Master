using DB;
using DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.Commands
{
    class AddRequestCommand // : ICommand
    {
       /* #region ICommand Members  

        private Request request;
        private IDataQuery dataQuery;

        public AddRequestCommand(Request _request, IDataQuery db)
        {
            request = _request;
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
            Console.WriteLine(request.PersonID + " " + request.RoleID + " " + request.ValidityStart + " " + request.ValidityEnd + " " + request);
            Console.WriteLine("-add_request-");
            dataQuery.AddNewRequest(request);
        }
        #endregion*/
    }
}
