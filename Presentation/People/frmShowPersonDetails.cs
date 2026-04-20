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
    public partial class frmShowPersonDetails : Form
    {
        private int personID=-1;
        public frmShowPersonDetails(int personID)
        {
            InitializeComponent();
            this.personID=personID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlShowPersonInfo1.LoadPerson(personID);
        }
    }
}
