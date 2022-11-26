using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Work;
using BusinessLayer_.Entity;

namespace YEMEKTARIFISITESI
{
    public partial class Iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }



        protected void btnMsjGndr_Click(object sender, EventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Mesaj mesaj = new Mesaj(veriTabaniIslemleri);
            mesaj.MesajGonderen = txtGonderenAdSoyad.Text;
            mesaj.MesajIcerik = txtKonu.Text;
            mesaj.MesajMail = txtGonderenMail.Text;
            mesaj.MesajBaslik = txtMesaj.Text;
            mesaj.Insert();
            veriTabaniIslemleri.BaglantiBitir();




            //SqlCommand comm = new SqlCommand("insert into Tbl_Mesajlar (mesajgonderen, mesajbaslik, mesajmail, mesajicerik) values (@p1, @p2,@p3, @p4)", conn.baglan());
            //comm.Parameters.AddWithValue("@p1", txtGonderenAdSoyad.Text);
            //comm.Parameters.AddWithValue("@p2", txtKonu.Text);
            //comm.Parameters.AddWithValue("@p3", txtGonderenMail.Text);
            //comm.Parameters.AddWithValue("@p4", txtMesaj.Text);
            //comm.ExecuteNonQuery();
            //conn.baglantiKapat();

            txtGonderenAdSoyad.Text="";
            txtGonderenMail.Text="";
            txtKonu.Text="";
            txtMesaj.Text = "";
            lbl_isSucces.Visible = true;
            lbl_isSucces.Text = "Basarili";
            lbl_isSucces.ForeColor = System.Drawing.Color.Green;
        }
    }
}