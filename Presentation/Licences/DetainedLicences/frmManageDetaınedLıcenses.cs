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

namespace DVLD.Licences.DetainedLicences
{
    public partial class frmManageDetaınedLıcenses : Form
    {
        private DataTable _dtDetainedLicenses=new DataTable();
        public frmManageDetaınedLıcenses()
        {
            InitializeComponent();
        }
        private bool _TryGetSelectedCellValue(out int cellValue, int cellIndex)
        {
            cellValue = -1;
            return dgvDetainedLicenses.SelectedRows.Count > 0 &&
                int.TryParse(dgvDetainedLicenses.SelectedRows[0].Cells[cellIndex].Value.ToString(), out cellValue);

        }
        private bool _EnsureApplicationSelected(out int cellValue, int cellIndex)
        {
            if (!_TryGetSelectedCellValue(out cellValue, cellIndex))
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
            dgvDetainedLicenses.Columns["DetainID"].HeaderText = "D.ID";
            dgvDetainedLicenses.Columns["LicenseID"].HeaderText = "L.ID";
            dgvDetainedLicenses.Columns["DetainDate"].HeaderText = "D.Date";
            dgvDetainedLicenses.Columns["IsReleased"].HeaderText = "Is Released";
            dgvDetainedLicenses.Columns["FineFees"].HeaderText = "Fine Fees";
            dgvDetainedLicenses.Columns["ReleaseDate"].HeaderText = "Release Date";
            dgvDetainedLicenses.Columns["NationalNo"].HeaderText = "National No";
            dgvDetainedLicenses.Columns["FullName"].HeaderText = "Full Name";
            dgvDetainedLicenses.Columns["ReleaseApplicationID"].HeaderText = "Release AppID";

            dgvDetainedLicenses.Columns["FullName"].FillWeight = 150;


        }
        private void _RefreshPeopleDataGrid()
        {
            _dtDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            _SetDataGridColumnNamesAndWidth();
            lblTotalApplications.Text = dgvDetainedLicenses.DisplayedRowCount(false).ToString();

        }
        private void _InitalizeFormLayout()
        {
            this.BackColor = Color.White;

            dgvDetainedLicenses.DefaultCellStyle.ForeColor = Color.Black;
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvDetainedLicenses.EnableHeadersVisualStyles = false;

            lblTotalApplications.ForeColor = Color.Black;
            lblFilterBy.ForeColor = Color.Black;
            lblRecord.ForeColor = Color.Black;
        }
        private void _ApplyFilter()
        {
            string[] filterColumns = { "None", "DetainID", "IsReleased", "NationalNo", "FullName", "RleaseApplicationID" };
            if (_dtDetainedLicenses == null) return;

            string column = filterColumns[cmbFilterBy.SelectedIndex];
            string value = cmbFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(value) || column == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                return;
            }
            
            else if (column == "DetainID" || column == "RleaseApplicationID")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = $"[{column}]={value}";

            }
            else if (column == "IsReleased")
            {
                if (value == "All")
                    _dtDetainedLicenses.DefaultView.RowFilter = "";
                else
                {
                    bool b = value == "Released" ? true : false;
                    _dtDetainedLicenses.DefaultView.RowFilter = $"[{column}] ={b}";
                }
            }
            else
            {
                _dtDetainedLicenses.DefaultView.RowFilter = $"[{column}] like '%{value}%'";
            }
            lblTotalApplications.Text = dgvDetainedLicenses.RowCount.ToString();

        }

        private void frmManageDetaınedLıcenses_Load(object sender, EventArgs e)
        {
            _InitalizeFormLayout();
            _RefreshPeopleDataGrid();
            cmbFilterBy.SelectedIndex = 0;

        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtDetainedLicenses.DefaultView.RowFilter = "";
            cmbFilterValue.Text = "";
            cmbFilterValue.Items.Clear();
            cmbFilterValue.Enabled = true;


            if (cmbFilterBy.SelectedIndex == 0)
            {
                cmbFilterValue.Enabled= false;
                return;
            }
            if (cmbFilterBy.SelectedIndex == 2) //IsActive
            {
                cmbFilterValue.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbFilterValue.Items.Add("All");
                cmbFilterValue.Items.Add("Released");
                cmbFilterValue.Items.Add("Detained");
                cmbFilterValue.SelectedIndex = 0;
            }
            else
            {
                cmbFilterValue.DropDownStyle = ComboBoxStyle.DropDown;
            }

        }

        private void cmbFilterValue_TextUpdate(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void cmbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string nationalNo = dgvDetainedLicenses.SelectedRows[0].Cells[6].Value.ToString();
            int personID = clsPerson.GetPersonIDByNationalNo(nationalNo);
            frmShowPersonDetails frm = new frmShowPersonDetails(personID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureApplicationSelected(out int licenseID, 1))
                return;
            frmLicenseInfoCard frm = new frmLicenseInfoCard(licenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nationalNo = dgvDetainedLicenses.SelectedRows[0].Cells[6].Value.ToString();
            int personID = clsPerson.GetPersonIDByNationalNo(nationalNo);
            frmLicenseHistory frm = new frmLicenseHistory(personID);
            frm.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dgvDetainedLicenses.SelectedRows[0].Cells["LicenseID"].Value.ToString(),
                out int licenseID))
                return;
            frmReleaseDetaınedLıcense frm = new frmReleaseDetaınedLıcense(licenseID);
            frm.ShowDialog();
            _RefreshPeopleDataGrid();
        }

        private void cmbFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.SelectedIndex == 1 || cmbFilterBy.SelectedIndex == 5)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmsOpertaions_Opening(object sender, CancelEventArgs e)
        {
            releaseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.SelectedRows[0].Cells["IsReleased"].Value;
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshPeopleDataGrid();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetaınedLıcense frm = new frmReleaseDetaınedLıcense();
            frm.ShowDialog();
            _RefreshPeopleDataGrid();
        }
    }
}
