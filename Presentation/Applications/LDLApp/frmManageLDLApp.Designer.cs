namespace DVLD
{
    partial class frmManageLDLApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageLDLApp));
            this.lblTotalApplications = new System.Windows.Forms.Label();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.tbFilterByValue = new System.Windows.Forms.TextBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvLDLA = new System.Windows.Forms.DataGridView();
            this.cmsOperationsOnLDLApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canceleApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualTesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.btnAddNewLDLApp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLA)).BeginInit();
            this.cmsOperationsOnLDLApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalApplications
            // 
            this.lblTotalApplications.AutoSize = true;
            this.lblTotalApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalApplications.Location = new System.Drawing.Point(129, 582);
            this.lblTotalApplications.Name = "lblTotalApplications";
            this.lblTotalApplications.Size = new System.Drawing.Size(66, 24);
            this.lblTotalApplications.TabIndex = 14;
            this.lblTotalApplications.Text = "label3";
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(6, 193);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(80, 20);
            this.lblFilterBy.TabIndex = 13;
            this.lblFilterBy.Text = "Filter By:";
            // 
            // tbFilterByValue
            // 
            this.tbFilterByValue.Location = new System.Drawing.Point(313, 193);
            this.tbFilterByValue.MaxLength = 30;
            this.tbFilterByValue.Name = "tbFilterByValue";
            this.tbFilterByValue.Size = new System.Drawing.Size(165, 20);
            this.tbFilterByValue.TabIndex = 12;
            this.tbFilterByValue.TextChanged += new System.EventHandler(this.tbFilterByValue_TextChanged);
            this.tbFilterByValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterByValue_KeyPress);
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.LAppID",
            "National No",
            "Full Name",
            "Status"});
            this.cmbFilterBy.Location = new System.Drawing.Point(98, 193);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(191, 21);
            this.cmbFilterBy.TabIndex = 11;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // dgvLDLA
            // 
            this.dgvLDLA.AllowUserToAddRows = false;
            this.dgvLDLA.AllowUserToDeleteRows = false;
            this.dgvLDLA.AllowUserToOrderColumns = true;
            this.dgvLDLA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLDLA.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLDLA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDLA.ContextMenuStrip = this.cmsOperationsOnLDLApp;
            this.dgvLDLA.Location = new System.Drawing.Point(16, 216);
            this.dgvLDLA.MultiSelect = false;
            this.dgvLDLA.Name = "dgvLDLA";
            this.dgvLDLA.ReadOnly = true;
            this.dgvLDLA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLDLA.Size = new System.Drawing.Size(1125, 344);
            this.dgvLDLA.TabIndex = 10;
            // 
            // cmsOperationsOnLDLApp
            // 
            this.cmsOperationsOnLDLApp.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsOperationsOnLDLApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.canceleApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.schedualTesToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showDrivingLicenseToolStripMenuItem,
            this.showLicenseHistoryToolStripMenuItem});
            this.cmsOperationsOnLDLApp.Name = "cmsOperationsOnLDLApp";
            this.cmsOperationsOnLDLApp.Size = new System.Drawing.Size(289, 196);
            this.cmsOperationsOnLDLApp.Opening += new System.ComponentModel.CancelEventHandler(this.cmsOperationsOnLDLApp_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showApplicationDetailsToolStripMenuItem.Image")));
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // canceleApplicationToolStripMenuItem
            // 
            this.canceleApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("canceleApplicationToolStripMenuItem.Image")));
            this.canceleApplicationToolStripMenuItem.Name = "canceleApplicationToolStripMenuItem";
            this.canceleApplicationToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.canceleApplicationToolStripMenuItem.Text = "Cancele Application";
            this.canceleApplicationToolStripMenuItem.Click += new System.EventHandler(this.canceleApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteApplicationToolStripMenuItem.Image")));
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // schedualTesToolStripMenuItem
            // 
            this.schedualTesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItemVisionTest,
            this.cmsItemWrittenTest,
            this.cmsItemStreetTest});
            this.schedualTesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("schedualTesToolStripMenuItem.Image")));
            this.schedualTesToolStripMenuItem.Name = "schedualTesToolStripMenuItem";
            this.schedualTesToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.schedualTesToolStripMenuItem.Text = "Schedule Tests";
            // 
            // cmsItemVisionTest
            // 
            this.cmsItemVisionTest.Image = ((System.Drawing.Image)(resources.GetObject("cmsItemVisionTest.Image")));
            this.cmsItemVisionTest.Name = "cmsItemVisionTest";
            this.cmsItemVisionTest.Size = new System.Drawing.Size(221, 24);
            this.cmsItemVisionTest.Text = "Schedual Vision Test";
            this.cmsItemVisionTest.Click += new System.EventHandler(this.cmsItemVisionTest_Click);
            // 
            // cmsItemWrittenTest
            // 
            this.cmsItemWrittenTest.Image = ((System.Drawing.Image)(resources.GetObject("cmsItemWrittenTest.Image")));
            this.cmsItemWrittenTest.Name = "cmsItemWrittenTest";
            this.cmsItemWrittenTest.Size = new System.Drawing.Size(221, 24);
            this.cmsItemWrittenTest.Text = "Schedual Written Test";
            this.cmsItemWrittenTest.Click += new System.EventHandler(this.cmsItemWrittenTest_Click);
            // 
            // cmsItemStreetTest
            // 
            this.cmsItemStreetTest.Image = ((System.Drawing.Image)(resources.GetObject("cmsItemStreetTest.Image")));
            this.cmsItemStreetTest.Name = "cmsItemStreetTest";
            this.cmsItemStreetTest.Size = new System.Drawing.Size(221, 24);
            this.cmsItemStreetTest.Text = "Schedual Street Test";
            this.cmsItemStreetTest.Click += new System.EventHandler(this.cmsItemStreetTest_Click);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("issueDrivingLicenseFirstTimeToolStripMenuItem.Image")));
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License(First Time)";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showDrivingLicenseToolStripMenuItem
            // 
            this.showDrivingLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDrivingLicenseToolStripMenuItem.Image")));
            this.showDrivingLicenseToolStripMenuItem.Name = "showDrivingLicenseToolStripMenuItem";
            this.showDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.showDrivingLicenseToolStripMenuItem.Text = "Show Driving License Details";
            this.showDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.showDrivingLicenseToolStripMenuItem_Click);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(272, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(604, 33);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mangae Local Driving License Apllicatoins";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(12, 582);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(111, 24);
            this.lblRecord.TabIndex = 16;
            this.lblRecord.Text = "# Records:";
            // 
            // btnAddNewLDLApp
            // 
            this.btnAddNewLDLApp.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewLDLApp.Image")));
            this.btnAddNewLDLApp.Location = new System.Drawing.Point(1076, 169);
            this.btnAddNewLDLApp.Name = "btnAddNewLDLApp";
            this.btnAddNewLDLApp.Size = new System.Drawing.Size(57, 45);
            this.btnAddNewLDLApp.TabIndex = 15;
            this.btnAddNewLDLApp.UseVisualStyleBackColor = true;
            this.btnAddNewLDLApp.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(496, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageLDLApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 622);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnAddNewLDLApp);
            this.Controls.Add(this.lblTotalApplications);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.tbFilterByValue);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.dgvLDLA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageLDLApp";
            this.ShowIcon = false;
            this.Text = "Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageLDLApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLA)).EndInit();
            this.cmsOperationsOnLDLApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewLDLApp;
        private System.Windows.Forms.Label lblTotalApplications;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.TextBox tbFilterByValue;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.DataGridView dgvLDLA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.ContextMenuStrip cmsOperationsOnLDLApp;
        private System.Windows.Forms.ToolStripMenuItem canceleApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualTesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItemVisionTest;
        private System.Windows.Forms.ToolStripMenuItem cmsItemWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem cmsItemStreetTest;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}