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
    public partial class PoorPeople : Form
    {
        private DataAccess Da { get; set; }
        public PoorPeople()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.GenerateID();
            this.PopulateGridView();
        }
        private void PopulateGridView(string sql = "select * from HelplessPeopleTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvPoorPeopleView.AutoGenerateColumns = false;
            this.dgvPoorPeopleView.DataSource = ds.Tables[0];
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            EmployeeCategory cate = new EmployeeCategory();
            cate.Show();
            this.Hide();
        }

        private void PoorPeople_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private bool IsDataValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtId.Text) || String.IsNullOrEmpty(this.txtName.Text))

                return false;
            else
                return true;
        }
        private void ClearAll()
        {
            this.txtId.Clear();
            this.txtName.Clear();

            this.dgvPoorPeopleView.ClearSelection();
            this.dgvPoorPeopleView.DataSource = null;

            this.GenerateID();
            this.PopulateGridView();
        }

        private void dgvPoorPeopleView_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = this.dgvPoorPeopleView.CurrentRow.Cells[0].Value.ToString();
            this.txtName.Text = this.dgvPoorPeopleView.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                    var id = this.dgvPoorPeopleView.CurrentRow.Cells[0].Value.ToString();
                    var name = this.dgvPoorPeopleView.CurrentRow.Cells[1].Value.ToString();

                    var query = "select * from HelplessPeopleTable where Id= '" + id + "';";


                    var dst = this.Da.ExecuteQuery(query);


                    if (dst.Tables[0].Rows.Count == 1)
                    {

                        var kt = @"update HelplessPeopleTable
                                
                                set Name = '" + this.txtName.Text + @"',
                                Id = '" + this.txtId.Text + @"'
                                where Id = '" + id + "';";


                        int count = this.Da.ExecuteDMLQuery(kt);

                        if (count == 1)
                        {
                            MessageBox.Show("Data updated properly");


                        }

                        else
                            MessageBox.Show("Data upgradation failed");
                    }



                }

                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please try again.\n" + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = "select * from HelplessPeopleTable where Name = '" + this.txtSearch.Text + "';";
                this.PopulateGridView(search);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please try again.\n" + exc.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

                    var sql = @"insert into HelplessPeopleTable values('" + this.txtId.Text + "', '" + this.txtName.Text + "');";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                    {
                        MessageBox.Show(" Insertion successful");

                    }

                    else
                        MessageBox.Show(" Insertion failed");


                }
                this.PopulateGridView();
                this.ClearAll();
            }

            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please try again.\n" + exc.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPoorPeopleView.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please select a row first to delete.");
                    return;
                }

                var id = this.dgvPoorPeopleView.CurrentRow.Cells[0].Value.ToString();
                var name = this.dgvPoorPeopleView.CurrentRow.Cells[1].Value.ToString();

                var sql = "delete from HelplessPeopleTable where Id = '" + id + "';";

                int count = this.Da.ExecuteDMLQuery(sql);



                if (count == 1)
                {
                    MessageBox.Show(name.ToUpper() + "  has been removed properly");
                }
                else

                {
                    MessageBox.Show(" Remove failed");
                }



                this.PopulateGridView();
                this.ClearAll();
                string newid = this.txtId.Text.ToString();
                if (String.Compare(id, newid) == 0)
                {
                    var q = "select Id from HelplessPeopleTable order by Id desc;";
                    var dt = this.Da.ExecuteQueryTable(q);
                    var lastId = dt.Rows[0][0].ToString();
                    string[] s = lastId.Split('-');
                    int temp = Convert.ToInt32(s[1]);
                    string newId = "h-" + (temp = temp + 2).ToString("d3");
                    this.txtId.Text = newId;

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please try again.\n" + exc.Message);
            }
        }
        private void GenerateID()
        {
            try
            {
                var q = "select Id from HelplessPeopleTable order by Id desc;";
                var dt = this.Da.ExecuteQueryTable(q);
                var lastId = dt.Rows[0][0].ToString();
                string[] s = lastId.Split('-');
                int temp = Convert.ToInt32(s[1]);
                string newId = "h-" + (temp = temp + 1).ToString("d3");
                this.txtId.Text = newId;


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

        private void PoorPeople_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
