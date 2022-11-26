using BusinessLayer.Interfaces;
using BusinessLayer.Work;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class OrtakDegiskenler
    {
        public SqlCommand sqlCommand;
        public OrtakDegiskenler()
        {
            this.sqlCommand.CommandType = CommandType.StoredProcedure;
        }
    }
}
