using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Work;
using BusinessLayer_.Entity;
using System.Data;

namespace YEMEKTARIFISITESI
{
    public partial class Yemekler : System.Web.UI.Page
    {
        int id;
        int kategori_id;
        string islem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Yemekid"]);
            if (!Page.IsPostBack)
            {
                YemekleriiGetir(ddlOnayTuru.SelectedItem.ToString());

            }
            if (islem == "del")
            {

            }
            else if (islem == "Onayla")
            {
                //SqlCommand comm3 = new SqlCommand("update Tbl_Yemekler Set YemekOnayDurum=1 where Yemekid=@p1;", conn.baglan());
                //comm3.Parameters.AddWithValue("@p1", id);
                //comm3.ExecuteNonQuery();
                //conn.baglantiKapat();
                VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
                veriTabaniIslemleri.BaglantiBaslat();
                Yemek yemek = new Yemek(veriTabaniIslemleri);
                yemek.YemekId = id;
                veriTabaniIslemleri.BaglantiBitir();
                YemekleriiGetir(ddlOnayTuru.SelectedItem.ToString());
            }
            else if (islem == "OnayiKaldir")
            {

            }
        }
        private void YemekleriiGetir(string yorumTuru)
        {
            string sorgu = "";
            if (yorumTuru == "Hepsi")
            {
                VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
                veriTabaniIslemleri.BaglantiBaslat();
                Yemek yemek = new Yemek(veriTabaniIslemleri);
                DataList1.DataSource = yemek.TumunuGetir();
                DataList1.DataBind();
                veriTabaniIslemleri.BaglantiBitir();
            }
            else
            {
                bool onayliOrOnaysiz = true;
                if (yorumTuru == "Onaylı")//onaylı
                {
                    onayliOrOnaysiz = true;
                }
                else if (yorumTuru == "Onaysız")//onaysız
                {
                    onayliOrOnaysiz = false;
                }
                //sorgu = "select *,(case when YemekOnayDurum=1 then 'Onaylı' else 'Onaysız' End) [YemekOnayDurum] from Tbl_Yemekler  where YemekOnayDurum=0";
                //sorgu = "spOnayliOnaysizYemekleriGetir";
                //SqlCommand comm = new SqlCommand(sorgu, conn.baglan());
                //comm.CommandType = System.Data.CommandType.StoredProcedure;
                //comm.Parameters.AddWithValue("@YemeKOnay", onayliOrOnaysiz);
                //SqlDataReader dr = comm.ExecuteReader();
                //DataList1.DataSource = dr;
                //DataList1.DataBind();

                VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
                veriTabaniIslemleri.BaglantiBaslat();
                Yemek yemek = new Yemek(veriTabaniIslemleri);
                yemek.YemekOnay = onayliOrOnaysiz;
                DataTable dt= yemek.OnayDurumunaGoreGetir();
                DataList1.DataSource = dt;
                DataList1.DataBind();
                veriTabaniIslemleri.BaglantiBitir();


            }

        }
        protected void ddlOnayTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            YemekleriiGetir(ddlOnayTuru.SelectedItem.ToString());
        }

        protected void btn_Sil(object sender, CommandEventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yemek yemek = new Yemek(veriTabaniIslemleri);
            yemek.YemekId = Convert.ToInt32(e.CommandArgument);
            yemek.Delete();
            veriTabaniIslemleri.BaglantiBitir();
            YemekleriiGetir(ddlOnayTuru.SelectedItem.ToString());


            // silme islemi
            //SqlCommand comm3 = new SqlCommand("delete from Tbl_Yorumlar where Yemekid=@p1; " +
            //    "delete from Tbl_Yemekler where Yemekid=@p1", conn.baglan());
            //comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            //comm3.ExecuteNonQuery();
            //conn.baglantiKapat();

            //SqlCommand commDelKategoriAdet = new SqlCommand("UPDATE Tbl_Kategoriler SET KategoriAdet=KategoriAdet-1 WHERE Kategoriid=@p2", conn.baglan());
            //commDelKategoriAdet.Parameters.AddWithValue("@p2", kategori_id);
            //commDelKategoriAdet.ExecuteNonQuery();

            //conn.baglantiKapat();
            //YemekleriiGetir(0);
        }

        // yemek onaylama islemi
        protected void btn_Onayla(object sender, CommandEventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yemek yemek = new Yemek(veriTabaniIslemleri);
            yemek.YemekId = Convert.ToInt32(e.CommandArgument);
            yemek.UpdateOnayla();
            veriTabaniIslemleri.BaglantiBitir();
            YemekleriiGetir(ddlOnayTuru.SelectedItem.ToString());
            // Onayla islemi
            //SqlCommand comm3 = new SqlCommand("update Tbl_Yemekler Set YemekOnayDurum=1 where Yemekid=@p1;", conn.baglan());
            //comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            //comm3.ExecuteNonQuery();
            //conn.baglantiKapat();
            //YemekleriiGetir(0);
        }
        // yemek onay kaldirma islemi

        protected void btn_OnayKaldir(object sender, CommandEventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yemek yemek = new Yemek(veriTabaniIslemleri);
            yemek.YemekId = Convert.ToInt32(e.CommandArgument);
            yemek.UpdateOnayKaldir();
            veriTabaniIslemleri.BaglantiBitir();
            YemekleriiGetir(ddlOnayTuru.SelectedItem.ToString());
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
        //protected void lblbtn_Sil(object sender, CommandEventArgs e)
        //{
        //    // silme islemi
        //    SqlCommand comm3 = new SqlCommand("delete from Tbl_Yorumlar where Yemekid=@p1; " +
        //        "delete from Tbl_Yemekler where Yemekid=@p1", conn.baglan());
        //    comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
        //    comm3.ExecuteNonQuery();
        //    conn.baglantiKapat();

        //    SqlCommand commDelKategoriAdet = new SqlCommand("UPDATE Tbl_Kategoriler SET KategoriAdet=KategoriAdet-1 WHERE Kategoriid=@p2", conn.baglan());
        //    commDelKategoriAdet.Parameters.AddWithValue("@p2", kategori_id);
        //    commDelKategoriAdet.ExecuteNonQuery();

        //    conn.baglantiKapat();
        //    YemekleriiGetir(0);
        //}
        //protected void lblbtn_Onayla(object sender, CommandEventArgs e)
        //{
        //    // Onayla islemi
        //    SqlCommand comm3 = new SqlCommand("update Tbl_Yemekler Set YemekOnayDurum=1 where Yemekid=@p1;", conn.baglan());
        //    comm3.Parameters.AddWithValue("@p1", id);
        //    comm3.ExecuteNonQuery();
        //    conn.baglantiKapat();
        //    YemekleriiGetir(0);
        //}
        //protected void lblbtn_OnayKaldir(object sender, CommandEventArgs e)
        //{
        //    // Onaykaldir islemi
        //    SqlCommand comm3 = new SqlCommand("update Tbl_Yemekler Set YemekOnayDurum=0 where Yemekid=@p1;", conn.baglan());
        //    comm3.Parameters.AddWithValue("@p1", id);
        //    comm3.ExecuteNonQuery();
        //    conn.baglantiKapat();
        //    YemekleriiGetir(0);

        //}


    }
}