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

namespace WFApp1.Forms
{
    public partial class AddPersonForm : Form
    {

        ProgDatabaseEntities context = new ProgDatabaseEntities();
        public AddPersonForm()
        {
            InitializeComponent();

            var locationQuery = (from l in context.Locations
                        select new { l.LocationID, l.LocationName }).ToList();
            cmbLocation.DataSource = locationQuery;
            cmbLocation.ValueMember = "LocationID";
            cmbLocation.DisplayMember = "LocationName";

            var managerQuery = ( from p in context.People
                                 select new { Name = p.FirstName +" "+p.LastName,p.PersonID}).ToList();
            cmbManager.DataSource = managerQuery;
            cmbManager.ValueMember = "PersonID";
            cmbManager.DisplayMember = "Name";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.PersonFillListbox();

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {                  
            try
            {
                Person newPerson = new Person
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    Manager = Convert.ToInt32(cmbManager.SelectedValue),
                    Position = txtPosition.Text,
                    LocationID = Convert.ToInt32(cmbLocation.SelectedValue.ToString())
                };

                context.People.Add(newPerson);
                context.SaveChanges();
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException );
                MessageBox.Show(ex.Source + ex.HelpLink + ex.HResult + ex.StackTrace +ex.TargetSite);
            }
        }
    }
}
