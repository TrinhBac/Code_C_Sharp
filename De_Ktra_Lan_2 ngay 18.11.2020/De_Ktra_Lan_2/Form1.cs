using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace De_Ktra_Lan_2
{
    public partial class Form1 : Form
    {
        string connStr = @"Data Source=DESKTOP-3IL1R52\SQLEXPRESS;Initial Catalog=Ktra_Lan_2;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }



        private void button4_Click(object sender, EventArgs e)  //thoat
        {
            Application.Exit();
        }

        private void FillDataGridView()
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlStr = $"SELECT * FROM Sach";
            SqlCommand com = new SqlCommand(sqlStr, conn);
            com.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            textBox1.Focus();
        }

        private bool CheckMaSP(string masp)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sqlStr = $"SELECT * FROM Sach WHERE MaSach = '{masp}'";
            SqlCommand com = new SqlCommand(sqlStr, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            conn.Close();
            if (dt.Rows.Count == 0) return true;    //chưa tồn tại mã
            else return false;  // đã tồn tại mã
        }

        private void button1_Click(object sender, EventArgs e)  //them
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text)
                || String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Thiếu thông tin", "Thông báo");
            }
            else
            {
                if (CheckMaSP(textBox1.Text) == true)
                {
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    bool sachDT = false;
                    if (checkBox1.Checked == true)
                        sachDT = true;
                    string sqlStr = $"INSERT INTO Sach VALUES('{textBox1.Text}'," +
                        $"N'{textBox2.Text}', '{int.Parse(textBox3.Text)}', '{dateTimePicker1.Value}', '{sachDT}')";
                    SqlCommand com = new SqlCommand(sqlStr, conn);
                    com.ExecuteNonQuery();
                    conn.Close();
                    FillDataGridView();
                }
                else
                    MessageBox.Show("Đã tồn tại mã sách", "Thông báo");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)   //check dữ liệu số trang
        {
            if (!String.IsNullOrWhiteSpace(textBox3.Text))
            {
                try
                {
                    int.Parse(textBox3.Text);
                }
                catch
                {
                    MessageBox.Show("Dữ liệu phải là số", "Thông báo");
                    textBox3.Clear();
                    textBox3.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)  //xoa
        {
            if (CheckMaSP(textBox1.Text) == false)
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                string sqlStr = $"DELETE FROM Sach WHERE MaSach = '{textBox1.Text}'";
                SqlCommand com = new SqlCommand(sqlStr, conn);
                com.ExecuteNonQuery();
                conn.Close();
                FillDataGridView();
            }
            else
                MessageBox.Show("Khong ton tai sach", "Thong bao");
        }

        private void button2_Click(object sender, EventArgs e)   //Sua
        {
            if (CheckMaSP(textBox1.Text) == false)
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                bool sachDT = false;
                if (checkBox1.Checked == true)
                    sachDT = true;
                string sqlStr = $"UPDATE Sach SET TenSach = N'{textBox2.Text}', " +
                    $"SoTrang = '{int.Parse(textBox3.Text)}', NamXB = '{dateTimePicker1.Value}', " +
                    $"SachDT = '{sachDT}' WHERE MaSach = '{textBox1.Text}'";

                SqlCommand com = new SqlCommand(sqlStr, conn);
                com.ExecuteNonQuery();
                conn.Close();
                FillDataGridView();
            }
            else
                MessageBox.Show("Không tồn tại bản ghi", "Thông báo");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)    //cell click
        {
            int i = e.RowIndex;
            if (i > -1)
            {
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "True")
                    checkBox1.Checked = true;
                else checkBox1.Checked = false;
            }
        }
    }
}
