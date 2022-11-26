using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class Tarifler : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();

        // KULLANİLMİYOR
        protected void Page_Load(object sender, EventArgs e)
        { 
            //Panel4.Visible = false;
            //Panel6.Visible = false;
            //SqlCommand comm = new SqlCommand("select * from Tbl_Yemekler where YemekOnayDurum=0", conn.baglan());
            //SqlDataReader dr = comm.ExecuteReader();
            //DataList2.DataSource = dr;
            //DataList2.DataBind();
            //conn.baglantiKapat();
            //SqlCommand comm2 = new SqlCommand("select * from Tbl_Yemekler where YemekOnayDurum=1", conn.baglan());
            //SqlDataReader dr2 = comm2.ExecuteReader();
            //DataList3.DataSource = dr2;
            //DataList3.DataBind();
            //conn.baglantiKapat();

        }

        protected void btn_plusOnaysizYorum_Click(object sender, EventArgs e)
        {
            Panel4.Visible = true;
        }

        protected void btn_minusOnaysizYorum_Click(object sender, EventArgs e)
        {
            Panel4.Visible = false;
        }


        protected void btn_PlusOnayliYorum_Click1(object sender, EventArgs e)
        {
            Panel6.Visible = true;

        }

        protected void btn_minusOnayliYorum_Click1(object sender, EventArgs e)
        {
            Panel6.Visible = false;
        }
    }
}