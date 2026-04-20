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
    public partial class frmLDLAppDetails : Form
    {
        private int _LDLAppID;
        public frmLDLAppDetails(int lDLAppID)
        {
            InitializeComponent();
            _LDLAppID = lDLAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLDLAppDetails_Load(object sender, EventArgs e)
        {
            ctrlShowLDLAppInfo1.LoadControl(_LDLAppID);
        }
    }
}
