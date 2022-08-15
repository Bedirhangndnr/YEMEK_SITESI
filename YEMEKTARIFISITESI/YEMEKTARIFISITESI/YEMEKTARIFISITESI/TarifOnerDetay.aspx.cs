using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class Tar_fOnerDetay : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        int id;
        public void deleteBoxes()
        {
            txtbx_TarifAd.Text = "";
            txtbx_TarifMalzemeler.Text = "";
            txtbx_Tarif.Text = "";
            txtbx_TrfOnerenAdSyd.Text ="";
            txtbx_TarifOnerenMail.Text = "";
            fu_TarifResim = new FileUpload();
            ddl_Kategoriler.Items.Clear();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

            id = Convert.ToInt32(Request.QueryString["Yemekid"]);
            if (Page.IsPostBack== false)
            {
                //ddl'e ekleme kategorileri
                SqlCommand comm2 = new SqlCommand("select * from Tbl_Kategoriler", conn.baglan());
                SqlDataReader dr2 = comm2.ExecuteReader();
                ddl_Kategoriler.DataTextField = "KategoriAd";
                ddl_Kategoriler.DataValueField = "Kategoriid";
                ddl_Kategoriler.DataSource = dr2;
                ddl_Kategoriler.DataBind();
                conn.baglantiKapat();
                SqlCommand comm = new SqlCommand("select * from Tbl_Yemekler where Yemekid=@p1", conn.baglan());
                comm.Parameters.AddWithValue("@p1", id);
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    txtbx_TarifAd.Text = dr[1].ToString();
                    txtbx_TarifMalzemeler.Text = dr[2].ToString();
                    txtbx_Tarif.Text = dr[3].ToString();
                    txtbx_TrfOnerenAdSyd.Text = dr[5].ToString();
                    txtbx_TarifOnerenMail.Text = dr[6].ToString();
                }
                conn.baglantiKapat();
            }





        }

        protected void btn_TarifOner_Click(object sender, EventArgs e)
        {

            // Guncelleme
            //fu_yemekResim.SaveAs(Server.MapPath("/resimler/" + fu_yemekResim.FileName));
            //SqlCommand comm = new SqlCommand("update Tbl_Yemekler set YemekAd=@p1, YemekMalzeme=@p2, YemekTarif=@p3, Kategoriid=@p4, YemekResim=YemekResim where Yemekid=@p6", conn.baglanti());
            //comm.Parameters.AddWithValue("p1", txtbx_TarifAd.Text);
            //comm.Parameters.AddWithValue("p2", txtbx_TarifMalzemeler.Text);
            //comm.Parameters.AddWithValue("p3", txtbx_Tarif.Text);
            //comm.Parameters.AddWithValue("p4", ddl_Kategoriler.SelectedValue);
            ////comm.Parameters.AddWithValue("p5", "~/resimler/" + fu_yemekResim.FileName);
            //comm.Parameters.AddWithValue("p6", id);
            //comm.ExecuteNonQuery();
            //conn.baglanti().Close();




            fu_TarifResim.SaveAs(Server.MapPath("/resimler/" + fu_TarifResim.FileName));
            SqlCommand comm = new SqlCommand("update Tbl_Yemekler set YemekAd=@p1, YemekMalzeme=@p2, YemekTarif=@p3, Kategoriid=@p4, YemekResim=@p5, YemekOnayDurum=1, DurumGununYemegi=0, YemekOneren=@p6,  YemekOnerenMail=@p7 where Yemekid=@p8", conn.baglan());
            comm.Parameters.AddWithValue("@p1", txtbx_TarifAd.Text);
            comm.Parameters.AddWithValue("@p2", txtbx_TarifMalzemeler.Text);
            comm.Parameters.AddWithValue("@p3", txtbx_Tarif.Text);
            comm.Parameters.AddWithValue("@p4", ddl_Kategoriler.SelectedValue);
            comm.Parameters.AddWithValue("@p5", "~/resimler/" + fu_TarifResim.FileName);
            comm.Parameters.AddWithValue("@p6", txtbx_TrfOnerenAdSyd.Text);
            comm.Parameters.AddWithValue("@p7", txtbx_TarifOnerenMail.Text);
            comm.Parameters.AddWithValue("@p8", id);
            comm.ExecuteNonQuery();
            conn.baglantiKapat();
            deleteBoxes();

            //Yemegi/Tarifi guncelleme
            //SqlCommand comm2 = new SqlCommand("update Tbl_Yemekler set YemekAd=@p1, YemekMalzeme=@p2, YemekTarif=@p3, Kategoriid=@p4 where Tarifid=@p5" +
            //    "(@p1, @p2, @p3, @p4)", conn.baglanti());
            //comm2.Parameters.AddWithValue("@p1", txtbx_TarifAd.Text);
            //comm2.Parameters.AddWithValue("@p2", txtbx_TarifMalzemeler.Text);
            //comm2.Parameters.AddWithValue("@p3", txtbx_Tarif.Text);
            //comm2.Parameters.AddWithValue("@p4", ddl_Kategoriler.SelectedValue);
            //comm2.Parameters.AddWithValue("@p5", id);
            //comm2.ExecuteNonQuery();
            //conn.baglanti().Close();

        }
    }
}
