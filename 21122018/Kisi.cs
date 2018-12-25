using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21122018
{
    public partial class Kisi : Form
    {
        public Kisi()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kisiler kisiler = new Kisiler();
            if (textBoxAd.Text != "")
            {

                kisiler.Ad = textBoxAd.Text;
                kisiler.Soyad = textBoxSoyad.Text;
                kisiler.Cep = maskedTextBoxCep.Text;
                kisiler.Istel = maskedTextBoxIstel.Text;
                kisiler.Email = textBoxEmail.Text;
                kisiler.FirmaId = textBoxFırmaId.Text;
                kisiler.TcNo = textBoxTc.Text;
                


                if (kisiler.KisiEkle() > 0)
                {
                    MessageBox.Show("Kisi Eklendi");
                }
            }
            else
            {
                MessageBox.Show("Kisi Adini Girin");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kisiler k = new Kisiler();
            List<Kisiler> kisiler = k.KisileriVer();
            dataGridView1.DataSource = kisiler;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
