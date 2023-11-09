using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SHotelManagementSystem
{
    public partial class Employee : Form
    {
        private DataAccess Da { get; set; }
        public Employee()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.PopulateGridView();
            this.AutoIdGenerate();
        }
        private void PopulateGridView(string sql = "select * from MemberTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvMember.AutoGenerateColumns = false;
            this.dgvMember.DataSource = ds.Tables[0];
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select * from MemberTable where Id = '" + this.txtSearch.Text + "';";
            this.PopulateGridView(sql);
        }

        private void txtAutonomousSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from MemberTable where Name like '" + this.txtAutonomousSearch.Text + "%';";
            this.PopulateGridView(sql);
        }
        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtId.Text) || String.IsNullOrEmpty(this.txtName.Text) ||
                String.IsNullOrEmpty(this.txtSalary.Text) || String.IsNullOrEmpty(this.txtBonus.Text) ||
                String.IsNullOrEmpty(this.txtWorkHour.Text)|| String.IsNullOrEmpty(this.txtAddress.Text))
                return false;
            else
                return true;
        }
        private void ClearContent()
        {
            this.txtId.Clear();
            this.txtName.Clear();
            this.txtSalary.Clear();
            this.txtBonus.Clear();
            this.txtWorkHour.Clear();
            this.txtAddress.Clear();
            this.txtSearch.Clear();
            this.txtAutonomousSearch.Clear();

            this.dgvMember.ClearSelection();
            this.AutoIdGenerate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill up all the values");
                    return;
                }

                var query = "select * from MemberTable where Id = '" + this.txtId.Text + "'";
                var dt = this.Da.ExecuteQueryTable(query);

                if (dt.Rows.Count == 1)
                {
                    //update operation
                    var sql = "update MemberTable set Name = '"+this.txtName.Text+"',Salary = "+this.txtSalary.Text+",Bonus = "+this.txtBonus.Text+",WorkHour = "+this.txtWorkHour.Text+",Address = '"+this.txtAddress.Text+"' where Id = '"+this.txtId.Text+"';";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("Data updated Properly");
                    else
                        MessageBox.Show("Data upgradation failed");
                }
                else if (dt.Rows.Count == 0)
                {
                    //insert operation
                    var sql = "insert into MemberTable values('" + this.txtId.Text + "', '" + this.txtName.Text + "', " + this.txtSalary.Text + ", " + this.txtBonus.Text + ", " + this.txtWorkHour.Text + ", '" + this.txtAddress.Text + "'); ";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                    { 
                        MessageBox.Show("Data Added Properly");
                        this.PopulateGridView();
                        
                        string passwordTracker = txtId.Text;
                        AddPassword add = new AddPassword(passwordTracker);
                        add.Show();
                        this.ClearContent();
                        this.Hide();

                    }
                        
                    else
                    {
                        MessageBox.Show("Data insertion failure");
                        this.PopulateGridView();
                        this.ClearContent();
                    }
                        
                }

                this.PopulateGridView();
                this.ClearContent();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
        }

        private void dgvMember_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = this.dgvMember.CurrentRow.Cells[0].Value.ToString();
            this.txtName.Text = this.dgvMember.CurrentRow.Cells[1].Value.ToString();
            this.txtSalary.Text = this.dgvMember.CurrentRow.Cells[2].Value.ToString();
            this.txtBonus.Text = this.dgvMember.CurrentRow.Cells[3].Value.ToString();
            this.txtWorkHour.Text = this.dgvMember.CurrentRow.Cells[4].Value.ToString();
            this.txtAddress.Text = this.dgvMember.CurrentRow.Cells[5].Value.ToString();
        }
        private void AutoIdGenerate()
        {
            var q = "select Id from MemberTable order by Id desc;";
            var dt = this.Da.ExecuteQueryTable(q);
            var lastId = dt.Rows[0][0].ToString();
            string[] s = lastId.Split('-');
            int temp = Convert.ToInt32(s[1]);
            string newId = "m-" + (++temp).ToString("d3");
            this.txtId.Text = newId;
            //MessageBox.Show(newId);
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            this.dgvMember.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvMember.SelectedRows.Count < 1)
            {
                MessageBox.Show("Plaese select a Row first to Delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var id = this.dgvMember.CurrentRow.Cells[0].Value.ToString();
                var Name = this.dgvMember.CurrentRow.Cells["Name"].Value.ToString();

                DialogResult dr = MessageBox.Show("Are you sure you want to delete", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    //MessageBox.Show("No delete");
                    return;
                }

                var query = "delete from MemberTable where Id = '" + id + "';";
                var count = this.Da.ExecuteDMLQuery(query);
                var sql= "delete from UserInfo where Id = '" + id + "';";
                var count1 = this.Da.ExecuteDMLQuery(sql);

                if (count == 1 && count1==1)
                    MessageBox.Show(Name.ToUpper() + " has been removed from the list.");
                else
                    MessageBox.Show("Data remove failed");

                this.PopulateGridView();
                this.ClearContent();
                string newid = this.txtId.Text.ToString();
                if(String.Compare(id, newid) == 0)
                {
                    var q = "select Id from MemberTable order by Id desc;";
                    var dt = this.Da.ExecuteQueryTable(q);
                    var lastId = dt.Rows[0][0].ToString();
                    string[] s = lastId.Split('-');
                    int temp = Convert.ToInt32(s[1]);
                    string newId = "m-" + (temp=temp+2).ToString("d3");
                    this.txtId.Text = newId;

                }
                

                
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured: " + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            new ManagerCategory().Show();
            this.Visible = false;
        }

        private void Member_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

