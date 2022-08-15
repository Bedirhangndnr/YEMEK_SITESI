using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class yemekDetay : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        string yemekid="";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            yemekid = Request.QueryString["Yemekid"];

            //SqlCommand comm = new SqlCommand("SELECT YemekAd FROM Tbl_Yemekler where Yemekid=@p1", conn.baglanti());
            //comm.Parameters.AddWithValue("@p1", Convert.ToInt32(yemekid)); 
            //SqlDataReader dr = comm.ExecuteReader();
            //while (dr.Read())
            //{
            //    Label4.Text = dr[0].ToString();
            //}
            //conn.baglanti().Close();

            //yorumlari listeleme
            SqlCommand comm1 = new SqlCommand("SELECT * FROM Tbl_Yemekler where Yemekid=@p2", conn.baglan());
            comm1.Parameters.AddWithValue("@p2", Convert.ToInt32(yemekid));
            SqlDataReader dr1 = comm1.ExecuteReader();
            DataList2.DataSource = dr1;
            DataList2.DataBind();
            conn.baglantiKapat();
            SqlCommand comm2 = new SqlCommand("SELECT * FROM Tbl_Yorumlar where Yemekid=@p2", conn.baglan());
            comm2.Parameters.AddWithValue("@p2", Convert.ToInt32(yemekid));
            SqlDataReader dr2 = comm2.ExecuteReader();
            DataList1.DataSource = dr2;
            DataList1.DataBind();
            conn.baglantiKapat();

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    SqlCommand comm3 = new SqlCommand("insert into Tbl_Yorumlar (yorumadsoyad, yorummail, yorumicerik, yemekid) values(@p1,@p2,@p3,@p4)", conn.baglan());
        //    comm3.Parameters.AddWithValue("@p1", TextBox1.Text);
        //    comm3.Parameters.AddWithValue("@p2", TextBox2.Text);
        //    comm3.Parameters.AddWithValue("@p3", TextBox3.Text);
        //    comm3.Parameters.AddWithValue("@p4", yemekid);
        //    comm3.ExecuteNonQuery();
        //    conn.baglanti().Close();
        //}
    }
}