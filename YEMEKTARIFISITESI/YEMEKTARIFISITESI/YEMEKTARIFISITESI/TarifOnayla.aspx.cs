using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class TarifOnayla : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        int id;
        public void DeleteBoxes()
        {
            txtbx_TarifAd.Text = "";
            txtbx_TarifMalzemeler.Text = "";
            txtbx_Tarif.Text = "";
            txtbx_TrfOnerenAdSyd.Text = "";
            txtbx_TarifOnerenMail.Text = "";
            fu_TarifResim = new FileUpload();
            ddl_Kategoriler.Items.Clear();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Yemekid"]);
            if (Page.IsPostBack == false)
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
            if (String.IsNullOrEmpty(txtbx_Tarif.Text) || String.IsNullOrEmpty(txtbx_TarifMalzemeler.Text))
            {
                lbl_TarifOnerisiBasariliYadaDeğil.Text = "Gönderme işlemi başarısız. Yapılış veya malzemeler bilgilerini girmelisiniz...";
                lbl_TarifOnerisiBasariliYadaDeğil.ForeColor = System.Drawing.Color.Red;
                lbl_TarifOnerisiBasariliYadaDeğil.Visible = true;
            }
            else
            {
                try
                {
                    fu_TarifResim.SaveAs(Server.MapPath("/resimler/" + fu_TarifResim.FileName));
                    SqlCommand comm = new SqlCommand("update Tbl_Yemekler set YemekAd=@p1, YemekMalzeme=@p2, YemekTarif=@p3, Kategoriid=@p4, YemekResim=@p5, YemekOnayDurum=1 DurumGununYemegi=0 YemekOneren=@p6  YemekOnerenMail=@p7 where Yemekid=@p8", conn.baglan());
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
                    DeleteBoxes();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
