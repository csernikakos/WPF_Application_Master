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
    class DeleteRequestCommand// : ICommand
    {
        /*#region ICommand Members  

        private Request request;
        private IDataQuery DB;
        Action<Request> executeMethod;

        //IMessageBoxManager _messageBoxManager;

        public DeleteRequestCommand(Request _request, IDataQuery db, Action<Request> _executeMethod)
        {
            request = _request;            
            DB = db;
            executeMethod = _executeMethod;
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
            //var result = _messageBoxManager.ShowMessageBox("Do you want to delete " + person + "?", "Are you sure?", MessageBoxButton.YesNoCancel);
            //MessageBoxResult result = MessageBox.Show("Do you want to delete " + person + "?", "Are you sure?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            Console.WriteLine("delete : "+ request);
        }
        #endregion*/
    }
}
