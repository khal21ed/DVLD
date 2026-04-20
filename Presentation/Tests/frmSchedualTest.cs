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

namespace DVLD.LDLApp
{
    public partial class frmSchedualTest : Form
    {
        private int _LDLAppID;
        private clsLocalDrivingLicenseApp _LDLApp;
        private int _TestAppointmentID;
        private clsTestAppointment _TestAppointment=new clsTestAppointment();
        private int _NumberOfTrials;
        private float _TestFees;
        private clsTestType.enTestType _testType;
        public frmSchedualTest(int LDLAppID,int testAppointmentID,clsTestType.enTestType testType)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _TestAppointmentID = testAppointmentID;
           _testType = testType;
         
        }

        private void _FillTheControl()
        {
            if (_NumberOfTrials > 0)
                lblTitle.Text = "Schedual Retake Test";

            lblDLAppIDVal.Text=_LDLAppID.ToString();
            lblClassVal.Text=clsLicenseClass.GetLicenseClassNameByID(_LDLApp.LicenseClassID);
            lblNameVal.Text=clsPerson.GetPersonFullNameByID(_LDLApp.Application.ApplicantPersonID);
            lblTrialVal.Text = _NumberOfTrials.ToString();
            lblFeesVal.Text = _TestFees.ToString();
            if(_NumberOfTrials > 0)
            {
                float retakeAppFees = clsApplicationTypes.
                    GetApplicatoinTypeFee(clsApplicationTypes.enApplicatoinType.RetakeTest);
                lblTotalFees.Text = (_TestFees+retakeAppFees).ToString();
                lblRetakeAppFees.Text = retakeAppFees.ToString();
                
            }

        }

        private void _SetFormVisualsBasedOnTestType()
        {
            switch (_testType)
            {
                case clsTestType.enTestType.VisionTest:
                    pbTestImage.Image = Resources.VisionTest;
                    lblTitle.Text = "Visoin Test";
                    break;
                case clsTestType.enTestType.WrittenTest:
                    pbTestImage.Image = Resources.WrittenTest;
                    lblTitle.Text = "Written Test";
                    break;
                case clsTestType.enTestType.PracticalTest:
                    pbTestImage.Image = Resources.DrivingTest;
                    lblTitle.Text = "Steer Test";
                    break;
            }
        }
        private void frmAddUpdateTestAppointmen_Load(object sender, EventArgs e)
        {
            

            _LDLApp = clsLocalDrivingLicenseApp.FindLocalDrivingLicenseApp(_LDLAppID);
            _LDLApp.LoadApplication();

            _NumberOfTrials = clsTestAppointment.GetNumberOfTrials(_LDLAppID, (int)_testType);
            _TestFees = clsTestType.GetTestTypeFees((int)_testType);
            

            if (_TestAppointmentID != -1)
            {
                _TestAppointment = clsTestAppointment.FindAppointmentByID(_TestAppointmentID);
                if (_TestAppointment == null)
                {
                    _TestAppointment = new clsTestAppointment();
                }
                else
                {
                    dtpAppointmentDate.Value = _TestAppointment.AppointmentDate.Date;
                    if (_TestAppointment.IsLocked == true)
                    {
                        btnSave.Enabled = false;
                        lblNoEditingAllowed.Visible = true;
                        dtpAppointmentDate.Enabled = false;
                    }

                }
            }
            dtpAppointmentDate.MinDate = DateTime.Now.AddDays(1);
            dtpAppointmentDate.MaxDate = DateTime.Now.AddDays(120);

            if ( _NumberOfTrials == 0 )
            {
                gbRetakeTest.Enabled = false;
            }
            _FillTheControl();
            _SetFormVisualsBasedOnTestType();
        }
        private int _AddARetakeApplication()
        {
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = _LDLApp.Application.ApplicantPersonID;
            application.PaidFees = clsApplicationTypes.GetApplicatoinTypeFee
                (clsApplicationTypes.enApplicatoinType.RetakeTest);
            application.Status = clsApplication.enApplicationStatus.New;
            application.LastStatusDate = DateTime.Now;
            application.ApplicatoinDate = DateTime.Now;
            application.ApplicationTypeID = (int)clsApplicationTypes.enApplicatoinType.RetakeTest;
            application.CreatedByUser = clsSessoin.CurrentUser.ID;
            application.AddNewApplication();
            return application.ID;
        }
        private bool _SaveAppointment()
        {
            _TestAppointment.TestTypeID = (int)_testType; 
            _TestAppointment.LDLAppID = _LDLAppID;
            _TestAppointment.AppointmentDate=dtpAppointmentDate.Value;
            _TestAppointment.PaidFees = _TestFees;
            _TestAppointment.CreatedByUserID = clsSessoin.CurrentUser.ID;

            if (_NumberOfTrials == 0)
            {//First appointment
                _TestAppointment.RetakeTestApplicationID = -1;
            }
            else 
            {   //Retaking Test
                int retakeAppID = _AddARetakeApplication();
                _TestAppointment.RetakeTestApplicationID=retakeAppID;
                lblREtakeAppID.Text = retakeAppID.ToString();
            }
            

            if (_TestAppointment.Save())
            {
                MessageBox.Show("Appointment has been placed successfully", "Success"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("an error occured when trying to save your appointment","error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_SaveAppointment())
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
