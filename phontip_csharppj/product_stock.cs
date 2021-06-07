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
using System.IO;


namespace phontip_csharppj
{
    public partial class product_stock : Form
    {
        public product_stock()
        {
            InitializeComponent();
        }
        
        private MySqlConnection databaseConnection() //เชื่อมต่อ database
        {
            string connectionString = " datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }
        private void Showdata(string valueToSearch) //โชว์ data stock
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM stock";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);


            dataGrid.DataSource = ds.Tables[0].DefaultView;


            conn.Close();

        }
        MySqlConnection connection = new MySqlConnection(" datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;");

        private void Accessories_Click(object sender, EventArgs e)//menustrip
        {
            MySqlDataAdapter da;
            DataTable dt;
            connection.Open();
            da = new MySqlDataAdapter("SELECT * FROM stock WHERE Categories LIKE'" + this.Accessories.Text + "%'", connection);
            dt = new DataTable();
            da.Fill(dt);

            dataGrid.AllowUserToAddRows = false;
            dataGrid.DataSource = dt;
            connection.Close();

            int numRows = dataGrid.Rows.Count;
            label1.Text = dataGrid.CurrentRow.Cells[2].Value.ToString()+"  "+ numRows.ToString() + "  piece";

        }

        private void Bag_Click(object sender, EventArgs e)//menustrip
        {
            MySqlDataAdapter da;
            DataTable dt;
            connection.Open();
            da = new MySqlDataAdapter("SELECT * FROM stock WHERE Categories LIKE'" + this.Bag.Text + "%'", connection);
            dt = new DataTable();
            da.Fill(dt);

            dataGrid.AllowUserToAddRows = false;
            dataGrid.DataSource = dt;
            connection.Close();

            int numRows = dataGrid.Rows.Count;
            label1.Text = dataGrid.CurrentRow.Cells[2].Value.ToString()+"  "+ numRows.ToString() + "  piece";

            
        }

        private void Hat_Click(object sender, EventArgs e)//menustrip
        {

            MySqlDataAdapter da;
            DataTable dt;
            connection.Open();
            da = new MySqlDataAdapter("SELECT * FROM stock WHERE Categories LIKE'" + this.Hat.Text + "%'", connection);
            dt = new DataTable();
            da.Fill(dt);

            dataGrid.AllowUserToAddRows = false;
            dataGrid.DataSource = dt;
            connection.Close();

            int numRows = dataGrid.Rows.Count;
            label1.Text = dataGrid.CurrentRow.Cells[2].Value.ToString()+"  "+ numRows.ToString() + "  piece";
        }

        private void product_stock_Load(object sender, EventArgs e)
        {
            connection.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select sum(Quantity) from pair", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            stocklabel1.Text = dt.Rows[0][0].ToString();//เอาจํานวน สินค้า
            connection.Close();

            Showdata("SELECT * FROM stock");

        }

        private void panel3_Click(object sender, EventArgs e)//กลับไปหน้าstatistic
        {
            Statistic Obj = new Statistic();
            Obj.Show();
            this.Hide();
        }
    }
}
