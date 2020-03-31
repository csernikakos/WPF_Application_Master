using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel
{
    class RequestHistoryPageViewModel : BaseViewModel
    {
        private Request request;
        public RequestHistoryPageViewModel(Request _request)
        {
            request = _request;
        }

        public IEnumerable<Decision> Decisions
        {
            get
            {
                return DB.GetRequestDecisions(request);
            }
        }

    }
}
