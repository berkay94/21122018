using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace _21122018
{
    public partial class Firmalar : Form
    {
        public Firmalar()
        {
            InitializeComponent();
            Text=ConfigurationManager.AppSettings["ProgramAdi"].ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Firma f = new Firma();
            if (textBoxFirmaAd.Text != "")
            {
                
                f.Unvan = textBoxFirmaAd.Text;

                f.FirmaTipi = comboBoxFirmaTip.SelectedIndex;
                if (comboBoxFirmaTip.SelectedIndex == 0)
                    f.FirmaTipi = 1;
                else
                    f.FirmaTipi = 2;



                f.Adres1 = textBoxAdres1.Text;
                f.Adres2 = textBoxAdres2.Text;
                f.VergiDaire = textBoxVergiDaire.Text;
                f.VergiNo = textBoxVergiNo.Text;


                if (f.Ekle() > 0)
                {
                    MessageBox.Show("Firma Eklendi");
                }
            }
            else
            {
                MessageBox.Show("Firma Adini Girin");
            }
        }

        public void EkraniTemizle()
        {
            TextBox test = new TextBox();
            test.Multiline = true;
            groupBox1.Controls.Add(test);

            textBoxFirmaAd.Text = "";
            textBoxAdres1.Text = "";
            textBoxAdres2.Text = "";
            textBoxVergiDaire.Text = "";
            textBoxVergiNo.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EkraniTemizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Firma f = new Firma();
            List<Firma> firmalar = f.FirmalariVer();
            dataGridView1.DataSource = firmalar;
        }
    }
}
