using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project3
{
    public partial class Logins : Form
    {
        public Logins()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Billing Obj = new Billing();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UsernameTb.Text == "" || PasswordTb.Text == "")
            {
                MBox.Show("Enter Username and Password");
            }
            else if(UsernameTb.Text=="Admin" && PasswordTb.Text =="Password")
            {
                MainMenue Obj = new MainMenue();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MBox.Show("Invalid Username or Password");
            }
        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {
            PasswordTb.PasswordChar= '*';
        }
    }
}
