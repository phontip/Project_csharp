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
    public partial class ttuser : Form
    {
        public ttuser()
        {
            InitializeComponent();
        }
      
        MySqlConnection conn = new MySqlConnection(" datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;");
        
        private void Showdata(string valueToSearch) //โชว์ data user
        {
            
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM user";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);


            dataGrid.DataSource = ds.Tables[0].DefaultView;


            conn.Close();

        }
      

        private void ttuser_Load(object sender, EventArgs e)
        {
            Showdata("SELECT * FROM user");

            MySqlDataAdapter sda2 = new MySqlDataAdapter("select Count(*) from user", conn);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            stocklabel1.Text = dt2.Rows[0][0].ToString();//เอาจํานวนผู้ใช้
            conn.Close();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Statistic Obj = new Statistic();
            Obj.Show();
            this.Hide();
        }
    }
}
