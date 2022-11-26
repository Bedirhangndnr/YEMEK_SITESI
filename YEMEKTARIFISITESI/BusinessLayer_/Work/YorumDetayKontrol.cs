using BusinessLayer.Work;
using BusinessLayer_.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_.Work
{
    public class YorumDetayKontrol
    {
        public bool YorumOnayliMi(int id)
        {
            VeriTabaniIslemleri veriTabaniIslemleri = new VeriTabaniIslemleri();
            veriTabaniIslemleri.BaglantiBaslat();
            Yorum yorum = new Yorum(veriTabaniIslemleri);
            yorum.YorumId = id;
            DataTable dt= yorum.SatirGetir();
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToBoolean(dr["YorumOnay"]) == false)
                    return false;
            }
            return true;
        }
    }
}
