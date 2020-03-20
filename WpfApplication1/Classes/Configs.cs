using DB;
using DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Classes
{
    static class Configs
    {
        public static IDataQuery GetContext
        {
            get
            {
                return new DataQuery();
            }
        }
    }
}
