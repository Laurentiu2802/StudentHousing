using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class Connection
    {
       private string conection = "Server=mssqlstud.fhict.local;Database=dbi478560;User Id=dbi478560;Password=1234;Encrypt=false;";

        public SqlConnection InitializeConection()
        {
            return new SqlConnection(conection);
        }
    }
}
