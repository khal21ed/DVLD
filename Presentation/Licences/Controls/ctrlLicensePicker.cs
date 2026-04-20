using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LDLApp
{
    public partial class ctrlLicensePicker : UserControl
    {
        public bool FindLicenseEnabeled
        {
            get => gbSearchBar.Enabled;
            set => gbSearchBar.Enabled = value;
        }

        public void PerformSearchClick()
        {
            btnFindLicense.PerformClick();
        }
        public string txtLicenseIDText
        {
            set => txtLicenseID.Text = value;
        }

        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int licenseID)
        {
            Action<int> handler= OnLicenseSelected;
            if(handler!= null)
            {
                handler(licenseID);
            }
        }

        public ctrlLicensePicker()
        {
            InitializeComponent();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);

            if(e.KeyChar == (char)13)
            {
                btnFindLicense.PerformClick();
            }
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text))
            {
                MessageBox.Show("The Search bar is empty please type the ID of the license you want to find",
                    "Faild",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int licenseID = Convert.ToInt32(txtLicenseID.Text.Trim());
            ctrlLicenseInfo1.LoadControl(licenseID);

            if(OnLicenseSelected != null)
                LicenseSelected(licenseID);
        }

      
    }
}
