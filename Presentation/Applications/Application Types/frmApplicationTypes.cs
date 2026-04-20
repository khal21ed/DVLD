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
    public partial class frmApplicationTypes : Form
    {
        public frmApplicationTypes()
        {
            InitializeComponent();
        }
        private void _RefreshDataGrid()
        {
            dgvApplicationTypes.DataSource=clsApplicationTypes.GetApplicationTypes();
            lblRecordsValue.Text= "# "+dgvApplicationTypes.RowCount.ToString();
        }

        private void _SetFormLayoutAndColors()
        {
               this.BackColor = Color.White;

            dgvApplicationTypes.DefaultCellStyle.ForeColor = Color.Black;
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvApplicationTypes.EnableHeadersVisualStyles = false;

            lblRecords.ForeColor = Color.Black;
            lblRecordsValue.ForeColor = Color.Black;
            dgvApplicationTypes.Columns["ApplicationTypeTitle"].FillWeight = 200;
        }
        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshDataGrid();
            _SetFormLayoutAndColors();
         
        }
        private bool _TryGetApplicatoinID(out int id)
        {
            id = -1;
            return dgvApplicationTypes.SelectedRows.Count > 0&&
                int.TryParse(dgvApplicationTypes.SelectedRows[0].Cells[0].Value.ToString(), out id);
        }
        private bool _EnsureAnApplicatoinIsSelected(out int id)
        {
            if (!_TryGetApplicatoinID(out id))
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
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!_EnsureAnApplicatoinIsSelected(out int applicatoinID))
                return;
                
            frmUpdateApplicationType frm = new frmUpdateApplicationType(applicatoinID);
            frm.ShowDialog();
            _RefreshDataGrid();
        }
    }
}
