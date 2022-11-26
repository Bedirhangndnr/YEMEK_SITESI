using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Work;
using BusinessLayer_.Work;
using BusinessLayer_.Entity;
using System.Data;

namespace YEMEKTARIFISITESI
{
    public partial class YorumDetay : System.Web.UI.Page
    {
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
                Label1.Visible = false; 

            id = Convert.ToInt32(Request.QueryString["Yorumid"]);
            if (Page.IsPostBack == false)
            {
                YorumDetayKontrol yorumDetayKontrol = new YorumDetayKontrol();
                if (!yorumDetayKontrol.YorumOnayliMi(id))
                    btn_Onayla.Text = "Onay Kaldir";


                VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
                veriTabaniIslemleri.BaglantiBaslat();
                Yorum yorum = new Yorum(veriTabaniIslemleri);
                yorum.YorumId = id;
                DataTable dt=yorum.YorumVeYemekAdiGetir();


                Label1.Visible = false;
                //SqlCommand comm = new SqlCommand("select YorumAdSoyad, YorumMail, YorumIcerik, YemekAd from yorumlar inner join yemekler on yorumlar.Yemekid=yemekler.Yemekid where Yorumid=@p1", conn.baglan());
                //comm.Parameters.AddWithValue("@p1", id);
                //SqlDataReader dr = comm.ExecuteReader();
                foreach (DataRow dr in dt.Rows)
                {
                    txtbx_AdSoyad.Text = dr[0].ToString();
                    txtbx_Mail.Text = dr[1].ToString();
                    txtbx_Icerik.Text = dr[2].ToString();
                    txtbx_Yemek.Text = dr[3].ToString();
                }
                veriTabaniIslemleri.BaglantiBitir();

            }


        }

        protected void btn_Onayla_Click(object sender, EventArgs e)
        {
            YorumDetayKontrol yorumDetayKontrol = new YorumDetayKontrol();
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yorum yorum = new Yorum(veriTabaniIslemleri);
            yorum.YorumId = id;
            if (btn_Onayla.Text=="Onayla")
            {
                yorum.UpdateOnayla();
            }
            else if(btn_Onayla.Text=="Onay Kaldir")
            {
                yorum.UpdateOnayKaldir();
            }
            veriTabaniIslemleri.BaglantiBitir();
            //SqlCommand comm2 = new SqlCommand("Update Tbl_yorumlar set YorumIcerik=@p1,YorumOnay=@p2 where yorumid=@p3", conn.baglan());
            //comm2.Parameters.AddWithValue("@p1", txtbx_Icerik.Text);
            //comm2.Parameters.AddWithValue("@p2", "True");
            //comm2.Parameters.AddWithValue("@p3", id);
            //comm2.ExecuteNonQuery();
            //conn.baglantiKapat();
            Label1.Visible = true;
            Label1.Text = "basarili";
            txtbx_AdSoyad.Text = "";
            txtbx_Icerik.Text = "";
            txtbx_Mail.Text = "";
            txtbx_Yemek.Text = "";


        }
    }
}