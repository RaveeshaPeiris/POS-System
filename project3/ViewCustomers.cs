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
    public partial class ViewCustomers : Form
    {
        public ViewCustomers()
        {
            InitializeComponent();
            DisplayCust();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MainMenue obj = new MainMenue();
            obj.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\project3Db.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayCust()
        {
            con.Open();
            string Query = "Select * from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomersDGV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void Reset()
        {
            CNameTb.Text = "";
            CPhoneTb.Text = "";
            CAddressTb.Text = "";
            Key = 0;

        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MBox.Show("Select The Customer");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CustomerTbl where CustId=@CKey", con);
                    cmd.Parameters.AddWithValue("@CKey", Key);

                    cmd.ExecuteNonQuery();
                    MBox.Show("Customer Deleted");
                    con.Close();
                    DisplayCust();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        int Key = 0;
        private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.CustomersDGV.Rows[e.RowIndex];

                CNameTb.Text = CustomersDGV.SelectedRows[0].Cells[1].Value.ToString();
                CAddressTb.Text = CustomersDGV.SelectedRows[0].Cells[2].Value.ToString();
                CPhoneTb.Text = CustomersDGV.SelectedRows[0].Cells[3].Value.ToString();
               

                if (CNameTb.Text == "")
                {
                    Key = 0;

                }
                else
                {
                    Key = Convert.ToInt32(CustomersDGV.SelectedRows[0].Cells[0].Value.ToString());
                }

                CNameTb.Text = row.Cells["CustName"].Value.ToString();
                CAddressTb.Text = row.Cells["CustAd"].Value.ToString();
                CPhoneTb.Text = row.Cells["Custphone"].Value.ToString();
                
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CPhoneTb.Text == "" || CAddressTb.Text == "" || Key ==0)
            {
                MBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update CustomerTbl set CustName=@CN,CustAd=@CA,Custphone=@CP where CustId=@CKey", con);
                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CAddressTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MBox.Show("Customer Updated");
                    con.Close();
                    DisplayCust();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
