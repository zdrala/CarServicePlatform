namespace CarService.WinUI.Forms
{
    partial class frmSetPayment
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
            this.txtLabelHeaderText = new System.Windows.Forms.Label();
            this.dgvServicesList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCarPartsList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPaymentType = new System.Windows.Forms.TextBox();
            this.btnSetPayment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPartsList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLabelHeaderText
            // 
            this.txtLabelHeaderText.AutoSize = true;
            this.txtLabelHeaderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelHeaderText.Location = new System.Drawing.Point(298, 0);
            this.txtLabelHeaderText.Name = "txtLabelHeaderText";
            this.txtLabelHeaderText.Size = new System.Drawing.Size(336, 33);
            this.txtLabelHeaderText.TabIndex = 0;
            this.txtLabelHeaderText.Text = "Evidencija uplate klijenta";
            // 
            // dgvServicesList
            // 
            this.dgvServicesList.AllowUserToAddRows = false;
            this.dgvServicesList.AllowUserToDeleteRows = false;
            this.dgvServicesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvServicesList.Location = new System.Drawing.Point(24, 75);
            this.dgvServicesList.Name = "dgvServicesList";
            this.dgvServicesList.ReadOnly = true;
            this.dgvServicesList.Size = new System.Drawing.Size(331, 221);
            this.dgvServicesList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Obavljene usluge na terminu";
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
            this.dgvCarPartsList.Location = new System.Drawing.Point(408, 75);
            this.dgvCarPartsList.Name = "dgvCarPartsList";
            this.dgvCarPartsList.ReadOnly = true;
            this.dgvCarPartsList.Size = new System.Drawing.Size(497, 221);
            this.dgvCarPartsList.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(504, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Odabrani dijelovi od strane klijenta";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(265, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ukupni iznos:";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(426, 341);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(193, 20);
            this.txtTotalPrice.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(247, 366);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Način plaćanja:";
            // 
            // txtPaymentType
            // 
            this.txtPaymentType.Location = new System.Drawing.Point(426, 371);
            this.txtPaymentType.Name = "txtPaymentType";
            this.txtPaymentType.ReadOnly = true;
            this.txtPaymentType.Size = new System.Drawing.Size(193, 20);
            this.txtPaymentType.TabIndex = 8;
            this.txtPaymentType.Text = "Plaćeno gotovinom";
            // 
            // btnSetPayment
            // 
            this.btnSetPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSetPayment.Location = new System.Drawing.Point(387, 419);
            this.btnSetPayment.Name = "btnSetPayment";
            this.btnSetPayment.Size = new System.Drawing.Size(135, 34);
            this.btnSetPayment.TabIndex = 9;
            this.btnSetPayment.Text = "Evidentiraj uplatu klijenta";
            this.btnSetPayment.UseVisualStyleBackColor = false;
            this.btnSetPayment.Click += new System.EventHandler(this.btnSetPayment_Click);
            // 
            // frmSetPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 489);
            this.Controls.Add(this.btnSetPayment);
            this.Controls.Add(this.txtPaymentType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvCarPartsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvServicesList);
            this.Controls.Add(this.txtLabelHeaderText);
            this.Name = "frmSetPayment";
            this.Text = "frmSetPayment";
            this.Load += new System.EventHandler(this.frmSetPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPartsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtLabelHeaderText;
        private System.Windows.Forms.DataGridView dgvServicesList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dgvCarPartsList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPaymentType;
        private System.Windows.Forms.Button btnSetPayment;
    }
}