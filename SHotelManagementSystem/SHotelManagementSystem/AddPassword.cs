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
    public partial class AddPassword : Form
    {
        private DataAccess Da { get; set; }
        public AddPassword()
        {
            InitializeComponent();

        }
            public AddPassword(string addpass)
        {
            InitializeComponent();

            this.Da = new DataAccess();

            if (addpass != null && txtId.Text != null)
            {
                txtId.Text = addpass;
            }

        }
        private bool IsDataValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtId.Text) || String.IsNullOrEmpty(this.txtPassword.Text))

            {
                return false;

            }
            else
                return true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDataValidToSave())
                {
                    MessageBox.Show("Please Fill all the Data.");
                    return;
                }
                else
                {

                    string sql = @"insert into UserInfo values('" + this.txtId.Text + "', '" + this.txtPassword.Text + "',  'Member');";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                    {
                        MessageBox.Show("Password setting successful");

                        
                    }
                    else
                    {
                        MessageBox.Show("Password setting failed");
                    }

                }

            }

            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please try again.\n" + exc.Message);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            new Employee().Show();
            this.Visible = false;

        }

        private void AddPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
