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
    public partial class Order : Form
    {
        private DataAccess Da { get; set; }
        public Order()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.GenerateID();
            this.PopulateGridView();
        }
        private void PopulateGridView(string sql = "select * from OrderTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvOrderView.AutoGenerateColumns = false;
            this.dgvOrderView.DataSource = ds.Tables[0];
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

        private void Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private bool IsDataValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtOrderID.Text) || String.IsNullOrEmpty(this.txtOrderName.Text))

                return false;
            else
                return true;
        }
        private void ClearAll()
        {
            this.txtOrderID.Clear();
            this.txtOrderName.Clear();

            this.dgvOrderView.ClearSelection();
            this.dgvOrderView.DataSource = null;

            this.GenerateID();
            this.PopulateGridView();
        }

        private void dgvOrderView_DoubleClick(object sender, EventArgs e)
        {
            this.txtOrderID.Text = this.dgvOrderView.CurrentRow.Cells[0].Value.ToString();
            this.txtOrderName.Text = this.dgvOrderView.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnOderUpdate_Click(object sender, EventArgs e)
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
                    var id = this.dgvOrderView.CurrentRow.Cells[0].Value.ToString();
                    var name = this.dgvOrderView.CurrentRow.Cells[1].Value.ToString();

                    var query = "select * from OrderTable where Id = '" + id + "';";


                    var dst = this.Da.ExecuteQuery(query);


                    if (dst.Tables[0].Rows.Count == 1)
                    {

                        var kt = @"update OrderTable
                                
                                set Name = '" + this.txtOrderName.Text + @"',
                                Id = '" + this.txtOrderID.Text + @"'
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string search = "select * from OrderTable where Name = '" + this.txtSearch.Text + "';";
                this.PopulateGridView(search);
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please try again.\n" + exc.Message);
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
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

                    var sql = @"insert into OrderTable values('" + this.txtOrderID.Text + "', '" + this.txtOrderName.Text + "');";
                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                    {
                        MessageBox.Show("Item insertion successful");

                    }

                    else
                        MessageBox.Show("Item insertion failed");


                }
                this.PopulateGridView();
                this.ClearAll();
            }

            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please try again.\n" + exc.Message);
            }
        }

        private void btnOrderRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvOrderView.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please select a row first to delete.");
                    return;
                }

                var id = this.dgvOrderView.CurrentRow.Cells[0].Value.ToString();
                var name = this.dgvOrderView.CurrentRow.Cells[1].Value.ToString();

                var sql = "delete from OrderTable where Id = '" + id + "';";

                int count = this.Da.ExecuteDMLQuery(sql);



                if (count == 1)
                {
                    MessageBox.Show(name.ToUpper() + " Order has been removed properly");
                }
                else

                {
                    MessageBox.Show("Order remove failed");
                }



                this.PopulateGridView();
                this.ClearAll();
                string newid = this.txtOrderID.Text.ToString();
                if (String.Compare(id, newid) == 0)
                {
                    var q = "select Id from OrderTable order by Id desc;";
                    var dt = this.Da.ExecuteQueryTable(q);
                    var lastId = dt.Rows[0][0].ToString();
                    string[] s = lastId.Split('-');
                    int temp = Convert.ToInt32(s[1]);
                    string newId = "o-" + (temp = temp + 2).ToString("d3");
                    this.txtOrderID.Text = newId;

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
                var q = "select Id from OrderTable order by Id desc;";
                var dt = this.Da.ExecuteQueryTable(q);
                var lastId = dt.Rows[0][0].ToString();
                string[] s = lastId.Split('-');
                int temp = Convert.ToInt32(s[1]);
                string newId = "o-" + (temp = temp + 1).ToString("d3");
                this.txtOrderID.Text = newId;


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
    }
}
