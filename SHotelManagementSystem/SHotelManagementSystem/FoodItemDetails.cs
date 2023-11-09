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
    public partial class FoodItemDetails : Form
    {
        private DataAccess Da
        {
            get; set;
        }
        public FoodItemDetails()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private void PopulateGridView(string sql = "select * from FoodItemList;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvFoodItemDetails.AutoGenerateColumns = false;
            this.dgvFoodItemDetails.DataSource = ds.Tables[0];
        }

        private void btnShowFoodItemList_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            new ManagerCategory().Show();
            this.Hide();

        }

        private void FoodItemDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
