using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp19
{
    public partial class Form2 : Form
    {
        public Boolean userExist = false;
        public Boolean picExist = false;
        public String imglink = null;
        public Form2()
        {
            InitializeComponent();
            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader reading = new StreamReader(@"U:\MULTIMEDIA\lab assignment\logins.txt", true);
            while (!reading.EndOfStream)
            {
                String[] temp = reading.ReadLine().Split(',');
                if(temp[0] == textBox5.Text)
                {
                    MessageBox.Show("this username is taken please enter a new one");
                    userExist = true;
                }
                if(temp[2] == imglink)
                {
                    MessageBox.Show("this pic is already taken please pick a new one");
                    picExist = true;
                }
            }
            if (textBox3.Text != textBox4.Text || textBox7.Text != textBox8.Text || (radioButton1.Checked == false && radioButton2.Checked == false) || checkBox1.Checked == false || userExist || picExist)
            {
                MessageBox.Show("you have to follow these rules: emails matching, passwords matching, unique username, unique pic, pick a gender and agree to our terms and conditions!");   
            }
            else
            {
                StreamWriter writing = new StreamWriter(@"U:\MULTIMEDIA\lab assignment\logins.txt", true);
                String username = textBox5.Text, password = textBox7.Text, img = imglink, fname = textBox1.Text,
                    lname = textBox2.Text, email = textBox3.Text, phone = comboBox1.Text + textBox6.Text, gender = null;
                if (radioButton1.Checked == true)
                { gender = radioButton1.Text; }
                else if(radioButton2.Checked == true){ gender = radioButton2.Text; }
                writing.WriteLine(username + ',' + password + ',' + img + ',' + fname + ',' + lname + ',' + email + ',' + phone + ',' + gender);
                writing.Close();
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog link = new OpenFileDialog();
            if (link.ShowDialog() == DialogResult.OK)
            {
                imglink = link.FileName;
                pictureBox1.Image = new Bitmap(imglink);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
            
        }
    }
}
