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
    public partial class ViewBills : Form
    {
        public ViewBills()
        {
            InitializeComponent();
            DisplayBill();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\project3Db.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayBill()
        {
            con.Open();
            string Query = "Select * from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellsDGV.DataSource = ds.Tables[0];
            con.Close();

        }
        private void ViewBills_Load(object sender, EventArgs e)
        {

        }
    }
}
