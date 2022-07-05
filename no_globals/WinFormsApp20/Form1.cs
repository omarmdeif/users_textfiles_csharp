using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp20
{
    public partial class Form1 : Form
    {
        public Boolean found = false;
        string templine = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            StreamReader reading = new StreamReader(@"U:\MULTIMEDIA\lab assignment\logins.txt", true);
            while (!reading.EndOfStream)
            {

                templine = reading.ReadLine();
                string[] temp = templine.Split(',');
                if (temp[0] == username && temp[1] == password)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                MessageBox.Show("login successful!!!");
                this.Visible = false;
                StreamWriter writing = new StreamWriter(@"U:\MULTIMEDIA\lab assignment\temp.txt", true);
                writing.WriteLine(templine);
                writing.Close();
                Form3 f3 = new Form3();
                f3.Show();
            }
            else
            {
                MessageBox.Show("there is no account with the same login credintials you entered," +
                    " if you'd like to register please click on Sign Up");
            }

            reading.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 f2 = new Form2();
            f2.Show();
        }

    }
}
