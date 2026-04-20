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
using static Business.clsTestType;

namespace DVLD.LDLApp
{
    public partial class frmTakeTest : Form
    {
        private int _appointmentID;
        private clsTestAppointment _appointment=new clsTestAppointment();
        private clsTest _test=new clsTest();
        private clsTestType.enTestType _testType;
        private clsLocalDrivingLicenseApp _LDLApp;
        private int _numberOfTrials;
        public frmTakeTest(int appointmentID,clsTestType.enTestType testType)
        {
            InitializeComponent();
            _appointmentID = appointmentID;
            _testType = testType;
        }

        private void _SetFormVisualsBasedOnTestType()
        {
            switch (_testType)
            {
                case clsTestType.enTestType.VisionTest:
                    pbTestImage.Image = Resources.VisionTest;
                    lblTitle.Text = "Take Visoin Test";
                    break;
                case clsTestType.enTestType.WrittenTest:
                    pbTestImage.Image = Resources.WrittenTest;
                    lblTitle.Text = "Take Written Test";
                    break;
                case clsTestType.enTestType.PracticalTest:
                    pbTestImage.Image = Resources.DrivingTest;
                    lblTitle.Text = "Take Steer Test";
                    break;
            }
        }

        private void _LoadFormWithValues()
        {
            lblDLAppIDVal.Text = _appointment.LDLAppID.ToString();
            lblClassVal.Text = clsLicenseClass.GetLicenseClassNameByID(_LDLApp.LicenseClassID);
            lblNameVal.Text = clsPerson.GetPersonFullNameByID(_LDLApp.Application.ApplicantPersonID);
            lblTrialVal.Text = _numberOfTrials.ToString();
            lblDateVal.Text = _appointment.AppointmentDate.ToString("yyyy-MM-dd");
            lblFeesVal.Text = _appointment.PaidFees.ToString();
            _SetFormVisualsBasedOnTestType();

        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
             _appointment = clsTestAppointment.FindAppointmentByID(_appointmentID);

            if(_appointment == null )
            {
                MessageBox.Show("Appointment was not found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            _LDLApp = clsLocalDrivingLicenseApp.FindLocalDrivingLicenseApp(_appointment.LDLAppID);
            _LDLApp.LoadApplication();

            _numberOfTrials = clsTestAppointment.GetNumberOfTrials(_LDLApp.LDLAID, (int)_testType);

            _LoadFormWithValues();

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           DialogResult dialogResult= MessageBox.Show("Are you sure you want to save the result,you won't be able to change it later",
                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.OK)
            {
                if (rbPass.Checked)
                    _test.TestResult = true;
                else
                    _test.TestResult = false;
                _test.AppointmentID = _appointmentID;
                _test.Notes = txtNotes.Text;
                _test.CreatedByUserID = clsSessoin.CurrentUser.ID;

                if (_test.AddNewTest())
                {
                    MessageBox.Show("Test Result Has been saved successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _appointment.LockAppointment();
                    this.Close();
                }
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close ();  
        }
    }
}
