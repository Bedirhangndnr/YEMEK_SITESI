using BusinessLayer.Interfaces;
using BusinessLayer.Work;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class Kategori : OrtakDegiskenler, ICRUD
    {
        DataTable dt;
        public string SpAd { get; set; }
        public Kategori(VeriTabaniIslemleri veriTabanİIslemleri)
        {
            veriTabanİIslemleri = veritabaniIslem;
        }

        private VeriTabaniIslemleri veritabaniIslem;
        protected VeriTabaniIslemleri VeritabaniIslem { 
            get { return veritabaniIslem; } 
            set { veritabaniIslem = value; } 
        }
        [Key]
        private int kategoriId;
        public int KategoriId
        {
            get { return KategoriId; }
            set { kategoriId = value; }
        }
        [StringLength(50)]
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
            throw new NotImplementedException();
        }

        public SqlDataReader GetAll()
        {
            return veritabaniIslem.GetAll();
        }

        public DataTable GetById()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
