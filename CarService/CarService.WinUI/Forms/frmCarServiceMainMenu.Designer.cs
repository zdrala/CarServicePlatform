namespace CarService.WinUI.Forms
{
    partial class frmCarServiceMainMenu
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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.txtServiceName = new System.Windows.Forms.Label();
            this.btnServices = new System.Windows.Forms.Button();
            this.txtCarParts = new System.Windows.Forms.Button();
            this.btnRequests = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSchedules = new System.Windows.Forms.Button();
            this.btnSchedulesInProgress = new System.Windows.Forms.Button();
            this.btnQuestions = new System.Windows.Forms.Button();
            this.btnCompletedServicesByDate = new System.Windows.Forms.Button();
            this.btnEarnings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(38, 25);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(169, 135);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 2;
            this.PictureBox.TabStop = false;
            // 
            // txtServiceName
            // 
            this.txtServiceName.AutoSize = true;
            this.txtServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceName.Location = new System.Drawing.Point(254, 77);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(0, 29);
            this.txtServiceName.TabIndex = 3;
            // 
            // btnServices
            // 
            this.btnServices.Location = new System.Drawing.Point(12, 208);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(169, 47);
            this.btnServices.TabIndex = 4;
            this.btnServices.Text = "Usluge";
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // txtCarParts
            // 
            this.txtCarParts.Location = new System.Drawing.Point(198, 208);
            this.txtCarParts.Name = "txtCarParts";
            this.txtCarParts.Size = new System.Drawing.Size(169, 47);
            this.txtCarParts.TabIndex = 5;
            this.txtCarParts.Text = "Auto dijelovi";
            this.txtCarParts.UseVisualStyleBackColor = true;
            this.txtCarParts.Click += new System.EventHandler(this.txtCarParts_Click);
            // 
            // btnRequests
            // 
            this.btnRequests.Location = new System.Drawing.Point(384, 208);
            this.btnRequests.Name = "btnRequests";
            this.btnRequests.Size = new System.Drawing.Size(152, 47);
            this.btnRequests.TabIndex = 6;
            this.btnRequests.Text = "Zahtjevi za termin servisiranja";
            this.btnRequests.UseVisualStyleBackColor = true;
            this.btnRequests.Click += new System.EventHandler(this.btnRequests_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(548, 25);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(125, 41);
            this.btnInfo.TabIndex = 8;
            this.btnInfo.Text = "Podaci o auto servisu";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(578, 308);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(129, 33);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Odjavi se";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSchedules
            // 
            this.btnSchedules.Location = new System.Drawing.Point(548, 208);
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(152, 47);
            this.btnSchedules.TabIndex = 12;
            this.btnSchedules.Text = "Termini";
            this.btnSchedules.UseVisualStyleBackColor = true;
            this.btnSchedules.Click += new System.EventHandler(this.btnSchedules_Click);
            // 
            // btnSchedulesInProgress
            // 
            this.btnSchedulesInProgress.Location = new System.Drawing.Point(548, 150);
            this.btnSchedulesInProgress.Name = "btnSchedulesInProgress";
            this.btnSchedulesInProgress.Size = new System.Drawing.Size(152, 52);
            this.btnSchedulesInProgress.TabIndex = 14;
            this.btnSchedulesInProgress.Text = "Prikaži termine u toku na kojima su klijenti odabrali dijelove sa ponude";
            this.btnSchedulesInProgress.UseVisualStyleBackColor = true;
            this.btnSchedulesInProgress.Click += new System.EventHandler(this.btnSchedulesInProgress_Click);
            // 
            // btnQuestions
            // 
            this.btnQuestions.Location = new System.Drawing.Point(384, 150);
            this.btnQuestions.Name = "btnQuestions";
            this.btnQuestions.Size = new System.Drawing.Size(152, 52);
            this.btnQuestions.TabIndex = 16;
            this.btnQuestions.Text = "Pitanja";
            this.btnQuestions.UseVisualStyleBackColor = true;
            this.btnQuestions.Click += new System.EventHandler(this.btnQuestions_Click);
            // 
            // btnCompletedServicesByDate
            // 
            this.btnCompletedServicesByDate.Location = new System.Drawing.Point(68, 272);
            this.btnCompletedServicesByDate.Name = "btnCompletedServicesByDate";
            this.btnCompletedServicesByDate.Size = new System.Drawing.Size(139, 37);
            this.btnCompletedServicesByDate.TabIndex = 18;
            this.btnCompletedServicesByDate.Text = "Izvještaj o obavljenim uslugama";
            this.btnCompletedServicesByDate.UseVisualStyleBackColor = true;
            this.btnCompletedServicesByDate.Click += new System.EventHandler(this.btnCompletedServicesByDate_Click);
            // 
            // btnEarnings
            // 
            this.btnEarnings.Location = new System.Drawing.Point(227, 272);
            this.btnEarnings.Name = "btnEarnings";
            this.btnEarnings.Size = new System.Drawing.Size(140, 37);
            this.btnEarnings.TabIndex = 20;
            this.btnEarnings.Text = "Izvještaj o zaradi";
            this.btnEarnings.UseVisualStyleBackColor = true;
            this.btnEarnings.Click += new System.EventHandler(this.btnEarnings_Click);
            // 
            // frmCarServiceMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 353);
            this.Controls.Add(this.btnEarnings);
            this.Controls.Add(this.btnCompletedServicesByDate);
            this.Controls.Add(this.btnQuestions);
            this.Controls.Add(this.btnSchedulesInProgress);
            this.Controls.Add(this.btnSchedules);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnRequests);
            this.Controls.Add(this.txtCarParts);
            this.Controls.Add(this.btnServices);
            this.Controls.Add(this.txtServiceName);
            this.Controls.Add(this.PictureBox);
            this.IsMdiContainer = true;
            this.Name = "frmCarServiceMainMenu";
            this.Text = "frmCarServiceMainMenu";
            this.Activated += new System.EventHandler(this.frmCarServiceMainMenu_Activated);
            this.Load += new System.EventHandler(this.frmCarServiceMainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label txtServiceName;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button txtCarParts;
        private System.Windows.Forms.Button btnRequests;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSchedules;
        private System.Windows.Forms.Button btnSchedulesInProgress;
        private System.Windows.Forms.Button btnQuestions;
        private System.Windows.Forms.Button btnCompletedServicesByDate;
        private System.Windows.Forms.Button btnEarnings;
    }
}



