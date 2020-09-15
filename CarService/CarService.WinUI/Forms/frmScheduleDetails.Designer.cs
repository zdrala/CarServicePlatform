namespace CarService.WinUI.Forms
{
    partial class frmScheduleDetails
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScheduleDate = new System.Windows.Forms.TextBox();
            this.txtUserNameLastName = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStatusSchedule = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIsPaidSchedule = new System.Windows.Forms.Label();
            this.btnSetPaymentDetails = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPartsSubCategories = new System.Windows.Forms.ComboBox();
            this.txtSelectedCategory = new System.Windows.Forms.Label();
            this.txtSubCategoryName = new System.Windows.Forms.TextBox();
            this.txtQuantityNeeded = new System.Windows.Forms.Label();
            this.txtNeededQuantity = new System.Windows.Forms.TextBox();
            this.btnAddToOfferList = new System.Windows.Forms.Button();
            this.dgvSelectedSubCategories = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSendOffer = new System.Windows.Forms.Button();
            this.btnFinishSchedule = new System.Windows.Forms.Button();
            this.txtIsOfferSent = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.LabelTotalPrice = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.Label();
            this.btnShowPaymentDetails = new System.Windows.Forms.Button();
            this.txtLabelCreateTicket = new System.Windows.Forms.Label();
            this.btnCreateOnlineTicket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedSubCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detalji termina servisiranja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Termin";
            // 
            // txtScheduleDate
            // 
            this.txtScheduleDate.Location = new System.Drawing.Point(54, 99);
            this.txtScheduleDate.Name = "txtScheduleDate";
            this.txtScheduleDate.ReadOnly = true;
            this.txtScheduleDate.Size = new System.Drawing.Size(166, 20);
            this.txtScheduleDate.TabIndex = 2;
            // 
            // txtUserNameLastName
            // 
            this.txtUserNameLastName.AutoSize = true;
            this.txtUserNameLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNameLastName.Location = new System.Drawing.Point(242, 72);
            this.txtUserNameLastName.Name = "txtUserNameLastName";
            this.txtUserNameLastName.Size = new System.Drawing.Size(60, 24);
            this.txtUserNameLastName.TabIndex = 3;
            this.txtUserNameLastName.Text = "Klijent";
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(246, 99);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(170, 20);
            this.txtClient.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(458, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status: ";
            // 
            // txtStatusSchedule
            // 
            this.txtStatusSchedule.AutoSize = true;
            this.txtStatusSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusSchedule.Location = new System.Drawing.Point(558, 58);
            this.txtStatusSchedule.Name = "txtStatusSchedule";
            this.txtStatusSchedule.Size = new System.Drawing.Size(79, 29);
            this.txtStatusSchedule.TabIndex = 6;
            this.txtStatusSchedule.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(458, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Plaćeno?";
            // 
            // txtIsPaidSchedule
            // 
            this.txtIsPaidSchedule.AutoSize = true;
            this.txtIsPaidSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsPaidSchedule.Location = new System.Drawing.Point(558, 93);
            this.txtIsPaidSchedule.Name = "txtIsPaidSchedule";
            this.txtIsPaidSchedule.Size = new System.Drawing.Size(79, 29);
            this.txtIsPaidSchedule.TabIndex = 8;
            this.txtIsPaidSchedule.Text = "label5";
            // 
            // btnSetPaymentDetails
            // 
            this.btnSetPaymentDetails.Location = new System.Drawing.Point(457, 159);
            this.btnSetPaymentDetails.Name = "btnSetPaymentDetails";
            this.btnSetPaymentDetails.Size = new System.Drawing.Size(150, 56);
            this.btnSetPaymentDetails.TabIndex = 9;
            this.btnSetPaymentDetails.Text = "Postavi uplatu klijenta";
            this.btnSetPaymentDetails.UseVisualStyleBackColor = true;
            this.btnSetPaymentDetails.Click += new System.EventHandler(this.btnSetPaymentDetails_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(188, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(341, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ponuda s auto dijelovima";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(123, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(498, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Odaberi podkategoriju dijelova i postavi na ponudu";
            // 
            // cmbPartsSubCategories
            // 
            this.cmbPartsSubCategories.FormattingEnabled = true;
            this.cmbPartsSubCategories.Location = new System.Drawing.Point(194, 304);
            this.cmbPartsSubCategories.Name = "cmbPartsSubCategories";
            this.cmbPartsSubCategories.Size = new System.Drawing.Size(296, 21);
            this.cmbPartsSubCategories.TabIndex = 12;
            this.cmbPartsSubCategories.SelectedIndexChanged += new System.EventHandler(this.cmbPartsSubCategories_SelectedIndexChanged);
            this.cmbPartsSubCategories.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPartsSubCategories_Validating);
            // 
            // txtSelectedCategory
            // 
            this.txtSelectedCategory.AutoSize = true;
            this.txtSelectedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedCategory.Location = new System.Drawing.Point(36, 339);
            this.txtSelectedCategory.Name = "txtSelectedCategory";
            this.txtSelectedCategory.Size = new System.Drawing.Size(184, 20);
            this.txtSelectedCategory.TabIndex = 13;
            this.txtSelectedCategory.Text = "Odabrana podkategorija:";
            // 
            // txtSubCategoryName
            // 
            this.txtSubCategoryName.Location = new System.Drawing.Point(231, 339);
            this.txtSubCategoryName.Name = "txtSubCategoryName";
            this.txtSubCategoryName.ReadOnly = true;
            this.txtSubCategoryName.Size = new System.Drawing.Size(200, 20);
            this.txtSubCategoryName.TabIndex = 14;
            // 
            // txtQuantityNeeded
            // 
            this.txtQuantityNeeded.AutoSize = true;
            this.txtQuantityNeeded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityNeeded.Location = new System.Drawing.Point(86, 370);
            this.txtQuantityNeeded.Name = "txtQuantityNeeded";
            this.txtQuantityNeeded.Size = new System.Drawing.Size(134, 20);
            this.txtQuantityNeeded.TabIndex = 15;
            this.txtQuantityNeeded.Text = "Potrebna količina:";
            // 
            // txtNeededQuantity
            // 
            this.txtNeededQuantity.Location = new System.Drawing.Point(232, 370);
            this.txtNeededQuantity.Name = "txtNeededQuantity";
            this.txtNeededQuantity.Size = new System.Drawing.Size(199, 20);
            this.txtNeededQuantity.TabIndex = 16;
            this.txtNeededQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.txtNeededQuantity_Validating);
            // 
            // btnAddToOfferList
            // 
            this.btnAddToOfferList.Location = new System.Drawing.Point(463, 353);
            this.btnAddToOfferList.Name = "btnAddToOfferList";
            this.btnAddToOfferList.Size = new System.Drawing.Size(129, 23);
            this.btnAddToOfferList.TabIndex = 17;
            this.btnAddToOfferList.Text = "Dodaj na ponudu";
            this.btnAddToOfferList.UseVisualStyleBackColor = true;
            this.btnAddToOfferList.Click += new System.EventHandler(this.btnAddToOfferList_Click);
            // 
            // dgvSelectedSubCategories
            // 
            this.dgvSelectedSubCategories.AllowUserToAddRows = false;
            this.dgvSelectedSubCategories.AllowUserToDeleteRows = false;
            this.dgvSelectedSubCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedSubCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvSelectedSubCategories.Location = new System.Drawing.Point(194, 445);
            this.dgvSelectedSubCategories.Name = "dgvSelectedSubCategories";
            this.dgvSelectedSubCategories.ReadOnly = true;
            this.dgvSelectedSubCategories.Size = new System.Drawing.Size(296, 185);
            this.dgvSelectedSubCategories.TabIndex = 18;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SubCategoryName";
            this.Column1.HeaderText = "Podkategorija";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "QuantityNeeded";
            this.Column2.HeaderText = "Potrebna količina";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 103;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(263, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Odabrane kategorije";
            // 
            // btnSendOffer
            // 
            this.btnSendOffer.Location = new System.Drawing.Point(538, 507);
            this.btnSendOffer.Name = "btnSendOffer";
            this.btnSendOffer.Size = new System.Drawing.Size(152, 23);
            this.btnSendOffer.TabIndex = 20;
            this.btnSendOffer.Text = "Pošalji ponudu klijentu";
            this.btnSendOffer.UseVisualStyleBackColor = true;
            this.btnSendOffer.Click += new System.EventHandler(this.btnSendOffer_Click);
            // 
            // btnFinishSchedule
            // 
            this.btnFinishSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFinishSchedule.Location = new System.Drawing.Point(54, 147);
            this.btnFinishSchedule.Name = "btnFinishSchedule";
            this.btnFinishSchedule.Size = new System.Drawing.Size(180, 56);
            this.btnFinishSchedule.TabIndex = 21;
            this.btnFinishSchedule.Text = "Završi termin";
            this.btnFinishSchedule.UseVisualStyleBackColor = false;
            this.btnFinishSchedule.Click += new System.EventHandler(this.btnFinishSchedule_Click);
            // 
            // txtIsOfferSent
            // 
            this.txtIsOfferSent.AutoSize = true;
            this.txtIsOfferSent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtIsOfferSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIsOfferSent.Location = new System.Drawing.Point(172, 390);
            this.txtIsOfferSent.Name = "txtIsOfferSent";
            this.txtIsOfferSent.Size = new System.Drawing.Size(344, 29);
            this.txtIsOfferSent.TabIndex = 22;
            this.txtIsOfferSent.Text = "Ponuda je već poslana klijentu!";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.BackColor = System.Drawing.Color.Red;
            this.btnDeleteSchedule.Location = new System.Drawing.Point(267, 147);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(127, 56);
            this.btnDeleteSchedule.TabIndex = 23;
            this.btnDeleteSchedule.Text = "Obriši termin";
            this.btnDeleteSchedule.UseVisualStyleBackColor = false;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // LabelTotalPrice
            // 
            this.LabelTotalPrice.AutoSize = true;
            this.LabelTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTotalPrice.Location = new System.Drawing.Point(458, 122);
            this.LabelTotalPrice.Name = "LabelTotalPrice";
            this.LabelTotalPrice.Size = new System.Drawing.Size(149, 25);
            this.LabelTotalPrice.TabIndex = 24;
            this.LabelTotalPrice.Text = "Ukupan iznos:";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.AutoSize = true;
            this.txtTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.Location = new System.Drawing.Point(613, 122);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(0, 25);
            this.txtTotalPrice.TabIndex = 25;
            // 
            // btnShowPaymentDetails
            // 
            this.btnShowPaymentDetails.Location = new System.Drawing.Point(614, 159);
            this.btnShowPaymentDetails.Name = "btnShowPaymentDetails";
            this.btnShowPaymentDetails.Size = new System.Drawing.Size(136, 56);
            this.btnShowPaymentDetails.TabIndex = 26;
            this.btnShowPaymentDetails.Text = "Detalji uplate";
            this.btnShowPaymentDetails.UseVisualStyleBackColor = true;
            this.btnShowPaymentDetails.Click += new System.EventHandler(this.btnShowPaymentDetails_Click);
            // 
            // txtLabelCreateTicket
            // 
            this.txtLabelCreateTicket.AutoSize = true;
            this.txtLabelCreateTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelCreateTicket.Location = new System.Drawing.Point(163, 642);
            this.txtLabelCreateTicket.Name = "txtLabelCreateTicket";
            this.txtLabelCreateTicket.Size = new System.Drawing.Size(397, 29);
            this.txtLabelCreateTicket.TabIndex = 27;
            this.txtLabelCreateTicket.Text = "Kreiraj i pošalji Online račun klijentu";
            // 
            // btnCreateOnlineTicket
            // 
            this.btnCreateOnlineTicket.Location = new System.Drawing.Point(289, 674);
            this.btnCreateOnlineTicket.Name = "btnCreateOnlineTicket";
            this.btnCreateOnlineTicket.Size = new System.Drawing.Size(127, 37);
            this.btnCreateOnlineTicket.TabIndex = 28;
            this.btnCreateOnlineTicket.Text = "Kreiraj račun";
            this.btnCreateOnlineTicket.UseVisualStyleBackColor = true;
            this.btnCreateOnlineTicket.Click += new System.EventHandler(this.btnCreateOnlineTicket_Click);
            // 
            // frmScheduleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 738);
            this.Controls.Add(this.btnCreateOnlineTicket);
            this.Controls.Add(this.txtLabelCreateTicket);
            this.Controls.Add(this.btnShowPaymentDetails);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.LabelTotalPrice);
            this.Controls.Add(this.btnDeleteSchedule);
            this.Controls.Add(this.txtIsOfferSent);
            this.Controls.Add(this.btnFinishSchedule);
            this.Controls.Add(this.btnSendOffer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvSelectedSubCategories);
            this.Controls.Add(this.btnAddToOfferList);
            this.Controls.Add(this.txtNeededQuantity);
            this.Controls.Add(this.txtQuantityNeeded);
            this.Controls.Add(this.txtSubCategoryName);
            this.Controls.Add(this.txtSelectedCategory);
            this.Controls.Add(this.cmbPartsSubCategories);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSetPaymentDetails);
            this.Controls.Add(this.txtIsPaidSchedule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStatusSchedule);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.txtUserNameLastName);
            this.Controls.Add(this.txtScheduleDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmScheduleDetails";
            this.Text = "frmScheduleDetails";
            this.Activated += new System.EventHandler(this.frmScheduleDetails_Activated);
            this.Load += new System.EventHandler(this.frmScheduleDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedSubCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScheduleDate;
        private System.Windows.Forms.Label txtUserNameLastName;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtStatusSchedule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtIsPaidSchedule;
        private System.Windows.Forms.Button btnSetPaymentDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPartsSubCategories;
        private System.Windows.Forms.Label txtSelectedCategory;
        private System.Windows.Forms.TextBox txtSubCategoryName;
        private System.Windows.Forms.Label txtQuantityNeeded;
        private System.Windows.Forms.TextBox txtNeededQuantity;
        private System.Windows.Forms.Button btnAddToOfferList;
        private System.Windows.Forms.DataGridView dgvSelectedSubCategories;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSendOffer;
        private System.Windows.Forms.Button btnFinishSchedule;
        private System.Windows.Forms.Label txtIsOfferSent;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Label LabelTotalPrice;
        private System.Windows.Forms.Label txtTotalPrice;
        private System.Windows.Forms.Button btnShowPaymentDetails;
        private System.Windows.Forms.Button btnCreateOnlineTicket;
        private System.Windows.Forms.Label txtLabelCreateTicket;
    }
}