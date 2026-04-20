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
    public partial class ctrlShowLDLAppInfo : UserControl
    {
        private int _LDLAppID;
        private clsLocalDrivingLicenseApp _LDLApp;
        private byte _passedTests;
        private string _personFullName;
        public ctrlShowLDLAppInfo()
        {
            InitializeComponent();
        }
        


        private void _FillLabelsWithValues()
        {
            lblDLAppIDValue.Text = _LDLApp.LDLAID.ToString();
            lblLicenseClassValue.Text = clsLicenseClass.GetLicenseClassNameByID(_LDLApp.LicenseClassID);
            lblPassedTestsValue.Text = _passedTests.ToString()+"/3";
            lblAppID.Text=_LDLApp.Application.ID.ToString();
            lblStatusValue.Text=_LDLApp.Application.Status.ToString();
            lblFeesValue.Text=_LDLApp.Application.PaidFees.ToString();
            lblApplicantValue.Text = clsPerson.GetPersonFullNameByID(_LDLApp.Application.ApplicantPersonID);
            lblDateValue.Text=_LDLApp.Application.ApplicatoinDate.ToString("yyyy-MM-dd");
            lblStatusDateValue.Text=_LDLApp.Application.LastStatusDate.ToString("yyyy-MM-dd");
            lblCreatedByUserValue.Text=clsUser.GetUserNameByID(_LDLApp.Application.CreatedByUser);
            lblAppTypeVal.Text = clsApplicationTypes.ApplicationTypeToText
                (((clsApplicationTypes.enApplicatoinType)_LDLApp.Application.ApplicationTypeID));
        }
        private void _LoadApplicationControl(int LDLAppID)
        {
            _LDLAppID = LDLAppID;
            _LDLApp=clsLocalDrivingLicenseApp.FindLocalDrivingLicenseApp(LDLAppID);
            if (_LDLApp == null)
                return;

            _LDLApp.LoadApplication();
            _passedTests = _LDLApp.GetNumberOfTestsPassed();
            _FillLabelsWithValues();

            if (!clsLicense.HasLicenseByLDLAppID(LDLAppID))
            {
                llShowLicenseInfo.Enabled= false;
            }
            
        }
        public void LoadControl(int LDLAppID)
        {
            _LoadApplicationControl(LDLAppID);
        }
        private void llPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDetails frm = new frmShowPersonDetails(_LDLApp.Application.ApplicantPersonID);
            frm.ShowDialog();
            lblApplicantValue.Text = clsPerson.GetPersonFullNameByID(_LDLApp.Application.ApplicantPersonID);
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int licenseID = clsLicense.GetLicenseIDByLDLAppID(_LDLAppID);

            frmLicenseInfoCard frm = new frmLicenseInfoCard(licenseID);
            frm.ShowDialog();
        }
    }
}
