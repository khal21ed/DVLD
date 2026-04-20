using Business;
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
    public partial class frmIssueDrivingLicense : Form
    {
        private clsLicense _license=new clsLicense();
        private clsLocalDrivingLicenseApp _LDLApp;
        private int _LDLAppID;
        public frmIssueDrivingLicense(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID=LDLAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillLicenseObject()
        {
            _license.ApplicationID = _LDLApp.ApplicationID;
            _license.IssueReason = clsLicense.enIssueReason.FirstTime;
            _license.CreatedByUserID = clsSessoin.CurrentUser.ID;
            _license.IssueDate=DateTime.Now;
            _license.LicenseClassID = _LDLApp.LicenseClassID;
            _license.ExpirationDate= DateTime.Now.AddYears
                (clsLicenseClass.GetLicenseClassValidatyLength(_LDLApp.LicenseClassID));
            _license.PaidFees = clsLicenseClass.GetLicenseClassFees(_LDLApp.LicenseClassID);
            _license.Notes=txtNotes.Text;
            _license.IsActive = true;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _LDLApp=clsLocalDrivingLicenseApp.FindLocalDrivingLicenseApp(_LDLAppID);
            _LDLApp.LoadApplication();
            
            _FillLicenseObject();

            if (_license.IssueLicense(_LDLApp.Application.ApplicantPersonID))
            {
                MessageBox.Show($"License has been Issued Successfully License ID={_license.ID}"
                    ,"Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsLocalDrivingLicenseApp.ChangeApplicationStatus(_LDLAppID,
                    clsApplication.enApplicationStatus.Completed);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Error Occured While Issuing the License",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlShowLDLAppInfo1.LoadControl(_LDLAppID);

        }
    }
}
