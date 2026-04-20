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

namespace DVLD
{
    
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }
        private DataTable _dtUsers;

        private void _RefreshDataGrid()
        {
            _dtUsers=clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtUsers;
            lblRecordsVAlue.Text=dgvUsers.RowCount.ToString();
        }
        private void _SetFormLayout()
        {
            this.BackColor = Color.White;

            dgvUsers.DefaultCellStyle.ForeColor = Color.Black;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvUsers.EnableHeadersVisualStyles = false;

            lblRecordsVAlue.ForeColor = Color.Black;
            lblFilterBy.ForeColor = Color.Black;
            lblRecords.ForeColor = Color.Black;
            dgvUsers.Columns["FullName"].FillWeight = 200;
        }
        private void _ApplyFilter()
        {
            string[] filterColumns = { "UserID", "PersonID", "FullName", "UserName", "IsActive" };

            if (_dtUsers == null) return;

            string column = filterColumns[cmbFilterBy.SelectedIndex]; // or map it to real column name
            string value = cmbFilterByValue.Text.Trim().Replace("'", "''"); // escape '

            //Numerical columns
            if (string.IsNullOrWhiteSpace(value))
            {
                _dtUsers.DefaultView.RowFilter = "";   // clear filter
                return;
            }
            else if (column == "UserID" || column == "PersonID")
            {
                _dtUsers.DefaultView.RowFilter = $"[{column}] ={value}";
            }
            //bool column
            else if (column == "IsActive")
            {
                if (value == "All")
                    _dtUsers.DefaultView.RowFilter = "";

                else
                {
                    bool b = value == "Active" ? true : false;
                    _dtUsers.DefaultView.RowFilter = $"[{column}] ={b}";
                }
            }
            else
            {
                // TEXT columns:
                _dtUsers.DefaultView.RowFilter = $"[{column}] LIKE '%{value}%'";
            }
        }
        private bool _TryGetSelectedPersonId(out int userID)
        {
            userID = -1;
            return dgvUsers.SelectedRows.Count > 0 &&
                int.TryParse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString(), out userID);

        }
        private bool _EnsureUserSelected(out int userID)
        {
            if (!_TryGetSelectedPersonId(out userID))
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
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshDataGrid();
            cmbFilterBy.SelectedIndex = 0;
            _SetFormLayout();
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFilterByValue.Text = "";
            _RefreshDataGrid();

            if (cmbFilterBy.SelectedIndex == 4) //IsActive
            {
                cmbFilterByValue.DropDownStyle=ComboBoxStyle.DropDownList;
                cmbFilterByValue.Items.Add("All");
                cmbFilterByValue.Items.Add("Active");
                cmbFilterByValue.Items.Add("InActive");
            }
            else
            {
                cmbFilterByValue.Items.Clear();
                cmbFilterByValue.DropDownStyle = ComboBoxStyle.DropDown;
            }

        }
        private void cmbFilterByValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }
        private void cmbFilterByValue_TextUpdate(object sender, EventArgs e)
        {
            _ApplyFilter();

        }
        private void cmbFilterByValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //PersonId or UserID
            if (cmbFilterBy.SelectedIndex == 0 || cmbFilterBy.SelectedIndex == 1)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(-1);
            frm.ShowDialog();
            _RefreshDataGrid();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!_EnsureUserSelected(out int userID))
                return;

            frmAddUpdateUser frm = new frmAddUpdateUser(userID);
            frm.ShowDialog();
            _RefreshDataGrid();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!_EnsureUserSelected(out int userID))
                return;

            try
            {
                clsUser.DeleteUser(userID);
                MessageBox.Show("User deleted successfully", "Success"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshDataGrid() ;
            }
            catch(Exception)
            {
                MessageBox.Show(
                    "The User couldn't be deleted because it has references in other tabels",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!_EnsureUserSelected(out int userID))
                return;

            frmShowUserInfo frm=new frmShowUserInfo(userID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureUserSelected(out int userID))
                return;

            frmChangeUserPassword frm = new frmChangeUserPassword(userID);
            frm.ShowDialog();
            
        }
    }
}
