using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL_QLSV
{
    public class DAL_Lop
    {
        //tạo kết nối csdl
        public SqlConnection getConnect()
        {
            return new SqlConnection(@"Data Source = DESKTOP-3IL1R52\SQLEXPRESS;Initial Catalog = QLSV; Integrated Security = True");
        }
        //trả về 1 bảng lưu trữ
        public DataTable getTable(string strsql)
        {
            SqlConnection conn = getConnect();
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        //Thực thi câu lệnh
        public void ExcuteNonQuery(string strsql)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            SqlCommand com = new SqlCommand(strsql, conn);
            com.ExecuteNonQuery();
            com.Dispose();
            com.Clone();
        }
    }
}
