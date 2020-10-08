using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace bai_2
{
    class NhanVien
    {
        private string _MaNhanVien;
        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }

        private string _TenNhanVien;

        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; }
        }

        private int _Luong1Gio;
        public int Luong1Gio
        {
            get { return _Luong1Gio; }
            set { _Luong1Gio = value; }
        }

        private double _SoGioLamViec;

        public double SoGioLamViec
        {
            get { return _SoGioLamViec; }
            set { _SoGioLamViec = value; }
        }

        public NhanVien(string maNhanVien, string hoTen,
            int luong1Gio, double soGioLamViec)
        {
            this.MaNhanVien = maNhanVien;
            this.TenNhanVien = hoTen;
            this.Luong1Gio = luong1Gio;
            this.SoGioLamViec = soGioLamViec;
        }
        public NhanVien() { }

        public virtual double TinhLuong()
        {
            return this.Luong1Gio * this.SoGioLamViec;
        }
        public double TinhLuong(int luong1Gio, int soGioLamViec)
        {
            return luong1Gio * soGioLamViec;
        }

        public override string ToString()
        {
            return string.Format("\n{0,-15}{1,-20}{2,-15}{3,-18}{4,-15}{5,-20}",
                this.MaNhanVien, this.TenNhanVien,
                this.Luong1Gio, this.SoGioLamViec,
                0, this.TinhLuong());
        }
    }
}

