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
    public partial class Order_satt : Form
    {
        public Order_satt()
        {
            InitializeComponent();
        }

        private MySqlConnection databaseConnection() //เชื่อมต่อ database
        {
            string connectionString = " datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }
        private void Showdata(string valueToSearch) //โชว์ data bill
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM bill";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);


            dataGrid.DataSource = ds.Tables[0].DefaultView;


            conn.Close();

        }
        MySqlConnection connection = new MySqlConnection(" datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;");


        private void Order_satt_Load(object sender, EventArgs e)
        {
            

            connection.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select sum(Amount) from bill", connection);//เอาจํานวน สินค้ามาโชว์

            DataTable dt = new DataTable();
            sda.Fill(dt);
            orderlabel1.Text = dt.Rows[0][0].ToString();
            connection.Close();

            Showdata("SELECT * FROM bill");

        }

        private void panel3_Click(object sender, EventArgs e)
        {

            Statistic Obj = new Statistic();
            Obj.Show();
            this.Hide();
        }

        private void Order_Click(object sender, EventArgs e) //menustrip order
        {
            MySqlDataAdapter da;
            DataTable dt;
            connection.Open();
            da = new MySqlDataAdapter("SELECT * FROM bill", connection);
            dt = new DataTable();
            da.Fill(dt);

            dataGrid.AllowUserToAddRows = false;
            dataGrid.DataSource = dt;
            connection.Close();

           
        }

        private void item_Click(object sender, EventArgs e)//menustrip sold items
        {
            MySqlDataAdapter da;
            DataTable dt;
            connection.Open();
            da = new MySqlDataAdapter("SELECT * FROM oder", connection);
            dt = new DataTable();
            da.Fill(dt);

            dataGrid.AllowUserToAddRows = false;
            dataGrid.DataSource = dt;
            connection.Close();
        }
    }
}
