using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdminPOS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTitle.Text = frmLogin.FullName;
            lblResponsible.Text = "Account Level : " + frmLogin.Responsibility;
            if (frmLogin.Responsibility != "Admin")
            {
                btnSettings.Enabled = false;
                btnUserManage.Enabled = false;
            }
            else
            {
                btnSettings.Enabled = true;
                btnUserManage.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult Logout = MessageBox.Show("Do you want to Logout ?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Logout == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnUserManage_Click(object sender, EventArgs e)
        {
            frmUserManage user = new frmUserManage();
            user.ShowDialog();
        } 
    }
}
