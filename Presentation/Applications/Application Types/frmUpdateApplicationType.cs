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
    public partial class frmUpdateApplicationType : Form
    {
        private int _applicationID=-1;
        private clsApplicationTypes _applicatoinType;
        public frmUpdateApplicationType(int applicationID)
        {
            InitializeComponent();
            _applicationID = applicationID;
        }

        private void _LoadDataIntoForm()
        {
             _applicatoinType= clsApplicationTypes.FindApplicationTypeByID( _applicationID);
            if( _applicatoinType == null )
            {
                MessageBox.Show("Application Type wasn't found", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtTitle.Text= _applicatoinType.Title;
            lblIDValue.Text=_applicatoinType.ApplicatoinID.ToString();
            txtFees.Text=_applicatoinType.Fees.ToString();

        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadDataIntoForm();
        }

        private bool ValidateInputs()
        {
            return !string.IsNullOrWhiteSpace(txtTitle.Text) &&
                !string.IsNullOrWhiteSpace(txtFees.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                _applicatoinType.Title= txtTitle.Text.Trim();
                _applicatoinType.Fees = int.Parse(txtFees.Text.Trim());

                if (_applicatoinType.UpdateApplicationType())
                    MessageBox.Show("Applicatoin type has been Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Inputs are Invalid", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                epCheckInputs.SetError(txtTitle, "This field should not be empty");
            }
            else
            {
                epCheckInputs.SetError(txtTitle, "");
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFees.Text))
            {
                epCheckInputs.SetError(txtFees, "This field should not be empty");
            }
            else
            {
                epCheckInputs.SetError(txtFees, "");
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
