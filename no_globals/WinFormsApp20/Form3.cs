using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace WinFormsApp20
{
    public partial class Form3 : Form
    {
        public String[] temp = null;
        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
                StreamReader reading = new StreamReader(@"U:\MULTIMEDIA\lab assignment\temp.txt", true);
                while (!reading.EndOfStream)
                {
                    temp = reading.ReadLine().Split(',');
                }
                textBox1.Text = temp[3];
                textBox2.Text = temp[4];
                pictureBox1.Image = new Bitmap(temp[2]);
                reading.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
