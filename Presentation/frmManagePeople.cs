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

            string columnToSearchIn = "";
            switch (cmbFilterBy.SelectedIndex)
            {
                case 1:
                    columnToSearchIn = "PersonID";
                    break;
                case 2:
                    columnToSearchIn = "NationalNo";
                    break;
                case 3:
                    columnToSearchIn = "FirstName";
                    break;
                case 4:
                    columnToSearchIn = "SecondName";
                    break;
                case 5:
                    columnToSearchIn = "ThirdName";
                    break;
                case 6:
                    columnToSearchIn = "LastName";
                    break;
                case 7:
                    columnToSearchIn = "Gendor";
                    break;
                case 8:
                    columnToSearchIn = "Nationality";
                    break;
                case 9:
                    columnToSearchIn = "Phone";
                    break;
                case 10:
                    columnToSearchIn = "Email";
                    break;
            }

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
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
        }

  
    }
}
