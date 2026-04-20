namespace DVLD
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.mspMainMenue = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicenseServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementForDamagedOrLostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogedinUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mspMainMenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMainMenue
            // 
            resources.ApplyResources(this.mspMainMenue, "mspMainMenue");
            this.mspMainMenue.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.mspMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.mspMainMenue.Name = "mspMainMenue";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageApplicationTypesToolStripMenuItem,
            this.manageTestTypesToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.drivingLicenseServicesToolStripMenuItem,
            this.detainLicensesToolStripMenuItem});
            resources.ApplyResources(this.applicationsToolStripMenuItem, "applicationsToolStripMenuItem");
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            resources.ApplyResources(this.manageApplicationTypesToolStripMenuItem, "manageApplicationTypesToolStripMenuItem");
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            resources.ApplyResources(this.manageTestTypesToolStripMenuItem, "manageTestTypesToolStripMenuItem");
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseApplicationsToolStripMenuItem,
            this.internationalLicenseApplicationsToolStripMenuItem});
            resources.ApplyResources(this.manageApplicationsToolStripMenuItem, "manageApplicationsToolStripMenuItem");
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            // 
            // localDrivingLicenseApplicationsToolStripMenuItem
            // 
            resources.ApplyResources(this.localDrivingLicenseApplicationsToolStripMenuItem, "localDrivingLicenseApplicationsToolStripMenuItem");
            this.localDrivingLicenseApplicationsToolStripMenuItem.Name = "localDrivingLicenseApplicationsToolStripMenuItem";
            this.localDrivingLicenseApplicationsToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseApplicationsToolStripMenuItem_Click);
            // 
            // internationalLicenseApplicationsToolStripMenuItem
            // 
            resources.ApplyResources(this.internationalLicenseApplicationsToolStripMenuItem, "internationalLicenseApplicationsToolStripMenuItem");
            this.internationalLicenseApplicationsToolStripMenuItem.Name = "internationalLicenseApplicationsToolStripMenuItem";
            this.internationalLicenseApplicationsToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseApplicationsToolStripMenuItem_Click);
            // 
            // drivingLicenseServicesToolStripMenuItem
            // 
            this.drivingLicenseServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.replacementForDamagedOrLostToolStripMenuItem});
            resources.ApplyResources(this.drivingLicenseServicesToolStripMenuItem, "drivingLicenseServicesToolStripMenuItem");
            this.drivingLicenseServicesToolStripMenuItem.Name = "drivingLicenseServicesToolStripMenuItem";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicenseToolStripMenuItem});
            resources.ApplyResources(this.newDrivingLicenseToolStripMenuItem, "newDrivingLicenseToolStripMenuItem");
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            // 
            // localLicenseToolStripMenuItem
            // 
            resources.ApplyResources(this.localLicenseToolStripMenuItem, "localLicenseToolStripMenuItem");
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicenseToolStripMenuItem
            // 
            resources.ApplyResources(this.internationalLicenseToolStripMenuItem, "internationalLicenseToolStripMenuItem");
            this.internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            this.internationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseToolStripMenuItem_Click);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            resources.ApplyResources(this.renewDrivingLicenseToolStripMenuItem, "renewDrivingLicenseToolStripMenuItem");
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // replacementForDamagedOrLostToolStripMenuItem
            // 
            this.replacementForDamagedOrLostToolStripMenuItem.Name = "replacementForDamagedOrLostToolStripMenuItem";
            resources.ApplyResources(this.replacementForDamagedOrLostToolStripMenuItem, "replacementForDamagedOrLostToolStripMenuItem");
            this.replacementForDamagedOrLostToolStripMenuItem.Click += new System.EventHandler(this.replacementForDamagedOrLostToolStripMenuItem_Click);
            // 
            // detainLicensesToolStripMenuItem
            // 
            this.detainLicensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detainLicenseToolStripMenuItem,
            this.releaseLicenseToolStripMenuItem,
            this.dToolStripMenuItem});
            resources.ApplyResources(this.detainLicensesToolStripMenuItem, "detainLicensesToolStripMenuItem");
            this.detainLicensesToolStripMenuItem.Name = "detainLicensesToolStripMenuItem";
            // 
            // detainLicenseToolStripMenuItem
            // 
            resources.ApplyResources(this.detainLicenseToolStripMenuItem, "detainLicenseToolStripMenuItem");
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // releaseLicenseToolStripMenuItem
            // 
            resources.ApplyResources(this.releaseLicenseToolStripMenuItem, "releaseLicenseToolStripMenuItem");
            this.releaseLicenseToolStripMenuItem.Name = "releaseLicenseToolStripMenuItem";
            this.releaseLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseLicenseToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            resources.ApplyResources(this.peopleToolStripMenuItem, "peopleToolStripMenuItem");
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            resources.ApplyResources(this.usersToolStripMenuItem, "usersToolStripMenuItem");
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            resources.ApplyResources(this.driversToolStripMenuItem, "driversToolStripMenuItem");
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Click += new System.EventHandler(this.driversToolStripMenuItem_Click);
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.showLogedinUserToolStripMenuItem,
            this.changeCurToolStripMenuItem});
            resources.ApplyResources(this.accountSettingsToolStripMenuItem, "accountSettingsToolStripMenuItem");
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            // 
            // logoutToolStripMenuItem
            // 
            resources.ApplyResources(this.logoutToolStripMenuItem, "logoutToolStripMenuItem");
            this.logoutToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // showLogedinUserToolStripMenuItem
            // 
            resources.ApplyResources(this.showLogedinUserToolStripMenuItem, "showLogedinUserToolStripMenuItem");
            this.showLogedinUserToolStripMenuItem.Name = "showLogedinUserToolStripMenuItem";
            this.showLogedinUserToolStripMenuItem.Click += new System.EventHandler(this.showLogedinUserToolStripMenuItem_Click);
            // 
            // changeCurToolStripMenuItem
            // 
            resources.ApplyResources(this.changeCurToolStripMenuItem, "changeCurToolStripMenuItem");
            this.changeCurToolStripMenuItem.Name = "changeCurToolStripMenuItem";
            this.changeCurToolStripMenuItem.Click += new System.EventHandler(this.changeCurToolStripMenuItem_Click_1);
            // 
            // dToolStripMenuItem
            // 
            resources.ApplyResources(this.dToolStripMenuItem, "dToolStripMenuItem");
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Click += new System.EventHandler(this.dToolStripMenuItem_Click);
            // 
            // frmMainMenue
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.CausesValidation = false;
            this.Controls.Add(this.mspMainMenue);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.LavenderBlush;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mspMainMenue;
            this.Name = "frmMainMenue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainMenue_Load);
            this.mspMainMenue.ResumeLayout(false);
            this.mspMainMenue.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspMainMenue;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLogedinUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicenseServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForDamagedOrLostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
    }
}

