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
    public partial class ViewSuppliers : Form
    {
        public ViewSuppliers()
        {
            InitializeComponent();
            DisplaySup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenue obj = new MainMenue();
            obj.Show();
            this.Close();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\project3Db.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplaySup()
        {
            con.Open();
            string Query = "Select * from SupplierTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SuppliersDGV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void Reset()
        {
            SNameTb.Text = "";
            SPhoneTb.Text = "";
            SAddressTb.Text = "";
            SRemarksTb.Text = "";
            Key = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MBox.Show("Select The Supplier");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from SupplierTbl where SupId=@SKey", con);
                    cmd.Parameters.AddWithValue("@SKey", Key);

                    cmd.ExecuteNonQuery();
                    MBox.Show("Supplier Deleted");
                    con.Close();
                    DisplaySup();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        int Key = 0;
        private void SuppliersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.SuppliersDGV.Rows[e.RowIndex];

                SNameTb.Text = SuppliersDGV.SelectedRows[0].Cells[1].Value.ToString();
                SAddressTb.Text = SuppliersDGV.SelectedRows[0].Cells[2].Value.ToString();
                SPhoneTb.Text = SuppliersDGV.SelectedRows[0].Cells[3].Value.ToString();
                SRemarksTb.Text = SuppliersDGV.SelectedRows[0].Cells[4].Value.ToString();

                if (SNameTb.Text == "")
                {
                    Key = 0;

                }
                else
                {
                    Key = Convert.ToInt32(SuppliersDGV.SelectedRows[0].Cells[0].Value.ToString());
                }

                SNameTb.Text = row.Cells["SupName"].Value.ToString();
                SAddressTb.Text = row.Cells["SupAddress"].Value.ToString();
                SPhoneTb.Text = row.Cells["SupPhone"].Value.ToString();
                SRemarksTb.Text = row.Cells["SupRem"].Value.ToString();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || SAddressTb.Text == "" || SPhoneTb.Text == "" || SRemarksTb.Text == "")
            {
                MBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update SupplierTbl set SupName=@SN,SupAddress=@SA,SupPhone=@SP,SupRem=@SR where SupId=@SKey", con);
                    cmd.Parameters.AddWithValue("@SN", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@SA", SAddressTb.Text);
                    cmd.Parameters.AddWithValue("@SP", SPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SR", SRemarksTb.Text);
                    cmd.Parameters.AddWithValue("@SKey", Key);
                    cmd.ExecuteNonQuery();
                    MBox.Show("Supplier Updated");
                    con.Close();
                    DisplaySup();
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
