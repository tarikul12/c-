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
    public partial class PoorPeopleDetails : Form
    {
        private DataAccess Da
        {
            get; set;
        }
        public PoorPeopleDetails()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private void PopulateGridView(string sql = "select * from HelplessPeopleTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvHelplessPeople.AutoGenerateColumns = false;
            this.dgvHelplessPeople.DataSource = ds.Tables[0];
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            new ManagerCategory().Show();
            this.Hide();
        }

        private void HelplessPeopleDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
