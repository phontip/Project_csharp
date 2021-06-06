using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;



namespace phontip_csharppj
{
    public partial class stock : Form
    {
        public stock()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection(" datasource=127.0.0.1;port=3306;username=root;password=;database=pair;charset=utf8;");
 
        public void FillDGV(string valueToSearch)//ใช้search
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM stock WHERE CONCAT(ID,Product_ID, Product_Name, Categories, Quantity, Price, image) LIKE '%" + valueToSearch+"%'", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGrid.RowTemplate.Height = 100;
            dataGrid.AllowUserToAddRows = false;

            dataGrid.DataSource = table;

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn) dataGrid.Columns[6];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 

        }

        private void select_Button_Click(object sender, EventArgs e) //เลือกรูปแล้วไปโชว์ที่ picturebox
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";
            if(opf.ShowDialog()==DialogResult.OK)
            {
                pictureBox6.Image = Image.FromFile(opf.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDGV("");
        }

        private void dataGrid_Click(object sender, EventArgs e) //คลิก datagrid ไปขึ้น textbox
        {
           
            Byte[] img = (Byte[])dataGrid.CurrentRow.Cells[6].Value;

            MemoryStream ms = new MemoryStream(img);
 
            pictureBox6.Image = Image.FromStream(ms); //ให้รูปขึ้นที่ pictureBox6

            textBox6.Text = dataGrid.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGrid.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGrid.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGrid.CurrentRow.Cells[5].Value.ToString();
     
        }

        private void Save_Button_Click(object sender, EventArgs e) //saveข้อมูล
        {
            MemoryStream ms = new MemoryStream();
            pictureBox6.Image.Save(ms, pictureBox6.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand command = new MySqlCommand("INSERT INTO stock(Product_ID, Product_Name, Categories, Quantity, Price, image) VALUES (@pro_id,@pro_name,@cate,@qty,@price,@image)", connection);

            command.Parameters.Add("@pro_id", MySqlDbType.Int32).Value = textBox1.Text;
            command.Parameters.Add("@pro_name", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@cate", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@qty", MySqlDbType.Int32).Value = textBox3.Text;
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = textBox4.Text;
            command.Parameters.Add("@image", MySqlDbType.LongBlob).Value = img;

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" )
            {
                ExecMyQuery(command, "Save Data Successfully");
            }
            
        }
 
        public void ExecMyQuery(MySqlCommand mcomd, string myMsg)
        {
            connection.Open();
            if(mcomd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);

            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }

            connection.Close();
            FillDGV("");
        }

        private void Edit_Button_Click(object sender, EventArgs e) //แก้ไขข้อมูล
        {
            MemoryStream ms = new MemoryStream();
            pictureBox6.Image.Save(ms, pictureBox6.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand command = new MySqlCommand("UPDATE stock SET Product_ID=@pro_id,Product_Name=@pro_name,Categories=@cate,Quantity=@qty,Price=@price,image=@image WHERE ID=@id", connection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = textBox6.Text;
            command.Parameters.Add("@pro_id", MySqlDbType.Int32).Value = textBox1.Text;
            command.Parameters.Add("@pro_name", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@cate", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@qty", MySqlDbType.Int32).Value = textBox3.Text;
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = textBox4.Text;
            command.Parameters.Add("@image", MySqlDbType.LongBlob).Value = img;

            ExecMyQuery(command, "Edit Data Successfully");
        }

        private void delete_Button_Click(object sender, EventArgs e) //ลบข้อมูล
        {
            MemoryStream ms = new MemoryStream();
            pictureBox6.Image.Save(ms, pictureBox6.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand command = new MySqlCommand("DELETE FROM stock WHERE ID=@id", connection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = textBox6.Text;
            

            ExecMyQuery(command, "Delet Data Successfully");
        }

        private void textBox5_TextChanged(object sender, EventArgs e) //ค้นหาข้อมูล
        {
            FillDGV(textBox5.Text);
        }

        private void label4_Click(object sender, EventArgs e)//มาหน้าuser
        {
            User Obj = new User();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)//มาหน้าstatistic
        {
            Statistic Obj = new Statistic();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e) //มาหน้าlogin
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e) //มาหน้าstock
        {
            stock Obj = new stock();
            Obj.Show();
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) //เช็คค่าให้กรอกได้เฉพาะตัวเลข
        {
            
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) //เช็คค่าให้กรอกได้เฉพาะตัวเลข
        {
            
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)//มาหน้าOrder
        {
            Order Obj = new Order();
            Obj.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            stock Obj = new stock();
            Obj.Show();
            this.Hide();
        }
    }
}
