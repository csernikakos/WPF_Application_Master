using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFApp1.Forms;

namespace WFApp1
{
    public partial class Form1 : Form
    {
        ProgDatabaseEntities context = new ProgDatabaseEntities();
        public Form1()
        {
            InitializeComponent();
            FillDataGrid();
            RequestFillListbox();
           // var e = new DB.DB();
           
        }

        //GET ----------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            PersonFillListbox();
        }


        //UPDATE ----------------------------------------------------------------

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = listBox1.SelectedItem.ToString();
                var people = from p in context.People
                             where selected.Contains(p.LastName)
                             select p;

                foreach (var item in people)
                {
                    item.LastName = txtLastName.Text;
                    item.FirstName = txtFirstName.Text;
                    item.Username = txtUsername.Text;
                    item.Email = txtEmail.Text;
                    item.Position = txtPosition.Text;
                    item.LocationID = Convert.ToInt32(txtLocationID.Text); 
                }
                context.SaveChanges();

                ClearTextBoxes();
                PersonFillListbox();             

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ADD NEW PERSON ----------------------------------------------------------------

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddPersonForm addPerson = new AddPersonForm();
            addPerson.ShowDialog();
        }


        // DELETE SELECTED PERSON ----------------------------------------------------------------

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var query = (from p in context.People
                         where listBox1.SelectedItem.ToString().Contains(p.LastName)
                         select p).ToList();



            foreach (var person in query)
            {
                Console.WriteLine(person.LastName + " " + person.FirstName);
                context.People.Remove(person);
                context.SaveChanges();
                PersonFillListbox();
                ClearTextBoxes();
            }
        }

        // FILL TEXTBOXES ON PERSON TAB ----------------------------------------------------------------

        public void FillPersonTextBoxes(Person person)
        {
            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtUsername.Text = person.Username;
            txtEmail.Text = person.Email;
            txtPosition.Text = person.Position;
            txtLocationID.Text = person.LocationID.ToString();
            txtPassword.Text = person.Password;
            txtLocation.Text = person.Location.LocationName;

            var query = from p in context.People
                        where person.Manager == p.PersonID
                        select new { Name = p.FirstName + " " + p.LastName };

            foreach (var item in query)
            {
                txtManager.Text = item.Name;
            }          

        }

        // CLEAR TEXTBOXES ON PESON TAB ----------------------------------------------------------------

        public void ClearTextBoxes()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPosition.Text = "";
            txtLocationID.Text = "";
            txtLocation.Text = "";
            txtPassword.Text = "";
            txtManager.Text = "";
        }

        // FILL LISTBOX ON PERSON TAB ----------------------------------------------------------------

        public void PersonFillListbox()
        {
            Console.WriteLine("test");
            listBox1.Items.Clear();
            var query = from p in context.People
                        select p;

            foreach (var person in query)
            {
                listBox1.Items.Add(person);
                //var loc = person.Location;
                Console.WriteLine(person.LastName);
            }
        }

        // SELECTED ITEM CHANGE ON PERSON TAB ----------------------------------------------------------------

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selected = listBox1.SelectedItem.ToString();
                var query = from p in context.People
                            join l in context.Locations
                            on p.LocationID equals l.LocationID
                            where selected.Contains(p.LastName)
                            orderby p.FirstName
                            select p;

                foreach (var person in query)
                {
                    FillPersonTextBoxes(person);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // LOCATION TAB ===================================================================================================
        // LOCATION ADMINS TABLE ----------------------------------------------------------------

        void FillDataGrid()
        {
            var dataGridQuery = (from la in context.LocationAdmins
                                 join l in context.Locations on la.LocationID equals l.LocationID
                                 join pe in context.People on la.PersonID equals pe.PersonID                                
                                 select new { Location = l.LocationName,
                                     Name = pe.FirstName + " " + pe.LastName}).ToList();

            dgvLocationAdmin.DataSource = dataGridQuery;
        }

        // REQUEST TAB ===================================================================================================
        // ----------------------------------------------------------------

        public void RequestFillListbox()
        {
            lstActiveRequests.Items.Clear();
            var requestQuery = from request in context.Requests
                               join person in context.People
                               on request.PersonID equals person.PersonID
                               join role in context.Roles
                               on request.RoleID equals role.RoleID
                               /*join requestType in context.RequestTypes
                               on request.RequestTypeID equals requestType.RequestTypeID*/

                               select new { PersonID = person.PersonID,
                                       /*     RoleID = role.RoleID,
                                            RequestTypeID = requestType.RequestTypeID,
                                            Name = person.FirstName+" "+person.LastName,
                                            Role = role.RoleName,
                                            ValidityStart = request.ValidityStart,
                                            ValidtiyEnd = request.ValidityEnd,
                                            RequestType = requestType.Description,
                                            DecisioNLevel = request.CurrentDecisionLevel,*/
                                            Display= person.FirstName + " " + person.LastName + "\t"+ role.RoleName
                               };
            
            lstActiveRequests.DataSource = requestQuery.ToList();
            lstActiveRequests.DisplayMember="Display";
            lstActiveRequests.ValueMember = "PersonID";
            lstActiveRequests.SelectedIndex = 0;
        }

        public void RequestFillTextbox(Request request)
        {
            var nameQuery = from p in context.People
                            where request.PersonID == p.PersonID
                            select new { PersonName = p.FirstName+" "+p.LastName};

            var roleQuery = from r in context.Roles
                            where request.RoleID == r.RoleID
                            select r.RoleName;

            foreach (var person in nameQuery)
            {
                txtPersonName.Text = person.PersonName;
            }
            foreach (var role in roleQuery)
            {
                txtRole.Text = role;
            }
            
            txtValidityStart.Text = request.ValidityStart.ToString();
            txtValidityEnd.Text = request.ValidityEnd.ToString();
            

        }

        private void lstActiveRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ///////////////////////////////////////////////////////////////////////////////
                
                    var requestQuery = from request in context.Requests
                                       join person in context.People
                                       on request.PersonID equals person.PersonID
                                       join role in context.Roles
                                       on request.RoleID equals role.RoleID
                                       join requestType in context.RequestTypes
                                       on request.RequestTypeID equals requestType.RequestTypeID
                                       where lstActiveRequests.SelectedValue.ToString().Equals((person.PersonID).ToString())
                                       
                                       select request;

                    Console.WriteLine("index: "+lstActiveRequests.SelectedIndex);

                    foreach (var request in requestQuery)
                    {
                        RequestFillTextbox(request);
                    }
                

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }


    }
}
