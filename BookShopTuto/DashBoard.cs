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

namespace BookShopTuto
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Books obj = new Books();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Users obj = new Users();
            obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DashBoard obj = new DashBoard();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tkzc\Documents\WhiteBookShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void DashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select sum(BQty) from BookTb1", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BookAmountLbl.Text = dt.Rows[0][0].ToString() + " 本";

                SqlDataAdapter sda1 = new SqlDataAdapter("select sum(Amount) from BillTb1", Con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                MoneyLbl.Text = dt1.Rows[0][0].ToString() + " 元";

                SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from UserTb1", Con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                MemberAmountLbl.Text = dt2.Rows[0][0].ToString() + " 人";
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
