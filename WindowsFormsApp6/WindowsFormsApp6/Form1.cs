using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("merhaba","selamlama");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("uygulamayı kapatalım mı?","uygulama çıkış",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes) { this.Close(); }
            else { label1.Text = "hayıra basıldı"; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("emin misin", "dikkat", MessageBoxButtons.YesNoCancel);
            if (cevap==DialogResult.Yes){ this.Close(); }
            else if (cevap == DialogResult.No){ label1.Text = "hayır"; }
            else { label1.Text = "iptal ettiniz"; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("kaydedilsin mi", "son çıkış", MessageBoxButtons.OKCancel);
            if (cevap == DialogResult.OK) { label1.Text = "kkaydedildi"; }
      
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("bir sorunla karşılaşıldı", "hata", MessageBoxButtons.AbortRetryIgnore); ;
            if (cevap == DialogResult.Abort) { this.Close(); }
            else if (cevap == DialogResult.Retry) { label1.Text = "yeniden denendi"; }
            else { label1.Text = "yoksayıldı"; }
        }
    }
}
