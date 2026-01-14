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
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _refreshPeopleDataGrid();
            cmbFilterBy.SelectedIndex = 0;
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
            //already handeled in the DAL
            //if (tbFilterBy.Text == "")
            //{
            //    dgvPeople.DataSource = clsPerson.getAllPeople();
            //    return;
            //}
            
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
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewPerson_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0) {
                MessageBox.Show("No Record Was Selected.Please select a complete record not a single cell ",
                    "Warning", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
                    }

            int personid = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells["personid"].Value);
            frmAddUpdatePerson frm = new frmAddUpdatePerson(personid);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Record Was Selected.Please select a complete record not a single cell ",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int personid = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells["personid"].Value);

            try
            {
                clsPerson.DeletePerson(personid);

                MessageBox.Show(
                    "Person deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "An unexpected error occurred.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            _refreshPeopleDataGrid();

        }
    }
}
