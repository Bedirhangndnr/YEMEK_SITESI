using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Work;
using BusinessLayer_.Entity;

namespace YEMEKTARIFISITESI
{
    public partial class TarifOner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lbl_TarifOnerisiBasariliYadaDeğil.Visible=false;
            }
        }
        protected void btnTarifOner_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtTarifYapilis.Text) || String.IsNullOrEmpty(txtTarifMalzemeler.Text))
            {
                lbl_TarifOnerisiBasariliYadaDeğil.Text = "Gönderme işlemi başarısız. Yapılış veya malzemeler bilgilerini girmelisiniz...";
                lbl_TarifOnerisiBasariliYadaDeğil.ForeColor=System.Drawing.Color.Red;
                lbl_TarifOnerisiBasariliYadaDeğil.Visible = true;
            }
            else
            {
                try
                {
                    VeriTabaniIslemleri veriTabaniIslemleriYemekEkle = new VeriTabaniIslemleri();
                    veriTabaniIslemleriYemekEkle.BaglantiBaslat();
                    Yemek yemek = new Yemek(veriTabaniIslemleriYemekEkle);
                    yemek.YemekAd = txtTarifAd.Text;
                    yemek.YemekMalzeme = txtTarifMalzemeler.Text;
                    if (fuTarifResim.HasFiles)
                    {
                        fuTarifResim.SaveAs(Server.MapPath("/resimler/" + fuTarifResim.FileName));
                        yemek.YemekResim = "~/resimler/" + fuTarifResim.FileName;
                    }
                    else
                        yemek.YemekResim = "";
                    yemek.YemekOnerenMail = txtTarifMail.Text;
                    yemek.YemekOneren = txtTarifOneri.Text;
                    yemek.YemekTarif = txtTarifYapilis.Text;
                    yemek.Insert();
                    veriTabaniIslemleriYemekEkle.BaglantiBitir();

                    //if (fuTarifResim.FileName.Length != 0)
                    //{
                    //    fuTarifResim.SaveAs(Server.MapPath("/resimler/" + fuTarifResim.FileName));
                    //}

                    //SqlCommand comm = new SqlCommand("INSERT INTO Tbl_Yemekler(YemekAd, YemekMalzeme, YemekTarif, YemekResim, YemekOneren, YemekOnerenMail) " +
                    //    "VALUES(@YemekAd, @YemekMalzeme, @YemekYapilis, @YemekResim, @YemekOneren, @YemekOnerenMail)", conn.baglan());
                    //comm.Parameters.AddWithValue("@YemekAd", txtTarifAd.Text);
                    //comm.Parameters.AddWithValue("@YemekMalzeme", txtTarifMalzemeler.Text);
                    //comm.Parameters.AddWithValue("@YemekYapilis", txtTarifYapilis.Text);
                    //if (fuTarifResim.FileName.Length != 0)
                    //{
                    //    comm.Parameters.AddWithValue("@YemekResim", "~/resimler/" + fuTarifResim.FileName);
                    //}
                    //else
                    //{
                    //    comm.Parameters.AddWithValue("@YemekResim", "");
                    //}
                    //comm.Parameters.AddWithValue("@YemekOneren", txtTarifOneri.Text);
                    //comm.Parameters.AddWithValue("@YemekOnerenMail", txtTarifMail.Text);
                    //comm.ExecuteNonQuery();
                    //conn.baglantiKapat();
                    lbl_TarifOnerisiBasariliYadaDeğil.Visible = true;
                    //txtTarifAd.Text = "";
                    //txtTarifMail.Text = "";
                    //txtTarifMalzemeler.Text = "";
                    //txtTarifOneri.Text = "";
                    //txtTarifYapilis.Text = "";
                }
                catch (Exception)
                {
                    throw;
                }
            }
            



        }
    }
}