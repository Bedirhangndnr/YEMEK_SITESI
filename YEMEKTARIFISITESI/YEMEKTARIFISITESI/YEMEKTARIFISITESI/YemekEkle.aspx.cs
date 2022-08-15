using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class YemekEkle : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Yemekid"]);

            //Kategori listesi
            SqlCommand comm2 = new SqlCommand("select * from Tbl_Kategoriler", conn.baglan());
            SqlDataReader dr2 = comm2.ExecuteReader();
            ddlKategoriler.DataTextField = "KategoriAd";
            ddlKategoriler.DataValueField = "Kategoriid";
            ddlKategoriler.DataSource = dr2;
            ddlKategoriler.DataBind();
            conn.baglantiKapat();

        }
        protected void btnYemekEkle_Click(object sender, EventArgs e)
        {
            // yemek ekleme
            SqlCommand comm = new SqlCommand("insert into Tbl_Yemekler(YemekAd, YemekMalzeme, YemekTarif, Kategoriid) values(@p1, @p2, @p3, @p4)",
                conn.baglan());
            comm.Parameters.AddWithValue("@p1", txtbxYemekAd.Text);
            comm.Parameters.AddWithValue("@p2", txtbxYemekMalzemeler.Text);
            comm.Parameters.AddWithValue("@p3", txtbxYemekTarif.Text);
            comm.Parameters.AddWithValue("@p4", ddlKategoriler.SelectedValue);
            comm.ExecuteNonQuery();
            conn.baglantiKapat();
            //Kategori sayısını 1 arttırma
            SqlCommand comm2 = new SqlCommand("update Tbl_Kategoriler set KategoriAdet=KategoriAdet+1 where kategoriid=@p1",
                conn.baglan());
            comm2.Parameters.AddWithValue("@p1", ddlKategoriler.SelectedValue);
            comm2.ExecuteNonQuery();
            conn.baglantiKapat();



        }
    }
}