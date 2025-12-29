using Business;
using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlAddUpdatePerson : UserControl
    {
        private clsPerson person = new clsPerson();
        public ctrlAddUpdatePerson()
        {
            InitializeComponent();
        }

        private bool _AreRequiredFieldsFilled()
        {
            if(string.IsNullOrEmpty(txtFirstName.Text)||string.IsNullOrEmpty(txtSecondName.Text)||
                string.IsNullOrEmpty(txtLastName.Text)|string.IsNullOrEmpty(txtPhone.Text)||string.IsNullOrEmpty(txtNationalNo.Text)||
                string.IsNullOrEmpty(txtAddress.Text)||string.IsNullOrEmpty(dtpDateOfBirth.Text)||string.IsNullOrEmpty(cbCountry.Text))
                { return false; }

            return true;
        }

        private void _SavePerson()
        {
            person.NationalNo=txtNationalNo.Text;
           person.FirstName = txtFirstName.Text;
            person.SecondName = txtSecondName.Text;
            person.ThirdName= txtThirdName.Text;
            person.LastName = txtLastName.Text;
            person.DateOfBirth=dtpDateOfBirth.Value;
            person.Phone = txtPhone.Text;
            if (rbFemale.Checked)
                person.Gender = clsPerson.enGender.Female;
            else
                person.Gender=clsPerson.enGender.Female;
            person.Address = txtAddress.Text;
            person.Email = txtEmail.Text;
            person.Country=clsCountry.findCountryByName(cbCountry.Text);


        }
        private bool _IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }
        private void _LoadCountriesIntoComboBox()
        {
           DataTable dtCountries= clsCountry.getAllCountryNames();

            foreach(DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtFirstName, "First Name should not be empty");
            }
        }
        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondName.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtSecondName, "Second Name should not be empty");
            }
        }
        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtLastName, "Last Name should not be empty");
            }
        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if(clsPerson.PersonExistsByNationalNo(txtNationalNo.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtNationalNo, $"National number {txtNationalNo.Text} already exists");
            }

            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtNationalNo, "National Number should not be empty");
            }
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtPhone, "Phone Number should not be empty");
            }
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonPicture.Tag.ToString() != "man" && pbPersonPicture.Tag.ToString() != "woman")
                return;

            if (rbMale.Checked)
            {
                pbPersonPicture.Image = Resources.person_man;
                pbPersonPicture.Tag = "man";
            }
            else if (rbFemale.Checked)
            {
                pbPersonPicture.Image = Resources.person_woman;
                pbPersonPicture.Tag = "woman";
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Length > 0)
            {
                if (!_IsValidEmail(txtEmail.Text))
                {                  
                        e.Cancel = true;
                        erpValidateInput.SetError(txtEmail, "Not a valid email format");              
                }
            }
        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtAddress, "Address should not be empty");
            }
        }
        private void ctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {
            
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            _LoadCountriesIntoComboBox();
            cbCountry.SelectedIndex = cbCountry.FindString("jordan");

        }
        private void llSetPersonImage_Click(object sender, EventArgs e)
        {
            ofdSetPersonImage.InitialDirectory = @"C:\";
            ofdSetPersonImage.Title = "Choosing an image";
            ofdSetPersonImage.DefaultExt = "png";
            ofdSetPersonImage.Filter = "png files (*.png)|*.PNG|jpeg files (*.jpeg)|*.JPEG|jpg files (*.jpg)|*.JPG";
            ofdSetPersonImage.FilterIndex= 0;

            if(ofdSetPersonImage.ShowDialog() == DialogResult.OK)
            {
                pbPersonPicture.Image=Image.FromFile(ofdSetPersonImage.FileName);
                pbPersonPicture.Tag = "Other";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_AreRequiredFieldsFilled())
                MessageBox.Show("Please fill all the required fiealds"); 
        }
    }
}
