using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace YEMEKTARIFISITESI
{
    public class sqlsinif
    {
        SqlConnection conn_;

        public sqlsinif()
        {
            conn_=new SqlConnection("Server=NAHRIDEBREN\\SQLEXPRESS;Database=YemekSitesi;Trusted_Connection=Yes;");
        }
        public SqlConnection baglan()
        {
            try
            {
                conn_.Open();
                return conn_;
            }
            catch (Exception)
            {
                conn_.Close();
                return null;
            }
        }
        public SqlConnection baglantiKapat()
        {
            try
            {
                conn_.Close();
                return conn_;
            }
            catch (Exception)
            {
                throw;
                return null;
            }
        }

        //public SqlConnection baglanti()
        //{
        //    con.Open();
        //    return con; 
        //}

        //public void BaglantiBaslat(SqlConnection con)
        //{
        //    if (con.State != ConnectionState.Open)
        //    {
        //        con.Close();
        //        baglanti();
        //    }
        //    //baglantının duruölarını kontrol et ve ona göre aç yada açma 
        //}

        //public void BaglantiBitir(SqlConnection con)
        //{

        //    if (con.State != ConnectionState.Closed)
        //        con.Close();
        //    //baglantının duruölarını kontrol et ve ona göre aç yada açma 
        //}

        //public void KayitEkle()
        //{
        //    BaglantiBaslat(baglanti());
        //    SqlCommand kaydet = new SqlCommand("Insert into Yemekler(adi) values('muhlama')", baglanti());
        //    kaydet.ExecuteNonQuery();
        //    BaglantiBitir(baglanti());
        //}
    }
}