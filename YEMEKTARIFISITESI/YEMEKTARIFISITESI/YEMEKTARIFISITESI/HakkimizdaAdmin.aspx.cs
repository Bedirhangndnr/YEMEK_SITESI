using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace YEMEKTARIFISITESI
{
    public partial class HakkimizdaAdmin : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                SqlCommand comm = new SqlCommand("select * from Tbl_Hakkimizda", conn.baglan());
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    txtbx_Hakkimizda.Text = dr[0].ToString();
                }
                conn.baglantiKapat();
            }
        }

        protected void btn_Guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("update Tbl_Hakkimizda set metin=@p1", conn.baglan());
            comm.Parameters.AddWithValue("@p1", txtbx_Hakkimizda.Text);
            comm.ExecuteNonQuery();
            conn.baglantiKapat();
            lbl_IsSucess.Visible = true;
            lbl_IsSucess.Text = "Güncelleme Başarılı";
            lbl_IsSucess.ForeColor = System.Drawing.Color.Green;

        }



    }
}
