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
            this.mspMainMenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMainMenue
            // 
            this.mspMainMenue.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.mspMainMenue.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.mspMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peopleToolStripMenuItem});
            this.mspMainMenue.Location = new System.Drawing.Point(0, 0);
            this.mspMainMenue.Name = "mspMainMenue";
            this.mspMainMenue.Size = new System.Drawing.Size(1404, 56);
            this.mspMainMenue.TabIndex = 1;
            this.mspMainMenue.Text = "menuStrip1";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = global::DVLD.Properties.Resources.patient__1_;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(139, 52);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // frmMainMenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Cyan;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1404, 662);
            this.Controls.Add(this.mspMainMenue);
            this.ForeColor = System.Drawing.Color.LavenderBlush;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mspMainMenue;
            this.Name = "frmMainMenue";
            this.Text = "Driving Lisense Management";
            this.mspMainMenue.ResumeLayout(false);
            this.mspMainMenue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspMainMenue;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
    }
}

