using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class YorumDetay : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Yorumid"]);
            if (Page.IsPostBack == false)
            {
                SqlCommand comm = new SqlCommand("select YorumAdSoyad, YorumMail, YorumIcerik, YemekAd from Tbl_yorumlar inner join Tbl_yemekler on Tbl_yorumlar.Yemekid=Tbl_Yemekler.Yemekid where Yorumid=@p1", conn.baglan());
                comm.Parameters.AddWithValue("@p1", id);
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    txtbx_AdSoyad.Text = dr[0].ToString();
                    txtbx_Mail.Text = dr[1].ToString();
                    txtbx_Icerik.Text = dr[2].ToString();
                    txtbx_Yemek.Text = dr[3].ToString();
                }
                conn.baglantiKapat();

            }


        }

        protected void btn_Onayla_Click(object sender, EventArgs e)
        {
            SqlCommand comm2 = new SqlCommand("Update Tbl_yorumlar set YorumIcerik=@p1,YorumOnay=@p2 where yorumid=@p3", conn.baglan());
            comm2.Parameters.AddWithValue("@p1", txtbx_Icerik.Text);
            comm2.Parameters.AddWithValue("@p2", "True");
            comm2.Parameters.AddWithValue("@p3", id);
            comm2.ExecuteNonQuery();
            conn.baglantiKapat();

        }
    }
}