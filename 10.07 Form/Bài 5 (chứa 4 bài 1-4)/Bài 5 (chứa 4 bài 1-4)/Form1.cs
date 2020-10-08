using AppCaculator;
using bài_4__xếp_loại_hs;
using Giảii_PT_Bậc_2;
using GiaiPhuongTrinhBacNhat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_5__chứa_4_bài_1_4_
{
    public partial class Bai_5 : Form
    {
        public Bai_5()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MayTinh bai_1 = new MayTinh();
            bai_1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GiaiPtBacNhat bai_2 = new GiaiPtBacNhat();
            bai_2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GiaiPtBacHai bai_3 = new GiaiPtBacHai();
            bai_3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XepLoaiHs bai_4 = new XepLoaiHs();
            bai_4.ShowDialog();
        }
    }
}
