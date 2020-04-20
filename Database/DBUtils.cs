using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Database
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "db4free.net";
            int port = 3306;
            string database = "langlearnerbot";
            string username = "itis11708";
            string password = "11708228";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }
}
