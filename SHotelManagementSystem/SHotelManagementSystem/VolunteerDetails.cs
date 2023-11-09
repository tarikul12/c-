using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHotelManagementSystem
{
    public partial class VolunteerDetails : Form
    {
        private DataAccess Da
        {
            get; set;
        }
        public VolunteerDetails()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private void PopulateGridView(string sql = "select * from VolunteerTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvVolunteerDetails.AutoGenerateColumns = false;
            this.dgvVolunteerDetails.DataSource = ds.Tables[0];
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            new ManagerCategory().Show();
            this.Hide();

        }

        private void VolunteerDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
