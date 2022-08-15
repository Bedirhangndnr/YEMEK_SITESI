using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class Yemekler : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        int id;
        int kategori_id;
        string islem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Yemekid"]);
            if (!Page.IsPostBack)
            {
                YemekleriiGetir(0);

            }
            if (islem == "del")
            {


            }
            else if (islem == "Onayla")
            {
                SqlCommand comm3 = new SqlCommand("update Tbl_Yemekler Set YemekOnayDurum=1 where Yemekid=@p1;", conn.baglan());
                comm3.Parameters.AddWithValue("@p1", id);
                comm3.ExecuteNonQuery();
                conn.baglantiKapat();
                YemekleriiGetir(0);
            }
            else if (islem == "OnayiKaldir")
            {

            }


        }
        private void YemekleriiGetir(int yorumTuru)
        {
            string sorgu = "";
            if (yorumTuru == 0)
            {
                sorgu = "select *,(case when YemekOnayDurum=1 then 'Onaylı' else 'Onaysız' End) [YemekOnayDurum] from Tbl_Yemekler ";
            }
            else if (yorumTuru == 1)//onaylı
            {
                sorgu = "select *,(case when YemekOnayDurum=1 then 'Onaylı' else 'Onaysız' End) [YemekOnayDurum] from Tbl_Yemekler where YemekOnayDurum=1";
            }
            else if (yorumTuru == -1)//onaysız
            {
                sorgu = "select *,(case when YemekOnayDurum=1 then 'Onaylı' else 'Onaysız' End) [YemekOnayDurum] from Tbl_Yemekler  where YemekOnayDurum=0";
            }
            SqlCommand comm = new SqlCommand(sorgu, conn.baglan());
            SqlDataReader dr = comm.ExecuteReader();
            DataList1.DataSource = dr;
            DataList1.DataBind();
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            //SqlCommand comm = new SqlCommand("update Tbl_Kategoriler set KategoriAd=@p1, kategoriAdet=@p2 " +
            //    "where  Kategoriid=@p3", conn.baglanti());
            //comm.Parameters.AddWithValue("@p1", txtboxKategoriAd.Text);
            //comm.Parameters.AddWithValue("@p2", txtboxKategoriAdet.Text);
            //comm.Parameters.AddWithValue("@p3", id);
            //comm.ExecuteNonQuery();
            //conn.baglanti().Close();

        }
        protected void lblbtn_Sil(object sender, CommandEventArgs e)
        {
            // silme islemi
            SqlCommand comm3 = new SqlCommand("delete from Tbl_Yorumlar where Yemekid=@p1; " +
                "delete from Tbl_Yemekler where Yemekid=@p1", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();

            SqlCommand commDelKategoriAdet = new SqlCommand("UPDATE Tbl_Kategoriler SET KategoriAdet=KategoriAdet-1 WHERE Kategoriid=@p2", conn.baglan());
            commDelKategoriAdet.Parameters.AddWithValue("@p2", kategori_id);
            commDelKategoriAdet.ExecuteNonQuery();

            conn.baglantiKapat();
            YemekleriiGetir(0);
        }
        protected void lblbtn_Onayla(object sender, CommandEventArgs e)
        {
            // Onayla islemi
            SqlCommand comm3 = new SqlCommand("update Tbl_Yemekler Set YemekOnayDurum=1 where Yemekid=@p1;", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", id);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();
            YemekleriiGetir(0);
        }
        protected void lblbtn_OnayKaldir(object sender, CommandEventArgs e)
        {
            // Onaykaldir islemi
            SqlCommand comm3 = new SqlCommand("update Tbl_Yemekler Set YemekOnayDurum=0 where Yemekid=@p1;", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", id);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();
            YemekleriiGetir(0);

        }
        protected void ddlOnayTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            YemekleriiGetir(Convert.ToInt32(ddlOnayTuru.SelectedValue));
        }

        protected void Unnamed_Command(object sender, CommandEventArgs e)
        {
            // silme islemi
            SqlCommand comm3 = new SqlCommand("delete from Tbl_Yorumlar where Yemekid=@p1; " +
                "delete from Tbl_Yemekler where Yemekid=@p1", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();

            SqlCommand commDelKategoriAdet = new SqlCommand("UPDATE Tbl_Kategoriler SET KategoriAdet=KategoriAdet-1 WHERE Kategoriid=@p2", conn.baglan());
            commDelKategoriAdet.Parameters.AddWithValue("@p2", kategori_id);
            commDelKategoriAdet.ExecuteNonQuery();

            conn.baglantiKapat();
            YemekleriiGetir(0);
        }

        protected void Unnamed_Command1(object sender, CommandEventArgs e)
        {
            // Onayla islemi
            SqlCommand comm3 = new SqlCommand("update Tbl_Yemekler Set YemekOnayDurum=1 where Yemekid=@p1;", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();
            YemekleriiGetir(0);
        }

        protected void Unnamed_Command2(object sender, CommandEventArgs e)
        {
            // Onaykaldir islemi
            SqlCommand comm3 = new SqlCommand("update Tbl_Yemekler Set YemekOnayDurum=0 where Yemekid=@p1;", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();
            YemekleriiGetir(0);
        }

    }
}