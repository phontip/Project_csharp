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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection() //เชื่อมต่อ database
        {
            string connectionString = " datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }
        private void Showdata(string valueToSearch) //โชว์ data user
        {
            MySqlConnection conn = databaseConnection();
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
      
        public void SELECT_DGV(string valueToSearch) //ใช้search
        {
            MySqlConnection conn = databaseConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM user WHERE CONCAT(ID,User_Name,Phone,Address,Password) LIKE '%" + valueToSearch + "%'", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGrid.AllowUserToAddRows = false;
            dataGrid.DataSource = table;         
           

        }
        private void textBox5_TextChanged(object sender, EventArgs e)//ช่องค้นหา
        {

            SELECT_DGV(textBox5.Text);
        }

        private void Usere_Load(object sender, EventArgs e)
        {
            Showdata("SELECT * FROM user");
        } 
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e) //คลิก datagrid ไป textbox
        {
            MySqlConnection conn = databaseConnection();
            dataGrid.CurrentRow.Selected = true;
            textBox1.Text = dataGrid.Rows[e.RowIndex].Cells["User_Name"].FormattedValue.ToString();
            textBox2.Text = dataGrid.Rows[e.RowIndex].Cells["Phone"].FormattedValue.ToString();
            textBox3.Text = dataGrid.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
            textBox4.Text = dataGrid.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();
           
          
           
           
            
            

        }

        private void Save_Button_Click(object sender, EventArgs e) //ปุ่มบันทึก
        {
                MySqlConnection conn = databaseConnection();
                string sql = $"INSERT INTO user (User_Name,Phone,Address,Password) VALUES (\"{textBox1.Text}\",\"{textBox2.Text}\",\"{textBox3.Text}\",\"{textBox4.Text}\")";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    MessageBox.Show("Save Data Successfully");
                    Showdata("SELECT * FROM user");
                }
            

        }

        private void Edit_Button_Click(object sender, EventArgs e) //ปุ่มแก้ไขข้อมูล
        {
            {
                int selectRow = dataGrid.CurrentCell.RowIndex;
                int EditID = Convert.ToInt32(dataGrid.Rows[selectRow].Cells["ID"].Value);
                MySqlConnection conn = databaseConnection();
                string sql = $"UPDATE user SET User_Name = \"{textBox1.Text}\",Phone=\"{textBox2.Text}\",Address=\"{textBox3.Text}\",Password=\"{textBox4.Text}\"WHERE id = \"{EditID}\"";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
              
                MessageBox.Show("Edit Data Successfully");
                Showdata("SELECT * FROM pair");  
            }
        }

        private void delete_Button_Click(object sender, EventArgs e) //ปุ่มลบข้อมูล
        {
            int selectRow = dataGrid.CurrentCell.RowIndex;
            int deleteID = Convert.ToInt32(dataGrid.Rows[selectRow].Cells["ID"].Value);
            MySqlConnection conn = databaseConnection();
            string sql = $"DELETE FROM user WHERE ID = \"{deleteID}\"";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            conn.Close();
      
            MessageBox.Show("Delete Data Successfully");
            Showdata("SELECT * FROM user");

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) //เช็คค่าให้กรอกได้เฉพาะตัวเลข
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void label6_Click(object sender, EventArgs e) //ปุ่ม logout
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)//ปุ่ม product
        {
            stock Obj = new stock();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e) //ปุ่ม Statistic
        {
            Statistic Obj = new Statistic();
            Obj.Show();
            this.Hide();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
             
                dataGrid.CurrentRow.Selected = true;
                textBox1.Text = dataGrid.Rows[e.RowIndex].Cells["User_Name"].FormattedValue.ToString();
                textBox2.Text = dataGrid.Rows[e.RowIndex].Cells["Phone"].FormattedValue.ToString();
                textBox3.Text = dataGrid.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                textBox4.Text = dataGrid.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();

                



            
        }
    }
}
