namespace CarService.WinUI
{
    partial class Form1
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
            this.txtCarServiceID = new System.Windows.Forms.TextBox();
            this.btnServiceID = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCarServiceID
            // 
            this.txtCarServiceID.Location = new System.Drawing.Point(24, 61);
            this.txtCarServiceID.Name = "txtCarServiceID";
            this.txtCarServiceID.Size = new System.Drawing.Size(100, 20);
            this.txtCarServiceID.TabIndex = 0;
            // 
            // btnServiceID
            // 
            this.btnServiceID.Location = new System.Drawing.Point(188, 57);
            this.btnServiceID.Name = "btnServiceID";
            this.btnServiceID.Size = new System.Drawing.Size(75, 23);
            this.btnServiceID.TabIndex = 1;
            this.btnServiceID.Text = "Open";
            this.btnServiceID.UseVisualStyleBackColor = true;
            this.btnServiceID.Click += new System.EventHandler(this.btnServiceID_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnServiceID);
            this.Controls.Add(this.txtCarServiceID);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

 
       
        private System.Windows.Forms.TextBox txtCarServiceID;
        private System.Windows.Forms.Button btnServiceID;
    }
}

