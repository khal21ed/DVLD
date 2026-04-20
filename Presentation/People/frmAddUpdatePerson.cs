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
        public delegate void PersonIDBackEventHandler(object sender, int personID);

        public event PersonIDBackEventHandler PersonIDBack;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlAddUpdatePerson1.SavePerson(out string message))
            {
                MessageBox.Show(message, "Successful",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                _personId = ctrlAddUpdatePerson1.PersonID;
            }
            else
            {
                MessageBox.Show(message, "Failed",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(_personId != -1) 
                PersonIDBack?.Invoke(this,_personId);

            this.Close();
        }
    }
}
