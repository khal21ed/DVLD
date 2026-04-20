namespace DVLD.Lıcences.InternatıonalLıcense
{
    partial class frmManageInternationalLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageInternationalLicenses));
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblTotalIntLicenses = new System.Windows.Forms.Label();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.txtFilterByValue = new System.Windows.Forms.TextBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvIntLicenses = new System.Windows.Forms.DataGridView();
            this.cmsOperations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewLDLApp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntLicenses)).BeginInit();
            this.cmsOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(8, 580);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(111, 24);
            this.lblRecord.TabIndex = 25;
            this.lblRecord.Text = "# Records:";
            // 
            // lblTotalIntLicenses
            // 
            this.lblTotalIntLicenses.AutoSize = true;
            this.lblTotalIntLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIntLicenses.Location = new System.Drawing.Point(125, 580);
            this.lblTotalIntLicenses.Name = "lblTotalIntLicenses";
            this.lblTotalIntLicenses.Size = new System.Drawing.Size(66, 24);
            this.lblTotalIntLicenses.TabIndex = 23;
            this.lblTotalIntLicenses.Text = "label3";
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBy.Location = new System.Drawing.Point(2, 191);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(80, 20);
            this.lblFilterBy.TabIndex = 22;
            this.lblFilterBy.Text = "Filter By:";
            // 
            // txtFilterByValue
            // 
            this.txtFilterByValue.Location = new System.Drawing.Point(309, 191);
            this.txtFilterByValue.MaxLength = 30;
            this.txtFilterByValue.Name = "txtFilterByValue";
            this.txtFilterByValue.Size = new System.Drawing.Size(165, 20);
            this.txtFilterByValue.TabIndex = 21;
            this.txtFilterByValue.TextChanged += new System.EventHandler(this.tbFilterByValue_TextChanged);
            this.txtFilterByValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterByValue_KeyPress);
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "None",
            "Int.License ID",
            "Application ID",
            "Driver ID",
            "L.License ID"});
            this.cmbFilterBy.Location = new System.Drawing.Point(94, 191);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(191, 21);
            this.cmbFilterBy.TabIndex = 20;
            this.cmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cmbFilterBy_SelectedIndexChanged);
            // 
            // dgvIntLicenses
            // 
            this.dgvIntLicenses.AllowUserToAddRows = false;
            this.dgvIntLicenses.AllowUserToDeleteRows = false;
            this.dgvIntLicenses.AllowUserToOrderColumns = true;
            this.dgvIntLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIntLicenses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvIntLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntLicenses.ContextMenuStrip = this.cmsOperations;
            this.dgvIntLicenses.Location = new System.Drawing.Point(12, 214);
            this.dgvIntLicenses.MultiSelect = false;
            this.dgvIntLicenses.Name = "dgvIntLicenses";
            this.dgvIntLicenses.ReadOnly = true;
            this.dgvIntLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIntLicenses.Size = new System.Drawing.Size(880, 344);
            this.dgvIntLicenses.TabIndex = 19;
            // 
            // cmsOperations
            // 
            this.cmsOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonToolStripMenuItem,
            this.showLicenseHistoryToolStripMenuItem,
            this.showLicenseIToolStripMenuItem});
            this.cmsOperations.Name = "cmsOperations";
            this.cmsOperations.Size = new System.Drawing.Size(187, 70);
            // 
            // showPersonToolStripMenuItem
            // 
            this.showPersonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showPersonToolStripMenuItem.Image")));
            this.showPersonToolStripMenuItem.Name = "showPersonToolStripMenuItem";
            this.showPersonToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showPersonToolStripMenuItem.Text = "Show Person Details";
            this.showPersonToolStripMenuItem.Click += new System.EventHandler(this.showPersonToolStripMenuItem_Click);
            // 
            // showLicenseHistoryToolStripMenuItem
            // 
            this.showLicenseHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseHistoryToolStripMenuItem.Image")));
            this.showLicenseHistoryToolStripMenuItem.Name = "showLicenseHistoryToolStripMenuItem";
            this.showLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showLicenseHistoryToolStripMenuItem.Text = "Show License History";
            this.showLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicenseHistoryToolStripMenuItem_Click);
            // 
            // showLicenseIToolStripMenuItem
            // 
            this.showLicenseIToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseIToolStripMenuItem.Image")));
            this.showLicenseIToolStripMenuItem.Name = "showLicenseIToolStripMenuItem";
            this.showLicenseIToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showLicenseIToolStripMenuItem.Text = "Show License Details";
            this.showLicenseIToolStripMenuItem.Click += new System.EventHandler(this.showLicenseIToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(236, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 33);
            this.label1.TabIndex = 18;
            this.label1.Text = "International License Aplications";
            // 
            // btnAddNewLDLApp
            // 
            this.btnAddNewLDLApp.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewLDLApp.Image")));
            this.btnAddNewLDLApp.Location = new System.Drawing.Point(835, 167);
            this.btnAddNewLDLApp.Name = "btnAddNewLDLApp";
            this.btnAddNewLDLApp.Size = new System.Drawing.Size(57, 45);
            this.btnAddNewLDLApp.TabIndex = 24;
            this.btnAddNewLDLApp.UseVisualStyleBackColor = true;
            this.btnAddNewLDLApp.Click += new System.EventHandler(this.btnAddNewLDLApp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(380, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 615);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.btnAddNewLDLApp);
            this.Controls.Add(this.lblTotalIntLicenses);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.txtFilterByValue);
            this.Controls.Add(this.cmbFilterBy);
            this.Controls.Add(this.dgvIntLicenses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageInternationalLicenses";
            this.ShowIcon = false;
            this.Text = "Manage International Driving Licenses";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntLicenses)).EndInit();
            this.cmsOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Button btnAddNewLDLApp;
        private System.Windows.Forms.Label lblTotalIntLicenses;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.TextBox txtFilterByValue;
        private System.Windows.Forms.ComboBox cmbFilterBy;
        private System.Windows.Forms.DataGridView dgvIntLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsOperations;
        private System.Windows.Forms.ToolStripMenuItem showPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseIToolStripMenuItem;
    }
}