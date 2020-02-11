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
    public partial class EdycjaPojazdu : Form
    {
        DB db = new DB();

        public Pojazd p = new Pojazd();

        public EdycjaPojazdu(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                p = db.Pojazd.FirstOrDefault(x => x.Id == id);

                button3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Czy chcesz usunąć pojazd?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (p.Id > 0)
                    db.Pojazd.Remove(p);

                db.SaveChanges();

                DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Podaj markę i model pojazdu!");
                return;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Podaj VIN pojazdu!");
                return;
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Podaj numer rejestracyjny pojazdu!");
                return;
            }

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Podaj rok produkcji pojazdu!");
                return;
            }

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Podaj opis pojazdu!");
                return;
            }

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Podaj cenę wynajęcia pojazdu!");
                return;
            }

            p.Marka = textBox1.Text;
            p.Model = textBox2.Text;
            p.VIN = textBox3.Text;
            p.NrRej = textBox4.Text;
            p.RokProd = int.Parse(textBox5.Text);
            p.Opis = textBox6.Text;
            p.Cena = decimal.Parse(textBox7.Text);
            
            if (p.Id == 0)
            {
                db.Pojazd.Add(p);
            }

            db.SaveChanges();

            DialogResult = DialogResult.OK;
        }

        private void EdycjaPracownika_Shown(object sender, EventArgs e)
        {
            if(p.Id > 0)
            {
                textBox1.Text = p.Marka;
                textBox2.Text = p.Model;
                textBox3.Text = p.VIN;
                textBox4.Text = p.NrRej;
                textBox5.Text = p.RokProd.ToString();
                textBox6.Text = p.Opis;
                textBox7.Text = p.Cena.ToString();
            }
        }
    }
}
