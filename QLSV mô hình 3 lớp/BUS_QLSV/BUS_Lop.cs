using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using DAL_QLSV;

namespace BUS_QLSV
{
    public class BUS_Lop
    {
        DAL_Lop dalLop = new DAL_Lop();
        //Lấy thông tin các lớp
        public DataTable ShowLop()
        {
            string sql = "select * from Lop";
            DataTable dt = new DataTable();
            dt = dalLop.getTable(sql);
            return dt;
        }
        //Insert table Lop
        public void InsertLop(string ml, string tl, string ph)
        {
            string sql = "Insert into Lop values('" + ml +"',N'" + tl + "',N'" + ph + "')";
            dalLop.ExcuteNonQuery(sql);
        }
        //Xóa table Lop
        public void DeleteLop(string ml)
        {
            string sql = "Delete Lop where malop='" + ml + "'";
            dalLop.ExcuteNonQuery(sql);
        }
        //Cập nhật lớp
        public void UpdateLop(string ml, string tl, string ph)
        {
            string sql = "update lop set tenlop = N'"+tl+"',Phong = N'"+ph+"' where malop = '"+ml+"'";
            dalLop.ExcuteNonQuery(sql);
        }
        //tìm kiếm theo tenlop
        public DataTable LookLop(string tl)
        {
            string sql = "select * from lop where tenlop like N'%" + tl + "%'";
            DataTable dt = new DataTable();
            dt = dalLop.getTable(sql);
            return dt;
        }
    }
}
