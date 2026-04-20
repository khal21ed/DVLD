using Business;
using DVLD.Properties;
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

namespace DVLD.LDLApp
{
    public partial class ctrlLicenseInfo : UserControl
    {
        private clsLicenseCardInfo _licenseCardInfo;
        private bool IsDesignTime =>
    LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        private void _SetCardPicture()
        {
            if (_licenseCardInfo.ImagePath != null)
            {
                pbPersonImage.Image = clsGlobal.LoadImage(_licenseCardInfo.ImagePath);
            }
            else
            {
                if (_licenseCardInfo.Gender == clsPerson.enGender.Male)
                    pbPersonImage.Image = Resources.person_man;
                else
                    pbPersonImage.Image = Resources.person_woman;
            }
        }
        private void ResetLicenseCardLabels()
        {
            lblClass.Text = "???";
            lblName.Text = "???";
            lblLicenseID.Text = "???";
            lblNationalNo.Text = "???";
            lblIssueDate.Text = "???";
            lblIssueReason.Text = "???";
            lblNotes.Text = "???";
            lblIsActive.Text = "???";
            lblDateOfBirth.Text = "???";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "???";
            lblIsDetained.Text = "???";
            lblGender.Text = "???";
            pbPersonImage.Image = Resources.person_man ; 
        }


        public void LoadControl(int licenseID)
        {
            _licenseCardInfo = clsLicense.GetLicenseCardInfo(licenseID);

            if (_licenseCardInfo == null)
            {
                MessageBox.Show($"Driving License with the ID={licenseID} was not found",
                    "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetLicenseCardLabels();
                return;
            }

            lblClass.Text = _licenseCardInfo.ClassName;
            lblName.Text = _licenseCardInfo.FullName;
            lblLicenseID.Text = _licenseCardInfo.LicenseID.ToString();
            lblNationalNo.Text = _licenseCardInfo.NationalNo;
            lblIssueDate.Text = _licenseCardInfo.IssueDate.ToString("yyyy-MM-dd");
            lblIssueReason.Text = _licenseCardInfo.IssueReason.ToSpacedString();
            lblNotes.Text = string.IsNullOrWhiteSpace(_licenseCardInfo.Notes)?"No notes":_licenseCardInfo.Notes;
            lblIsActive.Text = _licenseCardInfo.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _licenseCardInfo.DateOfBirth.ToString("yyyy-MM-dd");
            lblDriverID.Text = _licenseCardInfo.DriverID.ToString();
            lblExpirationDate.Text = _licenseCardInfo.ExpirationDate.ToString("yyyy-MM-dd");
            lblIsDetained.Text = _licenseCardInfo.IsDetained ? "Yes" : "No";

            if (_licenseCardInfo.Gender == clsPerson.enGender.Male)
            {
                pbGender.Image = Resources.man;
                lblGender.Text = "Male";
            }
            else
            {
                pbGender.Image = Resources.woman;
                lblGender.Text = "Female";
            }
            _SetCardPicture();


        }
    }
}
