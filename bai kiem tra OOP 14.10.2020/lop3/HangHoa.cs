using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lop3
{
    class HangHoa
    {
        string _ten;
        double _soluong;
        double _gia;

        public string Ten { get => _ten; set => _ten = value; }
        public double Soluong { get => _soluong; set => _soluong = value; }
        public double Gia { get => _gia; set => _gia = value; }

        public HangHoa() { }

        public HangHoa(string tenHang, double soLuong, double giaTien)
        {
            this._ten = tenHang;
            this._soluong = soLuong;
            this._gia = giaTien;
        }

        public double TongTien()
        {
            return this._soluong * this._gia;
        }

        public override string ToString()
        {
            string st = $"{this._ten,15}{this._soluong,15}{this._gia,15}{this.TongTien(),15}";
            return string.Format(st);
        }
    }
}
