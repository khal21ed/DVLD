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

        private void button1_Click(object sender, EventArgs e)
        {
           label1.Text= clsCountry.findCountryByName(textBox1.Text).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             DataTable dt = clsCountry.getAllCountryNames();

            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["CountryName"]);
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "first name should not be empty");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("hello");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
