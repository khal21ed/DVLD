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
    public partial class frmLicenseInfoCard : Form
    {
        private int _licenseID;
        public frmLicenseInfoCard(int licenseID)
        {
            InitializeComponent();
            _licenseID = licenseID;
        }

        private void frmShowLicenseinfo_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfo.LoadControl(_licenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
