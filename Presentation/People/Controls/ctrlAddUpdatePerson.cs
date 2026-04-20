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
        enum enMode { Add=1 , Update=2}
        private enMode _mode = enMode.Add;
        public  int PersonID { get => _person.Id; }
        public ctrlAddUpdatePerson()
        {
            InitializeComponent();
            _person = new clsPerson();
        }

        private bool _AreRqequriedFieldsFilled()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtSecondName.Text) ||
                string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtNationalNo.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(dtpDateOfBirth.Text) || string.IsNullOrEmpty(cbCountry.Text))
            { return false; }

            return true;
        }
       
        private bool _ValidateInputs()
        {
            if (_AreRqequriedFieldsFilled() ){
                if (_person.Mode == clsPerson.enMode.Update&&
                    _person.NationalNo==txtNationalNo.Text.Trim())
                {
                    return true;
                }
                else if (!clsPerson.PersonExistsByNationalNo(txtNationalNo.Text.Trim()))
                {
                    return true;
                }
            }
            return false;
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

            lblTitle.Text = "Update Person";
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
            cbCountry.SelectedIndex= cbCountry.FindString(clsCountry.FindCountryByID(_person.Country))  ;

            if (_person.Gender == clsPerson.enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (!string.IsNullOrWhiteSpace(_person.ImagePath))
            {
                pbPersonPicture.ImageLocation = _person.ImagePath;
                clsGlobal.LoadImage(_person.ImagePath);
                //_LoadPersonImage();
                //pbPersonPicture.Image = Image.FromFile(_person.ImagePath);
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

            pbPersonPicture.ImageLocation = null;
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

        private void _FillPersonFromForm()
        {
            _person.NationalNo = txtNationalNo.Text.Trim();
            _person.FirstName = txtFirstName.Text.Trim();
            _person.SecondName = txtSecondName.Text.Trim();
            _person.ThirdName = txtThirdName.Text.Trim();
            _person.LastName = txtLastName.Text.Trim();
            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.Phone = txtPhone.Text.Trim();
            if (rbFemale.Checked)
                _person.Gender = clsPerson.enGender.Female;
            else
                _person.Gender = clsPerson.enGender.Male;
            _person.Address = txtAddress.Text.Trim();
            _person.Email = txtEmail.Text.Trim();

            //since the countries are sorted by name their indecies doesn't equal the indecies in the DB
            _person.Country = clsCountry.findCountryByName(cbCountry.Text);
            _person.ImagePath = pbPersonPicture.ImageLocation;
        }
        public bool SavePerson(out string message)
        {
            if (!_ValidateInputs()) 
            {
                message = "Inputs are invalid check if the required fields are empty or the NationalNo already exists";
                return false;
                    }

            _FillPersonFromForm();

            if (_person.Save())
            {        
                lblPerosnID.Text = _person.Id.ToString();
                lblTitle.Text = "Update Person";
                message = "Person Saved Successfully";
                return true;
            }
            else
            {
                message = "Error Occured";
                return false;
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
       
        private void ValidatingEmptytxt(object sender, CancelEventArgs e)
        {
            TextBox currentTxt=(TextBox)sender;
            if (string.IsNullOrEmpty(currentTxt.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError((TextBox)sender, "This field shouldn't be empty");
            }
            else
            {
                erpValidateInput.SetError((TextBox)sender, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtNationalNo, "National Number should not be empty");
            }
            else if (clsPerson.PersonExistsByNationalNo(txtNationalNo.Text)&&
                _person.NationalNo!=txtNationalNo.Text.Trim())
                //It actually exists but its the NationalNo of the person we are currently Updating
            {
                e.Cancel = true;
                erpValidateInput.SetError(txtNationalNo, $"National number {txtNationalNo.Text} already exists");
            }
            else
            {
                erpValidateInput.SetError(txtNationalNo, "");
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
            else
            {
                //if user writes something and then removes it we remove the error
                erpValidateInput.SetError(txtEmail, "");
            }

        }

        private void ctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {
            //the min age available is 18 
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
                _person.ImagePath = ofdSetPersonImage.FileName;

                //_LoadPersonImage();
                //pbPersonPicture.Image=Image.FromFile(ofdSetPersonImage.FileName);
                
                pbPersonPicture.Tag = "Other";
            }
        }
        private void llRemovePersonImage_Click(object sender, EventArgs e)
        {
            pbPersonPicture.ImageLocation = null;
            pbPersonPicture.Tag = "";
            _PickDefaultFemaleOrMalePic();
        } 
    }
}
