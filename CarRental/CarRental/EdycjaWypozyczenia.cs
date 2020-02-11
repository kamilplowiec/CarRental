using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{
    public partial class EdycjaWypozyczenia : Form
    {
        DB db = new DB();

        Wypozyczenie p = new Wypozyczenie();

        public EdycjaWypozyczenia(int id = 0)
        {
            InitializeComponent();

            LadujPojazdy();
            LadujKlientow();

            if (id > 0)
            {
                p = db.Wypozyczenie.FirstOrDefault(x => x.Id == id);

                button3.Visible = true;
            }
        }

        private void LadujPojazdy()
        {
            comboBox2.Items.Clear();
            db.Pojazd.Load();
            comboBox2.Items.AddRange(db.Pojazd.Select(x => x.Marka + " " + x.Model + " " + x.NrRej).ToList().ToArray());
        }

        private void UstawPojazd(string pojazd)
        {
            comboBox2.SelectedItem = pojazd;
        }

        private void LadujKlientow()
        {
            comboBox1.Items.Clear();
            db.Klient.Load();
            comboBox1.Items.AddRange(db.Klient.Select(x => x.Nazwa).ToList().ToArray());
        }

        private void UstawKlienta(string klient)
        {
            comboBox1.SelectedItem = klient;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy chcesz usunąć wypożyczenie?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (p.Id > 0)
                {
                    db.Wypozyczenie.Remove(p);
                }

                db.SaveChanges();

                DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Wybierz pojazd!");
                return;
            }

            var pojazd = db.Pojazd.FirstOrDefault(x => x.Marka + " " + x.Model + " " + x.NrRej == comboBox2.SelectedItem.ToString());

            if(pojazd == null)
            {
                MessageBox.Show("Wybierz pojazd!");
                return;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Wybierz klienta!");
                return;
            }

            var klient = db.Klient.FirstOrDefault(x => x.Nazwa == comboBox1.SelectedItem.ToString());

            if (klient == null)
            {
                MessageBox.Show("Wybierz klienta!");
                return;
            }

            DateTime przyjecie;
            if(!DateTime.TryParse(dateTimePicker1.Value.ToString(), out przyjecie))
            {
                MessageBox.Show("Wprowadź poprawną datę początku wypożyczenia pojazdu!");
                return;
            }

            DateTime zwrot;
            if (!DateTime.TryParse(dateTimePicker2.Value.ToString(), out zwrot))
            {
                MessageBox.Show("Wprowadź poprawną datę zwrotu pojazdu przez klienta!");
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Wprowadź informacje dodatkowe na temat wypożyczającego!");
                return;
            }

            //zapis

            p.PojazdId = pojazd.Id;

            p.KlientId = klient.Id;

            p.DataOd = przyjecie;

            p.DataDo = zwrot;

            p.Zwrot = checkBox1.Checked;

            p.Komentarz = textBox1.Text;

            if (p.Id == 0)
            {
                p.WypozyczajacyPracownikId = Form1.ZalogowanyId;

                db.Wypozyczenie.Add(p);
            }

            db.SaveChanges();

            DialogResult = DialogResult.OK;
        }

        private void EdycjaPracownika_Shown(object sender, EventArgs e)
        {
            if (p.Id > 0)
            {
                var pojazd = db.Pojazd.FirstOrDefault(x => x.Id == p.PojazdId);
                if (pojazd != null)
                {
                    UstawPojazd(pojazd.Marka + " " + pojazd.Model + " " + pojazd.NrRej);
                }

                var klient = db.Klient.FirstOrDefault(x => x.Id == p.KlientId);
                if (klient != null)
                {
                    UstawKlienta(klient.Nazwa);
                }

                dateTimePicker1.Value = p.DataOd;

                if(p.DataDo.HasValue)
                    dateTimePicker2.Value = p.DataDo.Value;

                textBox1.Text = p.Komentarz;

                checkBox1.Checked = p.Zwrot;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = checkBox1.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EdycjaKlienta edycjaKlienta = new EdycjaKlienta();
            if(edycjaKlienta.ShowDialog(this) == DialogResult.OK)
            {
                LadujKlientow();
                UstawKlienta(edycjaKlienta.p.Nazwa);
            }
        }
    }
}
