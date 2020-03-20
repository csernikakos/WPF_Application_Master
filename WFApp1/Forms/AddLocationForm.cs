using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp1.Forms
{
    public partial class AddLocationForm : Form
    {
        ProgDatabaseEntities context = new ProgDatabaseEntities();
        Form1 form = new Form1();
        public AddLocationForm()
        {
            InitializeComponent();

            var locManagerQuery = (from p in context.People
                                  select new { Name = p.FirstName + " " + p.LastName,
                                               PersonID = p.PersonID}).ToList();

            cmbLocationManager.DataSource = locManagerQuery;
            cmbLocationManager.DisplayMember = "Name";
            cmbLocationManager.ValueMember = "PersonID";
             
        }


        private void btnSaveNewLocation_Click(object sender, EventArgs e)
        {
            try
            {
                Location location = new Location
                {
                    LocationName = txtNewLocName.Text
                };
                context.Locations.Add(location);

                LocationAdmin locAdmin = new LocationAdmin
                {
                    LocationID = location.LocationID,
                    PersonID = Convert.ToInt32(cmbLocationManager.SelectedValue)
                };
                context.LocationAdmins.Add(locAdmin);
                context.SaveChanges();
                //form.FillDataGrid();
                form.RefreshDataGrid();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
        }

        private void btnCancelNewLocation_Click(object sender, EventArgs e)
        {
            form.FillDataGrid();
            form.RefreshDataGrid();
            Close();
        }
    }
}
