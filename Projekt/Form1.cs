using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Form1 : Form
    {
        g4_6it23Entities Daten = new g4_6it23Entities();
        bool mode;
        public Form1()
        {
            InitializeComponent();
            anzeige(1);
            button1.Text = "Login";
            button2.Text = "Register";
            button3.Text = "Beenden";
        }

        private void anzeige(int nu)
        {
            switch (nu)
            {
                case 1:
                    label1.Text = "Email";
                    label2.Text = "Passwort";
                    label3.Text = "";
                    label4.Text = "";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = false;
                    label4.Visible = false;
                    textBox2.PasswordChar = '*';
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    break;
                case 2:
                    label1.Text = "Name";
                    label2.Text = "Email";
                    label3.Text = "Passwort";
                    label4.Text = "Passwort erneut";
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    textBox3.PasswordChar = '*';
                    textBox4.PasswordChar = '*';
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var users = Daten.public_users.FirstOrDefault(u => u.username == textBox1.Text);


            string tes = textBox1.Text;
            anzeige(1);
            if (mode||!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox2.Text))
            {
                if (textBox1.Text.Contains("@")&& textBox1.Text.Contains("."))
                {
                    string passwordHash = Passwordhasher.HashPassword(textBox2.Text);

                    var user = Daten.public_users
                .FirstOrDefault(u => u.email.ToLower() == textBox1.Text.ToLower()
                                  && u.password == passwordHash);
                    

                    if (user!=null)
                    {
                        MessageBox.Show("Login ja!");
                    }
                    else
                    {
                        MessageBox.Show("Login neiun");
                    }
                }
                else
                {
                    MessageBox.Show("Gültige Email!");
                }
            }
            else
            {
                MessageBox.Show("Bitte Füll alle Felder aus!");
            }
                mode = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            anzeige(2);
            if (!mode
                &&!string.IsNullOrEmpty(textBox1.Text)
                ||!string.IsNullOrEmpty(textBox2.Text)
                ||!string.IsNullOrEmpty(textBox3.Text)
                ||!string.IsNullOrEmpty(textBox4.Text)
                    )
            {
                if (textBox1.Text.Contains("@"))
                {
                    MessageBox.Show("Register!");
                }
                else
                {
                    MessageBox.Show("Gültige Email!");
                }
            }
            else
            {
                MessageBox.Show("Bitte Füll alle Felder aus!");
            }

            mode = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
