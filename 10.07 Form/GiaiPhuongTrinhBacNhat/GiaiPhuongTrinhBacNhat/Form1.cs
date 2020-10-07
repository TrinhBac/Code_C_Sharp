using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaiPhuongTrinhBacNhat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(this.textBox1.Text);
                try
                {
                    double b = double.Parse(this.textBox2.Text);
                    if (a == 0 && b == 0)
                        this.textBox3.Text = "Vô số nghiệm";
                    else if(a==0 && b!=0)
                        this.textBox3.Text = "Vô nghiệm";
                    else
                        this.textBox3.Text = (-b/a).ToString();
                }
                catch
                {
                    MessageBox.Show("Hệ số b không hợp lệ !", "Cảnh báo");
                    this.textBox2.Clear();
                    this.textBox2.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Hệ số a không hợp lệ !", "Cảnh báo");
                this.textBox1.Clear();
                this.textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
