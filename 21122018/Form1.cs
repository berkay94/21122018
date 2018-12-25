using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _21122018
{
    public partial class Form1 : Form
    {

        
        

        public Form1()

        {
            InitializeComponent();
        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            

            
            //sql = "Insert into Urunler (UrunAdi,barkod,Miktar,Birim,rafOmru,mensei) ";
            //sql += "Values ('" + textBox1.Text + "','" + textBox2.Text + "'";
            //sql += " ," + textBox3.Text + " ," + textBox4.Text + " , Convert(datetime,'";
            //sql += DateTime.Now.AddMonths(12).ToShortDateString() + "',103) ,'" + textBox6.Text + "')";



            //Class yapısı
            Urunler u = new Urunler();
            u.UrunAdi = textBox1.Text;
            u.Barkod = textBox2.Text;
            u.Miktar = int.Parse(textBox3.Text);
            u.Birim = int.Parse(textBox4.Text);
            u.RafOmru = DateTime.Now.AddMonths(12);
            u.Mensei = textBox6.Text;

            u.Ekle();
            if (u.Hata == true)
                MessageBox.Show("Alinan Hata:" + u.HataMesaji);
            else
                MessageBox.Show("Kayit Eklenmistir");
            

            


            


           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
