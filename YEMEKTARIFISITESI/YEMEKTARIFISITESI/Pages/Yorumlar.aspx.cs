using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Work;
using BusinessLayer_.Entity;
using BusinessLayer.Entity;
using System.Data;

namespace YEMEKTARIFISITESI
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YorumlariGetir(0);
            }
        }

        private void YorumlariGetir(int yorumTuru)
        {
            string spSorgu = "";
            //if (yorumTuru == 0)
            //{
            //    spSorgu = "select *,(case when YorumOnay=1 then 'Onaylı' else 'Onaysız' End) [YorumDurum] from yorumlar ";
            //}
            //else if (yorumTuru == 1)//onaylı
            //{
            //    spSorgu = "select *,(case when YorumOnay=1 then 'Onaylı' else 'Onaysız' End) [YorumDurum] from yorumlar where YorumOnay=1";
            //}
            //else if (yorumTuru == -1)//onaysız
            //{
            //    spSorgu = "select *,(case when YorumOnay=1 then 'Onaylı' else 'Onaysız' End) [YorumDurum] from yorumlar  where YorumOnay=0";
            //}
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yorum yorum = new Yorum(veriTabaniIslemleri);
            DataTable dt;
            if (yorumTuru == 0)
            {
                dt = yorum.TumunuGetir();
            }
            else if (yorumTuru == 1)//onaylı
            {
                yorum.YorumOnay = true;
                dt = yorum.TumunuGetir();
            }
            else//onaysız
            {
                yorum.YorumOnay = false;
                dt = yorum.TumunuGetir();
            }
            DataList1.DataSource =dt;
            DataList1.DataBind();
            veriTabaniIslemleri.BaglantiBitir();

        }

        protected void Onayla(object sender, CommandEventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yorum yorum = new Yorum(veriTabaniIslemleri);
            yorum.YorumId = Convert.ToInt32(e.CommandArgument);
            yorum.UpdateOnayla();
            veriTabaniIslemleri.BaglantiBitir();
            //SqlCommand comm3 = new SqlCommand("update yorumlar set YorumOnay=1 where Yorumid=@p1;", conn.baglan());
            //comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            //comm3.ExecuteNonQuery();
            //conn.baglantiKapat();
            //YorumlariGetir(Convert.ToInt32(ddlOnayTuru.SelectedValue)); 
        }
        protected void OnayIptal(object sender, CommandEventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yorum yorum = new Yorum(veriTabaniIslemleri);
            yorum.YorumId = Convert.ToInt32(e.CommandArgument);
            yorum.UpdateOnayKaldir();
            veriTabaniIslemleri.BaglantiBitir();
            
            //SqlCommand comm3 = new SqlCommand("update yorumlar set YorumOnay=0 where Yorumid=@p1;", conn.baglan());
            //comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            //comm3.ExecuteNonQuery();
            //conn.baglantiKapat();
            //YorumlariGetir(Convert.ToInt32(ddlOnayTuru.SelectedValue));
        }
        protected void Sil(object sender, CommandEventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yorum yorum = new Yorum(veriTabaniIslemleri);
            yorum.YorumId = Convert.ToInt32(e.CommandArgument);
            yorum.Delete();
            veriTabaniIslemleri.BaglantiBitir();


            //SqlCommand comm3 = new SqlCommand("delete from yorumlar where Yorumid=@p1;", conn.baglan());
            //comm3.Parameters.AddWithValue("@p1", e.CommandArgument);
            //comm3.ExecuteNonQuery();
            //conn.baglantiKapat();
            //YorumlariGetir(Convert.ToInt32(ddlOnayTuru.SelectedValue));
        }

        protected void ddlOnayTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            YorumlariGetir(Convert.ToInt32(ddlOnayTuru.SelectedValue));
        }
    }
}