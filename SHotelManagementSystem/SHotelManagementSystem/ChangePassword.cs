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
    public partial class ChangePassword : Form
    {
        private DataAccess Da
        {
            get; set;
        }
        public ChangePassword()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private bool IsDataValidToSave()
        {
            string newPass = this.txtNewPassword.ToString();
            string reTypePass = this.txtRetypePassword.ToString();

            if (String.IsNullOrEmpty(this.txtId.Text) || String.IsNullOrEmpty(this.txtNewPassword.Text) || String.IsNullOrEmpty(this.txtRetypePassword.Text))
            {

                return false;

            }

            else if (String.Compare(newPass, reTypePass) == 0)
            { 
                
                return true;
            }
            else
                return false;
                
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDataValidToSave())
                {
                    MessageBox.Show(" All Data are not filled or second Password is not same first Password.");
                    return;
                }

                else
                {
                    var query = "select * from UserInfo where Id = '" + this.txtId.Text + "';";
                    var dst = this.Da.ExecuteQuery(query);

                    if (dst.Tables[0].Rows.Count == 1)
                    {




                        var kt = @"update userInfo
                                set Password = '" + this.txtNewPassword.Text + @"'    
                                where Id = '" + this.txtId.Text + "';";


                        int count = this.Da.ExecuteDMLQuery(kt);

                        if (count == 1)

                        {
                            //this.Close();
                            MessageBox.Show("Password updated properly");
                            
                        }
                        else
                            MessageBox.Show("Password upgradation failed! PLEASE TRY AGAIN");
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
            new EmployeeCategory().Show();
            this.Visible = false;

        }

        private void ChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
