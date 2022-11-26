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
    public partial class MesajDetay : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Convert.ToInt32(Request.QueryString["Mesajid"]);
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Mesaj mesaj = new Mesaj(veriTabaniIslemleri);
            mesaj.MesajId= id;
            DataTable dr = mesaj.SatirGetir();


            //SqlCommand comm = new SqlCommand("select * from Tbl_Mesajlar where Mesajid=@p1", conn.baglan());
            //comm.Parameters.AddWithValue("@p1", id);
            //SqlDataReader dr = comm.ExecuteReader();
            foreach ( DataRow r in dr.Rows)
            {
                lbl_MesajGonderen.Text = r["MesajGonderen"].ToString();
                Lbl_MesajBaslik.Text = r["MesajBaslik"].ToString();
                lbl_MesajAdres.Text = r["MesajMail"].ToString();
                lbl_MesajIcerik.Text = r["MesajIcerik"].ToString();
            }
            veriTabaniIslemleri.BaglantiBitir();
        }
    }
}