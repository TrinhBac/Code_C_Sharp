using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giảii_PT_Bậc_2
{
    public partial class Form1 : Form
    {
        public Form1()
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
            this.textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(this.textBox1.Text);
                try
                {
                    double b = double.Parse(this.textBox2.Text);
                    try
                    {
                        double c = double.Parse(this.textBox3.Text);
                        if (a == 0 && b == 0 && c == 0)
                            this.textBox4.Text = "Vô số nghiệm";
                        else if (a == 0 && b == 0 && c != 0)
                            this.textBox3.Text = "Vô nghiệm";
                        else if (a == 0 && b != 0)
                            this.textBox4.Text = (-c / b).ToString();
                        else
                        {
                            double denTa = b * b - 4 * a * c;
                            if(denTa<0)
                                this.textBox4.Text = "Vô nghiệm";
                            if (denTa == 0)
                                this.textBox4.Text = $"Nghiệm kép: {-b/(2*a)}";
                            else if (denTa>0)
                                this.textBox4.Text = $"X1 = {(-b+Math.Sqrt(denTa)) / (2 * a)} , " +
                                    $"X1 = {(-b - Math.Sqrt(denTa)) / (2 * a)}";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Hệ số c không hợp lệ !", "Cảnh báo");
                        this.textBox3.Clear();
                        this.textBox3.Focus();
                    }
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
    }
}
