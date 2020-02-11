using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{
    public partial class EdycjaKlienta : Form
    {
        DB db = new DB();

        public Klient p = new Klient();

        public EdycjaKlienta(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                p = db.Klient.FirstOrDefault(x => x.Id == id);

                button3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Czy chcesz usunąć klienta?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (p.Id > 0)
                    db.Klient.Remove(p);

                db.SaveChanges();

                DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Podaj imię i nazwisko klienta!");
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Podaj adres klienta!");
                return;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Podaj numer telefonu klienta!");
                return;
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Podaj adres e-mail klienta!");
                return;
            }

            p.Nazwa = textBox1.Text;
            p.Adres = textBox2.Text;
            p.NrTel = textBox3.Text;
            p.Email = textBox4.Text;

            if(p.Id == 0)
            {
                db.Klient.Add(p);
            }

            db.SaveChanges();

            DialogResult = DialogResult.OK;
        }

        private void EdycjaPracownika_Shown(object sender, EventArgs e)
        {
            if(p.Id > 0)
            {
                textBox1.Text = p.Nazwa;
                textBox2.Text = p.Adres;
                textBox3.Text = p.NrTel;
                textBox4.Text = p.Email;
            }
        }
    }
}
