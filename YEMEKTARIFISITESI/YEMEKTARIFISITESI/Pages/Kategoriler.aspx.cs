using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer;
using BusinessLayer.Work;
using BusinessLayer.Entity;
using System.Data;

namespace YEMEKTARIFISITESI
{
    public partial class Kategoriler : System.Web.UI.Page
    {
        string islem = "";
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["Kategoriid"];
            islem = Request.QueryString["islem"];
            if (Page.IsPostBack == false)
            {
                KategorileriGetir();
            }
        }
        private void KategorileriGetir()
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Kategori kategori = new Kategori(veriTabaniIslemleri);
            DataTable dt= kategori.TumunuGetir();
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Sil(object sender, CommandEventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Kategori kategori = new Kategori(veriTabaniIslemleri);
            kategori.KategoriId = Convert.ToInt32(e.CommandArgument);
            kategori.Delete();
            veriTabaniIslemleri.BaglantiBitir();
            KategorileriGetir();


        }
    }
}