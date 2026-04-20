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

namespace DVLD.Lıcences.InternatıonalLıcense
{
    public partial class frmIssueInternationalLicense : Form
    {
        private clsLicense _license;
        private clsInternationalLicense _intLicense;
        public frmIssueInternationalLicense()
        {
            InitializeComponent();
        }

            
        private void ctrlLicensePicker1_OnLicenseSelected_1(int obj)
        {
            _license=clsLicense.FindLicenseByID(obj);
            if (_license == null)
            {
                llLicenseHistory.Enabled = false;
                btnIssue.Enabled = false;
                return;
            }

            llLicenseHistory.Enabled=true;
            lblLocalLicenseID.Text=_license.ID.ToString();

            if (clsInternationalLicense.HasInternationalLicenseByLDLID(_license.ID,out int intLicenseID))
            {
                MessageBox.Show($"Person Already has an international license with ID={intLicenseID}",
                    "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;


        }

        private void frmIssueInternationalLicense_Load(object sender, EventArgs e)
        {
            lblIssueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblAppDate.Text= DateTime.Now.ToString("yyyy-MM-dd");
            lblFees.Text = clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.NewInternationalLicense).ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedByUser.Text=clsSessoin.CurrentUser.UserName;

        }

        private void _FillApplication(clsApplication app)
        {
            app.ApplicantPersonID = clsPerson.GetPersonIDByDriverID(_license.DriverID);
            app.Status = clsApplication.enApplicationStatus.New;
            app.PaidFees = clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.NewInternationalLicense);
            app.ApplicatoinDate = DateTime.Now;
            app.CreatedByUser = clsSessoin.CurrentUser.ID;
            app.LastStatusDate = DateTime.Now;
            app.ApplicationTypeID = (int)clsApplicationTypes.enApplicatoinType.NewInternationalLicense;

        }
        private void _FillInternationalLicense(clsInternationalLicense intLicense)
        {
            intLicense.IssuedUsingLocalLicenseID = _license.ID;
            intLicense.IssueDate=DateTime.Now;
            intLicense.ExpiratinoDate = DateTime.Now.AddYears(1);
            intLicense.CreatedByUserID=clsSessoin.CurrentUser.ID;
            intLicense.DriverID= _license.DriverID;
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int personID = clsPerson.GetPersonIDByDriverID(_license.DriverID);
            frmLicenseHistory frm = new frmLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (!_license.IsActive)
            {
                MessageBox.Show("You license is inactive please activate it first", "Faild",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_license.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("Your License is expired please issue a new one first","Faild",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }
            
            clsApplication app=new clsApplication();
            _FillApplication(app);

            if (!app.AddNewApplication())
            {
                MessageBox.Show("An Error occured the application couldn't be saved", "Faild",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

             _intLicense=new clsInternationalLicense();
            _intLicense.ApplicationID = app.ID;
            _FillInternationalLicense(_intLicense);

            if (_intLicense.IssueDrivingLicense())
            {
                MessageBox.Show($"International Licnse has been issued successfully License ID= {_intLicense.ID}",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                llLicenseInfo.Enabled= true;
                btnIssue.Enabled= false;
                lblAppID.Text = app.ID.ToString();
                lblIntLicenseID.Text = _intLicense.ID.ToString();
                ctrlLicensePicker1.FindLicenseEnabeled = false;

                return;
            }
            else
            {
                MessageBox.Show("An Error occured while issuing your license","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }
        }

        private void llLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(_intLicense.ID);
            frm.ShowDialog();
        }
    }
}
