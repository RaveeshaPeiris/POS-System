using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project3
{
    public partial class AddProducts : Form
    {
        public AddProducts()
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
            PnameTb.Text = "";
            QtyTb.Text = "";
            PriceTb.Text = "";
            PCatCb.SelectedIndex = -1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(PnameTb.Text == "" || PCatCb.SelectedIndex ==-1 || PriceTb.Text == ""|| QtyTb.Text == "")
            {
                MBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ProductTbl(PName,PCat,Pprice,PQty)values(@PN,@PC,@PP,@PQ)", con);
                    cmd.Parameters.AddWithValue("@PN", PnameTb.Text);
                    cmd.Parameters.AddWithValue("@PC", PCatCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PP", PriceTb.Text);
                    cmd.Parameters.AddWithValue("@PQ", QtyTb.Text);
                    cmd.ExecuteNonQuery();
                    MBox.Show("Product Saved");
                    con.Close();
                    Reset();
                }catch(Exception ex)
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
