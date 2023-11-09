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
    public partial class EmployeeCategory : Form
    {
        public EmployeeCategory()
        {
            InitializeComponent();
        }

        private void btnOrderForm_Click(object sender, EventArgs e)
        {
            new Order().Show();
            this.Visible = false;
        }

        private void btnVolunteerForm_Click(object sender, EventArgs e)
        {
            new Volunteer().Show();
            this.Visible = false;
        }

        private void btnHelplessPeopleForm_Click(object sender, EventArgs e)
        {
            new PoorPeople().Show();
            this.Visible = false;
        }

        private void btnFoodItemForm_Click(object sender, EventArgs e)
        {
            new FoodItem().Show();
            this.Visible = false;
        }

        private void btnMemberCategoryLogout_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();

        }

        private void MemberCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
           
            ChangePassword res = new ChangePassword();
            res.Show();
            this.Hide();
        }
    }
}
