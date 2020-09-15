namespace CarService.WinUI.Forms
{
    partial class frmCreateOnlineTicket
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
            this.btnSetPayment = new System.Windows.Forms.Button();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCarPartsList = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvServicesList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLabelHeaderText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPartsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetPayment
            // 
            this.btnSetPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSetPayment.Location = new System.Drawing.Point(346, 385);
            this.btnSetPayment.Name = "btnSetPayment";
            this.btnSetPayment.Size = new System.Drawing.Size(209, 62);
            this.btnSetPayment.TabIndex = 19;
            this.btnSetPayment.Text = "Kreiraj Online račun i pošalji ga klijentu";
            this.btnSetPayment.UseVisualStyleBackColor = false;
            this.btnSetPayment.Click += new System.EventHandler(this.btnSetPayment_Click);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(380, 340);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(193, 20);
            this.txtTotalPrice.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(216, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ukupni iznos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(519, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Lista dijelova na računu";
            // 
            // dgvCarPartsList
            // 
            this.dgvCarPartsList.AllowUserToAddRows = false;
            this.dgvCarPartsList.AllowUserToDeleteRows = false;
            this.dgvCarPartsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarPartsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvCarPartsList.Location = new System.Drawing.Point(380, 74);
            this.dgvCarPartsList.Name = "dgvCarPartsList";
            this.dgvCarPartsList.ReadOnly = true;
            this.dgvCarPartsList.Size = new System.Drawing.Size(497, 221);
            this.dgvCarPartsList.TabIndex = 13;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CarPartName";
            this.Column3.HeaderText = "Naziv auto dijela";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 154;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Quality";
            this.Column4.HeaderText = "Kvalitet";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "QuantityNeeded";
            this.Column5.HeaderText = "Potrebna količina";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "inTotal";
            this.Column6.HeaderText = "Ukupna cijena(KM)";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Lista usluga na računu";
            // 
            // dgvServicesList
            // 
            this.dgvServicesList.AllowUserToAddRows = false;
            this.dgvServicesList.AllowUserToDeleteRows = false;
            this.dgvServicesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvServicesList.Location = new System.Drawing.Point(3, 74);
            this.dgvServicesList.Name = "dgvServicesList";
            this.dgvServicesList.ReadOnly = true;
            this.dgvServicesList.Size = new System.Drawing.Size(331, 221);
            this.dgvServicesList.TabIndex = 11;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ServiceName";
            this.Column1.HeaderText = "Usluga";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 170;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ServicePrice";
            this.Column2.HeaderText = "Cijena usluge(KM)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 118;
            // 
            // txtLabelHeaderText
            // 
            this.txtLabelHeaderText.AutoSize = true;
            this.txtLabelHeaderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelHeaderText.Location = new System.Drawing.Point(291, -1);
            this.txtLabelHeaderText.Name = "txtLabelHeaderText";
            this.txtLabelHeaderText.Size = new System.Drawing.Size(322, 33);
            this.txtLabelHeaderText.TabIndex = 10;
            this.txtLabelHeaderText.Text = "Kreiranje Online računa";
            // 
            // frmCreateOnlineTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 475);
            this.Controls.Add(this.btnSetPayment);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvCarPartsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvServicesList);
            this.Controls.Add(this.txtLabelHeaderText);
            this.Name = "frmCreateOnlineTicket";
            this.Text = "frmCreateOnlineTicket";
            this.Load += new System.EventHandler(this.frmCreateOnlineTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPartsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetPayment;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCarPartsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvServicesList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label txtLabelHeaderText;
    }
}