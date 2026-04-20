using Business;
using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Lıcences.InternatıonalLıcense
{

    public partial class ctrlInternationalLicenseCard : UserControl
    {
        private clsInternationalLicenseCardInfo _intLicenseCardInfo;
        public ctrlInternationalLicenseCard()
        {
            InitializeComponent();
        }
        private void _SetCardPicture()
        {
            if (_intLicenseCardInfo.ImagePath != null)
            {
                pbPersonImage.Image = clsGlobal.LoadImage(_intLicenseCardInfo.ImagePath);
            }
            else
            {
                if (_intLicenseCardInfo.Gender == clsPerson.enGender.Male)
                    pbPersonImage.Image = Resources.person_man;
                else
                    pbPersonImage.Image = Resources.person_woman;
            }
        }
        public void LoadControl(int intLicenseID)
        {
             _intLicenseCardInfo=clsInternationalLicense.GetInternationalLicenseCardInfoDTO(intLicenseID);

            if (_intLicenseCardInfo == null)
                return;

            lblName.Text = _intLicenseCardInfo.FullName;
            lblIntLicenseID.Text = _intLicenseCardInfo.IntLicenseID.ToString();
            lblLicenseID.Text=_intLicenseCardInfo.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text=_intLicenseCardInfo.NationalNo.ToString();    
            lblIssueDate.Text=_intLicenseCardInfo.IssueDate.ToString("yyyy-MM-dd");
            lblApplicationID.Text=_intLicenseCardInfo.ApplicationID.ToString();
            lblIsActive.Text = _intLicenseCardInfo.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _intLicenseCardInfo.DateOfBirth.ToString("yyyy-MM-dd");
            lblDriverID.Text=_intLicenseCardInfo.DriverID.ToString();
            lblExpirationDate.Text = _intLicenseCardInfo.ExpirationDate.ToString("yyyy-MM-dd");

            if (_intLicenseCardInfo.Gender == clsPerson.enGender.Male)
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
