using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using BusinessLayer.Entity;

namespace BusinessLayer.Work
{
    
    public class VeriTabaniIslemleri:ICRUD
    {
        private SqlConnection conn_;
        public SqlConnection Conn
        {
            get { return conn_; }
            set { conn_ = value; }
        }
        public VeriTabaniIslemleri(string _sp_Ad)
        {
            try
            {
                conn_ = new SqlConnection("Server=NAHRIDEBREN\\SQLEXPRESS;Database=YemekSitesi;Trusted_Connection=Yes;");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public SqlConnection BaglantiBaslat()
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
        public SqlConnection BaglantiBitir()
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
        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public SqlDataReader GetAll()
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri()
            Kategori kategori=new Kategori()
        }

        public SqlDataReader GetById()
        {
            throw new NotImplementedException();
        }
    }
}
