using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLayer.Work;
using BusinessLayer_.Entity;
using System.Data;

namespace YEMEKTARIFISITESI
{
    public partial class Mesajlar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Mesaj mesaj= new Mesaj(veriTabaniIslemleri);
            DataTable dt = mesaj.TumunuGetir();
            DataList1.DataSource = dt;
            DataList1.DataBind();
            veriTabaniIslemleri.BaglantiBitir();
            //SqlCommand comm = new SqlCommand("select * from mesajlar", conn.baglan());
            //SqlDataReader dr = comm.ExecuteReader();
            //DataList1.DataSource = dr;
            //DataList1.DataBind();
            //conn.baglantiKapat();
        }


    }
}