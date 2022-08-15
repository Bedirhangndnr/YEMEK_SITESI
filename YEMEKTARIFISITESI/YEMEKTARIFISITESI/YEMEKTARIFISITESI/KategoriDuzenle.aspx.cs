using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{

    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Kategoriid"]);

            if (!Page.IsPostBack)
            {
                fillAllField();
            }
        }
        private void ClearField(){
            txtbx_KategoriAd.Text = "";
            txtbx_KategoriAdet.Text = "";
        }
        private void fillAllField()
        {
            SqlCommand comm = new SqlCommand("select * From Tbl_Kategoriler where Kategoriid=@p1", conn.baglan());
            comm.Parameters.AddWithValue("@p1", id);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                txtbx_KategoriAd.Text = dr[1].ToString();
                txtbx_KategoriAdet.Text = dr[2].ToString();
                img_KategoriResim.ImageUrl = dr[3].ToString();
            }
            conn.baglantiKapat();
        }
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {


        }

        protected void btn_Güncelle_Click(object sender, EventArgs e)
        {
            if (Fu_KategoriResim.FileName.Length != 0)
            {
                Fu_KategoriResim.SaveAs(Server.MapPath("/resimler/" + Fu_KategoriResim.FileName));
                SqlCommand comm = new SqlCommand("update Tbl_Kategoriler set Kategoriresim=@p1 where Kategoriid=@p2", conn.baglan());
                comm.Parameters.AddWithValue("@p1", "~/resimler/" + Fu_KategoriResim.FileName);
                comm.Parameters.AddWithValue("@p2", id);
                comm.ExecuteNonQuery();
                conn.baglantiKapat();
            }
            SqlCommand comm1 = new SqlCommand("update Tbl_Kategoriler set KategoriAd=@p1, kategoriAdet=@p2 where Kategoriid=@p3", conn.baglan());
            comm1.Parameters.AddWithValue("@p1", txtbx_KategoriAd.Text);
            comm1.Parameters.AddWithValue("@p2", txtbx_KategoriAdet.Text);
            comm1.Parameters.AddWithValue("@p3", id);
            comm1.ExecuteNonQuery();
            conn.baglantiKapat();
            fillAllField();
            ClearField();
        }
        protected void btn_Sil_Click(object sender, EventArgs e)
        {

            SqlCommand comm = new SqlCommand("delete From Tbl_Kategoriler where Kategoriid=@p2", conn.baglan());
            comm.Parameters.AddWithValue("@p2", id);
            comm.ExecuteNonQuery();
            conn.baglantiKapat();
            fillAllField();
            ClearField();
        }
    }
}