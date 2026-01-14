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
    public partial class frmAddUpdatePerson : Form
    {
        private int _personId=-1;
        public frmAddUpdatePerson(int ID)
        {
            InitializeComponent();
            _personId = ID;
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            ctrlAddUpdatePerson1.LoadControlWithPersonInfo(_personId);
        }
    }
}
