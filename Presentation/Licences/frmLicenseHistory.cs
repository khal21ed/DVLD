using Business;
using DVLD.Lıcences.InternatıonalLıcense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LDLApp
{
    public partial class frmLicenseHistory : Form
    {
        private int _personID;

        public frmLicenseHistory(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }
  
        private void _ChangeLocalLicensesGridViewHeadders()
        {
            dgvLocalDrivingLicenses.Columns["LicenseID"].HeaderText = "Lic ID";
            dgvLocalDrivingLicenses.Columns["ApplicationID"].HeaderText = "App ID";
            dgvLocalDrivingLicenses.Columns["ClassName"].HeaderText = "Class Name";
            dgvLocalDrivingLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvLocalDrivingLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvLocalDrivingLicenses.Columns["IsActive"].HeaderText = "Is Active";

        }

        private void _ChangeInternationalLicensesGridViewHeadders()
        {
            dgvInternationalLicenses.Columns["InternationalLicenseID"].HeaderText = "Int.License ID";
            dgvInternationalLicenses.Columns["ApplicationID"].HeaderText = "App ID";
            dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L.License ID";
            dgvInternationalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvInternationalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvInternationalLicenses.Columns["IsActive"].HeaderText = "Is Active";
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {

            ctrlPersonPicker1.FindPersonAndLoadIntoPersonCard(sender, _personID);
            ctrlPersonPicker1.FindPersonEnabled = false;

            dgvLocalDrivingLicenses.DataSource = clsLicense.GetAllLocalLicensesPerPerson(_personID);
            lblTotalLocalLicenses.Text=dgvLocalDrivingLicenses.RowCount.ToString();
            _ChangeLocalLicensesGridViewHeadders();

            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetAllInternationalLicensesPerPerson(_personID);
            lblTotalInternationalLicenses.Text = dgvInternationalLicenses.RowCount.ToString();
            _ChangeInternationalLicensesGridViewHeadders();

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvLocalDrivingLicenses.SelectedRows[0].Cells[0].Value.
                ToString(), out int localLicenseID))
            {

                frmLicenseInfoCard frm = new frmLicenseInfoCard(localLicenseID);
                frm.ShowDialog();
            }
            
        }

        private void showInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if( int.TryParse(dgvInternationalLicenses.SelectedRows[0].Cells[0].Value.
                ToString(), out int intLicenseID))
            {
                frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(intLicenseID);
                frm.ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
