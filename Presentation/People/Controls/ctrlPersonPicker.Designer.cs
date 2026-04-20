namespace DVLD
{
    partial class ctrlPersonPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonPicker));
            this.cmbFindBy = new System.Windows.Forms.ComboBox();
            this.txtFindBy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.gbFindPerson = new System.Windows.Forms.GroupBox();
            this.ctrlShowPersonInfo1 = new DVLD.ctrlShowPersonInfo();
            this.gbFindPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbFindBy
            // 
            this.cmbFindBy.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFindBy.FormattingEnabled = true;
            this.cmbFindBy.Items.AddRange(new object[] {
            "Person ID",
            "NationlNo"});
            this.cmbFindBy.Location = new System.Drawing.Point(93, 22);
            this.cmbFindBy.Name = "cmbFindBy";
            this.cmbFindBy.Size = new System.Drawing.Size(143, 26);
            this.cmbFindBy.TabIndex = 1;
            this.cmbFindBy.SelectedIndexChanged += new System.EventHandler(this.cmbFindBy_SelectedIndexChanged);
            // 
            // txtFindBy
            // 
            this.txtFindBy.Location = new System.Drawing.Point(253, 22);
            this.txtFindBy.Name = "txtFindBy";
            this.txtFindBy.Size = new System.Drawing.Size(162, 24);
            this.txtFindBy.TabIndex = 2;
            this.txtFindBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindBy_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find By:";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.Image")));
            this.btnAddPerson.Location = new System.Drawing.Point(472, 15);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(45, 43);
            this.btnAddPerson.TabIndex = 4;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnFindPerson.Image")));
            this.btnFindPerson.Location = new System.Drawing.Point(421, 14);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(45, 43);
            this.btnFindPerson.TabIndex = 0;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // gbFindPerson
            // 
            this.gbFindPerson.Controls.Add(this.btnAddPerson);
            this.gbFindPerson.Controls.Add(this.btnFindPerson);
            this.gbFindPerson.Controls.Add(this.label1);
            this.gbFindPerson.Controls.Add(this.txtFindBy);
            this.gbFindPerson.Controls.Add(this.cmbFindBy);
            this.gbFindPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFindPerson.Location = new System.Drawing.Point(3, 3);
            this.gbFindPerson.Name = "gbFindPerson";
            this.gbFindPerson.Size = new System.Drawing.Size(621, 54);
            this.gbFindPerson.TabIndex = 6;
            this.gbFindPerson.TabStop = false;
            this.gbFindPerson.Text = "Find Person";
            // 
            // ctrlShowPersonInfo1
            // 
            this.ctrlShowPersonInfo1.Location = new System.Drawing.Point(0, 81);
            this.ctrlShowPersonInfo1.Name = "ctrlShowPersonInfo1";
            this.ctrlShowPersonInfo1.Size = new System.Drawing.Size(718, 237);
            this.ctrlShowPersonInfo1.TabIndex = 0;
            // 
            // ctrlPersonPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFindPerson);
            this.Controls.Add(this.ctrlShowPersonInfo1);
            this.Name = "ctrlPersonPicker";
            this.Size = new System.Drawing.Size(713, 336);
            this.Load += new System.EventHandler(this.ctrlAddUpdateUser_Load);
            this.gbFindPerson.ResumeLayout(false);
            this.gbFindPerson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowPersonInfo ctrlShowPersonInfo1;
        private System.Windows.Forms.ComboBox cmbFindBy;
        private System.Windows.Forms.TextBox txtFindBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.GroupBox gbFindPerson;
    }
}
