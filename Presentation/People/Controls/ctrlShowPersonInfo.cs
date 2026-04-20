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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlShowPersonInfo : UserControl
    {
        private clsPerson _person;
        private int _personID=-1;
        public int PersonId   // READ-ONLY
        {
            get { return _personID; }
        }
        public ctrlShowPersonInfo()
        {
            InitializeComponent();
        }

        private void _PickPersonDeafultImage()
        {
            if (_person.Gender == clsPerson.enGender.Male)
                pbPersonPicture.Image = Resources.person_man;

            else
                pbPersonPicture.Image = Resources.person_woman;
        }
        public void Clear()
        {
            _person = null;
            _personID= -1;
            lblAddressValue.Text = "Empty";
            lblEmailValue.Text = "Empty";
            lblPersonIDValue.Text = "Empty";
            lblNationalNoValue.Text = "Empty";
            lblGenderValue.Text = "Empty";
            lblPhoneValue.Text = "Empty";
            lblCountryValue.Text = "Empty";
            lblDateOfBirthValue.Text = "Empty";
            lblNameValue.Text = "Empty";
            llGoToUpdateForm.Enabled= false;
            pbPersonPicture.ImageLocation = null;
            pbPersonPicture.Image= Resources.person_man;
        }
        private void _LoadPersonImage()
        {
            if (!File.Exists(_person.ImagePath))
            {
                pictureBox1.Image = null;
                return;
            }

            // Dispose previous image to avoid memory leak + locks
            pbPersonPicture.Image?.Dispose();

            // Load bytes -> create a copy in memory -> file is NOT locked
            byte[] bytes = File.ReadAllBytes(_person.ImagePath);
            using (var ms = new MemoryStream(bytes))
            {
                pbPersonPicture.Image = new Bitmap(ms);
            }
        }

        private void _LoadPersonInfoFromDatabase(int personID)
        {
         _person= clsPerson.FindPersonByID(personID);
            if (_person == null)
            { 
                llGoToUpdateForm.Enabled= false;
                MessageBox.Show("Person was not found", "Faild to get person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this._personID=personID;

            lblPersonIDValue.Text= _person.Id.ToString();
            lblNameValue.Text = _person.FullName;
            lblNationalNoValue.Text = _person.NationalNo;
            lblEmailValue.Text = _person.Email;
            lblCountryValue.Text=clsCountry.FindCountryByID(_person.Country);
            lblPhoneValue.Text = _person.Phone;
            lblAddressValue.Text = _person.Address;
            lblDateOfBirthValue.Text = _person.DateOfBirth.ToString("yyyy-MM-dd");

            if (_person.Gender == clsPerson.enGender.Male)
            {
                //pbGender.Image = Resources.man;
                lblGenderValue.Text = "Male";
            }
            else
            {
                //pbGender.Image = Resources.woman;
                lblGenderValue.Text = "Female";
            }

            if (!string.IsNullOrEmpty(_person.ImagePath))
            {
                pbPersonPicture.ImageLocation = _person.ImagePath;
                _LoadPersonImage();
            }

            else
            {
                _PickPersonDeafultImage();
            }
            llGoToUpdateForm.Enabled = true;
        }

        public void LoadPerson(int personID)
        {
            _LoadPersonInfoFromDatabase(personID);
        }

        private void llGoToUpdateForm_Click(object sender, EventArgs e)
        {
         
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_personID);
            frm.ShowDialog();
            _LoadPersonInfoFromDatabase(_personID);

        }

     
    }
}
