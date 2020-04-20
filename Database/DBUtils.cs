using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageBot.Database
{
    class DBUtils
    {
        public static NpgsqlConnection GetDBConnection()
        {

            const string herokuConnectionString = @"
                Host=ec2-54-228-250-82.eu-west-1.compute.amazonaws.com;
                Port=5432;
                Username=nsnsfxfisolalx;
                Password=424b43100451c212c103c3ce5d6b088c9a9b7aa032df6c009f66c52f100782f7;
                Database=d53shlohdkblvr;
                Pooling=true;
                SSL Mode=Require;
                TrustServerCertificate=True;
                ";

            return DBPGSQLUtils.GetDBConnection(herokuConnectionString);
        }

    }
}
