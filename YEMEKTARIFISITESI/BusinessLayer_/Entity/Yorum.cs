using BusinessLayer.Entity;
//using BusinessLayer.Interfaces;
using BusinessLayer.Work;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_.Entity
{
    public class Yorum : OrtakDegiskenler/*, ICRUD*/
    {
        private VeriTabaniIslemleri veritabaniIslem;
        public Yorum(VeriTabaniIslemleri veriTabanİIslemleri)
        {
            veritabaniIslem = veriTabanİIslemleri;
        }
        protected VeriTabaniIslemleri VeritabaniIslem
        {
            get { return veritabaniIslem; }
            set { veritabaniIslem = value; }
        }

        private int yorumId;
        public int YorumId
        {
            get { return yorumId; }
            set { yorumId = value; }
        }
        private DateTime yorumTarih;
        public DateTime YorumTarih
        {
            get { return yorumTarih; }
            set { yorumTarih = value; }
        }
        private string yorumMail;
        public string YorumMail
        {
            get { return yorumMail; }
            set { yorumMail = value; }
        }
        private string yorumAdSoyad;
        public string YorumAdSoyad
        {
            get { return yorumAdSoyad; }
            set { yorumAdSoyad = value; }
        }
        private string yorumIcerik;
        public string YorumIcerik
        {
            get { return yorumIcerik; }
            set { yorumIcerik = value; }
        }
        private int yemekId;
        public int YemekId
        {
            get { return yemekId; }
            set { yemekId = value; }
        }
        private bool yorumOnay;
        public bool YorumOnay
        {
            get { return yorumOnay; }
            set { yorumOnay = value; }
        }


        public void Delete()
        {
            veritabaniIslem.spAd = "spYorumKaldir";
            veritabaniIslem.AddSqlParameter("@YorumId", YorumId);
            try
            {
                veritabaniIslem.Calistir();
                //veritabaniIslem.Delete();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable TumunuGetir()
        {
            veritabaniIslem.spAd = "spYorumlariGetir";
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        public DataTable SatirGetir()
        {
            veritabaniIslem.spAd = "spSeciliYorumlariGetir";
            veritabaniIslem.AddSqlParameter("@YorumID", yorumId);
            veritabaniIslem.Calistir();
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        //public SqlDataReader GetAll()
        //{
        //    veritabaniIslem.spAd = "spYorumlariGetir";
        //    return veritabaniIslem.GetAll();
        //}

        //public SqlDataReader GetById()
        //{
        //    veritabaniIslem.spAd = "spYorumGetir";
        //    veritabaniIslem.AddSqlParameter("@YorumID", yorumId); 
        //    veritabaniIslem.Calistir();
        //    return veritabaniIslem.GetById();
        //}

        public void Insert()
        {
            veritabaniIslem.spAd = "spYorumekle";
            //veritabaniIslem.AddSqlParameter("@YemekAd", yorumAdSoyad);
            //veritabaniIslem.AddSqlParameter("@YemekMalzeme", yorumMail);
            //veritabaniIslem.AddSqlParameter("@YemekTarif", yorumIcerik);
            //veritabaniIslem.AddSqlParameter("@YemekResim", yemekId);
            veritabaniIslem.AddSqlParameter("@YorumAdSoyad", yorumAdSoyad);
            veritabaniIslem.AddSqlParameter("@YorumMail", yorumMail);
            veritabaniIslem.AddSqlParameter("@YorumIcerik", @YorumIcerik);
            veritabaniIslem.AddSqlParameter("@Yemekid", yemekId);
            try
            {
                veritabaniIslem.Calistir();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public SqlDataReader OnayDurumunaGoreGetir()
        //{
        //    veritabaniIslem.spAd = "spYorumGetirOnayDurumunaGore";
        //    veritabaniIslem.AddSqlParameter("@YorumOnay", yorumOnay);
        //    veritabaniIslem.Calistir();
        //    return veritabaniIslem.GetAll();
        //}
        public DataTable OnayDurumunaGoreGetir()
        {
            veritabaniIslem.spAd = "spYorumGetirOnayDurumunaGore";
            veritabaniIslem.AddSqlParameter("@YorumOnay", yorumOnay);
            veritabaniIslem.Calistir();
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        //public SqlDataReader YorumVeYemekAdiGetir()
        //{
        //    veritabaniIslem.spAd = "spYorumVeYemekAdiGetir";
        //    veritabaniIslem.AddSqlParameter("@YorumID", yorumId);
        //    veritabaniIslem.Calistir();
        //    return veritabaniIslem.GetAll();
        //}
        public DataTable YorumVeYemekAdiGetir()
        {
            veritabaniIslem.spAd = "spYorumVeYemekAdiGetir";
            veritabaniIslem.AddSqlParameter("@YorumID", yorumId);
            veritabaniIslem.Calistir();
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        public void Update()
        {
            veritabaniIslem.spAd = "spYemekGuncelle";
            veritabaniIslem.AddSqlParameter("@YorumIcerik", yorumIcerik);
            veritabaniIslem.AddSqlParameter("@YorumOnay", yorumOnay);
            //veritabaniIslem.AddSqlParameter("@YemekResim", yemekResim);
            veritabaniIslem.AddSqlParameter("@yorumid", yorumId);
            try
            {
                veritabaniIslem.Calistir();
                //veritabaniIslem.Update();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool YorumOnayliMi()
        {
            veritabaniIslem.spAd = "spYorumOnayDurumuGetir";
            veritabaniIslem.AddSqlParameter("YorumID", yorumId);
            try
            {
                veritabaniIslem.TabloGetir();
                //veritabaniIslem.VeriTablosu;
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
        public void UpdateOnayla()
        {
            veritabaniIslem.spAd = "spYorumOnayla";
            veritabaniIslem.AddSqlParameter("@YorumID", yorumId);
            veritabaniIslem.Calistir();
            //veritabaniIslem.Update();
        }
        public void UpdateOnayKaldir()
        {
            veritabaniIslem.spAd = "spYorumOnayKaldir";
            veritabaniIslem.AddSqlParameter("@YorumID", yorumId);
            veritabaniIslem.Calistir();
            //veritabaniIslem.Update();
        }
    }
}
