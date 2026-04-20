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
    public partial class frmManageInternationalLicenses : Form
    {
        private DataTable _dtIntLicenses;
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }
        private void _SetDataGridColumnNamesAndWidth()
        {
            dgvIntLicenses.Columns["IntLicenseID"].HeaderText = "Int.license ID";
            dgvIntLicenses.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvIntLicenses.Columns["driverID"].HeaderText = "Driver ID";
            dgvIntLicenses.Columns["LLicenseID"].HeaderText = "L.License ID";
            dgvIntLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvIntLicenses.Columns["ExpirationDate"].HeaderText = "Passed Tests";

        }

        private void _ApplyFilter()
        {
            string[] filterColumns = { "None", "IntLicenseID", "ApplicationID", "driverID", "LLicenseID" };
            if (_dtIntLicenses == null) return;

            string column = filterColumns[cmbFilterBy.SelectedIndex];
            string value = txtFilterByValue.Text.Trim();

            if (string.IsNullOrEmpty(value) || column == "None")
            {
                _dtIntLicenses.DefaultView.RowFilter = "";
                return;
            }
            else if (column == "IntLicenseID"|| column == "ApplicationID"|| 
                column == "driverID"|| column == "LLicenseID")
            {
                _dtIntLicenses.DefaultView.RowFilter = $"[{column}]={value}";

            }
            else
            {
                _dtIntLicenses.DefaultView.RowFilter = $"[{column}] like '%{value}%'";
            }
            lblTotalIntLicenses.Text = dgvIntLicenses.RowCount.ToString();

        }

        private bool _TryGetSelectedCellValue(out int cellValue,int cellIndex)
        {
            cellValue = -1;
            return dgvIntLicenses.SelectedRows.Count > 0 &&
                int.TryParse(dgvIntLicenses.SelectedRows[0].Cells[cellIndex].Value.ToString(), out cellValue);

        }
        private bool _EnsureApplicationSelected(out int cellValue,int cellIndex)
        {
            if (!_TryGetSelectedCellValue(out cellValue,cellIndex))
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
            _dtIntLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvIntLicenses.DataSource = _dtIntLicenses;
            lblTotalIntLicenses.Text=dgvIntLicenses.RowCount.ToString();
            _SetDataGridColumnNamesAndWidth();
        }

        private void _InitalizeFormLayout()
        {
            this.BackColor = Color.White;

            dgvIntLicenses.DefaultCellStyle.ForeColor = Color.Black;
            dgvIntLicenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvIntLicenses.EnableHeadersVisualStyles = false;

            lblTotalIntLicenses.ForeColor = Color.Black;
            lblFilterBy.ForeColor = Color.Black;
            lblRecord.ForeColor = Color.Black;
        }
        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDataGrid();
            _InitalizeFormLayout();
            cmbFilterBy.SelectedIndex = 0;
            
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterByValue.Text = "";
            _ApplyFilter();
            if(cmbFilterBy.SelectedIndex == 0)
            {
                txtFilterByValue.Enabled = false;
            }
            else
            {
                txtFilterByValue.Enabled=true;
            }
        }

        private void btnAddNewLDLApp_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicense frm = new frmIssueInternationalLicense();
            frm.ShowDialog();
            _RefreshDataGrid();
        }

        private void tbFilterByValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void tbFilterByValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            int[] numericalColumnIndecies = { 1, 2, 3, 4 };
            if (numericalColumnIndecies.Contains(cmbFilterBy.SelectedIndex))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void showLicenseIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int intLicenseID,0))//InernationalLicenseID is at index 0
                return;
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(intLicenseID);
            frm.ShowDialog();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int driverID, 2))//driverID is at index 2
                return;

            int personID=clsPerson.GetPersonIDByDriverID(driverID);

            frmShowPersonDetails frm = new frmShowPersonDetails(personID);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int driverID, 2))//driverID is at index 2
                return;
            int personID = clsPerson.GetPersonIDByDriverID(driverID);
            
            frmLicenseHistory frm = new frmLicenseHistory(personID);
            frm.ShowDialog();
        }
    }
}
