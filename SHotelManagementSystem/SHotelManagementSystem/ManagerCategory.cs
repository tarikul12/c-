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
    public partial class ManagerCategory : Form
    {
        public ManagerCategory()
        {
            InitializeComponent();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            new Employee().Show();
            this.Visible = false;

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            new OrderDetails().Show();
            this.Hide();

        }

        private void btnVolunteer_Click(object sender, EventArgs e)
        {
            new VolunteerDetails().Show();
            this.Hide();

        }

        private void btnHelplessPeople_Click(object sender, EventArgs e)
        {
            new PoorPeopleDetails().Show();
            this.Hide();
        }

        private void btnFoodItem_Click(object sender, EventArgs e)
        {
            new FoodItemDetails().Show();
            this.Hide();

        }

        private void btnCategoryLogout_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();

        }

        private void Category_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
