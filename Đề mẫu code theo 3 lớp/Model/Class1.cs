using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Model
{
    public class Model_thuvien
    {
        public SqlConnection getConnect()
        {
            return new SqlConnection(@"Data Source=DESKTOP-3IL1R52\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True");
        }

        public DataTable getTable(string sql)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public void ExcuteNonQuery(string sql)
        {
            SqlConnection conn = getConnect();
            conn.Open();
            SqlCommand com = new SqlCommand(sql, conn);
            com.ExecuteNonQuery();
            com.Dispose();
            com.Clone();
        }
    }
}
