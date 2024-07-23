using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignApp
{
    public partial class Form2 : Form
    {
        string name;
        string idd;
        public Form2(string itemanme, string id)
        {
            InitializeComponent();
            name = itemanme;
            idd = id;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.Text = name;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("不可為空!");
            }
            else
            {
                string copyvalue = $"交易序號:{idd}\r\n消費者： @{textBox1.Text} \r\n購買日期： {dateTimePicker1.Value.ToString("yyyy-MM-dd")}\r\n購買商品名稱： {textBox2.Text}\r\n交易證明：";
                DialogResult = MessageBox.Show(copyvalue, "確認資訊", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if(DialogResult == DialogResult.OK)
                {
                    Clipboard.SetText(copyvalue);
                    MessageBox.Show("複製成功!","通知",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
