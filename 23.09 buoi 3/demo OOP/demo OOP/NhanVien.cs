using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_OOP
{
    class NhanVien
    {
        private string _MaNV;
        private string _TenNV;
        private double _TienLuong1h;
        private double _SoGio;

        public string MaNhanVien
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }

        public string TenNhanVien
        {
            get { return _TenNV; }
            set { _TenNV = value; }
        }

        public double LuongMotGio
        {
            get { return _TienLuong1h; }
            set { _TienLuong1h = value; }
        }

        public double SoGioLam
        {
            get { return _SoGio; }
            set { _SoGio = value; }
        }

        public void Nhap(string ma, string ten, double luong, double gio)
        {
            this._MaNV = ma;
            this._TenNV = ten;
            this._TienLuong1h = luong;
            this._SoGio = gio;
        }

        public double TinhLuong()
        {
            return this._TienLuong1h * this._SoGio;
        }

        public string Xuat()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}", this._MaNV, this._TenNV, this._TienLuong1h, this._SoGio, this.TinhLuong());
        }
    }
}
