using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace phontip_csharppj
{
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection() //เชื่อมต่อ database
        {
            string connectionString = " datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }

        public static string UserName = "";

        private void login_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from user where User_Name ='" + username_textBox.Text + "' and Password='" + passw_textBox.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                UserName = username_textBox.Text;

                pairshop obj = new pairshop();
                obj.Show();
                this.Hide();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            conn.Close();
        }


        private void label5_Click(object sender, EventArgs e) //ไปหน้าcreateacc
        {
            createacc Obj = new createacc();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e) //ไปหน้า admin
        {
            admin Obj = new admin();
            Obj.Show();
            this.Hide();
        }

        private void cancel_Click(object sender, EventArgs e) //ปุ่ม exit
        {
            Application.Exit();
        }



        private void ShowPassword_checkBox_CheckedChanged(object sender, EventArgs e)//เปิดการมองเห็นรหัสผ่าน
        {
            if (ShowPassword_checkBox.Checked)
            {
                passw_textBox.UseSystemPasswordChar = true;
            }
            else
            {
                passw_textBox.UseSystemPasswordChar = false;
            }
               

        }

       
    }
}
