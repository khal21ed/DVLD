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
    public partial class frmManageDrivers : Form
    {
        private DataTable _dtDrivers;
        public frmManageDrivers()
        {
            InitializeComponent();
        }
       

        private void _SetDataGridColumnNamesAndWidth()
        {
            dgvDrivers.Columns["DriverID"].HeaderText = "Driver ID";
            dgvDrivers.Columns["NationalNo"].HeaderText = "National No";
            dgvDrivers.Columns["PersonID"].HeaderText = "Person ID";
            dgvDrivers.Columns["FullName"].HeaderText = "Full Name";
            dgvDrivers.Columns["CreatedDate"].HeaderText = "Date";
            dgvDrivers.Columns["ActiveLicenses"].HeaderText = "Active Licenses";

            dgvDrivers.Columns["CreatedDate"].FillWeight = 120;
            dgvDrivers.Columns["FullName"].FillWeight = 150;


        }
        private void _InitalizeFormLayout()
        {
            this.BackColor = Color.White;

            dgvDrivers.DefaultCellStyle.ForeColor = Color.Black;
            dgvDrivers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvDrivers.EnableHeadersVisualStyles = false;

            lblTotalDrivers.ForeColor = Color.Black;
            lblFilterBy.ForeColor = Color.Black;
            lblRecord.ForeColor = Color.Black;
        }

        private void _RefreshPeopleDataGrid()
        {
            _dtDrivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtDrivers;
            lblTotalDrivers.Text = dgvDrivers.DisplayedRowCount(false).ToString();
            _SetDataGridColumnNamesAndWidth();
        }

        private void _ApplyFilter()
        {
            string[] filterColumns = { "None", "DriverID", "PersonID","NationalNo", "FullName"};
            if (_dtDrivers == null) return;

            string column = filterColumns[cmbFilterBy.SelectedIndex];
            string value = tbFilterByValue.Text.Trim();

            if (string.IsNullOrEmpty(value) || column == "None")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                return;
            }
            else if (column == "PersonID"||column=="DriverID")
            {
                _dtDrivers.DefaultView.RowFilter = $"[{column}]={value}";

            }
            else
            {
                _dtDrivers.DefaultView.RowFilter = $"[{column}] like '%{value}%'";
            }
            lblTotalDrivers.Text = dgvDrivers.RowCount.ToString();

        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterBy.SelectedIndex == 0)//None
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
            if (cmbFilterBy.SelectedIndex == 1||cmbFilterBy.SelectedIndex==2)//PersonID or DriverID
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _InitalizeFormLayout();
            _RefreshPeopleDataGrid();
            cmbFilterBy.SelectedIndex = 0;
        }
    }
}
