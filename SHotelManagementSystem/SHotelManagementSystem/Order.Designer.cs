
namespace SHotelManagementSystem
{
    partial class Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvOrderView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOrderRemove = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnOderUpdate = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.txtOrderName = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.dgvOrderView);
            this.panel1.Controls.Add(this.btnOrderRemove);
            this.panel1.Controls.Add(this.btnPlaceOrder);
            this.panel1.Controls.Add(this.btnOderUpdate);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.txtOrderName);
            this.panel1.Controls.Add(this.txtOrderID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 549);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(511, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Enter Order Name->";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(727, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(253, 22);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // dgvOrderView
            // 
            this.dgvOrderView.AllowUserToAddRows = false;
            this.dgvOrderView.AllowUserToDeleteRows = false;
            this.dgvOrderView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvOrderView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name});
            this.dgvOrderView.Location = new System.Drawing.Point(545, 163);
            this.dgvOrderView.Name = "dgvOrderView";
            this.dgvOrderView.ReadOnly = true;
            this.dgvOrderView.RowHeadersWidth = 51;
            this.dgvOrderView.RowTemplate.Height = 24;
            this.dgvOrderView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderView.Size = new System.Drawing.Size(415, 375);
            this.dgvOrderView.TabIndex = 10;
            this.dgvOrderView.DoubleClick += new System.EventHandler(this.dgvOrderView_DoubleClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Order ID";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Order Item Name";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // btnOrderRemove
            // 
            this.btnOrderRemove.BackColor = System.Drawing.Color.Red;
            this.btnOrderRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderRemove.Location = new System.Drawing.Point(843, 82);
            this.btnOrderRemove.Name = "btnOrderRemove";
            this.btnOrderRemove.Size = new System.Drawing.Size(170, 49);
            this.btnOrderRemove.TabIndex = 9;
            this.btnOrderRemove.Text = "Order Remove";
            this.btnOrderRemove.UseVisualStyleBackColor = false;
            this.btnOrderRemove.Click += new System.EventHandler(this.btnOrderRemove_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPlaceOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceOrder.Location = new System.Drawing.Point(653, 82);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(155, 49);
            this.btnPlaceOrder.TabIndex = 8;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // btnOderUpdate
            // 
            this.btnOderUpdate.BackColor = System.Drawing.Color.LawnGreen;
            this.btnOderUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOderUpdate.Location = new System.Drawing.Point(477, 82);
            this.btnOderUpdate.Name = "btnOderUpdate";
            this.btnOderUpdate.Size = new System.Drawing.Size(155, 49);
            this.btnOderUpdate.TabIndex = 7;
            this.btnOderUpdate.Text = "Order Update";
            this.btnOderUpdate.UseVisualStyleBackColor = false;
            this.btnOderUpdate.Click += new System.EventHandler(this.btnOderUpdate_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Aqua;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(147, 408);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(138, 49);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Text = "<<Previous";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(236, 330);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 49);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Lime;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(60, 330);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(106, 49);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // txtOrderName
            // 
            this.txtOrderName.Location = new System.Drawing.Point(60, 247);
            this.txtOrderName.Name = "txtOrderName";
            this.txtOrderName.Size = new System.Drawing.Size(253, 22);
            this.txtOrderName.TabIndex = 3;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(60, 130);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(253, 22);
            this.txtOrderID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Order Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Order ID";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.btnLogOut);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1043, 130);
            this.panel2.TabIndex = 1;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Red;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(889, 36);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(106, 49);
            this.btnLogOut.TabIndex = 10;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(244, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Receive and Collections";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 679);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            
            this.Text = "Order";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Order_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvOrderView;
        private System.Windows.Forms.Button btnOrderRemove;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnOderUpdate;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TextBox txtOrderName;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
    }
}