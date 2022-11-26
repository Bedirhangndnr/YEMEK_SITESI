//using BusinessLayer.Interfaces;
using BusinessLayer.Work;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BusinessLayer.Entity
{
    public class Kategori : OrtakDegiskenler/*, ICRUD*/
    {
        DataTable dt;
        private VeriTabaniIslemleri veritabaniIslem;
        public Kategori(VeriTabaniIslemleri veriTabanİIslemleri)
        {
            veritabaniIslem = veriTabanİIslemleri;
        }
        private bool resimEklenecekmi;
        public bool ResimEklenecekmi
        {
            get { return resimEklenecekmi; }
            set { resimEklenecekmi = value; }
        }

        protected VeriTabaniIslemleri VeritabaniIslem
        {
            get { return veritabaniIslem; }
            set { veritabaniIslem = value; }
        }
        private int kategoriId;
        public int KategoriId
        {
            get { return KategoriId; }
            set { kategoriId = value; }
        }
        private string kategoriAd;
        public string KategoriAd
        {
            get { return kategoriAd; }
            set { kategoriAd = value; }
        }
        private int kategoriAdet;
        public int KategoriAdet
        {
            get { return kategoriAdet; }
            set { kategoriAdet = value; }
        }
        private string kategoriResim;
        public string KategoriResim
        {
            get { return kategoriResim; }
            set { kategoriResim = value; }
        }

        public void Delete()
        {
            veritabaniIslem.spAd = "spKategoriSil";
            veritabaniIslem.AddSqlParameter("@kategoriID", kategoriId);
            try
            {
                veritabaniIslem.Calistir();
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void Insert()
        {
            veritabaniIslem.spAd = "spKategoriEkle";
            veritabaniIslem.AddSqlParameter("@kategoriAd", kategoriAd);
            if (resimEklenecekmi)
            {
                veritabaniIslem.AddSqlParameter("@kategoriResim", kategoriResim);
            }
            else if (!resimEklenecekmi)
            {
                veritabaniIslem.AddSqlParameter("@kategoriResim", "");
            }
            try
            {
                veritabaniIslem.Calistir();
                //veritabaniIslem.Insert();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update()
        {
            //resim her türlü eklesin fakat yoksa boş olsun              
            veritabaniIslem.spAd = "spKategoriGuncelleResimle";
            veritabaniIslem.AddSqlParameter("@kategoriAd", kategoriAd);
            veritabaniIslem.AddSqlParameter("@kategoriId", kategoriId);
            veritabaniIslem.AddSqlParameter("@kategoriResim", kategoriResim);
            try
            {
                veritabaniIslem.Calistir();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public SqlDataReader GetAll()
        //{
        //    veritabaniIslem.spAd = "spTumKategorileriGetir";
        //    return veritabaniIslem.GetAll();
        //}
        public DataTable KategoriAdAdedGetir()
        {
            veritabaniIslem.spAd = "spKategoriAdAdetGetir";
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        public DataTable TumunuGetir()
        {
            veritabaniIslem.spAd = "spTumKategorileriGetir";
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        public DataTable SatirGetir()
        {
            veritabaniIslem.spAd = "spTumKategorileriGetir";
            veritabaniIslem.AddSqlParameter("@Kategoriid", kategoriId);
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }

        //public SqlDataReader GetById()
        //{
        //    veritabaniIslem.spAd = "spSeciliKategorileriGetir";
        //    veritabaniIslem.AddSqlParameter("@kategoriId", kategoriId);
        //    veritabaniIslem.Calistir();
        //    return veritabaniIslem.GetById();
        //}


        public bool Doldur()
        {
            veritabaniIslem.spAd = "spSeciliKategorileriGetir";
            veritabaniIslem.AddSqlParameter("@kategoriId", kategoriId);
            veritabaniIslem.Calistir();
            veritabaniIslem.TabloGetir();
            DataTable dt = veritabaniIslem.VeriTablosu;
            //SqlDataReader sqlDataAdapter = veritabaniIslem.GetAll();
            try
            {
                foreach (DataRow r in dt.Rows)
                {
                    kategoriId = Convert.ToInt32(r["Kategoriid"].ToString());
                    kategoriAd = r["KategoriAd"].ToString();
                    kategoriAdet = Convert.ToInt32(r["KategoriAdet"].ToString());
                    kategoriResim = r["Kategoriresim"].ToString();
                }
            }

            catch
            {
                return false;
            }
            return true;
        }

    }
}
