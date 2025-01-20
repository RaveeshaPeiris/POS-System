using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project3
{
    public partial class AddSuppliers : Form
    {
        public AddSuppliers()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\project3Db.mdf;Integrated Security=True;Connect Timeout=30");
        private void Reset()
        {
            SNameTb.Text = "";
            SPhoneTb.Text = "";
            SAddressTb.Text = "";
            SRemarks.Text = "";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || SAddressTb.Text == "" || SPhoneTb.Text == "" || SRemarks.Text == "")
            {
                MBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SupplierTbl(SupName,SupAddress,SupPhone,SupRem)values(@SN,@SA,@SP,@SR)", con);
                    cmd.Parameters.AddWithValue("@SN", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@SA", SAddressTb.Text);
                    cmd.Parameters.AddWithValue("@SP", SPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SR", SRemarks.Text);
                    cmd.ExecuteNonQuery();
                    MBox.Show("Supplier Saved");
                    con.Close();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
