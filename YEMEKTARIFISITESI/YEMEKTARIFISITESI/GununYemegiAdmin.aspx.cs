using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class GununYemegiAdmin : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlCommand comm = new SqlCommand("select * from tbl_yemekler", conn.baglan());
            //SqlDataReader dr = comm.ExecuteReader();

            //DataList1.DataSource = dr;
            //DataList1.DataBind();
            //conn.baglantiKapat();


        }
    }
}