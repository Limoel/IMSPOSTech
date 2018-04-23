using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IMSTech
{
    public partial class frmCategory : Form
    {
        ServerConnection server = new ServerConnection();
        public string ID = "";

        public frmCategory()
        {
            InitializeComponent();
        }

        private void ReloadList()
        {
            listView1.Items.Clear();
            try
            {
                string Categoryist = "Select * from prdct_category";
                server.Connection();
                MySqlCommand cmd = new MySqlCommand(Categoryist, server.con);
                MySqlDataReader read;
                server.OpenConnection();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem Category = new ListViewItem(read["ID"].ToString());
                    Category.SubItems.Add(read["Category"].ToString());
                    listView1.Items.Add(Category);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                server.CloseConnection();
            }
            server.CloseConnection();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            else
                txtCategory.Text = listView1.SelectedItems[0].SubItems[1].Text;
            ID = listView1.SelectedItems[0].SubItems[0].Text;

        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ReloadList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text != "" && txtCategory.Text != null)
            {
                try
                {
                    string Categoryist = "insert into prdct_category(Category)values('" + txtCategory.Text + "')";
                    server.Connection();
                    MySqlCommand cmd = new MySqlCommand(Categoryist, server.con);
                    MySqlDataReader read;
                    server.OpenConnection();
                    read = cmd.ExecuteReader();
                    MessageBox.Show("Category Save Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    server.CloseConnection();
                }
                server.CloseConnection();
                ReloadList();
            }
            else
            {
                MessageBox.Show("Field Empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text != "" && txtCategory.Text != null)
            {
                try
                {
                    string Categoryist = "update prdct_category set Category = '" + txtCategory.Text + "' where ID = '" + ID + "'";
                    server.Connection();
                    MySqlCommand cmd = new MySqlCommand(Categoryist, server.con);
                    MySqlDataReader read;
                    server.OpenConnection();
                    read = cmd.ExecuteReader();
                    MessageBox.Show("Updating Category Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    server.CloseConnection();
                }
                server.CloseConnection();
                ReloadList();
            }
            else
            {
                MessageBox.Show("Field Empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text != "" && txtCategory.Text != null)
            {
                DialogResult result = MessageBox.Show("Do you want to delete this Category ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }

                try
                {
                    string Categoryist = "delete from prdct_category where ID = '" + ID + "' and Category = '" + txtCategory.Text + "'";
                    server.Connection();
                    MySqlCommand cmd = new MySqlCommand(Categoryist, server.con);
                    MySqlDataReader read;
                    server.OpenConnection();
                    read = cmd.ExecuteReader();
                    MessageBox.Show("Deleting Category Success", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    server.CloseConnection();
                }
                server.CloseConnection();
                ReloadList();
            }
            else
            {
                MessageBox.Show("Field Empty", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
