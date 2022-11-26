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
    public partial class HakkimizdaAdmin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
                veriTabaniIslemleri.BaglantiBaslat();
                HakkimizdaEntity hakkimizda = new HakkimizdaEntity(veriTabaniIslemleri);
                DataTable dt = hakkimizda.TumunuGetir();
                foreach (DataRow dr in dt.Rows)
                {
                    txtbx_Hakkimizda.Text = dr[0].ToString();
                }
                veriTabaniIslemleri.BaglantiBitir();
                //SqlCommand comm = new SqlCommand("select * from hakkimizda", conn.baglan());
                //SqlDataReader dr = comm.ExecuteReader();
                //while (dr.Read())
                //{
                //    txtbx_Hakkimizda.Text = dr[0].ToString();
                //}
                //conn.baglantiKapat();
            }
        }

        protected void btn_Guncelle_Click(object sender, EventArgs e)
        {

            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            HakkimizdaEntity hakkimizda = new HakkimizdaEntity(veriTabaniIslemleri);
            hakkimizda.Metin = txtbx_Hakkimizda.Text;
            hakkimizda.Update();
            veriTabaniIslemleri.BaglantiBitir();

            //SqlCommand comm = new SqlCommand("update Tbl_Hakkimizda set metin=@p1", conn.baglan());
            //comm.Parameters.AddWithValue("@p1", txtbx_Hakkimizda.Text);
            //comm.ExecuteNonQuery();
            //conn.baglantiKapat();
            lbl_IsSucess.Visible = true;
            lbl_IsSucess.Text = "Güncelleme Başarılı";
            lbl_IsSucess.ForeColor = System.Drawing.Color.Green;

        }



    }
}
