using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            if (fu_kategoriResim.FileName.Length != 0)
            {
                fu_kategoriResim.SaveAs(Server.MapPath("/resimler/" + fu_kategoriResim.FileName));
            }
            SqlCommand comm = new SqlCommand("insert into Tbl_Kategoriler (KategoriAd, KategoriResim) values(@p1, @p2)", conn.baglan());
            comm.Parameters.AddWithValue("@p1", txtbx_KategoriAd.Text);
            if (fu_kategoriResim.FileName.Length != 0)
            {
                comm.Parameters.AddWithValue("@p2", "~/resimler/" + fu_kategoriResim.FileName);

            }
            else
            {
                comm.Parameters.AddWithValue("@p2", "");

            }
            comm.ExecuteNonQuery();
            conn.baglantiKapat();
            txtbx_KategoriAd.Text = String.Empty;
        }
    }
}