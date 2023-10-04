using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace FootccerClient.Footccer.DAO
{
    internal class PartyJoinDAO
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        private MySqlDataAdapter dataAdapter;
        string strConnection = "Server=192.168.0.18;Database=Footccer;Uid=root;Pwd=1234;Port=3306";

        public int nonSQL(string sql)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public MySqlDataReader selectUsingReader(string sql)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                using (cmd = new MySqlCommand(sql, conn))
                {
                    reader = cmd.ExecuteReader();
                    return reader;
                }
            }
        }
        public DataSet selectUsingAdapter(string sql)
        {
            DataSet ds = new DataSet();
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                dataAdapter = new MySqlDataAdapter(sql, conn);
                dataAdapter.Fill(ds);
                return ds;
            }
        }

        public List<string> selectPosition(int positionIndex)
        {
            using (conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                string sql = $"select position from Position p where p.Position_idx = @positionIndex";
                List<string> list = new List<string>();
                using (cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new MySqlParameter("@positionIndex", MySqlDbType.Int32, 10)).Value = positionIndex;
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString("position"));
                        }
                        return list;
                    }
                }
            }
        }
    }
}
