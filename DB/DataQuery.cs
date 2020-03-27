using DB;
using DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DB
{
    public class DataQuery : IDataQuery
    {

        #region PERSON TAB //////////////////////////////////////////////////////////////////////////////

        public List<Person> QueryPeople(string namePart)
        {
            using (var context = new ProgDatabaseEntities())
            {
                List<Person> peopleList = new List<Person>();
                var query = from p in context.People
                            where p.FirstName.Contains(namePart) || p.LastName.Contains(namePart)
                            select p;

                foreach (var person in query)
                {
                    peopleList.Add(person);
                }

                return peopleList;

                //var lst = context.People.Where(p => p.PersonID == 1).Single().Locations;

                /*
                var bennevan = context.Locations.Where(l => l.LocationID == 2).Single().People;
                foreach (var item in bennevan)
                {
                    Console.WriteLine("bennevan: "+item);
                }
                var manageli = context.Locations.Where(l => l.LocationID == 2).Single().People1;
                foreach (var item in manageli)
                {
                    Console.WriteLine("manageli: " + item);
                }
                */
                // ! IEumerable 
                //return context.People.Where(p => p.FirstName.Contains(namePart) || p.LastName.Contains(namePart)).ToList();
            }
        }

        public Location GetPersonLocation(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                Location location = new Location();
                var query = from p in context.People
                            join l in context.Locations on p.LocationID equals l.LocationID
                            where person.PersonID == p.PersonID
                            select l;

                foreach (var locationName in query)
                {
                    location = locationName;
                }
                return location;
            }

        }




        public Person GetPersonManager(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                Person manager = new Person();

                var query = from p in context.People
                            where person.Manager == p.PersonID
                            select p;

                foreach (var item in query)
                {
                    manager = item;
                }
                return manager;
            }
        }


        public List<Person> GetManagers()
        {
            using (var context = new ProgDatabaseEntities())
            {
                List<Person> managers = new List<Person>();
                var query = from p in context.People
                            select p;

             /*   var locmanagers = context.Locations.Single().People1;
                var locmgrs = (from l in context.Locations
                              select l.People1).ToList();
                              */
               // IEnumerable<Person> lista = query.Except(locmgrs);

                foreach (var person in query)
                {
                    managers.Add(person);
                }
                return managers;
            }
        }


        public IEnumerable<Person> GetPeopleWithoutLocManagers()
        {
            using(var context = new ProgDatabaseEntities())
            {
                List<Person> locationManagers = new List<Person>();
                var locations = context.Locations;
                foreach (var location in locations)
                {
                    var locManagers = context.Locations.Where(l => l.LocationID == location.LocationID).Single().People1;
                    foreach (var locManager in locManagers)
                    {
                        locationManagers.Add(locManager);
                    }
                }
                var people = (context.People).ToList();

                return people.Except(locationManagers).ToList();
            }
        }

        public IEnumerable<Person> GetPeopleWithoutManagers()
        {
            using(var context = new ProgDatabaseEntities())
            {
                List<Person> managerList = new List<Person>();
                var managers = (from Person in context.People
                               select new
                               {
                                   Person.Manager
                               }).Distinct();


                foreach (var item in managers)
                {
                    var managerItem = context.People.Where(p => p.PersonID == item.Manager);
                    foreach (var man in managerItem)
                    {
                        managerList.Add(man);
                    }
                }
                
                var people = (context.People).ToList();
                return people.Except(managerList).ToList();
            }
        }

        public void UpdatePerson(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var query = from p in context.People
                            where p.PersonID == person.PersonID
                            select p;

                foreach (var item in query)
                {
                    item.FirstName = person.FirstName;
                    item.LastName = person.LastName;
                    item.Username = person.Username;
                    item.Password = person.Password;
                    item.Email = person.Email;
                    item.Position = person.Position;
                    item.LocationID = person.LocationID;
                    item.Manager = person.Manager;
                }
                context.SaveChanges();
            }
        }



        public void AddNewPerson(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }


        public void RemoveEditedPerson(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                try
                {
                    context.Entry(person).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        public List<Person> GetPeople()
        {
            using (var context = new ProgDatabaseEntities())
            {
                var list = context.People;
                return list.ToList();
            }
        }
        #endregion

        #region LOCATION TAB /////////////////////////////////////////////////////////////////////////////////
        public List<Location> GetLocations()
        {
            using (var context = new ProgDatabaseEntities())
            {
                //var list = context.Locations.Include(p => p.People1).Include(p1=>p1.People1);
                var list = context.Locations;
                return list.ToList();
            }
        }
        //public IEnumerable<Person> GetLocationManager(Location location)
        public Person GetLocationManager(Location location)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var manager = context.Locations.Where(l => l.LocationID == location.LocationID).Single().People1;

                var managerPerson = new Person();
                foreach (var item in manager)
                {
                    managerPerson = item;
                }
                return managerPerson;
            }
        }

        public IEnumerable<Person> GetLocationPeople(Location location)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var people = context.Locations.Where(l => l.LocationID == location.LocationID).Single().People;
                return people;
            }
        }

        public void UpdateLocation(Location location, Person manager)
        {
            using (var context = new ProgDatabaseEntities())
            {
                Person oldLocManager = new Person();

                var loc = from l in context.Locations
                          where l.LocationID == location.LocationID
                          select l;

                var newManager = from m in context.People
                                 where m.PersonID == manager.PersonID
                                 select m;

                var _manager = context.Locations.Where(l => l.LocationID == location.LocationID).Single().People1;

                foreach (var item in _manager.ToList())
                {
                    _manager.Remove(item);
                }
                foreach (var m in newManager)
                {
                    _manager.Add(m);
                }
                context.SaveChanges();

                //var ujManager = context.Locations.Where(l => l.LocationID == location.LocationID).Single().People1;
            }
        }

        #endregion

        #region REQUEST TAB //////////////////////////////////////////////////////////////////////////

        public List<Role> GetRoles()
        {
            using (var context = new ProgDatabaseEntities())
            {
                var list = context.Roles;
                return list.ToList();
            }
        }

        public List<RequestType> GetRequestTypes()
        {
            using (var context = new ProgDatabaseEntities())
            {
                var list = context.RequestTypes;
                return list.ToList();
            }
        }

        public IEnumerable<Request> GetRequests()
        {
            using (var context = new ProgDatabaseEntities())
            {
                var list = context.Requests.Include(p => p.Person).Include(r => r.Role).Include(rt => rt.RequestType);
                return list.ToList();
            }
        }



        public void AddNewRequest(Request request)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var _person = context.People.Where(p => p.PersonID == request.Person.PersonID).Single();
                var _role = context.Roles.Where(r => r.RoleID == request.Role.RoleID).Single();
                var _requestType = context.RequestTypes.Where(rt => rt.RequestTypeID == request.RequestType.RequestTypeID).Single();
                var _decisionLevel = context.DecisionLevels.Where(d => d.DecisionLevel1 == 1);

                request.Person = _person;
                request.Role = _role;
                request.RequestType = _requestType;

                var allRequest = context.Requests;
                foreach (var req in allRequest)
                {
                    if (req.PersonID == _person.PersonID && req.RoleID == _role.RoleID)
                    {
                        Console.WriteLine("van már ilyen!");
                    }
                }

                foreach (var dLevel in _decisionLevel)
                {
                    request.DecisionLevel = dLevel;
                }

                context.Requests.Add(request);
                context.SaveChanges();
            }
        }

        public void AddNewDecision(Person person, Request request)
        {
            using (var context = new ProgDatabaseEntities())
            {
                Decision newDecision = new Decision();
                //var actions = context.Actions.Where(a => a.DisplayName.Contains("Pending"));                
                //var decesionLevels = context.DecisionLevels.Where(d => d.DecisionLevel1 == 1);

                var _person = context.People.Where(p => p.PersonID == person.PersonID).Single();
                var _request = context.Requests.Where(r => r.RequestID == request.RequestID).Single();

                newDecision.Request = _request;
                newDecision.Person = _person;
                newDecision.ChangeDate = DateTime.Now;
                newDecision.Reason = "Request created by " + person;
                context.Decisions.Add(newDecision);
                context.SaveChanges();
            }
        }

        public IEnumerable<DB.Action> GetActions()
        {
            using (var context = new ProgDatabaseEntities()) {
                var actions = context.Actions;
                return actions.ToList();
            }
        }

        public void DeleteSelectedRequest(Request request)
        {
            using (var context = new ProgDatabaseEntities())
            {
                try
                {
                    Console.WriteLine("delete: " + request.Person + " " + request.RequestType);
                    context.Entry(request).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void RaiseDecisionLevelToLocationManager(Request request, Action action, Person approver, string reason)
        {
            using (var context = new ProgDatabaseEntities())
            {

                Decision _newDecision = new Decision();
                _newDecision.Action1 = context.Actions.Where(a => a.ActionID == action.ActionID).Single();
                _newDecision.Request = context.Requests.Where(r => r.RequestID == request.RequestID).Single();
                _newDecision.Person1 = context.People.Where(p => p.PersonID == approver.PersonID).Single();
                _newDecision.ChangeDate = DateTime.Now;
                _newDecision.Reason = reason;
                context.Decisions.Add(_newDecision);

                DecisionLevel _newDecisionLevel = new DecisionLevel();
                _newDecisionLevel = context.DecisionLevels.Where(d => d.DecisionLevel1 == 2).Single();

                Request _request = new Request();
                _request = context.Requests.Where(r => r.RequestID == request.RequestID).Single();
                _request.DecisionLevel = _newDecisionLevel;

                context.SaveChanges();

            }
        }

        public void RaiseDecisionLevelToApproved(Request request, Action action, Person approver, string reason)
        {
            using (var context = new ProgDatabaseEntities())
            {

                Decision _newDecision = new Decision();
                _newDecision.Action1 = context.Actions.Where(a => a.ActionID == action.ActionID).Single();
                _newDecision.Request = context.Requests.Where(r => r.RequestID == request.RequestID).Single();
                _newDecision.Person1 = context.People.Where(p => p.PersonID == approver.PersonID).Single();
                _newDecision.ChangeDate = DateTime.Now;
                _newDecision.Reason = reason;
                context.Decisions.Add(_newDecision);

                DecisionLevel _newDecisionLevel = new DecisionLevel();
                _newDecisionLevel = context.DecisionLevels.Where(d => d.DecisionLevel1 == 3).Single();

                Request _request = new Request();
                _request = context.Requests.Where(r => r.RequestID == request.RequestID).Single();
                _request.DecisionLevel = _newDecisionLevel;

                context.SaveChanges();

            }
        }


        #endregion

        #region LOGIN TAB /////////////////////////////////////////////////////////////////////////////

        public bool IsManager(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var managers = from p in context.People
                               select p.Manager;

                foreach (var item in managers)
                {
                    if (person.PersonID == item)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool IsLocationManager(Person person)
        {
            using(var context = new ProgDatabaseEntities())
            {
                List<Person> locationManagers = new List<Person>();
                var locations = context.Locations;
                foreach (var location in locations)
                {
                    var locManagers = context.Locations.Where(l => l.LocationID == location.LocationID).Single().People1;
                    foreach (var locManager in locManagers)
                    {
                        locationManagers.Add(locManager);
                    }
                }

                foreach (var _person in locationManagers)
                {
                    if (person.PersonID==_person.PersonID)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public IEnumerable<Request> GetPersonRequests(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var list = context.Requests.Where(p=>p.PersonID==person.PersonID).Include(p => p.Person).Include(r => r.Role).Include(rt => rt.RequestType).Include(dl => dl.DecisionLevel);
                return list.ToList();
            }
        }

        public IEnumerable<Request> GetApprovableRequestManager(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var managedPeopleList = context.People.Where(p => p.Manager == person.PersonID);
                List<Request> requestList = new List<Request>();                

                foreach (var managedPerson in managedPeopleList)
                {
                    var personRequestList = context.Requests.Where(p => p.PersonID == managedPerson.PersonID && p.CurrentDecisionLevel==1).Include(p => p.Person).Include(r => r.Role).Include(rt => rt.RequestType);
                   
                    foreach (var item in personRequestList)
                    {
                        requestList.Add(item);
                    }
                }

                return requestList;
            }
        }

        public IEnumerable<Request> GetApprovableRequestLocationManager(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var managedPeople = context.Locations.Where(l => l.LocationID == person.LocationID).Single().People;

                List<Person> managedPeopleList = new List<Person>();
                foreach (var _person in managedPeople)
                {
                    managedPeopleList.Add(_person);
                }
                List<Request> requestList = new List<Request>();

                foreach (var managedPerson in managedPeopleList)
                {
                    var personRequestList = context.Requests.Where(p => p.PersonID == managedPerson.PersonID && p.CurrentDecisionLevel == 3).Include(p => p.Person).Include(r => r.Role).Include(rt => rt.RequestType);

                    foreach (var item in personRequestList)
                    {
                        requestList.Add(item);
                    }
                }
                return requestList;
            }
        }


        public IEnumerable<Person> GetPeopleOfManager(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var list = context.People.Where(p => p.Manager == person.PersonID);                
                return list.ToList();
            }
        }

    

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DataQuery() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

       
    }
}
