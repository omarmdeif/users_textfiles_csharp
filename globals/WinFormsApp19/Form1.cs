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

namespace WinFormsApp19
{
    public static class global
    {
        static global() { String username = null, password = null; }
        public static String username { get; private set; }
        public static String password { get; private set; }
        public static void setusername(String newv)
        {
            username = newv;
        }
        public static void setpassword(String newv)
        {
            password = newv;
        }
        public static String  getusername()
        {
            return username;
        }
        public static String getpassword()
        {
            return password;
        }

    }
    public partial class Form1 : Form
    {
        public Boolean found = false;
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
                string[] temp = reading.ReadLine().Split(',');
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
                global.setusername(username);
                global.setpassword(password);
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
