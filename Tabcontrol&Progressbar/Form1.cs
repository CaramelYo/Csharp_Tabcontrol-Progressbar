using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Week09
{
    public partial class Form1 : Form
    {
        string[] account = new string[10], password = new string[10];
        int[] english = new int[10], chinese = new int[10];
        int number = 0;

        public Form1()
        {
            InitializeComponent();

            account[0] = "aaa";
            password[0] = "a";
            english[0] = 80;
            chinese[0] = 70;

            account[1] = "bbb";
            password[1] = "b";
            english[1] = 60;
            chinese[1] = 80;

            account[2] = "ccc";
            password[2] = "c";
            english[2] = 20;
            chinese[2] = 60;

            account[3] = "ddd";
            password[3] = "d";
            english[3] = 50;
            chinese[3] = 90;

            number = 4;

            textBox2.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl2.Visible = false;
            tabControl1.Visible = true;

            progressBar1.Step = 1;
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;

            progressBar1.Visible = false;
        }

        private void login(int th)
        {
            progressBar1.Visible = true;
            while(true)
            {
                progressBar1.PerformStep();
                Thread.Sleep(50);
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                    break;
                }
            }

            tabControl1.Visible = false;
            tabControl2.Visible = true;
            tabControl2.Location = tabControl1.Location;

            //english
            label6.Text = english[th].ToString();

            int sum = 0;
            foreach(int grade in english)
            {
                sum += grade;
            }

            label7.Text = (sum / number).ToString();
            label8.Text = number.ToString();

            //chinese
            label11.Text = chinese[th].ToString();

            sum = 0;
            foreach (int grade in chinese)
            {
                sum += grade;
            }

            label10.Text = (sum / number).ToString();
            label9.Text = number.ToString();

            button1.Text = "登出";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tabControl2.Visible)
            {
                //to logout
                button1.Text = "登入";
                Form1_Load(this, e);
            }
            else
            {
                //to login
                if (!textBox1.Text.Equals("") && !textBox2.Equals(""))
                {
                    for (int i = 0; i < number; ++i)
                    {
                        if (account[i].Equals(textBox1.Text))
                            if (password[i].Equals(textBox2.Text))
                            {
                                login(i);
                                return;
                            }
                    }

                    MessageBox.Show("帳號密碼錯誤!!", "系統訊息");
                }
                else
                {
                    MessageBox.Show("帳號密碼錯誤!!", "系統訊息");
                }
            }
        }
    }
}
