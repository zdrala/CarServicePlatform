namespace CarService.WinUI.Forms
{
    partial class frmSchedulesInProgress
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOfferPartsSelected = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfferPartsSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klijenti koji su odabrali dijelove sa ponude";
            // 
            // dgvOfferPartsSelected
            // 
            this.dgvOfferPartsSelected.AllowUserToAddRows = false;
            this.dgvOfferPartsSelected.AllowUserToDeleteRows = false;
            this.dgvOfferPartsSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfferPartsSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvOfferPartsSelected.Location = new System.Drawing.Point(54, 85);
            this.dgvOfferPartsSelected.Name = "dgvOfferPartsSelected";
            this.dgvOfferPartsSelected.ReadOnly = true;
            this.dgvOfferPartsSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOfferPartsSelected.Size = new System.Drawing.Size(504, 353);
            this.dgvOfferPartsSelected.TabIndex = 1;
            this.dgvOfferPartsSelected.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfferPartsSelected_CellDoubleClick);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "OfferID";
            this.Column4.HeaderText = "OfferID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "User";
            this.Column1.HeaderText = "Klijent";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Date";
            this.Column2.HeaderText = "Datum termina";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Status";
            this.Column3.HeaderText = "Status";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 130;
            // 
            // frmSchedulesInProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 450);
            this.Controls.Add(this.dgvOfferPartsSelected);
            this.Controls.Add(this.label1);
            this.Name = "frmSchedulesInProgress";
            this.Text = "frmSchedulesInProgress";
            this.Load += new System.EventHandler(this.frmSchedulesInProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfferPartsSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOfferPartsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}