using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace YEMEKTARIFISITESI
{
    public partial class GununYemegi : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("select * From tbl_Yemekler where DurumGununYemegi=1", conn.baglan());

            SqlDataReader read = comm.ExecuteReader();
            DataList3.DataSource = read;
            DataList3.DataBind();
            conn.baglantiKapat();
        }

        protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}