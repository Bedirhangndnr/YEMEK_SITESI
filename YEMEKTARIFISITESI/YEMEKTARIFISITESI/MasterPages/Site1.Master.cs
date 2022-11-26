using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Work;
using BusinessLayer.Entity;

namespace YEMEKTARIFISITESI
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Kategori kategori = new Kategori(veriTabaniIslemleri);
            DataList1.DataSource = kategori.KategoriAdAdedGetir();
            DataList1.DataBind();
            veriTabaniIslemleri.BaglantiBitir();

            //SqlCommand comm = new SqlCommand("Select KategoriAd , count(*) 'KategoriAdet', kategoriler.Kategoriid 'Kategoriid'  from yemekler inner join kategoriler on yemekler.Kategoriid = kategoriler.Kategoriid where YemekOnayDurum=1 group by kategoriler.Kategoriid, kategoriler.Kategoriad ", bgl.baglan());
            //SqlDataReader read = comm.ExecuteReader();
            //DataList1.DataSource = read;
            //DataList1.DataBind();
            //bgl.baglantiKapat();
        }

        protected void Unnamed1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}




