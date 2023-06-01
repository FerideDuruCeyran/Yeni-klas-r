using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s1;
            int s2;
            int ort;
            int b;
            b = Convert.ToInt32(textBox4.Text);
            s1 = Convert.ToInt32(textBox1.Text);
            s2 = Convert.ToInt32(textBox2.Text);
            ort = (s1 + s2) / 2;
            listBox3.Items.Add(ort);
            listBox1.Items.Add(textBox1.Text);
            listBox2.Items.Add(textBox2.Text);
            if (ort >= b) { listBox3.Items.Add("geçti"); }
            else { listBox3.Items.Add("kaldı"); }
        }
    }
}
