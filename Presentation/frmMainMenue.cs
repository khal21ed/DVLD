using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMainMenue : Form
    {
        private frmManagePeople _frmManagePeople;
        private MdiClient _mdiClient;

        public frmMainMenue()
        {
            InitializeComponent();
            _frmManagePeople = new frmManagePeople();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmManagePeople
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void frmMainMenue_Load(object sender, EventArgs e)
        {
       
            this.Cursor = Cursors.Default;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
