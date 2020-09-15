namespace CarService.WinUI.Forms
{
    partial class frmCarParts
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
            this.cmbPartsCategory = new System.Windows.Forms.ComboBox();
            this.txtCarServiceName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPartsSubCategory = new System.Windows.Forms.ComboBox();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.txtAddCarPart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CarPartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Photoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbPartsCategory
            // 
            this.cmbPartsCategory.FormattingEnabled = true;
            this.cmbPartsCategory.Location = new System.Drawing.Point(111, 61);
            this.cmbPartsCategory.Name = "cmbPartsCategory";
            this.cmbPartsCategory.Size = new System.Drawing.Size(171, 21);
            this.cmbPartsCategory.TabIndex = 0;
            this.cmbPartsCategory.SelectedIndexChanged += new System.EventHandler(this.cmbPartsCategory_SelectedIndexChanged);
            // 
            // txtCarServiceName
            // 
            this.txtCarServiceName.AutoSize = true;
            this.txtCarServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarServiceName.Location = new System.Drawing.Point(374, 9);
            this.txtCarServiceName.Name = "txtCarServiceName";
            this.txtCarServiceName.Size = new System.Drawing.Size(0, 25);
            this.txtCarServiceName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prikaz auto dijelova";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kategorija:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(357, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Podkategorija:";
            // 
            // cmbPartsSubCategory
            // 
            this.cmbPartsSubCategory.FormattingEnabled = true;
            this.cmbPartsSubCategory.Location = new System.Drawing.Point(476, 58);
            this.cmbPartsSubCategory.Name = "cmbPartsSubCategory";
            this.cmbPartsSubCategory.Size = new System.Drawing.Size(170, 21);
            this.cmbPartsSubCategory.TabIndex = 6;
            this.cmbPartsSubCategory.SelectedIndexChanged += new System.EventHandler(this.cmbPartsSubCategory_SelectedIndexChanged);
            // 
            // dgvParts
            // 
            this.dgvParts.AllowUserToAddRows = false;
            this.dgvParts.AllowUserToDeleteRows = false;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CarPartID,
            this.CategoryID,
            this.SubCategoryID,
            this.Photoa,
            this.Namea,
            this.Quality,
            this.Price,
            this.CategoryName,
            this.SubCategoryName});
            this.dgvParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParts.Location = new System.Drawing.Point(3, 16);
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.ReadOnly = true;
            this.dgvParts.RowHeadersWidth = 150;
            this.dgvParts.RowTemplate.Height = 80;
            this.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParts.Size = new System.Drawing.Size(654, 282);
            this.dgvParts.TabIndex = 7;
            this.dgvParts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellDoubleClick);
            // 
            // txtAddCarPart
            // 
            this.txtAddCarPart.Location = new System.Drawing.Point(476, 101);
            this.txtAddCarPart.Name = "txtAddCarPart";
            this.txtAddCarPart.Size = new System.Drawing.Size(170, 23);
            this.txtAddCarPart.TabIndex = 8;
            this.txtAddCarPart.Text = "Dodaj novi dio";
            this.txtAddCarPart.UseVisualStyleBackColor = true;
            this.txtAddCarPart.Click += new System.EventHandler(this.txtAddCarPart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvParts);
            this.groupBox1.Location = new System.Drawing.Point(1, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 301);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // CarPartID
            // 
            this.CarPartID.DataPropertyName = "CarPartID";
            this.CarPartID.HeaderText = "CarPartID";
            this.CarPartID.Name = "CarPartID";
            this.CarPartID.ReadOnly = true;
            this.CarPartID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CarPartID.Visible = false;
            // 
            // CategoryID
            // 
            this.CategoryID.DataPropertyName = "CategoryID";
            this.CategoryID.HeaderText = "Column1";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.ReadOnly = true;
            this.CategoryID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CategoryID.Visible = false;
            // 
            // SubCategoryID
            // 
            this.SubCategoryID.DataPropertyName = "SubCategoryID";
            this.SubCategoryID.HeaderText = "Column2";
            this.SubCategoryID.Name = "SubCategoryID";
            this.SubCategoryID.ReadOnly = true;
            this.SubCategoryID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SubCategoryID.Visible = false;
            // 
            // Photoa
            // 
            this.Photoa.DataPropertyName = "Photo";
            this.Photoa.HeaderText = "Photo";
            this.Photoa.Name = "Photoa";
            this.Photoa.ReadOnly = true;
            this.Photoa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Photoa.Visible = false;
            // 
            // Namea
            // 
            this.Namea.DataPropertyName = "Name";
            this.Namea.HeaderText = "Naziv";
            this.Namea.Name = "Namea";
            this.Namea.ReadOnly = true;
            this.Namea.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Quality
            // 
            this.Quality.DataPropertyName = "Quality";
            this.Quality.HeaderText = "Kvaliteta";
            this.Quality.Name = "Quality";
            this.Quality.ReadOnly = true;
            this.Quality.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Cijena";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "Kategorija";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // SubCategoryName
            // 
            this.SubCategoryName.DataPropertyName = "SubCategoryName";
            this.SubCategoryName.HeaderText = "Podkategorija";
            this.SubCategoryName.Name = "SubCategoryName";
            this.SubCategoryName.ReadOnly = true;
            this.SubCategoryName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // frmCarParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 431);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtAddCarPart);
            this.Controls.Add(this.cmbPartsSubCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarServiceName);
            this.Controls.Add(this.cmbPartsCategory);
            this.Name = "frmCarParts";
            this.Text = "frmCarParts";
            this.Load += new System.EventHandler(this.frmCarParts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPartsCategory;
        private System.Windows.Forms.Label txtCarServiceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPartsSubCategory;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.Button txtAddCarPart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarPartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Photoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCategoryName;
    }
}