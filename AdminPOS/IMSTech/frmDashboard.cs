using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using IMSTech.Properties;

namespace IMSTech
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("ProductTab");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmNewProducts frmNewProducts = new frmNewProducts();
            DialogResult AddedNewProducts = frmNewProducts.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmDataKey frmKey = new frmDataKey();
            DialogResult frmKeyForm = frmKey.ShowDialog();
            if (frmKeyForm == DialogResult.OK)
            {
                tabControl1.SelectTab("SettingsTab");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default["Server"] = txtServer.Text;
                Settings.Default["User"] = txtUser.Text;
                Settings.Default["Password"] = txtPassword.Text;
                Settings.Default["Port"] = txtPort.Text;
                Settings.Default["Database"] = txtDatabase.Text;
                Settings.Default.Save();
                MessageBox.Show("Server Information Save","",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            txtServer.Text = Settings.Default["Server"].ToString();
            txtUser.Text = Settings.Default["User"].ToString();
            txtPassword.Text = Settings.Default["Password"].ToString();
            txtPort.Text =  Settings.Default["Port"].ToString();
            txtDatabase.Text = Settings.Default["Database"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmCategory category = new frmCategory();
            category.ShowDialog();
        }
    }
}
