using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdminPOS.Properties;

namespace AdminPOS
{
    public partial class frmSettings : Form
    {
        
        public frmSettings()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Maintenance";
            tabControl1.SelectTab("Maintenance");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Server Connection";
            tabControl1.SelectTab("ServerConnection");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Store Information";
            tabControl1.SelectTab("StoreInformation");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Warning = MessageBox.Show("Do you want to save changes ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Warning == DialogResult.No)
            {
                return;
            }

            Settings.Default["POSCode"] = txtPOSCode.Text;
            Settings.Default["Server"] = txtServer.Text;
            Settings.Default["User"] = txtUser.Text;
            Settings.Default["Password"] = txtPassword.Text;
            Settings.Default["Port"] = txtPort.Text;
            Settings.Default.Save();
            MessageBox.Show("Database Changes Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtServer.Text = Settings.Default["Server"].ToString();
            txtPort.Text = Settings.Default["Port"].ToString();
            txtPOSCode.Text = Settings.Default["POSCode"].ToString();
            txtUser.Text = Settings.Default["User"].ToString();
            txtPassword.Text = Settings.Default["Password"].ToString();
            if (frmLogin.DefaultUserAccess == false)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }
    }
}
