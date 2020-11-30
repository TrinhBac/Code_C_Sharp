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
using System.Data.SqlClient;    //cái này khi chạy nó thêm vào thì phải (dòng số 5)

namespace Quản_lý_laptop
{
    public partial class Form1 : Form
    {
        private static string connStr = @"Data Source = DESKTOP-3IL1R52\SQLEXPRESS;Initial Catalog = QLLAPTOP; Integrated Security = True";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            FillComboBox();
            radioButton1.Checked = true;
        }

        private void FillDataGridView()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlStr = $"SELECT * FROM Laptop";
            SqlCommand com = new SqlCommand(sqlStr, conn);
            com.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            da.Dispose();
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void FillComboBox()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlStr = $"SELECT MaNSX, TenNSX FROM NSX";
            SqlCommand com = new SqlCommand(sqlStr, conn);
            com.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            conn.Close();

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenNSX";
            comboBox1.ValueMember = "MaNSX";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)  // thêm laptop
        {
            if(String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text)
                || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Bạn nhập thiếu thông tin", "Thông báo");
            }
            else
            {
                //them moi laptop
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string tinhTrang = "";
                if (radioButton1.Checked == true) tinhTrang = "Moi";
                if (radioButton2.Checked == true) tinhTrang = "Cu";
                string sqlStr = $"INSERT INTO Laptop VALUES('{textBox1.Text}', '{comboBox1.SelectedValue}'," +
                    $"'{textBox2.Text}', '{tinhTrang}', '{textBox3.Text}', '{textBox4.Text}')";
                SqlCommand com = new SqlCommand(sqlStr, conn);
                com.ExecuteNonQuery();
                conn.Close();

                //cap nhat lai grid view
                FillDataGridView();
            }
        }

        private bool CheckMaLaptop(string malaptop)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlStr = $"SELECT * FROM Laptop WHERE MaLaptop = {malaptop}";
            SqlCommand com = new SqlCommand(sqlStr, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            if (dt.Rows.Count == 0) return false;
            else return true;
        }

        private void button2_Click(object sender, EventArgs e)  //sửa laptop
        {
            if (CheckMaLaptop(textBox1.Text) == true)
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string tinhtrang = "";
                if (radioButton1.Checked == true)   tinhtrang = "Moi";
                if (radioButton2.Checked == true) tinhtrang = "Cu";
                string sqlStr = $"UPDATE Laptop SET MaLaptop = '{textBox1.Text}', MaNSX = '{comboBox1.SelectedValue}'," +
                    $"TenLaptop = N'{textBox2.Text}', TinhTrang = '{tinhtrang}', Gia = '{int.Parse(textBox3.Text)}'," +
                    $"SoLuong = '{int.Parse(textBox4.Text)}' WHERE MaLaptop = '{textBox1.Text}'";
                SqlCommand com = new SqlCommand(sqlStr, conn);
                com.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("Sửa thành công", "Thông báo");
                FillDataGridView();
            }
            else
                MessageBox.Show("Không tồn tại bản ghi", "Thông báo");
        }

        private void button3_Click(object sender, EventArgs e)  //xoá laptop
        {
            if (CheckMaLaptop(textBox1.Text) == true)
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string sqlStr = $"DELETE FROM Laptop WHERE MaLaptop = '{textBox1.Text}'";
                SqlCommand com = new SqlCommand(sqlStr, conn);
                com.ExecuteNonQuery();
                conn.Close();
                FillDataGridView();
            }
            else
                MessageBox.Show("Khong ton tai", "Thong bao");
        }

        private string GetTenNSX(string mansx)
        {
            string tenNSX = "";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlStr = $"SELECT TenNSX FROM NSX WHERE MaNSX = '{mansx}'";
            SqlCommand com = new SqlCommand(sqlStr, conn);
            com.CommandType = CommandType.Text;
            SqlDataReader dr = com.ExecuteReader();
            while(dr.Read() == true)
            {
                tenNSX = dr["TenNSX"].ToString();
            }
            dr.Close();
            conn.Close();
            return tenNSX;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;  // chỉ số của hàng mà user click vào
            if (i > -1) // để khi click vào header nó không truy vấn, header tính là row thứ -1
            {
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                comboBox1.Text = GetTenNSX(dataGridView1.Rows[i].Cells[1].Value.ToString());
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "Moi") radioButton1.Checked = true;
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "Cu") radioButton2.Checked = true;
                textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            }
        }
    }
}
