using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21122018
{
    class Kisiler
    {
        SqlConnection sqlcon;
        SqlCommand command;

        private string _ad;

        public string Ad
        {
            get { return _ad; }
            set { _ad = value; }
        }

        private string _soyad;

        public string Soyad
        {
            get { return _soyad; }
            set { _soyad = value; }
        }

        private string _cep;

        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private string _isTel;

        public string Istel
        {
            get { return _isTel; }
            set { _isTel = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _firmaId;

        public int FirmaId
        {
            get { return _firmaId; }
            set { _firmaId = value; }
        }

        private string _tcNo;

        public string TcNo
        {
            get { return _tcNo; }
            set { _tcNo = value; }
        }

        public Kisiler()
        {
            Ad = "";
            Soyad = "";
            Cep = "";
            Istel = "";
            Email = "";
            //FirmaId = 1;
            TcNo = "";
        }

        public int KisiEkle()
        {
            int sonuc = 0;

            try
            {
                sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["testDb"].ConnectionString);
                //sqlcon = new SqlConnection(constr);
                command = new SqlCommand();
                command.Connection = sqlcon;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "KisiEkleB";
                command.Parameters.AddWithValue("@Ad", Ad);
                command.Parameters.AddWithValue("@Soyad", Soyad);
                command.Parameters.AddWithValue("@Cep", Cep);
                command.Parameters.AddWithValue("@Istel", Istel);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@FirmaId", FirmaId);
                command.Parameters.AddWithValue("@Tc", TcNo);



                sqlcon.Open();
                sonuc = command.ExecuteNonQuery();
                sqlcon.Close();

            }
            catch (Exception ex)
            {

                throw;
            }

            finally
            {
                sqlcon.Close();
            }

            return sonuc;
        }

        public List<Kisiler> KisileriVer()
        {
            string tc = "";
            List<Kisiler> kisilers = new List<Kisiler>();
            sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["testDb"].ConnectionString);
            command = new SqlCommand();
            command.Connection = sqlcon;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Kisiler";
            sqlcon.Open();

            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Kisiler kisi = new Kisiler();
                kisi.Ad = rdr["Ad"].ToString();
                kisi.Soyad = rdr["Soyad"].ToString();
                kisi.Cep = rdr["cep"].ToString();
                kisi.Istel = rdr["istel"].ToString();
                kisi.Email = rdr["email"].ToString();
                //kisi.FirmaId = int.Parse(rdr["firmaID"].ToString());

                
                tc = rdr["TcKimlikNo"].ToString();
                if (tc.Length> 0)
                    kisi.TcNo = tc.Substring(0,3)+"********";
                else
                    kisi.TcNo = tc;
                
                    
               

                kisilers.Add(kisi);
            }

            sqlcon.Close();

            return kisilers;

        }
    }
}
