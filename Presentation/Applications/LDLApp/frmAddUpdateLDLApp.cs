using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdateLDLApp : Form
    {
        clsLocalDrivingLicenseApp _LDLApplication;
        int _LDLApplicatoinID = -1;
        public frmAddUpdateLDLApp(int lDLApplicatoinID)
        {
            InitializeComponent();
            _LDLApplicatoinID = lDLApplicatoinID;
            _LDLApplication = new clsLocalDrivingLicenseApp();
        }

 
        private void _FillComboBoxWithLicenseClassNames()
        {
            DataTable _dtLicenseClasses = clsLicenseClass.GetAllLicenseClassNames();
            cbLicenseClass.DataSource = _dtLicenseClasses;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsPersonPicked())
            {
                tcAddUpdateLDLA.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Please select a person first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmAddUpdateLDLApp_Load(object sender, EventArgs e)
        {
            _FillComboBoxWithLicenseClassNames();
            lblFeesValue.Text = clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.NewLocalDrivingLicense).ToString();
            lblCreatedByUserValue.Text = clsSessoin.CurrentUser.UserName;
            lblApplicationDateValue.Text = DateTime.Now.ToString("yyyy-MM-dd");

            if (_LDLApplicatoinID != -1)
            {
               _LDLApplication= clsLocalDrivingLicenseApp.FindLocalDrivingLicenseApp(_LDLApplicatoinID);
                if (_LDLApplication != null)
                {
                    _LDLApplication.LoadApplication();
                    ctrlPersonPicker1.FindPersonAndLoadIntoPersonCard(sender,_LDLApplication.Application.ApplicantPersonID);
                    ctrlPersonPicker1.FindPersonEnabled = false;
                    lblLDLAppIDValue.Text = _LDLApplicatoinID.ToString();
                    cbLicenseClass.SelectedValue = _LDLApplication.LicenseClassID;
                }

            }
          
        }
        private bool IsPersonPicked()
        {
            //There is no person selected
            if (ctrlPersonPicker1.SelectedPersonId == -1)
                return false;
            return true;
        }
        private void _FillApplicatoin()
        {
            _LDLApplication.Application.ApplicantPersonID = ctrlPersonPicker1.SelectedPersonId;
            _LDLApplication.Application.ApplicatoinDate = DateTime.Now;
            //Here we only add Local Driving License Applications so the TypeID is always 2
            _LDLApplication.Application.ApplicationTypeID = 2;
            _LDLApplication.Application.Status = clsApplication.enApplicationStatus.New;
            _LDLApplication.Application.LastStatusDate = DateTime.Now;
            _LDLApplication.Application.PaidFees = clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.NewLocalDrivingLicense);
            _LDLApplication.Application.CreatedByUser = clsSessoin.CurrentUser.ID;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int licenseClassId = (int)cbLicenseClass.SelectedValue;
            if (!IsPersonPicked())
            {
                MessageBox.Show("Please Pick a person first", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLocalDrivingLicenseApp.
                PersonHasLDLAWithSameClassAndInNewStatus(ctrlPersonPicker1.SelectedPersonId, licenseClassId))
            {
                MessageBox.Show("Person already has an active applicatoin with the same License class"
                    ,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsLocalDrivingLicenseApp.PersonHasLDLAWithSameClassAndInCompletedStatus
                (ctrlPersonPicker1.SelectedPersonId, licenseClassId))
            {
                MessageBox.Show("Person already has a license of this class"
                , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_LDLApplication.Mode == clsLocalDrivingLicenseApp.enMode.AddNew)
            {
                _FillApplicatoin();
            }
            _LDLApplication.LicenseClassID = licenseClassId;
            
            if (_LDLApplication.Save())
            {
                MessageBox.Show("Application Saved Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblLDLAppIDValue.Text = _LDLApplication.LDLAID.ToString();
            }
            else
            {
                MessageBox.Show("An Error Ocured while saving", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tcAddUpdateLDLA_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpApplicationInfo)
            {
                if(!IsPersonPicked())
                    e.Cancel = true;
            }
        }
    }
}
