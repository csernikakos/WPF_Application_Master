﻿using DB;
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

                foreach (var person in query)
                {
                    managers.Add(person);
                }
                return managers;
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
               // var _decisionLevel = context.DecisionLevels.Where()

                request.Person = _person;
                request.Role = _role;
                request.RequestType = _requestType;
               // request.Decisions = 

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
                var decesionLevels = context.DecisionLevels.Where(d => d.DecisionLevel1 == 1);

                var _person = context.People.Where(p => p.PersonID == person.PersonID).Single();
                var _request = context.Requests.Where(r => r.RequestID == request.RequestID).Single();

                newDecision.Request = _request;
                newDecision.Person = _person;
                newDecision.ChangeDate = DateTime.Now;
                /* foreach (var item in actions)
                 {
                     newDecision.Action1 = item;
                 }   */
                foreach (var item in decesionLevels)
                {
                    newDecision.DecisionLevel = item;
                }
                newDecision.Reason = "Request created by " + person;
                /*Console.WriteLine("*********************************************");
                Console.WriteLine(newDecision.Action.DisplayName + " action");
                Console.WriteLine(newDecision.DecisionLevel.DecisionLevel1 + " DecisionLevel");
                Console.WriteLine(newDecision.Request.RequestType + " request");
                Console.WriteLine(newDecision.Person + " person");
                Console.WriteLine(newDecision.ChangeDate + " date");
                Console.WriteLine(newDecision.Reason + " reason");
                Console.WriteLine("*********************************************");
                Console.WriteLine(newDecision);*/
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
        /*
        public Decision GetDecision(Request request)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var decision = context.Decisions.Where(d=>d.RequestID==request.RequestID).Single();
                return decision;
            }
        }
        */
        public void RaiseDecisionLevel(Request request, Action action, Person approver, string reason)
        {
            using (var context = new ProgDatabaseEntities())
            {
                Decision _newDecision = new Decision();
                _newDecision.Action1 = context.Actions.Where(a=>a.ActionID==action.ActionID).Single();
                _newDecision.Request = context.Requests.Where(r => r.RequestID == request.RequestID).Single();
                _newDecision.Person1 = context.People.Where(p => p.PersonID == approver.PersonID).Single();
                _newDecision.ChangeDate = DateTime.Now;
                _newDecision.Reason = reason;

                var decesionLevels = context.DecisionLevels.Where(d => d.DecisionLevel1 == 2);
                foreach (var item in decesionLevels)
                {
                    _newDecision.DecisionLevel = item;
                }

                context.Decisions.Add(_newDecision);
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

        public IEnumerable<Request> GetPersonRequests(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var list = context.Requests.Where(p=>p.PersonID==person.PersonID).Include(p => p.Person).Include(r => r.Role).Include(rt => rt.RequestType);
                return list.ToList();
            }
        }

        public IEnumerable<Request> GetApprovableRequest(Person person)
        {
            using (var context = new ProgDatabaseEntities())
            {
                var managedPeopleList = context.People.Where(p => p.Manager == person.PersonID);
                List<Request> requestList = new List<Request>();

                bool isHigherLevel = false;
                int HighestDecisionLevel = 0;


                foreach (var managedPerson in managedPeopleList)
                {
                    var personRequestList = context.Requests.Where(p => p.PersonID == managedPerson.PersonID).Include(p => p.Person).Include(r => r.Role).Include(rt => rt.RequestType);
                    //var personRequetsList = context.Requests.Where(p => p.PersonID == managedPerson.PersonID).Include(p => p.Person).Include(r => r.Role).Include(rt => rt.RequestType).Join(context.Decisions.Where(d => d.DecisionID == 1));

                    foreach (var item in personRequestList)
                    {
                        var decisionList = context.Decisions.Where(d => d.RequestID == item.RequestID);
                        foreach (var decision in decisionList)
                        {
                            if (decision.DecisionLevelID > HighestDecisionLevel)
                            {
                                HighestDecisionLevel = decision.DecisionLevelID;
                                Console.WriteLine(HighestDecisionLevel);
                                /*  if (decision.DecisionLevelID == 1)
                                  {
                                      requestList.Add(item);
                                  }*/
                            }
                        }
                        if (HighestDecisionLevel==1)
                        {
                            requestList.Add(item);
                        }
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
