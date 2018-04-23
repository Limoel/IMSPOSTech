using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMSTech.Properties;

namespace IMSTech
{
    public partial class frmDataKey : Form
    {
        public frmDataKey()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Settings.Default["Data_Key"].ToString())
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Invalid Data Key", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
