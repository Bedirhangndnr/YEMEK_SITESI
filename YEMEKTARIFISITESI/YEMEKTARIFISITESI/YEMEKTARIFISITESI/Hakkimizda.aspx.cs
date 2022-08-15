using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class Hakkimizda : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            if (Page.IsPostBack==false)
            {
                SqlCommand comm = new SqlCommand("select metin from Tbl_Hakkimizda", conn.baglan());
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    lbl_Hakkimizda.Text = dr[0].ToString();
                }
                conn.baglantiKapat();
            }

        }

    }
}