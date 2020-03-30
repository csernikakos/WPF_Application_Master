using DB;
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
    class RenewRequestPageViewModel : BaseViewModel
    {

        private Request request = new Request();
        private Person person = new Person();
        public RenewRequestPageViewModel(Person _person, Request _request)
        {
            request = _request;
            person = _person;
        }
        
        public DateTime ValidityStart
        {
            get
            {
                return request.ValidityStart;
            }
            set
            {
                if (request.ValidityStart != value)
                {
                    request.ValidityStart = value;
                    OnPropertyChanged("ValidityStart");
                }
            }

        }

        public DateTime ValidityEnd
        {
            get
            {
                return request.ValidityEnd;
            }
            set
            {
                if (request.ValidityStart != value)
                {
                    request.ValidityEnd = value;
                    OnPropertyChanged("ValidityEnd");
                }
            }
        }

        private bool CanSubmit(object parameter)
        {
            return true;
        }

        private void Submit()
        {
            if (DB.CheckDateValidation(ValidityStart, ValidityEnd))
            {
               // MessageBoxResult result = MessageBox.Show("If you renew the the role date, the active role will be deleted. Do you really want to proceed?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
               // if (result == MessageBoxResult.Yes)
               // {
                    DB.RenewRequest(request, person, ValidityStart,ValidityEnd);
               // }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("The validity start date must be before the validity end date!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                return _submitCommand ?? (_submitCommand = new RelayCommand(x => { Submit(); }, CanSubmit));
            }
        }

    }


}
