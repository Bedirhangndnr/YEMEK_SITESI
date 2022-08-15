using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class OnayBekleyenYorumlar : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand comm2 = new SqlCommand("select * from Tbl_Yorumlar where YorumOnay=0", conn.baglan());
            SqlDataReader dr2 = comm2.ExecuteReader();
            DataList2.DataSource = dr2;
            DataList2.DataBind();
            conn.baglantiKapat();
        }
    }
}