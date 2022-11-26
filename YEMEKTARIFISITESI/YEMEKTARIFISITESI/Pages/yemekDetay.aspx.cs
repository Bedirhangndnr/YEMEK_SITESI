using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Work;
using BusinessLayer.Entity;
using BusinessLayer_.Entity;
using System.Data;

namespace YEMEKTARIFISITESI
{
    public partial class yemekDetay : System.Web.UI.Page
    {
        string yemekid="";
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Yemekid"]);
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            Yemek yemek = new Yemek(veriTabaniIslemleri);
            veriTabaniIslemleri.BaglantiBaslat();
            yemek.YemekId = id;
            ddlYemekDetay.DataSource= yemek.SatirGetir();
            ddlYemekDetay.DataBind();
            veriTabaniIslemleri.BaglantiBitir();

        }

    }
}