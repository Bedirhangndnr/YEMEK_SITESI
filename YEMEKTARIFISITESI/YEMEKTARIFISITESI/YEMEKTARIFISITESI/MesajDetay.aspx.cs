using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YEMEKTARIFISITESI
{
    public partial class MesajDetay : System.Web.UI.Page
    {
        sqlsinif conn = new sqlsinif();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["Mesajid"]);
            SqlCommand comm = new SqlCommand("select * from Tbl_Mesajlar where Mesajid=@p1", conn.baglan());
            comm.Parameters.AddWithValue("@p1", id);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                lbl_MesajGonderen.Text = dr[1].ToString();
                Lbl_MesajBaslik.Text = dr[2].ToString();
                lbl_MesajAdres.Text = dr[3].ToString();
                lbl_MesajIcerik.Text = dr[4].ToString();
            }
            conn.baglantiKapat();
        }
    }
}