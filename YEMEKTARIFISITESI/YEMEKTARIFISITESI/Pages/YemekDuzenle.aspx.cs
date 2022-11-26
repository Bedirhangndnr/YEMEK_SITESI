using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Entity;
using BusinessLayer.Work;
using BusinessLayer_.Entity;
using System.Data;

namespace YEMEKTARIFISITESI
{

    public partial class YemekDuzenle : System.Web.UI.Page
    {
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
        private void AlanlariTemizle()
        {
            txtbxYemekAd.Text = String.Empty;
            txtbxYemekMalzemeler.Text = String.Empty;
            txtbxYemekTarif.Text = String.Empty;
            //ddlKategoriler.Selecte
            txtbx_EkleyenAd.Text = String.Empty;
            txtbx_EkleyenMail.Text = String.Empty;
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
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Kategori kategori = new Kategori(veriTabaniIslemleri);
            DataTable dt= kategori.TumunuGetir();
            ddlKategoriler.DataTextField = "KategoriAd";
            ddlKategoriler.DataValueField = "Kategoriid";
            ddlKategoriler.DataSource = dt;
            ddlKategoriler.DataBind();
            veriTabaniIslemleri.BaglantiBitir();

            //SqlCommand comm2 = new SqlCommand("select * from kategoriler", conn.baglan());
            //SqlDataReader dr2 = comm2.ExecuteReader();
            //ddlKategoriler.DataTextField = "KategoriAd";
            //ddlKategoriler.DataValueField = "Kategoriid";
            //ddlKategoriler.DataSource = dr2;
            //ddlKategoriler.DataBind();
            //conn.baglantiKapat();

            VeriTabaniIslemleri veriTabaniIslemleri_yemekGetir = new VeriTabaniIslemleri();
            veriTabaniIslemleri_yemekGetir.BaglantiBaslat();
            Yemek yemek = new Yemek(veriTabaniIslemleri_yemekGetir);
            yemek.YemekId= id;
            //SqlDataReader dr = yemek.GetById();
            DataTable dt2 = yemek.SatirGetir();
            //SqlCommand comm = new SqlCommand("select * from yemekler where Yemekid=@p1", conn.baglan());
            //comm.Parameters.AddWithValue("@p1", id);
            //SqlDataReader dr = comm.ExecuteReader();

            foreach (DataRow r in dt2.Rows)
            {
                fu_yemekResim.SaveAs(Server.MapPath(r["YemekResim"].ToString()));
                txtbxYemekAd.Text = r["YemekAd"].ToString();
                txtbxYemekMalzemeler.Text = r["YemekMalzeme"].ToString();
                txtbxYemekTarif.Text = r["YemekTarif"].ToString();
                //ddlKategoriler.SelectedValue = dr[7].ToString();
                txtbx_EkleyenAd.Text = r["YemekOneren"].ToString();
                txtbx_EkleyenMail.Text = r["YemekOnerenMail"].ToString();
                img_YemekResim.ImageUrl = r["YemekResim"].ToString();
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



                VeriTabaniIslemleri veriTabaniIslemleriYemekEkle = new VeriTabaniIslemleri();
                veriTabaniIslemleriYemekEkle.BaglantiBaslat();
                Yemek yemek = new Yemek(veriTabaniIslemleriYemekEkle);
                yemek.YemekId = id;
                 if (yemek.Doldur())
                {
                    if (fu_yemekResim.HasFiles)
                    {
                        fu_yemekResim.SaveAs(Server.MapPath("/resimler/" + fu_yemekResim.FileName));
                        yemek.YemekResim = "~/resimler/" + fu_yemekResim.FileName;
                    }
                    yemek.YemekAd = txtbxYemekAd.Text;
                    yemek.YemekMalzeme = txtbxYemekMalzemeler.Text;
                    //fu_yemekResim.SaveAs(Server.MapPath("/resimler/" + fu_yemekResim.FileName));
                    //yemek.YemekResim = "~/resimler/" + fu_yemekResim.FileName;
                    yemek.YemekOnerenMail = txtbx_EkleyenMail.Text;
                    yemek.YemekOneren = txtbx_EkleyenAd.Text;
                    yemek.YemekTarif = txtbxYemekTarif.Text;
                }
                if (islem == "ekle")
                {
                    yemek.Insert();
                    veriTabaniIslemleriYemekEkle.BaglantiBitir();
                    // yemek ekleme
                    //SqlCommand comm = new SqlCommand("insert into Tbl_Yemekler(YemekAd, YemekMalzeme, YemekTarif, YemekResim,Kategoriid, YemekOneren, YemekOnerenMail) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7)",
                    //    conn.baglan());
                    //comm.Parameters.AddWithValue("@p1", txtbxYemekAd.Text);
                    //comm.Parameters.AddWithValue("@p2", txtbxYemekMalzemeler.Text);
                    //if (fu_yemekResim.FileName.Length != 0)
                    //{
                    //    comm.Parameters.AddWithValue("@p3", txtbxYemekMalzemeler.Text);
                    //}
                    //else
                    //{
                    //    comm.Parameters.AddWithValue("@p3", "");
                    //}
                    //comm.Parameters.AddWithValue("@p4", txtbxYemekTarif.Text);
                    //comm.Parameters.AddWithValue("@p5", ddlKategoriler.SelectedValue);
                    //comm.Parameters.AddWithValue("@p6", txtbx_EkleyenAd.Text);
                    //comm.Parameters.AddWithValue("@p7", txtbx_EkleyenMail.Text);
                    //comm.ExecuteNonQuery();
                    //conn.baglantiKapat();

                    ////Kategori sayısını 1 arttırma
                    //SqlCommand comm2 = new SqlCommand("update Tbl_Kategoriler set KategoriAdet=KategoriAdet+1 where kategoriid=@p1",
                    //    conn.baglan());
                    //comm2.Parameters.AddWithValue("@p1", ddlKategoriler.SelectedValue);
                    //comm2.ExecuteNonQuery();
                    //conn.baglantiKapat();
                    //lbl_BasariliYadaDegil.Text = "Ekleme islemi basarili";
                    //lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
                    //lbl_BasariliYadaDegil.Visible = true;
                }
                //Guncelle
                else
                {

                    yemek.Update();
                    SayfayiYukle();
                    lbl_BasariliYadaDegil.Text = "Guncelleme islemi basarili";
                    lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
                    lbl_BasariliYadaDegil.Visible = true;

                }
                veriTabaniIslemleriYemekEkle.BaglantiBitir();

            }
            


        }
        protected void GununYemegiYap(object sender, CommandEventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleriYemekEkle = new VeriTabaniIslemleri();
            veriTabaniIslemleriYemekEkle.BaglantiBaslat();
            Yemek yemek = new Yemek(veriTabaniIslemleriYemekEkle);
            yemek.YemekId = id;
            yemek.GununYemegiOnayKaldir();
            yemek.GununYemegiYap();
            veriTabaniIslemleriYemekEkle.BaglantiBitir();
            //SqlCommand comm = new SqlCommand("update Tbl_Yemekler set DurumGununYemegi=0", conn.baglan());
            //comm.ExecuteNonQuery();
            //conn.baglantiKapat();

            ////gunun yemeginin durumunu 1 yap:
            //SqlCommand comm2 = new SqlCommand("update Tbl_Yemekler set DurumGununYemegi=1 where Yemekid=@p1", conn.baglan());
            //comm2.Parameters.AddWithValue("@p1", id);
            //comm2.ExecuteNonQuery();
            //conn.baglantiKapat();
            lbl_BasariliYadaDegil.Text = "Gunun Yemeği Seçildi";
            lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
            lbl_BasariliYadaDegil.Visible = true;
        }

// BU KISIMDAN DEVAM EDİLECEK. ÜSTTE YAZILAN KODLARIN TAMAMI ÇALIŞTIRILIP DENENECEK. TARİH: 06.10.2022 11:08.
        protected void Sil(object sender, CommandEventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleriYemekEkle = new VeriTabaniIslemleri();
            veriTabaniIslemleriYemekEkle.BaglantiBaslat();
            Yemek yemek = new Yemek(veriTabaniIslemleriYemekEkle);
            yemek.YemekId = id;
            yemek.Delete();
            veriTabaniIslemleriYemekEkle.BaglantiBitir();
            lbl_BasariliYadaDegil.Text = "Basarili... Secili yemek silindi.";
            lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
            lbl_BasariliYadaDegil.Visible = true;
            SayfayiYukle();
            AlanlariTemizle();
            //SqlCommand comm3 = new SqlCommand("delete from Tbl_Yorumlar where Yemekid=@p1;", conn.baglan());
            //comm3.Parameters.AddWithValue("@p1", id);
            //comm3.ExecuteNonQuery();
            //conn.baglantiKapat();
            //SqlCommand comm4 = new SqlCommand("delete from Tbl_Yemekler where Yemekid=@p1;", conn.baglan());
            //comm4.Parameters.AddWithValue("@p1", id);
            //comm4.ExecuteNonQuery();
            //conn.baglantiKapat();
            //txtbxYemekAd.Text = "";
            //txtbxYemekMalzemeler.Text = "";
            //txtbxYemekTarif.Text = "";
            //txtbx_EkleyenMail.Text = "";
            //txtbx_EkleyenAd.Text = "";
            //SayfayiYukle();
            //lbl_BasariliYadaDegil.Text = "Silme islemi basarili";
            //lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
            //lbl_BasariliYadaDegil.Visible = true;
        }
    }
}