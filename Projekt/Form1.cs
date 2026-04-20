using Projekt.pages;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Form1 : Form
    {
        bool mode;
        public Form1()
        {
            InitializeComponent();
            mode = true;

            anzeige(1);
            button1.Text = "Login";
            button2.Text = "Register";
            button3.Text = "Beenden";
        }


        private void anzeigeclear()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
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
                    textBox2.PasswordChar = '\0';
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!mode)
            {
                anzeige(1);
                mode = true;
                anzeigeclear();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Bitte Email/Username und Passwort eingeben!");
                return;
            }

            string passwordHash = Passwordhasher.HashPassword(textBox2.Text);

            var userdata = globalstore.Daten.public_users.FirstOrDefault(a =>
                (a.email.ToLower() == textBox1.Text.ToLower() ||
                 a.username.ToLower() == textBox1.Text.ToLower()) &&
                a.password == passwordHash
            );

            if (userdata != null)
            {
                globalstore.user = userdata;
                var normal = new RoleForm();
                normal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Falsche Login-Daten!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mode)
            {
                anzeige(2);
                mode = false;
                anzeigeclear();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!");
                return;
            }

            if (!textBox2.Text.Contains("@"))
            {
                MessageBox.Show("Bitte gültige Email eingeben!");
                return;
            }

            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Passwörter stimmen nicht überein!");
                return;
            }

            var newone = new public_users
            {
                username = textBox1.Text,
                email = textBox2.Text,
                password = Passwordhasher.HashPassword(textBox3.Text),
                balance = 100
            };

            globalstore.Daten.public_users.Add(newone);
            globalstore.Daten.SaveChanges();

            MessageBox.Show("Registrierung erfolgreich!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
