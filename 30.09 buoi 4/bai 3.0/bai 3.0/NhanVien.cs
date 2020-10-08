using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_3
{
    class SanPham
    {
        private string _MaSp;
        private string _TenSp;
        private string _MauSacSp;
        private double _SoLuongSp;
        private double _GiaBanSp;

        public string MaSanPham
        {
            get { return _MaSp; }
            set { _MaSp = value; }
        }

        public string TenSanPham
        {
            get { return _TenSp; }
            set { _TenSp = value; }
        }

        public string MauSac
        {
            get { return _MauSacSp; }
            set { _MauSacSp = value; }
        }

        public double SoLuongSanPham
        {
            get { return _SoLuongSp; }
            set { _SoLuongSp = value; }
        }

        public double GiaBanSanPham
        {
            get { return _GiaBanSp; }
            set { _GiaBanSp = value; }
        }

        public SanPham(string masp, string tensp, string mausac, double soluong, double giaban)
        {
            this._MaSp = masp;
            this._TenSp = tensp;
            this._MauSacSp = mausac;
            this._SoLuongSp = soluong;
            this._GiaBanSp = giaban;
        }
        public SanPham() { }

        public double TinhTienBan()
        {
            return this._SoLuongSp * this._GiaBanSp;
        }

        public override string ToString()
        {
            return string.Format("{0,-15}{1,-20}{2,-15}{3,-18}{4,-15}{5,-20}",
                this._MaSp, this._TenSp,
                this._MauSacSp, this._SoLuongSp,
                this._GiaBanSp, this.TinhTienBan());
        }
    }
}
