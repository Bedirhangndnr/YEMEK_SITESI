using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace YEMEKTARIFISITESI
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        sqlsinif bgl = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("Select KategoriAd , count(*) 'KategoriAdet', Tbl_Kategoriler.Kategoriid 'Kategoriid'  from Tbl_Yemekler inner join Tbl_Kategoriler on Tbl_Yemekler.Kategoriid = Tbl_Kategoriler.Kategoriid group by Tbl_Kategoriler.Kategoriid, Tbl_Kategoriler.Kategoriad ", bgl.baglan());
            SqlDataReader read = comm.ExecuteReader();
            DataList1.DataSource = read;
            DataList1.DataBind();
            bgl.baglantiKapat();
        }

        protected void Unnamed1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}




