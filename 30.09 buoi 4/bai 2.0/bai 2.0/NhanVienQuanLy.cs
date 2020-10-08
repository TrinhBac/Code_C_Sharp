using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_2
{
    class NhanVienQuanLy : NhanVien
    {   //Lớp con không kế thừa constructor của lớp cha
        //Thêm thuộc tính He so phu cap
        private double _HeSoPhuCap;

        public double HeSoPhuCap
        {
            get { return _HeSoPhuCap; }
            set { _HeSoPhuCap = value; }
        }

        //Constructor không tham số
        public NhanVienQuanLy() { }
        //constructor có tham số
        public NhanVienQuanLy(string maNhanVien, string hoTen,
            int luong1Gio, double soGioLamViec, double heSoPhuCap)
            : base(maNhanVien, hoTen, luong1Gio, soGioLamViec)
        //gọi lại constructor của cha
        {
            this.HeSoPhuCap = heSoPhuCap;
        }
        //nạp đè phương thức tính lương
        public override double TinhLuong()
        {
            return this.Luong1Gio * this.SoGioLamViec * (1 + this.HeSoPhuCap);
        }

        public override string ToString()
        {
            return string.Format("\n{0,-15}{1,-20}{2,-15}{3,-18}{4,-15}{5,-20}",
                this.MaNhanVien, this.TenNhanVien,
                this.Luong1Gio, this.SoGioLamViec,
                this.HeSoPhuCap, this.TinhLuong());
        }
    }
}
