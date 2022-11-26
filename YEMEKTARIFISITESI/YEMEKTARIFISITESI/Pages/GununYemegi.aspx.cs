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
    public partial class GununYemegi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yemek yemek= new Yemek(veriTabaniIslemleri);
            DataList3.DataSource = yemek.GununYemegiGetir();
            DataList3.DataBind();
            veriTabaniIslemleri.BaglantiBitir();


            //SqlCommand comm = new SqlCommand("select * From tbl_Yemekler where DurumGununYemegi=1", conn.baglan());

            //SqlDataReader read = comm.ExecuteReader();
            //DataList3.DataSource = read;
            //DataList3.DataBind();
            //conn.baglantiKapat();
        }

        protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}