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
using System.Data.SqlClient;

namespace BookShopTuto
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            Populate();
        }

        private void Populate()
        {
            try
            {
                Con.Open();
                string query = "select * from UserTb1";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                UserDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset()
        {
            UNameTb.Text = "";
            UPhoneTb.Text = "";
            UAddrTb.Text = "";
            UPwdTb.Text = "";
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tkzc\Documents\WhiteBookShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || UPhoneTb.Text == "" || UAddrTb.Text == "" || UPwdTb.Text == "")
            {
                MessageBox.Show("信息缺失！！！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into UserTb1 values('" + UNameTb.Text + "', '" + UPhoneTb.Text + "', '" + UAddrTb.Text + "', " + UPwdTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("用户信息保存成功！！！");
                    Con.Close();
                    Populate();
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

        private int key = 0;

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("信息缺失！！！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from UserTb1 where UId = " + key + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("用户信息删除成功！！！");
                    Con.Close();
                    Populate();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UNameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UPhoneTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            UAddrTb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            UPwdTb.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (UNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || UPhoneTb.Text == "" || UAddrTb.Text == "" || UPwdTb.Text == "")
            {
                MessageBox.Show("信息缺失！！！");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update UserTb1 set UName = '" + UNameTb.Text + "', UPhone = '" + UPhoneTb.Text + "', UAdd = '" + UAddrTb.Text + "', UPassword = '" + UPwdTb.Text + "' where UId = " + key + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("用户信息更新成功！！！");
                    Con.Close();
                    Populate();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
    }
}
