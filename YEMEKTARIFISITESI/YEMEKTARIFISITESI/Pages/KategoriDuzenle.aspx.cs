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

    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Kategoriid"]);

            if (!Page.IsPostBack)
            {
                fillAllField();
            }
        }
        private void ClearField()
        {
            txtbx_KategoriAd.Text = "";
        }
        private void AlanlariTemizle()
        {
            txtbx_KategoriAd.Text = String.Empty;
        }
        private void fillAllField()
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Kategori kategori = new Kategori(veriTabaniIslemleri);
            kategori.KategoriId = id;
            DataTable dt = kategori.SatirGetir();
            foreach (DataRow r in dt.Rows)
            {
                txtbx_KategoriAd.Text = r["KategoriAd"].ToString();
                img_KategoriResim.ImageUrl = r["KategoriResim"].ToString();
            }
            veriTabaniIslemleri.BaglantiBitir();


            //SqlCommand comm = new SqlCommand("select * From kategoriler where Kategoriid=@p1", conn.baglan());
            //comm.Parameters.AddWithValue("@p1", id);
            //SqlDataReader dr = comm.ExecuteReader();
            //if (dr.Read())
            //{
            //    txtbx_KategoriAd.Text = dr[1].ToString();
            //    txtbx_KategoriAdet.Text = dr[2].ToString();
            //    img_KategoriResim.ImageUrl = dr[3].ToString();
            //}
            //conn.baglantiKapat();
        }
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {


        }

        protected void btn_Guncelle_Click(object sender, EventArgs e)
        {

            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Kategori kategori = new Kategori(veriTabaniIslemleri);
            kategori.KategoriId = id;

            if (kategori.Doldur())
            {
                kategori.KategoriAd = txtbx_KategoriAd.Text;
                if (Fu_KategoriResim.HasFiles)
                {
                    kategori.KategoriResim = Fu_KategoriResim.FileName;
                }
                kategori.Update();
            }

            veriTabaniIslemleri.BaglantiBitir();


            //if (Fu_KategoriResim.FileName.Length != 0)
            //{
            //    Fu_KategoriResim.SaveAs(Server.MapPath("/resimler/" + Fu_KategoriResim.FileName));
            //    SqlCommand comm = new SqlCommand("update Tbl_Kategoriler set Kategoriresim=@p1 where Kategoriid=@p2", conn.baglan());
            //    comm.Parameters.AddWithValue("@p1", "~/resimler/" + Fu_KategoriResim.FileName);
            //    comm.Parameters.AddWithValue("@p2", id);
            //    comm.ExecuteNonQuery();
            //    conn.baglantiKapat();
            //}
            //SqlCommand comm1 = new SqlCommand("update Tbl_Kategoriler set KategoriAd=@p1, kategoriAdet=@p2 where Kategoriid=@p3", conn.baglan());
            //comm1.Parameters.AddWithValue("@p1", txtbx_KategoriAd.Text);
            //comm1.Parameters.AddWithValue("@p2", txtbx_KategoriAdet.Text);
            //comm1.Parameters.AddWithValue("@p3", id);
            //comm1.ExecuteNonQuery();
            //conn.baglantiKapat();
            //fillAllField();
            //ClearField();
        }
        protected void btn_Sil_Click(object sender, EventArgs e)
        {

            VeriTabaniIslemleri veriTabaniIslemleriYemekEkle = new VeriTabaniIslemleri();
            veriTabaniIslemleriYemekEkle.BaglantiBaslat();
            Kategori kategori = new Kategori(veriTabaniIslemleriYemekEkle);
            kategori.KategoriId = id;
            kategori.Delete();
            veriTabaniIslemleriYemekEkle.BaglantiBitir();
            lbl_BasariliYadaDegil.Text = "Basarili... Secili kategori silindi.";
            lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
            lbl_BasariliYadaDegil.Visible = true;
            AlanlariTemizle();
        }

        protected void btn_Güncelle_Click(object sender, EventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Kategori kategori = new Kategori(veriTabaniIslemleri);
            kategori.KategoriId = id;

            if (kategori.Doldur())
            {
                kategori.KategoriAd = txtbx_KategoriAd.Text;
                if (Fu_KategoriResim.HasFiles)
                {
                    kategori.KategoriResim = Fu_KategoriResim.FileName;
                }
                kategori.Update();
            }
            veriTabaniIslemleri.BaglantiBitir();
            lbl_BasariliYadaDegil.Text = "Guncelleme islemi basarili";
            lbl_BasariliYadaDegil.ForeColor = System.Drawing.Color.Green;
            lbl_BasariliYadaDegil.Visible = true;
            AlanlariTemizle();

        }
    }
}