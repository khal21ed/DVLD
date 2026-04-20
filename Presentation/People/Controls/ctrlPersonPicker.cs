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
    public partial class ctrlPersonPicker : UserControl
    {
        public int SelectedPersonId   // READ-ONLY FORWARDING
        {
            get
            {
                return ctrlShowPersonInfo1.PersonId;
            }
        }
        public bool FindPersonEnabled
        {
            get => gbFindPerson.Enabled;
            set => gbFindPerson.Enabled = value;
        }

        public ctrlPersonPicker()
        {
            InitializeComponent();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm=new frmAddUpdatePerson(-1);
            frm.PersonIDBack += FindPersonAndLoadIntoPersonCard;
            frm.ShowDialog();
        }

        private void txtFindBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFindBy.SelectedIndex == 0)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            
        }

        public void FindPersonAndLoadIntoPersonCard(object sender,int personID)
        {
            if (clsPerson.PersonExistsByPersonID(personID))
            {
                ctrlShowPersonInfo1.LoadPerson(personID);
            }
        }
        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            int personID = -1;
            bool isExist = false;
            string[] findByColumnNames = { "PersonID", "NationalNo" };

            if (string.IsNullOrWhiteSpace(txtFindBy.Text))
                return;

            if (cmbFindBy.SelectedIndex == 0)//PersonID
            {
                if (clsPerson.PersonExistsByPersonID((Convert.ToInt32(txtFindBy.Text.ToString()))))
                {

                    personID = int.Parse(txtFindBy.Text.ToString());
                    isExist = true;
                }
            }
            else//NatoinalNo
            {
                if (clsPerson.PersonExistsByNationalNo((txtFindBy.Text.ToString())))
                {
                    isExist = true;
                    personID = clsPerson.GetPersonIDByNationalNo(txtFindBy.Text.ToString());
                }
            }
            if (isExist)
            {
                FindPersonAndLoadIntoPersonCard(sender,personID);
            }
            else
            {
                ctrlShowPersonInfo1.Clear();
                MessageBox.Show("Person was not found", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlAddUpdateUser_Load(object sender, EventArgs e)
        {
            cmbFindBy.SelectedIndex = 0;
            btnAddPerson.Focus();
        }

        private void cmbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFindBy.Text=string.Empty;
        }
    }
}
