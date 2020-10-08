using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bài_4__xếp_loại_hs
{
    public partial class XepLoaiHs : Form
    {
        public XepLoaiHs()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
            this.textBox7.Clear();
            this.textBox8.Clear();
            //this.radioButton1.
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                MessageBox.Show("Hãy nhập tên thí sinh !", "Cảnh báo");
                this.textBox1.Clear();
                this.textBox1.Focus();
            }
            else
            {
                try
                {
                    double toan = double.Parse(this.textBox2.Text);
                    if (toan < 0 || toan > 10)
                    {
                        MessageBox.Show("Điểm toán không hợp lệ !", "Cảnh báo");
                        this.textBox2.Clear();
                        this.textBox2.Focus();
                    }
                    else
                    {
                        try
                        {
                            double van = double.Parse(this.textBox3.Text);
                            if (van < 0 || van > 10)
                            {
                                MessageBox.Show("Điểm văn không hợp lệ !", "Cảnh báo");
                                this.textBox3.Clear();
                                this.textBox3.Focus();
                            }
                            else
                            {
                                try
                                {
                                    double anh = double.Parse(this.textBox4.Text);
                                    if (anh < 0 || anh > 10)
                                    {
                                        MessageBox.Show("Điểm anh không hợp lệ !", "Cảnh báo");
                                        this.textBox4.Clear();
                                        this.textBox4.Focus();
                                    }
                                    else
                                    {
                                        double dCong;
                                        if (radioButton1.Checked == true)
                                        {
                                            this.textBox6.Text = "0";
                                            dCong = 0;
                                        }
                                        else
                                        {
                                            this.textBox6.Text = "0.5";
                                            dCong = 0.5;
                                        }
                                        double min = toan;
                                        if (min > van) min = van;
                                        if (min > anh) min = anh;
                                        textBox5.Text = min.ToString();
                                        double kq = (toan + van) * 2 + anh + dCong;
                                        textBox7.Text = kq.ToString();
                                        if (kq >= 40 && min >= 7) textBox8.Text = "Giỏi";
                                        else if (kq >= 35 && min >= 6) textBox8.Text = "Khá";
                                        else if (kq >= 25 && min >= 5) textBox8.Text = "T.Bình";
                                        else textBox8.Text = "Yếu";
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Điểm anh phải là số !", "Cảnh báo");
                                    this.textBox4.Clear();
                                    this.textBox4.Focus();
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Điểm văn phải là số !", "Cảnh báo");
                            this.textBox3.Clear();
                            this.textBox3.Focus();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Điểm toán phải là số !", "Cảnh báo");
                    this.textBox2.Clear();
                    this.textBox2.Focus();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
