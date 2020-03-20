using DB;
using DB.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected IDataQuery DB {
            get {
                return Classes.Configs.GetContext;
            }
        }
        
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                Console.WriteLine("Changed property: " + propertyName);
                //isPropertyChanged = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
