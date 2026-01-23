namespace DVLD
{
    partial class frmMainMenue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenue));
            this.mspMainMenue = new System.Windows.Forms.MenuStrip();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogedinUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mspMainMenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMainMenue
            // 
            resources.ApplyResources(this.mspMainMenue, "mspMainMenue");
            this.mspMainMenue.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.mspMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peopleToolStripMenuItem,
            this.accountSettingsToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.applicationsToolStripMenuItem});
            this.mspMainMenue.Name = "mspMainMenue";
            // 
            // peopleToolStripMenuItem
            // 
            resources.ApplyResources(this.peopleToolStripMenuItem, "peopleToolStripMenuItem");
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
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
            // usersToolStripMenuItem
            // 
            resources.ApplyResources(this.usersToolStripMenuItem, "usersToolStripMenuItem");
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageApplicationTypesToolStripMenuItem});
            resources.ApplyResources(this.applicationsToolStripMenuItem, "applicationsToolStripMenuItem");
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            // 
            // manageApplicationTypesToolStripMenuItem
            // 
            resources.ApplyResources(this.manageApplicationTypesToolStripMenuItem, "manageApplicationTypesToolStripMenuItem");
            this.manageApplicationTypesToolStripMenuItem.Name = "manageApplicationTypesToolStripMenuItem";
            this.manageApplicationTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
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
    }
}

