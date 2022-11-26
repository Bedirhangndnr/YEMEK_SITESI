using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Entity;
using BusinessLayer.Work;
using System.Drawing;

namespace YEMEKTARIFISITESI
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Kategori kategori = new Kategori(veriTabaniIslemleri);
            kategori.KategoriAd = txtbx_KategoriAd.Text;
            kategori.KategoriResim = fu_kategoriResim.FileName;
            //kategori.ResimEklenecekmi = fu_kategoriResim.FileName.Length != 0;
            kategori.Insert();
            veriTabaniIslemleri.BaglantiBitir();
            lbl_KategoriEklemeBasariliYadaDegil.Visible = true;
            lbl_KategoriEklemeBasariliYadaDegil.Text = "Başarılı... Kategori eklendi.";
            lbl_KategoriEklemeBasariliYadaDegil.ForeColor = Color.Green;
            //if (fu_kategoriResim.FileName.Length != 0)
            //{
            //    fu_kategoriResim.SaveAs(Server.MapPath("/resimler/" + fu_kategoriResim.FileName));
            //}
            //SqlCommand comm = new SqlCommand("insert into Tbl_Kategoriler (KategoriAd, KategoriResim) values(@p1, @p2)", conn.baglan());
            //comm.Parameters.AddWithValue("@p1", txtbx_KategoriAd.Text);
            //if (fu_kategoriResim.FileName.Length != 0)
            //{
            //    comm.Parameters.AddWithValue("@p2", "~/resimler/" + fu_kategoriResim.FileName);

            //}
            //else
            //{
            //    comm.Parameters.AddWithValue("@p2", "");

            //}
            //comm.ExecuteNonQuery();
            //conn.baglantiKapat();
            txtbx_KategoriAd.Text = String.Empty;
        }
    }
}