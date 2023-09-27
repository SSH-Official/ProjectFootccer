using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Work_ELO.DB
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
        public int transactionUpdateElo(List<int> idx, int alter_elo)
        {
            using(conn = new MySqlConnection(strConnection))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (int i in idx)
                        {
                            string eloSql = "update UserInfo set elo = @alter_elo where User_idx = @idx ";

                            using(MySqlCommand cmd = new MySqlCommand(eloSql, conn, transaction)) 
                            {
                                cmd.Parameters.Add(new MySqlParameter("@alter_elo", MySqlDbType.Int32, 10)).Value = alter_elo;
                                cmd.Parameters.Add(new MySqlParameter("@idx", MySqlDbType.Int32, 10)).Value = i;

                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();                        
                        Console.WriteLine(ex.ToString());
                        return -1;
                    }
                }
            }
        }
    }
}
