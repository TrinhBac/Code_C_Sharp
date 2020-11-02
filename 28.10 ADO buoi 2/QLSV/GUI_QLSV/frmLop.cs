using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLSV;

namespace GUI_QLSV
{
    public partial class frmLop : Form
    {
        public frmLop()
        {
            InitializeComponent();
        }

        BUS_Lop lop = new BUS_Lop();
        private void frmLop_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = lop.ShowLop();
            dgvDSLOP.DataSource = dt;
        }
        private void dgvDSLOP_CellContentClick(object sender,
        DataGridViewCellEventArgs e)
        {
            int dong; dong = e.RowIndex;
            txtMaLop.Text =
            dgvDSLOP.Rows[dong].Cells[0].Value.ToString();
            txtTenLop.Text =
            dgvDSLOP.Rows[dong].Cells[1].Value.ToString();
            txtPhong.Text =
            dgvDSLOP.Rows[dong].Cells[2].Value.ToString();
        }
        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtPhong.Clear();
            txtMaLop.Text = "bac";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "" || txtMaLop.TextLength >=
            10 || txtTenLop.Text == "" || txtPhong.Text == "")
                MessageBox.Show("Bạn nhập lỗi!", "thông báo");
            else
            {
                try
                {
                    lop.InsertLop(txtMaLop.Text, txtTenLop.Text, txtPhong.Text);
                    MessageBox.Show("Bạn đã thêm thành công", "Thông báo");
                    //update lại datagridview4
                    frmLop_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("Có lỗi");
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "" || txtMaLop.TextLength >=
            10 || txtTenLop.Text == "" || txtPhong.Text == "")
                MessageBox.Show("Bạn nhập lỗi!", "thông báo");
            else
            {
                try
                {
                    lop.UpdateLop(txtMaLop.Text,
                    txtTenLop.Text, txtPhong.Text);
                    MessageBox.Show("Bạn đã sửa thành công",
                    "Thông báo");
                    //update lại datagridview
                    frmLop_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("Có lỗi");
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text == "")
                MessageBox.Show("Bạn cần có mã lớp");
            else
            {
                try
                {
                    lop.DeleteLop(txtMaLop.Text);
                    MessageBox.Show("Bạn đã xóa thành công",
                    "TB");
                    frmLop_Load(sender, e);
                }
                catch
                {
                MessageBox.Show("Lỗi xóa");
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTimkiem.Text == "")
                MessageBox.Show("Bạn phải nhập thông tin tìm kiếm");
            else
            {
                DataTable dt = new DataTable();
                dt = lop.LookLop(txtTimkiem.Text);
                dgvDSLOP.DataSource = dt;
            }
        }

        private void btnNhapLai_Click_1(object sender, EventArgs e)
        {
            txtMaLop.Text = "bac";
        }
    }
}
