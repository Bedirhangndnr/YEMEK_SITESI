using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{

    public partial class YemekDuzenle : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        int id;
        string islem = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            islem = Request.QueryString["islem"];
            id = Convert.ToInt32(Request.QueryString["Yemekid"]);
            if (Page.IsPostBack == false)
            {
                SayfayiYukle();
            }
        }

        private void SayfayiYukle()
        {
            lbl_BasariliYadaDegil.Visible=false;
            if (islem == "ekle")
            {
                btn_Sil.Visible = false;
                btn_Guncele.Text = "Ekle";
                btn_GununYemegiYp.Visible = false;
            }

            //ddl'e ekleme
            SqlCommand comm2 = new SqlCommand("select * from Tbl_Kategoriler", conn.baglan());
            SqlDataReader dr2 = comm2.ExecuteReader();
            ddlKategoriler.DataTextField = "KategoriAd";
            ddlKategoriler.DataValueField = "Kategoriid";
            ddlKategoriler.DataSource = dr2;
            ddlKategoriler.DataBind();
            conn.baglantiKapat();
            SqlCommand comm = new SqlCommand("select * from Tbl_Yemekler where Yemekid=@p1", conn.baglan());
            comm.Parameters.AddWithValue("@p1", id);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                fu_yemekResim.SaveAs(Server.MapPath(dr[4].ToString()));
                txtbxYemekAd.Text = dr[1].ToString();
                txtbxYemekMalzemeler.Text = dr[2].ToString();
                txtbxYemekTarif.Text = dr[3].ToString();
                ddlKategoriler.SelectedValue = dr[7].ToString();
                txtbx_EkleyenAd.Text = dr[10].ToString();
                txtbx_EkleyenMail.Text = dr[11].ToString();
                img_YemekResim.ImageUrl = dr[4].ToString();
            }

        }


        protected void Guncelle_Ekle(object sender, CommandEventArgs e)
        {
            if (String.IsNullOrEmpty(txtbxYemekMalzemeler.Text.Trim()) || String.IsNullOrEmpty(txtbxYemekTarif.Text.Trim()))
            {
                lbl_BasariliYadaDegil.Text = "Gönderme işlemi başarısız. Yapılış veya malzemeler bilgilerini girmelisiniz...";
                lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Red;
                lbl_BasariliYadaDegil.Visible = true;
            }
            else
            {
                if (fu_yemekResim.FileName.Length != 0)
                {
                    fu_yemekResim.SaveAs(Server.MapPath("/resimler/" + fu_yemekResim.FileName));
                }
                if (islem == "ekle")
                {
                    // yemek ekleme
                    SqlCommand comm = new SqlCommand("insert into Tbl_Yemekler(YemekAd, YemekMalzeme, YemekTarif, YemekResim,Kategoriid, YemekOneren, YemekOnerenMail) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7)",
                        conn.baglan());
                    comm.Parameters.AddWithValue("@p1", txtbxYemekAd.Text);
                    comm.Parameters.AddWithValue("@p2", txtbxYemekMalzemeler.Text);
                    if (fu_yemekResim.FileName.Length != 0)
                    {
                        comm.Parameters.AddWithValue("@p3", txtbxYemekMalzemeler.Text);
                    }
                    else
                    {
                        comm.Parameters.AddWithValue("@p3", "");
                    }
                    comm.Parameters.AddWithValue("@p4", txtbxYemekTarif.Text);
                    comm.Parameters.AddWithValue("@p5", ddlKategoriler.SelectedValue);
                    comm.Parameters.AddWithValue("@p6", txtbx_EkleyenAd.Text);
                    comm.Parameters.AddWithValue("@p7", txtbx_EkleyenMail.Text);
                    comm.ExecuteNonQuery();
                    conn.baglantiKapat();

                    //Kategori sayısını 1 arttırma
                    SqlCommand comm2 = new SqlCommand("update Tbl_Kategoriler set KategoriAdet=KategoriAdet+1 where kategoriid=@p1",
                        conn.baglan());
                    comm2.Parameters.AddWithValue("@p1", ddlKategoriler.SelectedValue);
                    comm2.ExecuteNonQuery();
                    conn.baglantiKapat();
                    lbl_BasariliYadaDegil.Text = "Ekleme islemi basarili";
                    lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
                    lbl_BasariliYadaDegil.Visible = true;
                }
                //Guncelle
                else
                {
                    if (fu_yemekResim.FileName.Length != 0)
                    {
                        SqlCommand comm1 = new SqlCommand("update Tbl_Yemekler set YemekResim=@p1 where Yemekid=@p2", conn.baglan());
                        comm1.Parameters.AddWithValue("@p1", "~/resimler/" + fu_yemekResim.FileName);
                        comm1.Parameters.AddWithValue("@p2", id);
                        comm1.ExecuteNonQuery();
                        conn.baglantiKapat();
                    }
                    SqlCommand comm = new SqlCommand("update Tbl_Yemekler set YemekAd=@p1, YemekMalzeme=@p2, YemekTarif=@p3, Kategoriid=@p4, YemekOneren=@p5, YemekOnerenMail=@p6 where Yemekid=@p7", conn.baglan());
                    comm.Parameters.AddWithValue("p1", txtbxYemekAd.Text);
                    comm.Parameters.AddWithValue("p2", txtbxYemekMalzemeler.Text);
                    comm.Parameters.AddWithValue("p3", txtbxYemekTarif.Text);
                    comm.Parameters.AddWithValue("p4", ddlKategoriler.SelectedValue);
                    comm.Parameters.AddWithValue("p5", txtbx_EkleyenAd.Text);
                    comm.Parameters.AddWithValue("p6", txtbx_EkleyenMail.Text);
                    comm.Parameters.AddWithValue("p7", id);
                    comm.ExecuteNonQuery();
                    conn.baglantiKapat();
                    SayfayiYukle();
                    lbl_BasariliYadaDegil.Text = "Guncelleme islemi basarili";
                    lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
                    lbl_BasariliYadaDegil.Visible = true;

                }
                txtbxYemekAd.Text="";
                txtbxYemekMalzemeler.Text = "";
                txtbxYemekTarif.Text="";
                txtbx_EkleyenAd.Text="";
                txtbx_EkleyenMail.Text="";
                ddlKategoriler.Items.Clear();

            }
            


        }
        protected void GununYemegiYap(object sender, CommandEventArgs e)
        {
            SqlCommand comm = new SqlCommand("update Tbl_Yemekler set DurumGununYemegi=0", conn.baglan());
            comm.ExecuteNonQuery();
            conn.baglantiKapat();

            //gunun yemeginin durumunu 1 yap:
            SqlCommand comm2 = new SqlCommand("update Tbl_Yemekler set DurumGununYemegi=1 where Yemekid=@p1", conn.baglan());
            comm2.Parameters.AddWithValue("@p1", id);
            comm2.ExecuteNonQuery();
            conn.baglantiKapat();
            lbl_BasariliYadaDegil.Text = "Gunun Yemeği Seçildi";
            lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
            lbl_BasariliYadaDegil.Visible = true;
        }
        protected void Sil(object sender, CommandEventArgs e)
        {
            SqlCommand comm3 = new SqlCommand("delete from Tbl_Yorumlar where Yemekid=@p1;", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", id);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();
            SqlCommand comm4 = new SqlCommand("delete from Tbl_Yemekler where Yemekid=@p1;", conn.baglan());
            comm4.Parameters.AddWithValue("@p1", id);
            comm4.ExecuteNonQuery();
            conn.baglantiKapat();
            txtbxYemekAd.Text = "";
            txtbxYemekMalzemeler.Text = "";
            txtbxYemekTarif.Text = "";
            txtbx_EkleyenMail.Text = "";
            txtbx_EkleyenAd.Text = "";
            SayfayiYukle();
            lbl_BasariliYadaDegil.Text = "Silme islemi basarili";
            lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
            lbl_BasariliYadaDegil.Visible = true;
        }
    }
}