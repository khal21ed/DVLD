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
    public partial class frmTestAppointments : Form
    {
        private int _LDLAppID;
        private DataTable _dtAppointmetns;
        private clsTestType.enTestType _testType;
        public frmTestAppointments(int LDLAppID,clsTestType.enTestType testType)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _testType = testType;
        }

        private bool _TryGetSelectedTestAppointmentID(out int appointmentID)
        {
            appointmentID = -1;
            return dgvTestAppointments.SelectedRows.Count > 0 &&
                int.TryParse(dgvTestAppointments.SelectedRows[0].Cells[0].Value.ToString(), out appointmentID);

        }
        private bool _EnsureAppointmentSelected(out int appointmentID)
        {
            if (!_TryGetSelectedTestAppointmentID(out appointmentID))
            {
                MessageBox.Show(
                    "No record was selected. Please select a complete row.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        private void _RefreshDataGrid()
        {
            _dtAppointmetns = clsTestAppointment.GetTestAppointmentsFilteredBy(_LDLAppID, (int)_testType);
            dgvTestAppointments.DataSource = _dtAppointmetns;
            lblTotalRecords.Text=dgvTestAppointments.RowCount.ToString();
        }
        private void _SetFormVisualsBasedOnTestType()
        {
            switch (_testType)
            {
                case clsTestType.enTestType.VisionTest:
                    pbTestImage.Image = Resources.VisionTest;
                    lblTitle.Text = "Vision Test Appointments";
                    break;
                case clsTestType.enTestType.WrittenTest:
                    pbTestImage.Image = Resources.WrittenTest;
                    lblTitle.Text = "Written Test Appointments";
                    break;
                case clsTestType.enTestType.PracticalTest:
                    pbTestImage.Image = Resources.DrivingTest;
                    lblTitle.Text = "Steer Test Appointments";
                    break;
            }
        }

        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {
            _SetFormVisualsBasedOnTestType();
            ctrlShowLDLAppInfo1.LoadControl(_LDLAppID);
            _RefreshDataGrid();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.HasActiveAppointment(_LDLAppID,(int) _testType))
            {
                MessageBox.Show(@"A new appointment can't be schedualed because,
                This person has an active Test Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check if the person has already passed the test
            if (clsTestAppointment.HasPassedTest(_LDLAppID, (int)_testType))
            {
                MessageBox.Show("This Person Has Already Passed the test", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmSchedualTest frm = new frmSchedualTest(_LDLAppID,-1,_testType);
            frm.ShowDialog();
            _RefreshDataGrid();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureAppointmentSelected(out int testAppointID))
                return;

            frmSchedualTest frm = new frmSchedualTest(_LDLAppID, testAppointID,_testType);
            frm.ShowDialog();
            _RefreshDataGrid();
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureAppointmentSelected(out int testAppointID))
                return;

            frmTakeTest frm = new frmTakeTest(testAppointID, _testType);
            frm.ShowDialog();
            _RefreshDataGrid();
        }

        private void cmsOperations_Opening(object sender, CancelEventArgs e)
        {
            DataGridViewRow row = dgvTestAppointments.SelectedRows[0];
            switch (Convert.ToBoolean(row.Cells["IsLocked"].Value))
            {
                case true:
                    takeToolStripMenuItem.Enabled = false;
                    break;

                case false:
                takeToolStripMenuItem.Enabled = true;
                break;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
