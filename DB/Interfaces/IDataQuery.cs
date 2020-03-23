using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IDataQuery
    {
        List<Person> QueryPeople(string namePart);
        List<Location> GetLocations();
        List<Person> GetManagers();
        List<Person> GetPeople();
        List<Role> GetRoles();
        List<RequestType> GetRequestTypes();
        Person GetPersonManager(Person person);
        void UpdatePerson(Person person);
        void AddNewPerson(Person person);
        void RemoveEditedPerson(Person person);
        Location GetPersonLocation(Person person);
        void AddNewRequest(Request request);
        IEnumerable<Request> GetRequests();
        Person GetLocationManager(Location location);
        IEnumerable<Person> GetLocationPeople(Location location);
        void UpdateLocation(Location location, Person manager);
        void DeleteSelectedRequest(Request request);

        bool IsManager(Person person);
        IEnumerable<Request> GetPersonRequests(Person person);


        void AddNewDecision(Person person, Request request);
        IEnumerable<Request> GetApprovableRequest(Person person);
        IEnumerable<DB.Action> GetActions();
        void RaiseDecisionLevel(Request request, Action action, Person approver, string reason);
    }
}
