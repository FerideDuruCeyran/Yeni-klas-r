using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            int ks;
            int uk;
            int al2;
            int cev2;
            ks = Convert.ToInt32(textBox1.Text);
            uk = Convert.ToInt32(textBox2.Text);
            al2 = uk * ks;
            cev2 = (uk * 2) + (ks * 2);
            label4.Text = al2.ToString();
            label6.Text = cev2.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            textBox2.Visible = false;
            label1.Text = "kare";
            panel1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            button4.Visible = false;
            button3.Visible = true;
            label2.Text = "bir kenarını girin:";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text ="kısa kenarı girin:";
            label1.Text = "dikdörtgen";
            panel1.Visible = true;
            textBox2.Visible = true;
            button3.Visible = false;
            button4.Visible = true;
            label7.Visible = true;
           
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            int k1;
            int al;
            int cev;
            k1 = Convert.ToInt32(textBox1.Text);
            al = k1 * k1;
            cev = k1 * 4;
            label4.Text = al.ToString();
            label6.Text = cev.ToString();


        }
    }
}
