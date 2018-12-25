using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21122018
{
    class Urunler
    {
        static string constr = "Data Source=10.10.22.85;Initial Catalog = test; User ID = test2; Password=test2";
        SqlConnection sqlcon;
        SqlCommand command;

        private bool _hata;

        public bool Hata
        {
            get { return _hata; }
            set { _hata = value; }
        }

        private string _hataMesaji;

        public string HataMesaji
        {
            get { return _hataMesaji; }
            set { _hataMesaji = value; }
        }




        private string _UrunAdi;

        public string UrunAdi
        {
            get { return _UrunAdi; }
            set { _UrunAdi = value; }
        }

        private string _barkod;

        public string Barkod
        {
            get { return _barkod; }
            set { _barkod = value; }
        }

        private int _miktar;

        public int Miktar
        {
            get { return _miktar; }
            set {

                if(value<=0)
                {
                    _hata = true;
                    _hataMesaji = "Miktar 0 dan buyuk olmali";
                    return;

                }


                _miktar = value;

                }
        }

        private int _birim;

        public int Birim
        {
            get { return _birim; }
            set { _birim = value; }
        }

        private DateTime _rafOmru;

        public DateTime RafOmru
        {
            get { return _rafOmru; }
            set { _rafOmru = value; }
        }

        private string _mensei;

        public string Mensei
        {
            get { return _mensei; }
            set { _mensei = value; }
        }


        public Urunler()
        {
            UrunAdi = "";
            Barkod = "";
            Miktar = 1;
            Birim = 1;
            RafOmru = DateTime.Now.AddMonths(12);
            Mensei = "";
 

        }

        public int Ekle()
        {
            int sonuc = 0;
            try
            {
                
                sqlcon = new SqlConnection(constr);
                command = new SqlCommand();
                command.Connection = sqlcon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UrunEkleB";
                command.Parameters.AddWithValue("@Urunadi", UrunAdi);
                command.Parameters.AddWithValue("@barkod", Barkod);
                command.Parameters.AddWithValue("@Miktar", Miktar);
                command.Parameters.AddWithValue("@Birim", Birim);
                command.Parameters.AddWithValue("@rafomru", RafOmru);
                command.Parameters.AddWithValue("@mensei", Mensei);



                sqlcon.Open();
                sonuc = command.ExecuteNonQuery();
                sqlcon.Close();

            }
            catch(Exception ex)
            {
                _hata = true;
                _hataMesaji = ex.Message;
            }

            return sonuc;
        }

    }
}
