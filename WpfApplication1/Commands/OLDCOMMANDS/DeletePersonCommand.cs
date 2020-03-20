using DB;
using DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApplication1.Commands
{
    class DeletePersonCommand //: ICommand
    {
      /*  #region ICommand Members  

        private Person person;
        private IDataQuery dataQuery;

        //IMessageBoxManager _messageBoxManager;

        public DeletePersonCommand(Person _person, IDataQuery db)
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
            //var result = _messageBoxManager.ShowMessageBox("Do you want to delete " + person + "?", "Are you sure?", MessageBoxButton.YesNoCancel);
            MessageBoxResult result = MessageBox.Show("Do you want to delete "+person+"?", "Are you sure?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result==MessageBoxResult.Yes)
            {
                dataQuery.RemoveEditedPerson(person); 
            }
        }
        #endregion*/
    }
}

