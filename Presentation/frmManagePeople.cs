using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _refreshPeopleDataGrid()
        {
            dgvPeople.DataSource = clsPerson.getAllPeople();
            lblTotalPeople.Text = "# Records: " + dgvPeople.DisplayedRowCount(false).ToString();

        }

        private bool _TryGetSelectedPersonId(out int personID)
        {
            personID= -1;
            return dgvPeople.SelectedRows.Count > 0 &&
                int.TryParse(dgvPeople.SelectedRows[0].Cells[0].Value.ToString(), out personID);

        }
        private bool _EnsurePersonSelected(out int personID)
        {
            if (!_TryGetSelectedPersonId(out personID))
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
        private void frmManagePeople_Load(object sender, EventArgs e)
        {

            _refreshPeopleDataGrid();
            cmbFilterBy.SelectedIndex = 0;
            this.BackColor = Color.White;

            dgvPeople.DefaultCellStyle.ForeColor = Color.Black;
            dgvPeople.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPeople.EnableHeadersVisualStyles = false;

            lblTotalPeople.ForeColor = Color.Black;
            lblFilterBy.ForeColor = Color.Black;
        }
        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterBy.Text = "";

            //check if the filter option is None so we disable the text box and reload the data
            if (cmbFilterBy.SelectedItem.ToString() == "None")
            {
                tbFilterBy.Visible = false;
                _refreshPeopleDataGrid();
            }
            else
            {
                tbFilterBy.Visible = true;
            }    
        }
        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            
            string[] columnNames = { "None", "PersonID", "NationalNo", "FirstName", "SecondName",
            "ThirdName","LastName","Gendor","CountryName","Phone","Email"};

            string columnToSearchIn = columnNames[cmbFilterBy.SelectedIndex];

            dgvPeople.DataSource = clsPerson.getPeopleFilterdBy(columnToSearchIn, tbFilterBy.Text.ToString());
            lblTotalPeople.Text ="# Records: "+  dgvPeople.DisplayedRowCount(false).ToString();
        }
        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterBy.SelectedIndex == 1 || cmbFilterBy.SelectedIndex == 9)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();
            _refreshPeopleDataGrid();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_EnsurePersonSelected(out int personID))
                return;

            frmShowPersonDetails frm = new frmShowPersonDetails(personID);
            frm.ShowDialog();
            _refreshPeopleDataGrid();       
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewPerson_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!_EnsurePersonSelected(out int personID))
                return;

            frmAddUpdatePerson frm = new frmAddUpdatePerson(personID);
            frm.ShowDialog();
            _refreshPeopleDataGrid();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        if(!_EnsurePersonSelected(out int personID))
                return;

            try
            {
                clsPerson.DeletePerson(personID);

                MessageBox.Show(
                    "Person deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                _refreshPeopleDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "The Person couldn't be deleted because it has references in other tabels",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }
    }
}
