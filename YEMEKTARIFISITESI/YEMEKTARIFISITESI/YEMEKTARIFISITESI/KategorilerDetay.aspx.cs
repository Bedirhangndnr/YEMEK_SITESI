using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class KategorilerDetay1 : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        int kategoriid;
        protected void Page_Load(object sender, EventArgs e)
        {
            kategoriid =Convert.ToInt32(Request.QueryString["kategoriid"]);
            SqlCommand comm = new SqlCommand("select * from Tbl_Yemekler where kategoriid=@p1", conn.baglan());
            comm.Parameters.AddWithValue("@p1",kategoriid);
            SqlDataReader dr = comm.ExecuteReader();
            DataList2.DataSource = dr;
            DataList2.DataBind();
            conn.baglantiKapat();
        }

    }
}