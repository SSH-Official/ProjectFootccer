using MySqlConnector;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System;

namespace FootccerClient.Footccer.Manager
{
    public class SSHDBManager
    {
        static string DefaultServer = "localhost";
        static string DefaultDatabase = "Footccer";
        static string DefaultUid = "root";
        static string DefaultPwd = "1234";
        static int DefaultPort = 3306;
        static string DefaultConnectionString
        {
            get
            {
                return
                    $"Server={DefaultServer};" +
                    $"Database={DefaultDatabase};" +
                    $"Uid={DefaultUid};" +
                    $"Pwd={DefaultPwd};" +
                    $"Port={DefaultPort}";
            }
        }

        protected object ExecuteQuery(string Query, Func<MySqlDataReader, object> ParseMethod)
        {
            string strConn = DefaultConnectionString;
            object theResult = null;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;

            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();
                
                cmd = new MySqlCommand(Query, conn);
                
                rdr = cmd.ExecuteReader();

                theResult = ParseMethod(rdr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (rdr != null) { rdr.Close(); }
                if (cmd != null) { cmd.Dispose(); }
                if (conn != null) { conn.Close(); }
            }


            return theResult;
        }
    }
}





