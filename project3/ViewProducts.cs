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
    public partial class ViewProducts : Form
    {
        public ViewProducts()
        {
            InitializeComponent();
            DisplayProducts();


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            MainMenue obj = new MainMenue();
            obj.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\project3Db.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayProducts()
        {
            con.Open();
            string Query = "Select * from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MBox.Show("Select The Product");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ProductTbl where PId=@PKey", con);
                    cmd.Parameters.AddWithValue("@PKey",Key );
                    
                    cmd.ExecuteNonQuery();
                    MBox.Show("Product Deleted");
                    con.Close();
                    DisplayProducts();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        int Key = 0;
        private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               DataGridViewRow row = this.ProductsDGV.Rows[e.RowIndex];

                PnameTb.Text = ProductsDGV.SelectedRows[0].Cells[1].Value.ToString();
                PCatCb.Text = ProductsDGV.SelectedRows[0].Cells[2].Value.ToString();
                PriceTb.Text = ProductsDGV.SelectedRows[0].Cells[3].Value.ToString();
                QtyTb.Text = ProductsDGV.SelectedRows[0].Cells[4].Value.ToString();

                if(PnameTb.Text == "")
                {
                    Key = 0;

                }else
                {
                    Key = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[0].Value.ToString());
                }

                PnameTb.Text = row.Cells["Pname"].Value.ToString();
                PCatCb.Text = row.Cells["PCat"].Value.ToString();
                PriceTb.Text = row.Cells["Pprice"].Value.ToString();
                QtyTb.Text = row.Cells["PQty"].Value.ToString();
            }
        }
     
    
        
        private void Reset()
        {
            PnameTb.Text = "";
            QtyTb.Text = "";
            PriceTb.Text = "";
            PCatCb.SelectedIndex = -1;
            Key = 0;
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PnameTb.Text == "" || PCatCb.SelectedIndex == -1 || PriceTb.Text == "" || QtyTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update ProductTbl set PName=@PN,PCat=@PC,Pprice=@PP,PQty=@PQ where PId=@PKey", con);
                    cmd.Parameters.AddWithValue("@PN", PnameTb.Text);
                    cmd.Parameters.AddWithValue("@PC", PCatCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PP", PriceTb.Text);
                    cmd.Parameters.AddWithValue("@PQ", QtyTb.Text);
                    cmd.Parameters.AddWithValue("@PKey",Key);
                    cmd.ExecuteNonQuery();
                    MBox.Show("Product Updated");
                    con.Close();
                    DisplayProducts();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
