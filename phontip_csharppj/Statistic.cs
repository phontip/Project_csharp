using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace phontip_csharppj
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
        }
        
        MySqlConnection conn = new MySqlConnection(" datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;");
        private void Statistic_Load(object sender, EventArgs e) //ดึงยอดรวมจํานวนสินค้า จํานวนเงิน จํานวนบัญชีผู้ใช้
        {
            conn.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select sum(Quantity) from pair", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            product_stock.Text = dt.Rows[0][0].ToString();

            MySqlDataAdapter sda1 = new MySqlDataAdapter("select sum(Amount) from bill", conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            total_amount.Text = dt1.Rows[0][0].ToString();
            conn.Close();

            MySqlDataAdapter sda2 = new MySqlDataAdapter("select Count(*) from user", conn);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            user.Text = dt2.Rows[0][0].ToString();
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e) //กลับไปหน้าstock
        {
            stock Obj = new stock();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e) //กลับไปหน้า user
        {
            User Obj = new User();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e) //กลับไปหน้า login
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        
    }
}
