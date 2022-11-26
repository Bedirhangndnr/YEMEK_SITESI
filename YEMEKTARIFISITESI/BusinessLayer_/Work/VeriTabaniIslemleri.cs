//using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLayer.Entity;
using System.Data;

namespace BusinessLayer.Work
{

    public class VeriTabaniIslemleri /*: ICRUD*/
    {
        SqlCommand comm = new SqlCommand();
        private SqlConnection conn_;
        List<SqlParameter> sqlParameters_ = new List<SqlParameter>();
        public string spAd;

        public SqlConnection Conn
        {
            get { return conn_; }
            set { conn_ = value; }
        }
        public VeriTabaniIslemleri()
        {
            try
            {
                conn_ = new SqlConnection("Server=NAHRIDEBREN\\SQLEXPRESS;Database=YemekSitesi;Trusted_Connection=Yes;");
                comm.Connection = conn_;
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
        // aşağıdaki 3 fonksiyonu yazıp kullandıktan sonra uygula fonksiyonunu yazıp onu kullandım. bu veritabani islemleri sınıfında
        // insert update delete fonksiyononları yerine bir uygulama fonksiyonu yeterli sanırım?
        //public void Insert()
        //{
        //    comm.CommandText = spAd;
        //    comm.CommandType = System.Data.CommandType.StoredProcedure;
        //    comm.ExecuteNonQuery();
        //}

        //public void Update()
        //{
        //    comm.CommandText = spAd;
        //    comm.CommandType = System.Data.CommandType.StoredProcedure;
        //    comm.ExecuteNonQuery();
        //}

        //public void Delete()
        //{
        //    comm.CommandType = System.Data.CommandType.StoredProcedure;
        //    comm.CommandText = spAd;
        //    comm.ExecuteNonQuery();
        //}
        public void Calistir()
        {
            DeleteSqlParameters();
            for (int i = 0; i < sqlParameters_.Count; i++)
            {
                comm.Parameters.AddWithValue(sqlParameters_[i].ParameterName, sqlParameters_[i].Value);
            }
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.CommandText = spAd;
            comm.ExecuteNonQuery();
            sqlParameters_.Clear();

        }
        //public void Uygula()
        //{
        //    DeleteSqlParameters();
        //    for (int i = 0; i < sqlParameters_.Count; i++)
        //    {
        //        comm.Parameters.AddWithValue(sqlParameters_[i].ParameterName, sqlParameters_[i].Value);
        //    }
        //    comm.CommandType = System.Data.CommandType.StoredProcedure;
        //    comm.CommandText = spAd;
        //    comm.ExecuteNonQuery();
        //    sqlParameters_.Clear();

        //}
        //public SqlDataReader GetAll()
        //{
        //    comm.CommandText = spAd;
        //    comm.CommandType = System.Data.CommandType.StoredProcedure;
        //    SqlDataReader dr = comm.ExecuteReader();
        //    return dr;
        //}


        private DataTable veriTablosu = new DataTable();
        public DataTable VeriTablosu
        {
            get { return veriTablosu; }
            set { veriTablosu = value; }
        }
        public void TabloGetir()
        {
            BaglantiBitir();
            BaglantiBaslat();
            comm.CommandText = spAd;
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(veriTablosu);
        }

        //public SqlDataReader GetById()
        //{
        //    comm.CommandText = spAd;
        //    comm.CommandType = System.Data.CommandType.StoredProcedure;
        //    SqlDataReader dr = comm.ExecuteReader();
        //    return dr;
        //}
        public void AddSqlParameter(string parameterName, object parameterValue)
        {

            sqlParameters_.Add(new SqlParameter(parameterName, parameterValue));
        }
        public void DeleteSqlParameters()
        {
            if (comm.Parameters.Count > 0)
            {
                comm.Parameters.Clear();
            }
        }
    }
}
