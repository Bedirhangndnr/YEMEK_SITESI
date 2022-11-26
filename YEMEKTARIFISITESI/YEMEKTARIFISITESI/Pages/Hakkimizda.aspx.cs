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
    public partial class Hakkimizda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            if (Page.IsPostBack==false)
            {


                VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
                veriTabaniIslemleri.BaglantiBaslat();
                HakkimizdaEntity hakkimizda= new HakkimizdaEntity(veriTabaniIslemleri);
                DataTable dt = hakkimizda.TumunuGetir();
                foreach (DataRow r in dt.Rows)
                {
                    lbl_Hakkimizda.Text = r["Metin"].ToString();
                }
                veriTabaniIslemleri.BaglantiBitir();
            }

        }

    }
}