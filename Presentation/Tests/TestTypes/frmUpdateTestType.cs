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
    public partial class frmUpdateTestType : Form
    {
        private int _testTypeID;
        private clsTestType _testType;
        public frmUpdateTestType(int testTypeID)
        {
            InitializeComponent();
            _testTypeID = testTypeID;
        }
        private void _LoadTestTypeIntoForm()
        {
            _testType=clsTestType.FindTestTypeByID(_testTypeID);
            if (_testType == null)
                return;

            lblIDValue.Text = _testTypeID.ToString();
            txtDescription.Text = _testType.Description;
            txtTitle.Text = _testType.Title;
            txtFees.Text=_testType.Fees.ToString();

        }
        private bool ValidateInputs()
        {
            return !string.IsNullOrWhiteSpace(txtTitle.Text) &&
                !string.IsNullOrWhiteSpace(txtFees.Text)&&
                !string.IsNullOrWhiteSpace(txtDescription.Text);
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadTestTypeIntoForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                _testType.Title = txtTitle.Text.Trim();
                _testType.Fees = int.Parse(txtFees.Text.Trim());
                _testType.Description = txtDescription.Text.Trim();

                if (_testType.UpdateTestType())
                    MessageBox.Show("Applicatoin type has been Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Inputs are Invalid","Faild",MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                epCheckInputs.SetError(txtDescription, "This field should not be empty");
            }
            else
            {
                epCheckInputs.SetError(txtDescription, "");
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
    }
}
