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
    public class HakkimizdaEntity : OrtakDegiskenler/*, ICRUD*/
    {
        private VeriTabaniIslemleri veritabaniIslem;
        public HakkimizdaEntity(VeriTabaniIslemleri veriTabanİIslemleri)
        {
            veritabaniIslem = veriTabanİIslemleri;
        }
        protected VeriTabaniIslemleri VeritabaniIslem
        {
            get { return veritabaniIslem; }
            set { veritabaniIslem = value; }
        }
        private string metin;
        public string Metin
        {
            get { return metin; }
            set { metin = value; }
        }
 
        //public void Delete()
        //{
        //    throw new NotImplementedException();
        //}

        //public SqlDataReader GetAll()
        //{
        //    veritabaniIslem.spAd = "spHakkimizdaGetir";
        //    return veritabaniIslem.GetAll();
        //}

        public DataTable TumunuGetir()
        {
            veritabaniIslem.spAd = "spHakkimizdaGetir";
            veritabaniIslem.TabloGetir();
            return veritabaniIslem.VeriTablosu;
        }

        //public SqlDataReader GetById()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert()
        //{
        //    throw new NotImplementedException();
        //}

        public void Update()
        {
            veritabaniIslem.spAd = "spHakkimizdaGuncelle";
            veritabaniIslem.AddSqlParameter("@Metin", metin);
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
    }
}
