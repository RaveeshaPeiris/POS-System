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
    public partial class Billings : Form
    {
        public Billings()
        {
            InitializeComponent();
            DisplayProducts();
            GetCustomer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logins Obj = new Logins();
            Obj.Show();
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
        private void GetCustName()
        {
            con.Open();
            string Query = "Select * from CustomerTbl where CustId=" + CustIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query,con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            con.Close();
        }
        private void SearchProducts()
        {
            con.Open();
            string Query = "Select * from ProductTbl where PName= ' "+SearchTb.Text+" ' ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            SearchProducts();
            SearchTb.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DisplayProducts();
            SearchTb.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void GetCustomer()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CustId from CustomerTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(rdr);
            CustIdCb.ValueMember = "CustId";
            CustIdCb.DataSource = dt;
            con.Close() ;
        }
        private void Reset()
        {
            Pname = "";
            QtyTb.Text = "";
            Key = 0;
        }
        int Key = 0;
        String Pname;
        int Pprice, PStock;
        int n = 0;

        private void AddToBill_Click(object sender, EventArgs e)
        {
            if(Key ==0)
            {
                MBox.Show("Select A Product");
            }
            else if(QtyTb.Text=="")
            {
                MBox.Show("Enter The Quantity");
            }
            else
            {
                int Subtotal = Convert.ToInt32(QtyTb.Text)*Pprice;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n;
                newRow.Cells[1].Value = Pname;
                newRow.Cells[2].Value = QtyTb.Text;
                newRow.Cells[3].Value = Pprice;
                newRow.Cells[4].Value = Subtotal;
                BillDGV.Rows.Add(newRow);
                n++;
                Reset();
            }
        }

        private void BillDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CustIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustName();
        }

       //private void CustIdCb(object sender, EventArgs e)
       // {

        //}

        private void CustIdCb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {

        }

        private void Billings_Load(object sender, EventArgs e)
        {

        }

        private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ProductsDGV.Rows[e.RowIndex];

                Pname = ProductsDGV.SelectedRows[0].Cells[1].Value.ToString();
                //PCatCb.Text = ProductsDGV.SelectedRows[0].Cells[2].Value.ToString();
                Pprice = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[3].Value.ToString());
                PStock = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[4].Value.ToString());

                if (Pname == "")
                {
                    Key = 0;

                }
                else
                {
                    Key = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[0].Value.ToString());
                }

               /* Pname = row.Cells["Pname"].Value.ToString();
                //PCat = row.Cells["PCat"].Value.ToString();
                Pprice = row.Cells["Pprice"].Value.ToString();
                PStock= row.Cells["PQty"].Value.ToString();               */
            }
        }
    }
}
