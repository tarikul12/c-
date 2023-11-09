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
    public partial class OrderDetails : Form
    {
        private DataAccess Da
        {
            get; set;
        }
        public OrderDetails()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private void PopulateGridView(string sql = "select * from OrderTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvOrderDetails.AutoGenerateColumns = false;
            this.dgvOrderDetails.DataSource = ds.Tables[0];
        }

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void OrderDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
