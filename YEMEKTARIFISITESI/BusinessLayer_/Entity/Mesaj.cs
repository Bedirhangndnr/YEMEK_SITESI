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
    public class Mesaj: OrtakDegiskenler/*, ICRUD*/
    {
        public string spAd;
        private VeriTabaniIslemleri veritabaniIslem;
        public Mesaj(VeriTabaniIslemleri veriTabanİIslemleri)
        {
            veritabaniIslem = veriTabanİIslemleri;
        }

        protected VeriTabaniIslemleri VeritabaniIslem
        {
            get { return veritabaniIslem; }
            set { veritabaniIslem = value; }
        }

        private int mesajId;
        public int MesajId
        {
            get { return mesajId; }
            set { mesajId = value; }
        }
        private string mesajGonderen;
        public string MesajGonderen
        {
            get { return mesajGonderen; }
            set { mesajGonderen = value; }
        }


        private string mesajBaslik;
        public string MesajBaslik
        {
            get { return mesajBaslik; }
            set { mesajBaslik = value; }
        }
        private string mesajMail;
        public string MesajMail
        {
            get { return mesajMail; }
            set { mesajMail = value; }
        }
        private string mesajIcerik;
        public string MesajIcerik
        {
            get { return mesajIcerik; }
            set { mesajIcerik = value; }
        }

        public void Insert()
        {
            veritabaniIslem.spAd = "spMesajEkle";
            veritabaniIslem.AddSqlParameter("@MesajGonderen", mesajGonderen);
            veritabaniIslem.AddSqlParameter("@MesajBaslik", mesajBaslik);
            veritabaniIslem.AddSqlParameter("@MesajMail", mesajMail);
            veritabaniIslem.AddSqlParameter("@MesajIcerik", mesajIcerik);
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
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        //public SqlDataReader GetAll()
        //{
        //    veritabaniIslem.spAd = "spTumMesajlariGetir";
        //    return veritabaniIslem.GetAll();
        //}
        public DataTable TumunuGetir()
        {
            veritabaniIslem.spAd = "spTumMesajlariGetir";
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        public DataTable SatirGetir()
        {
            veritabaniIslem.spAd = "spSeciliMesajiGetir";
            veritabaniIslem.AddSqlParameter("@Mesajid", mesajId);
            veritabaniIslem.Calistir();
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }
        //public SqlDataReader GetById()
        //{
        //    veritabaniIslem.spAd = "spSeciliMesajiGetir";
        //    veritabaniIslem.AddSqlParameter("@Mesajid", mesajId);
        //    veritabaniIslem.Calistir();
        //    return veritabaniIslem.GetById();
        //}
    }
}
