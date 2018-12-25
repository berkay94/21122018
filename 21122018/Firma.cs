using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace _21122018
{
    class Firma
    {
        //static string constr = "Data Source=10.10.22.199;Initial Catalog=test;User ID=test2;Password=test2";
        SqlConnection sqlcon;
        SqlCommand command;
        

        private bool _hatavar;

        public bool HataVar
        {
            get { return _hatavar; }
            set { _hatavar = value; }
        }

        private string _hataMesaji;

        public string HataMesaji
        {
            get { return _hataMesaji; }
            set { _hataMesaji = value; }
        }


        private string _unvan;

        public string Unvan
        {
            get { return _unvan; }
            set { _unvan = value; }
        }

        private string _adres1;

        public string Adres1
        {
            get { return _adres1; }
            set { _adres1 = value; }
        }

        private int _firmaTipi;

        public int FirmaTipi
        {
            get { return _firmaTipi; }
            set { _firmaTipi = value; }
        }

        private string _adres2;

        public string Adres2
        {
            get { return _adres2; }
            set { _adres2 = value; }
        }

        private string _vergiDaire;

        public string VergiDaire
        {
            get { return _vergiDaire; }
            set { _vergiDaire = value; }
        }

        private string _vergiNo;

        public string VergiNo
        {
            get { return _vergiNo; }
            set { _vergiNo = value; }
        }

        public Firma()
        {
            Unvan = "Belirsiz";
            FirmaTipi = 0;
            Adres1 = "";
            Adres2 = "";
            VergiDaire = "Yok";
            VergiNo = "";

        }

        public int Ekle()
        {

            int sonuc = 0;

            try
            {
                sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["testDb"].ConnectionString);
                //sqlcon = new SqlConnection(constr);
                command = new SqlCommand();
                command.Connection = sqlcon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FirmaEkleB";
                command.Parameters.AddWithValue("@Unvani", Unvan);
                command.Parameters.AddWithValue("@FirmaTipi", FirmaTipi);
                command.Parameters.AddWithValue("@Adres1", Adres1);
                command.Parameters.AddWithValue("@Adres2", Adres2);
                command.Parameters.AddWithValue("@VergiDaire", VergiDaire);
                command.Parameters.AddWithValue("@VergiNo", VergiNo);



                sqlcon.Open();
                sonuc = command.ExecuteNonQuery();
                sqlcon.Close();

            }
            catch (Exception ex)
            {

                HataVar = true;
                HataMesaji = ex.Message;
            }

         finally
            {
                sqlcon.Close();
            }
          
            return sonuc;
        }


        public List<Firma> FirmalariVer()
        {
            List<Firma> firmas = new List<Firma>();
            sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["testDb"].ConnectionString);
            command = new SqlCommand();
            command.Connection = sqlcon;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Firma";
            sqlcon.Open();

            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Firma firma = new Firma();
                firma.Unvan = rdr["Unvani"].ToString();
                firma.Adres1 = rdr["adres1"].ToString();
                firma.Adres2 = rdr["adres2"].ToString();
                firma.FirmaTipi =int.Parse(rdr["firmatipi"].ToString());
                firma.VergiDaire = rdr["vergiDairesi"].ToString();
                firma.VergiNo = rdr["vergiNo"].ToString();
                firmas.Add(firma);
            }

            sqlcon.Close();

            return firmas;

        }
            

            

    }
}
