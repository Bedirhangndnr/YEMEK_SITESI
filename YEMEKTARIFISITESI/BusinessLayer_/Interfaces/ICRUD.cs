using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    internal interface ICRUD
    {
        void Insert();


        void Update();

        void Delete();

        SqlDataReader GetAll();
        SqlDataReader GetById();

    }
}
