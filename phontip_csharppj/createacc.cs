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
    public partial class createacc : Form
    {
        //MySqlCommand cmd;
        //MySqlDataAdapter da;
        //DataTable dt;
        DataSet ds = new DataSet();
        public createacc()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection() //เชื่อมต่อ database
        {
            string connectionString = " datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }
        private void Create_Button_Click(object sender, EventArgs e)
        {


            MySqlConnection conn = databaseConnection();

            if (username_textBox.Text == "" || passw_textBox.Text == "" || phonetextBox.Text == "" || addresstextBox.Text == "")
            {
                MessageBox.Show("Please Enter your information completely");
            }
            else
            {

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE User_Name='" + username_textBox.Text + "'", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("Username  " + username_textBox.Text + "  Alredy Exists");
                    ds.Clear();
                }
                else
                {
                    try
                    {

                        string sql = $"INSERT INTO user (User_Name,Password,Phone,Address) VALUES (\"{username_textBox.Text}\",\"{passw_textBox.Text}\",\"{phonetextBox.Text}\",\"{addresstextBox.Text}\")";
                        cmd = new MySqlCommand(sql, conn);
                        conn.Open();
                        int row = cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Create Account Successfully");
                        login Obj = new login();
                        Obj.Show();
                        this.Hide();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            

        }

         
                
                  

        private void phonetextBox_KeyPress(object sender, KeyPressEventArgs e) //เช็คค่าให้กรอกได้เฉพาะตัวเลข
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cancel_Click(object sender, EventArgs e) //กลับไปที่หน้า login
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        
    }
}
