using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DBExecuter
{
    public class LHJDBExecuter
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataAdapter dataAdapter;
        string strConnection = "Server=192.168.0.18;Database=Footccer;Uid=root;Pwd=1234;Port=3306";


        public int nonSQL(MySqlCommand mySqlCommand)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                using (cmd = mySqlCommand)
                {
                    cmd.Connection = conn;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public DataSet selectUsingAdapter(MySqlCommand mySqlCommand)
        {
            DataSet ds = new DataSet();
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                using(cmd = mySqlCommand)
                {
                    cmd.Connection = conn;
                    using(dataAdapter = new MySqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(ds);
                        return ds;
                    }
                }
            }
        }
    }
}
