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
    public partial class Form1 : Form
    {
        DB db = new DB();

        public static int ZalogowanyId { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Zaloguj();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zaloguj();
        }

        private void Zaloguj()
        {
            label2.Text = "-";

            dataGridView1.DataSource = null;

            Logowanie l = new Logowanie();
            if (l.ShowDialog(this) == DialogResult.OK)
            {
                label2.Text = l.Pracownik.Nazwa;

                ZalogowanyId = l.Pracownik.Id;

                MessageBox.Show("Witaj " + l.Pracownik.Nazwa + "!\r\nZalogowano do systemu!");

                OdswiezLiczniki();
                Laduj();
            }
            else
            {
                Close();
            }
        }

        private void OdswiezLiczniki()
        {
            label4.Text = db.Pojazd.Count().ToString();
            label6.Text = db.Wypozyczenie.Where(x => !x.Zwrot && x.DataDo >= DateTime.Now && x.DataOd <= DateTime.Now).Count().ToString();
            label8.Text = db.Wypozyczenie.Where(x => !x.Zwrot && x.DataDo < DateTime.Now && x.DataOd < DateTime.Now).Count().ToString();
        }

        private void Laduj()
        {
            dataGridView1.DataSource = null;

            db = new DB();
            db.Wypozyczenie.Load();

            List<Wypozyczenie> lista = db.Wypozyczenie.ToList();

            dataGridView1.DataSource = lista.Select(x => new
            {
                x.Id,
                Klient = db.Klient.FirstOrDefault(k => k.Id == x.KlientId).Nazwa,
                Pojazd = db.Pojazd.Select(p => new { p.Id, Auto = p.Marka + " " + p.Model + " " + p.NrRej }).FirstOrDefault(p => p.Id == x.PojazdId).Auto,
                x.DataOd,
                x.DataDo,
                Zwrocony = x.Zwrot,
                Wypozyczajacy = db.Pracownik.FirstOrDefault(p => p.Id == x.WypozyczajacyPracownikId).Nazwa,
                Zaplata = db.Pojazd.FirstOrDefault(p => p.Id == x.PojazdId).Cena * (x.DataDo - x.DataOd).Value.Days
            }).ToList();

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListaPojazdow listaPojazdow = new ListaPojazdow();
            listaPojazdow.ShowDialog(this);

            Laduj();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListaPracownikow listaPracownikow = new ListaPracownikow();
            listaPracownikow.ShowDialog(this);

            Laduj();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaKlientow listaKlientow = new ListaKlientow();
            listaKlientow.ShowDialog(this);

            Laduj();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EdycjaWypozyczenia edycjaWypozyczenia = new EdycjaWypozyczenia();
            edycjaWypozyczenia.ShowDialog(this);

            OdswiezLiczniki();
            Laduj();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            if (int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out id))
            {
                EdycjaWypozyczenia ew = new EdycjaWypozyczenia(id);
                if (ew.ShowDialog(this) == DialogResult.OK)
                {
                    Laduj();
                }
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DateTime od_;
            if(!DateTime.TryParse(dataGridView1.Rows[e.RowIndex].Cells["DataOd"].Value.ToString(), out od_))
            {
                return;
            }

            DateTime do_;
            if (!DateTime.TryParse(dataGridView1.Rows[e.RowIndex].Cells["DataDo"].Value.ToString(), out do_))
            {
                return;
            }

            bool zwrot;
            if (!bool.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Zwrocony"].Value.ToString(), out zwrot))
            {
                return;
            }

            if (!zwrot && do_ < DateTime.Now && od_ < DateTime.Now) //opoznienie
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            else
                if(!zwrot && do_ >= DateTime.Now && od_ <= DateTime.Now) //wynajety
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                else
                    if (!zwrot && do_ > DateTime.Now && od_ > DateTime.Now) //oczekuje
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
        }
    }
}
