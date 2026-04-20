namespace DVLD.LDLApp
{
    partial class ctrlLicensePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlLicensePicker));
            this.ctrlLicenseInfo1 = new DVLD.LDLApp.ctrlLicenseInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.gbSearchBar = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.gbSearchBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(3, 97);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(805, 289);
            this.ctrlLicenseInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "LicenseID:";
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(156, 34);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(222, 26);
            this.txtLicenseID.TabIndex = 2;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            // 
            // gbSearchBar
            // 
            this.gbSearchBar.Controls.Add(this.btnFindLicense);
            this.gbSearchBar.Controls.Add(this.txtLicenseID);
            this.gbSearchBar.Controls.Add(this.label1);
            this.gbSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearchBar.Location = new System.Drawing.Point(68, 12);
            this.gbSearchBar.Name = "gbSearchBar";
            this.gbSearchBar.Size = new System.Drawing.Size(605, 79);
            this.gbSearchBar.TabIndex = 3;
            this.gbSearchBar.TabStop = false;
            this.gbSearchBar.Text = "Search Bar";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnFindLicense.Image")));
            this.btnFindLicense.Location = new System.Drawing.Point(405, 16);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(69, 57);
            this.btnFindLicense.TabIndex = 3;
            this.btnFindLicense.UseVisualStyleBackColor = true;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // ctrlLicensePicker
            // 
            this.Controls.Add(this.gbSearchBar);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "ctrlLicensePicker";
            this.Size = new System.Drawing.Size(810, 386);
            this.gbSearchBar.ResumeLayout(false);
            this.gbSearchBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLicenseInfo ctrlShowLicenseInfo1;
        private ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.GroupBox gbSearchBar;
        private System.Windows.Forms.Button btnFindLicense;
    }
}
