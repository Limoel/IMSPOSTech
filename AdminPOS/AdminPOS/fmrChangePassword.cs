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
    public partial class fmrChangePassword : Form
    {
        public int timeLeft = 30;

        public fmrChangePassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void fmrChangePassword_Load(object sender, EventArgs e)
        {
            frmSecurityQuestion security = new frmSecurityQuestion();

            timeLeft = 30;
            txtPassword.Text = frmSecurityQuestion.Password;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft.ToString();
            }
            else
            {
                this.Hide();
            }
        }
    }
}
