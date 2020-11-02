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


namespace Bài_tập_thực_hành_1
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        string connstring = @"Data Source=DESKTOP-3IL1R52\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
        //Data Source = DESKTOP - 3IL1R52\SQLEXPRESS;Integrated Security = True
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LayDuLieuDataGridView();
            LayDuLieuTenPB();
            //Mặc định giới tính là Nam
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            //Ô nhập liệu tại MaNV
            textBox1.Focus();
        }

        private void LayDuLieuDataGridView()
        {
            //Tạo chuỗi kết nối
            conn = new SqlConnection(connstring);
            //Mở kết nối
            conn.Open();
            //Câu lệnh lấy dữ liệu
            string sql = "select * from Employees";
            //bat dau truy van
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            //chuyen du lieu ve dataAdapter
            SqlDataAdapter da = new SqlDataAdapter(com);
            //tạo một kho ảo để lưu trữ dữ liệu
            DataTable dt = new DataTable();
            da.Fill(dt); // đổ dữ liệu vào kho
            da.Dispose(); //Giải phóng DataAdapter
            conn.Close(); // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }

        private void LayDuLieuTenPB()
        {
            //Tạo chuỗi kết nối
            conn = new SqlConnection(connstring);
            //Mở kết nối
            conn.Open();
            //Câu lệnh lấy dữ liệu
            string sql = "select DepartmentID,DepartmentName from Departments";
            //bat dau truy van
            SqlCommand com = new SqlCommand(sql, conn);
            com.CommandType = CommandType.Text;
            //chuyen du lieu ve dataAdapter
            SqlDataAdapter da = new SqlDataAdapter(com);
            //tạo một kho ảo để lưu trữ dữ liệu
            DataTable dt = new DataTable();
            da.Fill(dt); // đổ dữ liệu vào kho
            da.Dispose(); //Giải phóng DataAdapter
            conn.Close(); // đóng kết nối
                          //Gán dữ liệu nguồn cho comboBox
            comboBox1.DataSource = dt;
            //Gán trường sẽ hiển thị trên ComboBox
            comboBox1.DisplayMember = "DepartmentName";
            //Gán trường DepartmentID là mã ẩn sau mỗi DepartmentName
            //Vì trong bảng Employee chỉ có trường DapartmentID, cho nên mỗi DepartmentName
            //sẽ tương ứng 1 DepartmentID truyền vào.
            comboBox1.ValueMember = "DepartmentID";
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LayDuLieuDataGridView();
            LayDuLieuTenPB();
            //Mặc định giới tính là Nam
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            //Ô nhập liệu tại MaNV
            textBox1.Focus();
        }

        //2 function bên dưới phục vụ cho btn add nhân viên
        private void themMoiNhanVien()
        {
            try
            {
                //Tạo chuỗi kết nối
                conn = new SqlConnection(connstring);
                //Mở kết nối
                conn.Open();
                //câu lệnh thêm mới bản ghi
                string strInsert = "insert into Employees values('" +
                textBox1.Text + "','" + comboBox1.SelectedValue + "',N'";
                strInsert += textBox3.Text + "',N'" +
                textBox4.Text + "',N'" + textBox5.Text + "','";
                //Kiểm tra giới tính
                string gt;
                if (radioButton1.Checked == true)
                    gt = "Nam";
                else
                    gt = "Nu";
                strInsert += gt + "','" + dateTimePicker1.Value +
                "',N'" + textBox8.Text + "')";
                //Khai báo và khởi tạo command
                SqlCommand cmd = new SqlCommand(strInsert, conn);
                //Thực thi câu lệnh delete
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi nhập liệu!", "Thông báo");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" ||
                textBox4.Text == "" || textBox5.Text == "" || 
                textBox8.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Bạn nhập thiếu thông tin!", "Thông báo");
            }
            else
            {
                themMoiNhanVien();
                LayDuLieuDataGridView();
            }
        }

        //2 function bên dưới phục vụ cho btn edit nhân viên
        private bool KiemTraMaNV(int manv)
        {
            bool ktra = false;
            //Tạo chuỗi kết nối
            conn = new SqlConnection(connstring);
            //Mở kết nối
            conn.Open();
            //Câu lệnh lấy dữ liệu
            string sql = "select * from Employees where EmployeeID = '"+manv+"'";
            SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve dataAdapter
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt); // đổ dữ liệu vào kho
            da.Dispose(); //Giải phóng DataAdapter
            conn.Close(); // đóng kết nối
            if (dt.Rows.Count == 0)
                ktra = false;
            else
                ktra = true;
            return ktra;
        }

        private void SuaNhanVien()
        {
            try
            {
                //Tạo chuỗi kết nối
                conn = new SqlConnection(connstring);
                //Mở kết nối
                conn.Open();
                //câu lệnh cập nhật bản ghi
                string strUpdate = "Update Employees set DepartmentID = '" + comboBox1.SelectedValue + "',FirstName = N'";
                strUpdate += textBox3.Text + "',LastName=N'" + textBox4.Text + "',FullName=N'" + textBox5.Text + "',Gender='";
                //Kiểm tra giới tính
                string gt;
                if (radioButton1.Checked == true)
                    gt = "Nam";
                else
                    gt = "Nu";
                strUpdate += gt + "',Birthday='" +
                dateTimePicker1.Value + "',Addres=N'" + textBox8.Text + "' where EmployeeID = '"+textBox1.Text+"'";
                //Khai báo và khởi tạo command
                SqlCommand cmd = new SqlCommand(strUpdate, conn);
                //Thực thi câu lệnh delete
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi nhập liệu!", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (KiemTraMaNV(int.Parse(textBox1.Text)) == false)
            {
                MessageBox.Show("Không có nhân viên này!", "Thông báo");
            }
            else
            {
                if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox8.Text == "" || comboBox1.Text =="")
                    MessageBox.Show("Bạn nhập thiếu thông tin!",
                    "Thông báo");
                else
                {
                    SuaNhanVien();
                    LayDuLieuDataGridView();
                }
            }
        }

        //function bên dưới phục vụ cho btn xoá nhân viên
        private void XoaNhanVien()
        {
            try
            {
                //Tạo chuỗi kết nối
                conn = new SqlConnection(connstring);
                //Mở kết nối
                conn.Open();
                //câu lệnh cập nhật bản ghi
                string strDelete = "Delete from Employees where EmployeeID = '" + textBox1.Text + "'";
                //Khai báo và khởi tạo command
                SqlCommand cmd = new SqlCommand(strDelete, conn);
                    //Thực thi câu lệnh delete
                    cmd.ExecuteNonQuery();
                    conn.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi nhập liệu!", "Thông báo");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (KiemTraMaNV(int.Parse(textBox1.Text)) == false)
            {
                MessageBox.Show("Không có nhân viên này!", "Thông báo");
            }
            else
            {
                XoaNhanVien();
                LayDuLieuDataGridView();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            LayDuLieuTenPB();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox8.Clear();
            radioButton1.Checked = true; 
            radioButton2.Checked = false;
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult ok = new DialogResult();
            ok = MessageBox.Show("Bạn có muốn thoát?", "Question",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.Yes)
                Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.Rows.ToString();
        }
    }
    
}
