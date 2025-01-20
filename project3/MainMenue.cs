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
    public partial class MainMenue : Form
    {
        public MainMenue()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            AddProducts obj = new AddProducts();
            obj.Show();
            obj.TopMost = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AddSuppliers obj = new AddSuppliers();
            obj.Show();
            obj.TopMost = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            AddCustomers obj = new AddCustomers();
            obj.Show();
            obj.TopMost = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewProducts obj = new ViewProducts();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            ViewSuppliers obj = new ViewSuppliers();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

            ViewCustomers obj = new ViewCustomers();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
    }
}
