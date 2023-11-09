using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHotelManagementSystem
{
    public partial class Login : Form
    {
        private DataAccess Da { get; set; }
        public Login()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        
       private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Stop App");
            Application.Exit();
        }

        private void btnSignIn_Click_1(object sender, EventArgs e)
        {
            try
            {
                string Qury = "select* from UserInfo where Id ='" + this.txtUserId.Text + "' and Password='" + this.txtPassword.Text + "';";

                var ds = this.Da.ExecuteQuery(Qury);


                if (ds.Tables[0].Rows.Count == 1)
                {
                    MessageBox.Show("Valid User");
                    if (ds.Tables[0].Rows[0][2].ToString() == "admin")
                        new ManagerCategory().Show();
                    else if (ds.Tables[0].Rows[0][2].ToString() == "member")
                        new EmployeeCategory().Show();

                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Invalid Info");
                    return;
                }


            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please try again.\n" + exc.Message);
            }

        }

        
    }

    }

