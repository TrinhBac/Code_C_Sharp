using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Controller;

namespace View
{
    public partial class Form1 : Form
    {
        //code theo mô hình 3 lớp và theo chuẩn barem chấm điểm theo yêu cầu trong bản word của thầy

        Controller_thuvien controller = new Controller_thuvien();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            dataGridView1.DataSource = controller.getDataSource("SACH");
            comboBox1.DataSource = controller.getDataSource("THE_LOAI");
            comboBox1.DisplayMember = "TenTheLoai";
            comboBox1.ValueMember = "MaTheLoai";
        }

        private void setDataGridViewColor()     // Not necessary
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)  //Add
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text)   )
            {
                MessageBox.Show("Input is empty !", "Notification");
            }
            else
            {
                if (!controller.checkID(textBox1.Text))
                {
                    controller.InsertSach(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), comboBox1.SelectedValue.ToString());
                    MessageBox.Show("Insert successfully !", "Notification");
                    Form1_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Book ID exited !", "Notification");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)  //Edit
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text)  )
            {
                MessageBox.Show("Input is empty !", "Notification");
            }
            else
            {
                if (controller.checkID(textBox1.Text))
                {
                    controller.EditSach(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), comboBox1.SelectedValue.ToString());
                    MessageBox.Show("Update successfully !", "Notification");
                    Form1_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Book ID does not exit !", "Notification");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)  //Delete
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text)  )
            {
                MessageBox.Show("Input is empty !", "Notification");
            }
            else
            {
                if (controller.checkID(textBox1.Text))
                {
                    //controller.DeleteSach(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), textBox4.Text);
                    //MessageBox.Show("Delete successfully !", "Notification");
                    //Form1_Load(sender, e);

                    DialogResult selection;
                    selection = MessageBox.Show("Do you want to DELETE this record permanently?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (selection == DialogResult.OK)
                    {
                        controller.DeleteSach(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), textBox4.Text);
                        MessageBox.Show("Delete successfully !", "Notification");
                        Form1_Load(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Book ID does not exit !", "Notification");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)  //Search
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Input is empty !", "Notification");
            }
            else
            {
                dataGridView1.DataSource = controller.SearchSach(textBox4.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)    //cell click
        {
            int i = e.RowIndex;
            if(i>-1)
            {
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)   //check Page number > 0
        {
            if (!String.IsNullOrWhiteSpace(textBox3.Text))
            {
                try
                {
                    if(int.Parse(textBox3.Text)<=0)
                    {
                        MessageBox.Show("Page number must be greater than 0 !", "Notification");
                        textBox3.Clear();
                        textBox3.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Page number must be numeric type !", "Notification");
                    textBox3.Clear();
                    textBox3.Focus();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)  //back to datagrid view
        {
            Form1_Load(sender, e);
            textBox4.Clear();
        }
    }
}
