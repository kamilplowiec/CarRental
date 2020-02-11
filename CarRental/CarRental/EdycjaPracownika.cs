﻿using System;
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
    public partial class EdycjaPracownika : Form
    {
        DB db = new DB();

        Pracownik p = new Pracownik();

        public EdycjaPracownika(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                p = db.Pracownik.FirstOrDefault(x => x.Id == id);

                button3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Czy chcesz usunąć pracownika?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (p.Id > 0)
                    db.Pracownik.Remove(p);

                db.SaveChanges();

                DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Nazwa = textBox1.Text;
            p.Login = textBox2.Text;
            p.Haslo = textBox3.Text;

            if(p.Id == 0)
            {
                db.Pracownik.Add(p);
            }

            db.SaveChanges();

            DialogResult = DialogResult.OK;
        }

        private void EdycjaPracownika_Shown(object sender, EventArgs e)
        {
            if(p.Id > 0)
            {
                textBox1.Text = p.Nazwa;
                textBox2.Text = p.Login;
                textBox3.Text = p.Haslo;
            }
        }
    }
}
