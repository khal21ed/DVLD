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
    public partial class frmTestTypes : Form
    {
        public frmTestTypes()
        {
            InitializeComponent();
        }
        private void _RefreshDataGrid()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            lblRecordsValue.Text = "# " + dgvTestTypes.RowCount.ToString();
        }

        private void _SetFormLayoutAndColors()
        {
            this.BackColor = Color.White;

            dgvTestTypes.DefaultCellStyle.ForeColor = Color.Black;
            dgvTestTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvTestTypes.EnableHeadersVisualStyles = false;

            lblRecords.ForeColor = Color.Black;
            lblRecordsValue.ForeColor = Color.Black;
            dgvTestTypes.Columns["TestTypeDescription"].FillWeight = 200;
        }

        private bool _TryGetTestTypeID(out int id)
        {
            id = -1;
            return dgvTestTypes.SelectedRows.Count > 0 &&
                int.TryParse(dgvTestTypes.SelectedRows[0].Cells[0].Value.ToString(), out id);
        }
        private bool _EnsureAnApplicatoinIsSelected(out int id)
        {
            if (!_TryGetTestTypeID(out id))
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

        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshDataGrid();
            _SetFormLayoutAndColors();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsureAnApplicatoinIsSelected(out int testTypeID))
                return;

            frmUpdateTestType frm = new frmUpdateTestType(testTypeID);
            frm.ShowDialog();
        }
    }
}
