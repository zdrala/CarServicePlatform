namespace CarService.WinUI.Forms
{
    partial class frmServices
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddService = new System.Windows.Forms.Button();
            this.txtCarServiceName = new System.Windows.Forms.Label();
            this.btnLoadAgain = new System.Windows.Forms.Button();
            this.ServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvServices);
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 337);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceID,
            this.CarServiceID,
            this.ServiceName,
            this.ServicePrice,
            this.Description,
            this.ServiceTime});
            this.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServices.Location = new System.Drawing.Point(3, 16);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.Size = new System.Drawing.Size(509, 318);
            this.dgvServices.TabIndex = 0;
            this.dgvServices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServices_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upravljanje uslugama: ";
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(325, 64);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(202, 42);
            this.btnAddService.TabIndex = 2;
            this.btnAddService.Text = "Dodaj novu uslugu";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // txtCarServiceName
            // 
            this.txtCarServiceName.AutoSize = true;
            this.txtCarServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarServiceName.Location = new System.Drawing.Point(243, 16);
            this.txtCarServiceName.Name = "txtCarServiceName";
            this.txtCarServiceName.Size = new System.Drawing.Size(0, 25);
            this.txtCarServiceName.TabIndex = 3;
            // 
            // btnLoadAgain
            // 
            this.btnLoadAgain.Location = new System.Drawing.Point(17, 67);
            this.btnLoadAgain.Name = "btnLoadAgain";
            this.btnLoadAgain.Size = new System.Drawing.Size(183, 23);
            this.btnLoadAgain.TabIndex = 4;
            this.btnLoadAgain.Text = "Učitaj listu usluga ponovo";
            this.btnLoadAgain.UseVisualStyleBackColor = true;
            this.btnLoadAgain.Click += new System.EventHandler(this.btnLoadAgain_Click);
            // 
            // ServiceID
            // 
            this.ServiceID.DataPropertyName = "ServiceID";
            this.ServiceID.HeaderText = "ServiceID";
            this.ServiceID.Name = "ServiceID";
            this.ServiceID.ReadOnly = true;
            this.ServiceID.Visible = false;
            // 
            // CarServiceID
            // 
            this.CarServiceID.DataPropertyName = "CarServiceID";
            this.CarServiceID.HeaderText = "CarServiceID";
            this.CarServiceID.Name = "CarServiceID";
            this.CarServiceID.ReadOnly = true;
            this.CarServiceID.Visible = false;
            // 
            // ServiceName
            // 
            this.ServiceName.DataPropertyName = "ServiceName";
            this.ServiceName.HeaderText = "Naziv usluge";
            this.ServiceName.MinimumWidth = 50;
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.ReadOnly = true;
            this.ServiceName.Width = 166;
            // 
            // ServicePrice
            // 
            this.ServicePrice.DataPropertyName = "ServicePrice";
            this.ServicePrice.HeaderText = "Cijena usluge(KM)";
            this.ServicePrice.Name = "ServicePrice";
            this.ServicePrice.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Opis";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // ServiceTime
            // 
            this.ServiceTime.DataPropertyName = "ServiceTime";
            this.ServiceTime.HeaderText = "Vrijeme izvršavanja(u minutama)";
            this.ServiceTime.Name = "ServiceTime";
            this.ServiceTime.ReadOnly = true;
            // 
            // frmServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 457);
            this.Controls.Add(this.btnLoadAgain);
            this.Controls.Add(this.txtCarServiceName);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmServices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmServices";
            this.Activated += new System.EventHandler(this.frmServices_Activated);
            this.Load += new System.EventHandler(this.frmServices_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Label txtCarServiceName;
        private System.Windows.Forms.Button btnLoadAgain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarServiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceTime;
    }
}