using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCaculator
{
    public partial class MayTinh : Form
    {
        public MayTinh()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = "";
            try
            {
                double a = double.Parse(this.textBox1.Text);
                try
                {
                    double b = double.Parse(this.textBox2.Text);
                    this.textBox3.Text = (a - b).ToString();
                }
                catch
                {
                    MessageBox.Show("Số thứ hai không hợp lệ !", "Thông báo");
                    this.textBox2.Clear();
                    this.textBox2.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Số thứ nhất không hợp lệ !", "Thông báo");
                this.textBox1.Clear();
                this.textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = "";
            try
            {
                double a = double.Parse(this.textBox1.Text);
                try
                {
                    double b = double.Parse(this.textBox2.Text);
                    this.textBox3.Text = (a * b).ToString();
                }
                catch
                {
                    MessageBox.Show("Số thứ hai không hợp lệ !", "Thông báo");
                    this.textBox2.Clear();
                    this.textBox2.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Số thứ nhất không hợp lệ !", "Thông báo");
                this.textBox1.Clear();
                this.textBox1.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = "";
            try
            {
                double a = double.Parse(this.textBox1.Text);
                try
                {
                    double b = double.Parse(this.textBox2.Text);
                    this.textBox3.Text = (a + b).ToString();
                }
                catch
                {
                    MessageBox.Show("Số thứ hai không hợp lệ !", "Thông báo");
                    this.textBox2.Clear();
                    this.textBox2.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Số thứ nhất không hợp lệ !", "Thông báo");
                this.textBox1.Clear();
                this.textBox1.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = "";
            try
            {
                double a = double.Parse(this.textBox1.Text);
                try
                {
                    double b = double.Parse(this.textBox2.Text);
                    if (b == 0)
                    {
                        MessageBox.Show("Số thứ 2 phải khác 0", "Thông báo");
                        this.textBox2.Clear();
                    }    
                    else
                        this.textBox3.Text = (a / b).ToString();     
                }
                catch
                {
                    MessageBox.Show("Số thứ hai không hợp lệ !", "Thông báo");
                    this.textBox2.Clear();
                    this.textBox2.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Số thứ nhất không hợp lệ !", "Thông báo");
                this.textBox1.Clear();
                this.textBox1.Focus();
            }
        }

        private void MayTinh_Load(object sender, EventArgs e)
        {
            //this.textBox3.ForeColor = System.Drawing.Color.BlueViolet;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
