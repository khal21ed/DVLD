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

namespace DVLD
{
    public partial class frmManageLDLApp : Form
    {
        public frmManageLDLApp()
        {
            InitializeComponent();
        }
        private DataTable _dtLDLApps;

        private bool _TryGetSelectedLDLAppID(out int LDLAppID)
        {
            LDLAppID = -1;
            return dgvLDLA.SelectedRows.Count > 0 &&
                int.TryParse(dgvLDLA.SelectedRows[0].Cells[0].Value.ToString(), out LDLAppID);

        }
        private bool _EnsureApplicationSelected(out int LDLAppID)
        {
            if (!_TryGetSelectedLDLAppID(out LDLAppID))
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

        private void _SetDataGridColumnNamesAndWidth()
        {
            dgvLDLA.Columns["DrivingClass"].HeaderText = "Driving Class";
            dgvLDLA.Columns["NationalNo"].HeaderText = "National No";
            dgvLDLA.Columns["ApplicationDate"].HeaderText = "Application Date";
            dgvLDLA.Columns["PassedTests"].HeaderText = "Passed Tests";

            dgvLDLA.Columns["DrivingClass"].FillWeight = 150;
            dgvLDLA.Columns["FullName"].FillWeight = 150;


        }
        private void _RefreshPeopleDataGrid()
        {
            _dtLDLApps = clsLocalDrivingLicenseApp.GetAllLocalDrivingLicenses();
            dgvLDLA.DataSource = _dtLDLApps;
            _SetDataGridColumnNamesAndWidth();
            lblTotalApplications.Text = dgvLDLA.DisplayedRowCount(false).ToString();

        }
        private void _InitalizeFormLayout()
        {
            this.BackColor = Color.White;

            dgvLDLA.DefaultCellStyle.ForeColor = Color.Black;
            dgvLDLA.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvLDLA.EnableHeadersVisualStyles = false;

            lblTotalApplications.ForeColor = Color.Black;
            lblFilterBy.ForeColor = Color.Black;
            lblRecord.ForeColor = Color.Black;
        }
        private void _ApplyFilter()
        {
            string[] filterColumns = { "None", "L.D.L.AppID", "NationalNo", "FullName", "Status" };
            if (_dtLDLApps == null) return;

            string column = filterColumns[cmbFilterBy.SelectedIndex];
            string value=tbFilterByValue.Text.Trim();

            if (string.IsNullOrEmpty(value) ||column=="None")
            {
                _dtLDLApps.DefaultView.RowFilter = "";
                return;
            }
            else if (column == "L.D.L.AppID")
            {
                _dtLDLApps.DefaultView.RowFilter = $"[{column}]={value}";
                   
            }
            else
            {
                _dtLDLApps.DefaultView.RowFilter = $"[{column}] like '%{value}%'";
            }
            lblTotalApplications.Text=  dgvLDLA.RowCount.ToString();

        }
        private void frmManageLDLApp_Load(object sender, EventArgs e)
        {
            _InitalizeFormLayout();
            _RefreshPeopleDataGrid();
            cmbFilterBy.SelectedIndex = 0;
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(cmbFilterBy.SelectedIndex ==0)//None
            {
                tbFilterByValue.Enabled = false;
            }
            else
            {
                tbFilterByValue.Enabled = true;
            }
                tbFilterByValue.Text = string.Empty;
            _ApplyFilter();
        }
        private void tbFilterByValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }
        private void tbFilterByValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.SelectedIndex == 1 )
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdateLDLApp frm= new frmAddUpdateLDLApp(-1);
            frm.ShowDialog();
            _RefreshPeopleDataGrid();
        }

        private void canceleApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;

            if (clsLocalDrivingLicenseApp.CancelLDLApp(LDLAppID))
                MessageBox.Show("Application Has Been Cancled Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Faild to Cancel The Application","Faild",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            _RefreshPeopleDataGrid();
            
        }
        private void _DisabelAllContextMenueOptions()
        {
            
            editToolStripMenuItem.Enabled= false;
            canceleApplicationToolStripMenuItem.Enabled= false;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled= false;
            showDrivingLicenseToolStripMenuItem.Enabled= false;
            deleteApplicationToolStripMenuItem.Enabled= false;
            schedualTesToolStripMenuItem.Enabled= false;
            //The other options are always enabeled 
        }
        private void cmsOperationsOnLDLApp_Opening(object sender, CancelEventArgs e)
        {
            DataGridViewRow row = dgvLDLA.SelectedRows[0];
            if(row==null) return;//if no row was selected

            //We Start With All Options Disabeled State
            _DisabelAllContextMenueOptions();

            string statusText = row.Cells["Status"].Value?.ToString();

            if (!Enum.TryParse(statusText, ignoreCase: true, out clsApplication.enApplicationStatus status))
            {
                // Unknown value in grid (typo, localization, etc.)
                return;
            }
           if( !clsLocalDrivingLicenseApp.LDLAppHasAppointments
                (Convert.ToInt32(row.Cells["L.D.L.AppID"].Value)))
            {
                deleteApplicationToolStripMenuItem.Enabled = true;
            }

            if (status == clsApplication.enApplicationStatus.Cancelled)
            {
                return;
            }

            else if (status == clsApplication.enApplicationStatus.Completed)
            {
               showDrivingLicenseToolStripMenuItem.Enabled= true;
            }
            else
            {
                editToolStripMenuItem.Enabled= true;
                schedualTesToolStripMenuItem.Enabled = true;
                canceleApplicationToolStripMenuItem.Enabled = true;

                switch (Convert.ToInt32(row.Cells["PassedTests"].Value))
                {
                    case 0:
                        cmsItemWrittenTest.Enabled = cmsItemStreetTest.Enabled = false;
                        cmsItemVisionTest.Enabled = true;

                        break;

                    case 1:
                        cmsItemVisionTest.Enabled = cmsItemStreetTest.Enabled = false;
                        cmsItemWrittenTest.Enabled = true;
                        break;

                    case 2:
                        cmsItemVisionTest.Enabled = cmsItemWrittenTest.Enabled = false;
                        cmsItemStreetTest.Enabled = true;
                        break;
                    case 3:
                        cmsItemWrittenTest.Enabled =
                            cmsItemVisionTest.Enabled = cmsItemStreetTest.Enabled = false;
                        schedualTesToolStripMenuItem.Enabled = false;
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                        break;
                }
            }


         
        }

        private void cmsItemVisionTest_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;

            frmTestAppointments frm = new frmTestAppointments(LDLAppID,clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            _RefreshPeopleDataGrid();
            
        }

        private void cmsItemWrittenTest_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;

            frmTestAppointments frm = new frmTestAppointments(LDLAppID, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            _RefreshPeopleDataGrid();
        }

        private void cmsItemStreetTest_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;

            frmTestAppointments frm = new frmTestAppointments(LDLAppID, clsTestType.enTestType.PracticalTest);
            frm.ShowDialog();
            _RefreshPeopleDataGrid();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense(LDLAppID);
            frm.ShowDialog();
            _RefreshPeopleDataGrid();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;
            if (MessageBox.Show($"Are you Sure you want to delete the Application with ID={LDLAppID}", "Warning",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApp.DeleteLDLApp(LDLAppID))
                {
                    MessageBox.Show($@"Local Driving License Application with IDD={LDLAppID} has been deleted successfully",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleDataGrid();
                }
                else
                {
                    MessageBox.Show("An Error occured while trying to delete this applicatoin");
                }
            }
        }

        private void showDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;
            int licenseID=clsLicense.GetLicenseIDByLDLAppID(LDLAppID);

            frmLicenseInfoCard frm = new frmLicenseInfoCard(licenseID);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;
            int personID = clsLocalDrivingLicenseApp.GetPersonIDByLDLAppID(LDLAppID);

            frmLicenseHistory frm = new frmLicenseHistory(personID);
            frm.ShowDialog();

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;
            frmLDLAppDetails frm = new frmLDLAppDetails(LDLAppID);
            frm.ShowDialog();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int LDLAppID))
                return;

            frmAddUpdateLDLApp frm = new frmAddUpdateLDLApp(LDLAppID);
            frm.ShowDialog();
            _RefreshPeopleDataGrid();
        }
    }
}
