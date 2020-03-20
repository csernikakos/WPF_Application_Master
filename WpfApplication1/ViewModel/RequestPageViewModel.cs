using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.Commands;

namespace WpfApplication1.ViewModel
{
    class RequestPageViewModel : BaseViewModel
    {
        public RequestPageViewModel()
        {
        }
        public IEnumerable<Request> Requests
        {
            get
            {
                return DB.GetRequests();
            }
        }

        private Request _selectedRequest;
        public Request SelectedRequest
        {
            get
            {
                return _selectedRequest;
            }
            set
            {
                if (_selectedRequest != value)
                {
                    _selectedRequest = value;                    
                    OnPropertyChanged("SelectedRequest");
                }
            }
        }

        private bool CanDeleteRequest(object parameter)
        {
            if (SelectedRequest==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RemoveSelectedRequest()
        {
            DB.DeleteSelectedRequest(SelectedRequest);
        }


        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new RelayCommand(x =>{ RemoveSelectedRequest();}, CanDeleteRequest));
            }

        }

  
    }

}

