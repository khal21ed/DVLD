using Business;
using DVLD.LDLApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licences.DetainedLicences
{
    public partial class frmDetainLicense : Form
    {
        private clsLicense _license;
        private clsDetainedLicense _detainedLicense;
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ctrlLicensePicker1_OnLicenseSelected(int obj)
        {
            _license = clsLicense.FindLicenseByID(obj);
            if (_license == null)
            {
                btnDetain.Enabled = false;
                llLicenseHistory.Enabled = false;
                return;
            }
            lblLicenseID.Text=_license.ID.ToString();
            llLicenseHistory.Enabled = true;

            if (clsLicense.IsLicenseDetaind(_license.ID))
            {
                MessageBox.Show($"The license with the ID={_license.ID} is already detained", "Detained License",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            btnDetain.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsGlobal.FormatDate(DateTime.Now);
            lblCreatedByUser.Text=clsSessoin.CurrentUser.UserName;
            
        }
        private void _FillDetaindLicense()
        {
            _detainedLicense.DetainDate = DateTime.Now;
            _detainedLicense.FineFees = Convert.ToSingle(txtFineFees.Text);
            _detainedLicense.CreatedByUserID = clsSessoin.CurrentUser.ID;
            _detainedLicense.LicenseID = _license.ID;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFineFees.Text))
            {
                MessageBox.Show("The fine fees field can't be empty", "Empty field", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            _detainedLicense = new clsDetainedLicense();
            _FillDetaindLicense();

            if (_detainedLicense.AddNewDetainedLicense())
            {
                MessageBox.Show($"License has been detained successfully Detain ID={_detainedLicense.DetainID}",
                    "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblDetainID.Text=_detainedLicense.DetainID.ToString();
                llShowDetainedLicense.Enabled = true;
                btnDetain.Enabled = false;
                ctrlLicensePicker1.FindLicenseEnabeled = false;
                return;
            }
            else
            {
                MessageBox.Show("An error occured","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personID=clsPerson.GetPersonIDByDriverID(_license.DriverID);
            frmLicenseHistory frm = new frmLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void llShowDetainedLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfoCard frm=new frmLicenseInfoCard(_license.ID);
            frm.ShowDialog();
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFineFees.Text))
            {
                errProv.SetError(txtFineFees, "This fieald shouldn't be empty");
            }
            else
            {
                errProv.SetError(txtFineFees, "");
            }
        }
    }
}
