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
    public partial class ListaPojazdow : Form
    {
        DB db = new DB();

        public ListaPojazdow()
        {
            InitializeComponent();
        }

        private void ListaPracownikow_Shown(object sender, EventArgs e)
        {
            Laduj();
        }

        private void Laduj()
        {
            dataGridView1.DataSource = null;

            db = new DB();
            db.Pojazd.Load();

            List<Pojazd> lista = db.Pojazd.ToList();

            dataGridView1.DataSource = lista;

            if(dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            if(int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out id))
            {
                EdycjaPojazdu ep = new EdycjaPojazdu(id);
                if (ep.ShowDialog(this) == DialogResult.OK)
                {
                    Laduj();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EdycjaPojazdu ep = new EdycjaPojazdu();
            if (ep.ShowDialog(this) == DialogResult.OK)
            {
                Laduj();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
