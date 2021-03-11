using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AccountingLiabilities.Utilities
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"LUANVD";

            string database = "LUANVD";
            string username = "LUANVD";
            string password = "";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
