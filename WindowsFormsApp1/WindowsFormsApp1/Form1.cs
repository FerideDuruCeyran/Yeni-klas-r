﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HOŞ GELDİNİZ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "dikkat et";
            textBox1.Text = "nesne";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
        }
    }
}
