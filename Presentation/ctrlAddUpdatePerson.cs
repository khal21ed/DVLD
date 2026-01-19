using Business;
using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlAddUpdatePerson : UserControl
    {
        private clsPerson _person;
        public ctrlAddUpdatePerson()
        {
            InitializeComponent();
            _person = new clsPerson();
        }
        private bool _AreRequiredFieldsFilled()
        {
            if(string.IsNullOrEmpty(txtFirstName.Text)||string.IsNullOrEmpty(txtSecondName.Text)||
                string.IsNullOrEmpty(txtLastName.Text)|string.IsNullOrEmpty(txtPhone.Text)||string.IsNullOrEmpty(txtNationalNo.Text)||
                string.IsNullOrEmpty(txtAddress.Text)||string.IsNullOrEmpty(dtpDateOfBirth.Text)||string.IsNullOrEmpty(cbCountry.Text))
                { return false; }

            return true;
        }

    
        public  void LoadControlWithPersonInfo(int personId)
        {
            _LoadControlWithPersonInfo(personId);
        }
        private void _LoadControlWithPersonInfo(int personID)
        {
            if (personID == -1)
                return;

            _person=clsPerson.FindPersonByID(personID);
            if (_person == null)//the given ID might not exist
                return;

            lblPerosnID.Text = _person.Id.ToString();
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtNationalNo.Text = _person.NationalNo;
            dtpDateOfBirth.Value = _person.DateOfBirth;
            txtEmail.Text = _person.Email;
            txtAddress.Text = _person.Address;  
            txtPhone.Text = _person.Phone;
            cbCountry.SelectedIndex = _person.Country;

            if (_person.Gender == clsPerson.enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (!string.IsNullOrWhiteSpace(_person.ImagePath))
            {
                pbPersonPicture.ImageLocation = _person.ImagePath;
                pbPersonPicture.Image = Image.FromFile(_person.ImagePath);
                pbPersonPicture.Tag = "Other";
            }
            else 
            {
                _PickDefaultFemaleOrMalePic();
            }
        }
        private void _PickDefaultFemaleOrMalePic()
        {
            if (pbPersonPicture.Tag.ToString().ToLower() == "other" )
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
        private void _SavePerson()
        {
            _person.NationalNo=txtNationalNo.Text;
            _person.FirstName = txtFirstName.Text;
            _person.SecondName = txtSecondName.Text;
            _person.ThirdName= txtThirdName.Text;
            _person.LastName = txtLastName.Text;
            _person.DateOfBirth=dtpDateOfBirth.Value;
            _person.Phone = txtPhone.Text;
            if (rbFemale.Checked)
                _person.Gender = clsPerson.enGender.Female;
            else
                _person.Gender = clsPerson.enGender.Male;
            _person.Address = txtAddress.Text;
            _person.Email = txtEmail.Text;
            _person.Country=clsCountry.findCountryByName(cbCountry.Text);
            _person.ImagePath = pbPersonPicture.ImageLocation;

            if (_person.Save())
            {
                MessageBox.Show("Person Saved Successfully", "Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblPerosnID.Text = _person.Id.ToString();
            }
            else
            {
                MessageBox.Show("Error Occured", "Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtFirstName, "First Name should not be empty");
            }
            else
            {
                erpValidateInput.SetError(txtFirstName, "");
            }
        }
        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondName.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtSecondName, "Second Name should not be empty");
            }
            else
            {
                erpValidateInput.SetError(txtSecondName, "");
            }
        }
        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtLastName, "Last Name should not be empty");
            }
            else
            {
                erpValidateInput.SetError(txtLastName, "");
            }
        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
          
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtNationalNo, "National Number should not be empty");
            }
            else if (clsPerson.PersonExistsByNationalNo(txtNationalNo.Text)&&_person.Mode==clsPerson.enMode.AddNew)
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtNationalNo, $"National number {txtNationalNo.Text} already exists");
            }
            else
            {
                erpValidateInput.SetError(txtNationalNo, "");
            }
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtPhone, "Phone Number should not be empty");
            }
            else
            {
                erpValidateInput.SetError(txtPhone, "");
            }
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _PickDefaultFemaleOrMalePic();
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace( txtEmail.Text) )
            {
                if (!_IsValidEmail(txtEmail.Text))
                {                  
                        e.Cancel = true;
                        erpValidateInput.SetError(txtEmail, "Not a valid email format");              
                }
                else
                {
                    erpValidateInput.SetError(txtEmail, "");
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
            else
            {
                erpValidateInput.SetError(txtAddress, "");
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
                pbPersonPicture.ImageLocation = ofdSetPersonImage.FileName;
                pbPersonPicture.Image=Image.FromFile(ofdSetPersonImage.FileName);
                
                pbPersonPicture.Tag = "Other";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_AreRequiredFieldsFilled())
                MessageBox.Show("Please fill all the required fiealds", "Empty-required fields exist",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                _SavePerson();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        { 
            this.Parent.Hide();
        }
        private void llRemovePersonImage_Click(object sender, EventArgs e)
        {
            pbPersonPicture.ImageLocation = null;
            pbPersonPicture.Tag = "";
            _PickDefaultFemaleOrMalePic();
        } 
    }
}
