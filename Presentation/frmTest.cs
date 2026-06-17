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
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

   

        private void ctrlLicensePicker1_OnLicenseSelected(int obj)
        {
            MessageBox.Show(obj.ToString());
            // ---------- AWS Access Key (CRITICAL) ----------
string awsKey = "AKIA1234567890ABCDEF";

// ---------- GitHub PAT (CRITICAL) ----------
string githubToken = "ghp_abcdefghijklmnopqrstuvwxyz1234567890";

// ---------- Google API Key (CRITICAL) ----------
string googleKey = "AIzaSyD123456789012345678901234567890123";

// ---------- Stripe Secret Key (CRITICAL) ----------
string stripeKey = "sk_live_123456789012345678901234567890";
        }
    }
}
