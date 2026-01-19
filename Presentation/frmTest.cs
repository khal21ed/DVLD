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

        private void button1_Click_1(object sender, EventArgs e)
        {
            clsUser user = clsUser.GetUserByUserNameAndPassword(textBox1.Text, textBox2.Text);
            if (user != null)
            {
                MessageBox.Show(user.ToString());
            }
            else
            {
                MessageBox.Show("faild");
            }
        }
    }
}
