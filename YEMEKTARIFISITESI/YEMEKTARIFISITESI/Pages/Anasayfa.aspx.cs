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
    public partial class Anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yemek yemek = new Yemek(veriTabaniIslemleri); 
            DataList2.DataSource = yemek.TumunuGetir();
            DataList2.DataBind();


            veriTabaniIslemleri.BaglantiBitir();

            //SqlCommand comm = new SqlCommand("SELECT * FROM Tbl_Yemekler where YemekOnayDurum=1", conn.baglan());
            //SqlDataReader dr = comm.ExecuteReader();
            //DataList2.DataSource = dr;
            //DataList2.DataBind();
            //conn.baglantiKapat();


        }

        protected void btn_YorumYap_Command(object sender, CommandEventArgs e)
        {
            //SqlCommand comm2 = new SqlCommand("insert into yorumlar (YorumAdSoyad, YorumMail, YorumIcerik, Yemekid) values(@p1, @p2, @p3, @p4)", conn.baglan());
            //comm2.Parameters.AddWithValue("@p1", "userAdSoyad");
            //comm2.Parameters.AddWithValue("@p2", "userMail");
            ////comm2.Parameters.AddWithValue("@p3", );

            //comm2.ExecuteNonQuery();
            //conn.baglantiKapat();
        }

        protected void btn_PuanVer(object sender, CommandEventArgs e)
        {
            
        }
    }
}