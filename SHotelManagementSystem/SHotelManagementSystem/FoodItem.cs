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
    public partial class FoodItem : Form
    {
        private DataAccess Da { get; set; }
        public FoodItem()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.GenerateID();
            this.PopulateGridView();
        }
        private void PopulateGridView(string sql = "select * from FoodItemList;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvFoodItem.AutoGenerateColumns = false;
            this.dgvFoodItem.DataSource = ds.Tables[0];
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
        private bool IsDataValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtBarCode.Text) || String.IsNullOrEmpty(this.txtName.Text)|| String.IsNullOrEmpty(this.txtQuantity.Text))

                return false;
            else
                return true;
        }
        private void ClearAll()
        {
            this.txtBarCode.Clear();
            this.txtName.Clear();
            this.txtQuantity.Clear();

            this.dgvFoodItem.ClearSelection();
            this.dgvFoodItem.DataSource = null;

            this.GenerateID();
            this.PopulateGridView();
        }

        private void dgvFoodItem_DoubleClick(object sender, EventArgs e)
        {
            this.txtBarCode.Text = this.dgvFoodItem.CurrentRow.Cells[0].Value.ToString();
            this.txtName.Text = this.dgvFoodItem.CurrentRow.Cells[1].Value.ToString();
            this.txtQuantity.Text = this.dgvFoodItem.CurrentRow.Cells[2].Value.ToString();
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
                    var barCode = this.dgvFoodItem.CurrentRow.Cells[0].Value.ToString();
                    var name = this.dgvFoodItem.CurrentRow.Cells[1].Value.ToString();

                    var query = "select * from FoodItemList where BarCode= '" + barCode + "';";


                    var dst = this.Da.ExecuteQuery(query);


                    if (dst.Tables[0].Rows.Count == 1)
                    {

                        var kt = @"update FoodItemList
                                
                                set BarCode= '" + this.txtBarCode.Text + @"',
                                Name= '" + this.txtName.Text + @"',  
                               Quantity = '" + this.txtQuantity.Text + @"'
                                where BarCode = '" + barCode + "';";


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
                string search = "select * from FoodItemList where Name = '" + this.txtSearch.Text + "';";
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

                    var sql = @"insert into FoodItemList values('" + this.txtBarCode.Text + "', '" + this.txtName.Text + "', '" + this.txtQuantity.Text + "');";
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
                if (this.dgvFoodItem.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Please select a row first to delete.");
                    return;
                }

                var barCode = this.dgvFoodItem.CurrentRow.Cells[0].Value.ToString();
                var name = this.dgvFoodItem.CurrentRow.Cells[1].Value.ToString();

                var sql = "delete from FoodItemList where BarCode = '" + barCode + "';";

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
                string newBarCode = this.txtBarCode.Text.ToString();
                if (String.Compare(barCode, newBarCode) == 0)
                {
                    var q = "select BarCode from FoodItemList order by BarCode desc;";
                    var dt = this.Da.ExecuteQueryTable(q);
                    var lastBarCode = dt.Rows[0][0].ToString();
                    string[] s = lastBarCode.Split('-');
                    int temp = Convert.ToInt32(s[1]);
                    string newBar = "b-" + (temp = temp + 2).ToString("d3");
                    this.txtBarCode.Text = newBar;

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
                var q = "select BarCode from FoodItemList order by BarCode desc;";
                var dt = this.Da.ExecuteQueryTable(q);
                var lastBarCode = dt.Rows[0][0].ToString();
                string[] s = lastBarCode.Split('-');
                int temp = Convert.ToInt32(s[1]);
                string newBarCode = "b-" + (temp = temp + 1).ToString("d3");
                this.txtBarCode.Text = newBarCode;


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

        private void FoodItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
