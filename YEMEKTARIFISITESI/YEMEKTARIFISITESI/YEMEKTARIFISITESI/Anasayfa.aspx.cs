using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class Anasayfa : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("SELECT * FROM Tbl_Yemekler", conn.baglan());
            SqlDataReader dr = comm.ExecuteReader();
            DataList2.DataSource = dr;
            DataList2.DataBind();
            conn.baglantiKapat();


        }

        protected void btn_YorumYap_Command(object sender, CommandEventArgs e)
        {
            SqlCommand comm2 = new SqlCommand("insert inyo Tbl_yorumlar (YorumAdSoyad, YorumMail, YorumIcerik, Yemekid) values(@p1, @p2, @p3, @p4)", conn.baglan());
            comm2.Parameters.AddWithValue("@p1", "userAdSoyad");
            comm2.Parameters.AddWithValue("@p2", "userMail");
            //comm2.Parameters.AddWithValue("@p3", );

            comm2.ExecuteNonQuery();
            conn.baglantiKapat();
        }

        protected void btn_PuanVer(object sender, CommandEventArgs e)
        {
            
        }
    }
}