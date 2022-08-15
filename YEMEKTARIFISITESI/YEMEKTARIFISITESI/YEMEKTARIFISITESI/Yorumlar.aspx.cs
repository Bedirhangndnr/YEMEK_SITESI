using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YorumlariGetir(0);
            }
        }

        private void YorumlariGetir(int yorumTuru)
        {
            string sorgu = "";
            if (yorumTuru == 0)
            {
                sorgu = "select *,(case when YorumOnay=1 then 'Onaylı' else 'Onaysız' End) [YorumDurum] from Tbl_Yorumlar ";
            }
            else if (yorumTuru == 1)//onaylı
            {
                sorgu = "select *,(case when YorumOnay=1 then 'Onaylı' else 'Onaysız' End) [YorumDurum] from Tbl_Yorumlar where YorumOnay=1";
            }
            else if (yorumTuru == -1)//onaysız
            {
                sorgu = "select *,(case when YorumOnay=1 then 'Onaylı' else 'Onaysız' End) [YorumDurum] from Tbl_Yorumlar  where YorumOnay=0";
            }
            SqlCommand comm = new SqlCommand(sorgu, conn.baglan());
            SqlDataReader dr = comm.ExecuteReader();
            DataList1.DataSource = dr;
            DataList1.DataBind();
        }
         
        protected void Onayla(object sender, CommandEventArgs e)
        {
            SqlCommand comm3 = new SqlCommand("update Tbl_Yorumlar set YorumOnay=1 where Yorumid=@p1;", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();
            YorumlariGetir(Convert.ToInt32(ddlOnayTuru.SelectedValue)); 
        }
        protected void OnayIptal(object sender, CommandEventArgs e)
        {
            SqlCommand comm3 = new SqlCommand("update Tbl_Yorumlar set YorumOnay=0 where Yorumid=@p1;", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();
            YorumlariGetir(Convert.ToInt32(ddlOnayTuru.SelectedValue));
        }
        protected void Sil(object sender, CommandEventArgs e)
        {
            SqlCommand comm3 = new SqlCommand("delete from Tbl_Yorumlar where Yorumid=@p1;", conn.baglan());
            comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            comm3.ExecuteNonQuery();
            conn.baglantiKapat();
            YorumlariGetir(Convert.ToInt32(ddlOnayTuru.SelectedValue));
        }

        protected void ddlOnayTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            YorumlariGetir(Convert.ToInt32(ddlOnayTuru.SelectedValue));
        }
    }
}