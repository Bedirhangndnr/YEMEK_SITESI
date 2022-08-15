using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class Kategoriler : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        string islem = "";
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["Kategoriid"];
            islem = Request.QueryString["islem"];
            if (Page.IsPostBack == false)
            {
                KategorileriGetir();
            }
        }
        private void KategorileriGetir()
        {
            SqlCommand comm = new SqlCommand("select * From Tbl_Kategoriler", conn.baglan());
            SqlDataReader dr = comm.ExecuteReader();
            DataList1.DataSource = dr;
            DataList1.DataBind();
            conn.baglantiKapat();
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Sil(object sender, CommandEventArgs e)
        {
            // silme islemi
            SqlCommand komutSil = new SqlCommand("delete from Tbl_Kategoriler where Kategoriid=@p1", conn.baglan());
            komutSil.Parameters.AddWithValue("@p1", e.CommandArgument);
            komutSil.ExecuteNonQuery();
            conn.baglantiKapat();
            KategorileriGetir();
        }
    }
}