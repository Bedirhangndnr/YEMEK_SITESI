using BusinessLayer.Entity;
//using BusinessLayer.Interfaces;
using BusinessLayer.Work;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_.Entity
{
    public class Yemek : OrtakDegiskenler/*, ICRUD*/
    {
        public string spAd;
        private VeriTabaniIslemleri veritabaniIslem;
        public Yemek(VeriTabaniIslemleri veriTabanİIslemleri)
        {
            veritabaniIslem = veriTabanİIslemleri;
        }

        protected VeriTabaniIslemleri VeritabaniIslem
        {
            get { return veritabaniIslem; }
            set { veritabaniIslem = value; }
        }
        private int yemekId;
        public int YemekId
        {
            get { return yemekId; }
            set { yemekId = value; }
        }
        private DateTime yemekTarih;
        public DateTime YemekTarih
        {
            get { return yemekTarih; }
            set { yemekTarih = value; }
        }
        private int yemekPuan;
        public int YemekPuan
        {
            get { return yemekPuan; }
            set { yemekPuan = value; }
        }
        private string yemekAd;
        public string YemekAd
        {
            get { return yemekAd; }
            set { yemekAd = value; }
        }
        private string yemekMalzeme;
        public string YemekMalzeme
        {
            get { return yemekMalzeme; }
            set { yemekMalzeme = value; }
        }
        private string yemekTarif;
        public string YemekTarif
        {
            get { return yemekTarif; }
            set { yemekTarif = value; }
        }
        private string yemekOneren;
        public string YemekOneren
        {
            get { return yemekOneren; }
            set { yemekOneren = value; }
        }
        private string yemekOnerenMail;
        public string YemekOnerenMail
        {
            get { return yemekOnerenMail; }
            set { yemekOnerenMail = value; }
        }
        private string yemekResim;
        public string YemekResim
        {
            get { return yemekResim; }
            set { yemekResim = value; }
        }
        private bool durumGununYemegi;
        public bool DurumGununYemegi
        {
            get { return durumGununYemegi; }
            set { durumGununYemegi = value; }
        }
        private bool yemekOnay;
        public bool YemekOnay
        {
            get { return yemekOnay; }
            set { yemekOnay = value; }
        }

        public bool Doldur()
        {
            veritabaniIslem.spAd = "spSeciliYemegiGetir";
            veritabaniIslem.AddSqlParameter("@yemekID", yemekId);
            veritabaniIslem.Calistir();
            veritabaniIslem.TabloGetir();
            DataTable dt = veritabaniIslem.VeriTablosu;
            try
            {
                foreach (DataRow r in dt.Rows)
                {
                    YemekAd = r["YemekAd"].ToString();
                    YemekMalzeme = r["YemekMalzeme"].ToString();
                    YemekResim = r["YemekResim"].ToString();
                    YemekOnerenMail = r["YemekOnerenMail"].ToString();
                    YemekOneren = r["YemekOneren"].ToString();
                    YemekTarif = r["YemekTarif"].ToString();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public void Insert()
        {
            veritabaniIslem.spAd = "spTarifOnerisiEkle";
            veritabaniIslem.AddSqlParameter("@YemekAd", yemekAd);
            veritabaniIslem.AddSqlParameter("@YemekMalzeme", yemekMalzeme);
            veritabaniIslem.AddSqlParameter("@YemekTarif", yemekTarif);
            veritabaniIslem.AddSqlParameter("@YemekResim", yemekResim);
            veritabaniIslem.AddSqlParameter("@YemekOneren", yemekOneren);
            veritabaniIslem.AddSqlParameter("@YemekOnerenMail", yemekOnerenMail);
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
        public void UpdateResim()
        {
            veritabaniIslem.spAd = "spYemekResimGuncelle";
            veritabaniIslem.AddSqlParameter("@YemekAd", yemekAd);
            veritabaniIslem.AddSqlParameter("@YemekResim", yemekResim);
            try
            {
                veritabaniIslem.Calistir();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update()
        {
            veritabaniIslem.spAd = "spYemekGuncelle";
            veritabaniIslem.AddSqlParameter("@YemekAd", yemekAd);
            veritabaniIslem.AddSqlParameter("@YemekId", yemekId);
            veritabaniIslem.AddSqlParameter("@YemekResim", yemekResim);
            veritabaniIslem.AddSqlParameter("@YemekMalzeme", yemekMalzeme);
            veritabaniIslem.AddSqlParameter("@YemekTarif", yemekTarif);
            veritabaniIslem.AddSqlParameter("@YemekOneren", yemekOneren);
            veritabaniIslem.AddSqlParameter("@YemekOnerenMail", yemekOnerenMail);
            try
            {
                veritabaniIslem.Calistir();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateOnayla()
        {
            veritabaniIslem.spAd = "spYemekOnayla";
            veritabaniIslem.AddSqlParameter("@yemekID", YemekId);
            veritabaniIslem.Calistir();
            //veritabaniIslem.Update();
        }
        public void UpdateOnayKaldir()
        {
            veritabaniIslem.spAd = "spYemekOnayKaldir";
            veritabaniIslem.AddSqlParameter("@yemekID", YemekId);
            veritabaniIslem.Calistir();
            //veritabaniIslem.Update();
        }

        public void Delete()
        {
            veritabaniIslem.spAd = "spYemekKaldir";
            veritabaniIslem.AddSqlParameter("@yemekId", yemekId);
            try
            {
                veritabaniIslem.Calistir();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable OnayDurumunaGoreGetir()
        {
            veritabaniIslem.spAd = "spOnayliOnaysizYemekleriGetir";
            veritabaniIslem.AddSqlParameter("@YemekOnay", YemekOnay);
            veritabaniIslem.Calistir();
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        //public SqlDataReader GetAll()
        //{
        //    veritabaniIslem.spAd = "spYemekleriGetir";
        //    return veritabaniIslem.GetAll();
        //}


        public DataTable TumunuGetir()
        {
            veritabaniIslem.spAd = "spYemekleriGetir";
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        public DataTable SatirGetir()
        {
            veritabaniIslem.spAd = "spSeciliYemegiGetir";
            veritabaniIslem.AddSqlParameter("@yemekID", yemekId);
            veritabaniIslem.Calistir();
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        public DataTable GununYemegiGetir()
        {
            veritabaniIslem.spAd = "spGununYemegiGetir";
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }

        //public SqlDataReader GetById()
        //{
        //    veritabaniIslem.spAd = "spSeciliYemegiGetir";
        //    veritabaniIslem.AddSqlParameter("@yemekID", yemekId);
        //    veritabaniIslem.Uygula();
        //    return veritabaniIslem.GetById();
        //}
        public void GununYemegiOnayKaldir()
        {
            veritabaniIslem.spAd = "spGununYemegiOnayKaldir";
            veritabaniIslem.AddSqlParameter("@Yemekid", yemekId);
            veritabaniIslem.Calistir();
            //veritabaniIslem.Uygula();

        }
        public void GununYemegiYap()
        {
            veritabaniIslem.spAd = "spGununYemegiYap";
            veritabaniIslem.AddSqlParameter("@Yemekid", yemekId);
            veritabaniIslem.Calistir();
            //veritabaniIslem.Uygula();
        }
    }
}
