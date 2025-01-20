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
    public partial class MBox : Form
    {
        public MBox()
        {
            InitializeComponent();
            MessageLbl.Text = Message;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        static string Message;
        public static void Show (string msg)
        {
            Message = msg;
            MBox obj = new MBox();
            obj.Show();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void MBox_Load(object sender, EventArgs e)
        {

        }

        private void MessageLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
