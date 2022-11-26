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

    public partial class YorumYap : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Yemekid"]);


        }
        protected void AlanlariTemizle()
        {
            inpt_AdSoyad.Text = string.Empty;
            inpt_Mail.Text = string.Empty;
            inpt_Mesaj.Text = string.Empty;
        }
            protected void Button1_Click1(object sender, EventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yorum yorum = new Yorum(veriTabaniIslemleri);
            yorum.YorumAdSoyad = inpt_AdSoyad.Text;
            yorum.YorumMail= inpt_Mail.Text;
            yorum.YorumIcerik= inpt_Mesaj.Text;
            yorum.YemekId = id;
            yorum.Insert();
            veriTabaniIslemleri.BaglantiBitir();
            AlanlariTemizle();
            lbl_YorumYapmaBasariliYadaDeğil.Text = "Yorumunuz Gonderildi...";
            lbl_YorumYapmaBasariliYadaDeğil.ForeColor = System.Drawing.Color.Green;
            lbl_YorumYapmaBasariliYadaDeğil.Visible = true;
            //SqlCommand comm = new SqlCommand("insert into Tbl_Yorumlar(YorumAdSoyad, YorumMail, YorumIcerik, Yemekid) VALUES(@p1, @p2, @p3, @p4)", conn.baglan());
            //comm.Parameters.AddWithValue("@p1", inpt_AdSoyad.Text);
            //comm.Parameters.AddWithValue("@p2", inpt_Mail.Text);
            //comm.Parameters.AddWithValue("@p3", inpt_Mesaj.Text);
            //comm.Parameters.AddWithValue("@p4", id);
            //comm.ExecuteNonQuery();
            //conn.baglantiKapat();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (true)
            {
                //SqlCommand comm = new SqlCommand("insert into Tbl_Puanlar (PuanlayanAdSoyad, Puan, Yemekid) VALUES(@p1, @p2, @p3)", conn.baglan());
                //comm.Parameters.AddWithValue("@p1", inpt_AdSoyad.Text);
                //comm.Parameters.AddWithValue("@p2", "deneme");
                //comm.Parameters.AddWithValue("@p3", id);
                //comm.ExecuteNonQuery();
                //conn.baglantiKapat();

            }
            else
            {
                //puanVer.Text = "Lütfen önce puan giriniz.";
            }

        }
    }
}