using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Model;

namespace Controller
{
    public class Controller_thuvien
    {
        Model_thuvien model = new Model_thuvien();

        public DataTable getDataSource(string tableName)
        {
            if(tableName == "SACH")
            {
                string sql = $"Select MaSach, TenSach, SoTrang, TenTheLoai from SACH inner join THE_LOAI on SACH.MaTheLoai = THE_LOAI.MaTheLoai";
                return model.getTable(sql);
            }
            else  //if (tableName == "THE_LOAI")
            {
                string sql = $"Select * from THE_LOAI";
                return model.getTable(sql);
            }
        }

        public bool checkID(string id)
        {
            string sql = $"Select * from SACH where MaSach = '{id}'";
            if (model.getTable(sql).Rows.Count > 0)
                return true;   //da co
            else return false;   //chua co
        }

        public void InsertSach(string maSach, string tenSach, int soTrang, string theLoai)
        {
            string sql = $"Insert into SACH values('{maSach}', N'{tenSach}', '{soTrang}', N'{theLoai}')";
            model.ExcuteNonQuery(sql);
        }

        public void EditSach(string maSach, string tenSach, int soTrang, string theLoai)
        {
            string sql = $"Update SACH set TenSach = N'{tenSach}', SoTrang = '{soTrang}', MaTheLoai = N'{theLoai}' where MaSach = '{maSach}'";
            model.ExcuteNonQuery(sql);
        }

        public void DeleteSach(string maSach, string tenSach, int soTrang, string theLoai)
        {
            string sql = $"Delete SACH where MaSach = '{maSach}'";
            model.ExcuteNonQuery(sql);
        }

        public DataTable SearchSach(string tensach)
        {
            string sql = $"Select * from SACH where TenSach like N'%{tensach}%'";
            return model.getTable(sql);
        }
    }
}
