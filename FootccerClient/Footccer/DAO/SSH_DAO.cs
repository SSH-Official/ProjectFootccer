using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
{
    public class SSH_DAO
    {
        static string DefaultServer = "192.168.0.18";
        static string DefaultDatabase = "Footccer";
        static string DefaultUid = "Footccer";
        static string DefaultPwd = "1234";
        static int DefaultPort = 3306;
        public static string DefaultConnectionString
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

        /// <summary>
        /// 내부에서 새로 호출한 아이들은 꼭 리소스 반환해주세요...
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="ResultMethod"></param>
        /// <returns></returns>
        protected object ExecuteQuery(string Query, Func<MySqlCommand, object> ResultMethod)
        {
            string strConn = DefaultConnectionString;
            object theResult = null;
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(Query, conn);

                theResult = ResultMethod(cmd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (conn != null) { conn.Close(); }
            }

            return theResult;
        }

        /// <summary>
        /// 내부에서 새로 호출한 아이들은 꼭 리소스 반환해주세요...
        /// </summary>
        /// <param name="ResultMethod"></param>
        /// <returns></returns>
        protected object ExecuteTransaction(Func<MySqlCommand, object> ResultMethod)
        {
            string strConn = DefaultConnectionString;
            object result = null;
            MySqlConnection conn = null;
            MySqlTransaction trans = null;            

            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();
                trans = conn.BeginTransaction();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = trans;
                
                result = ResultMethod(cmd);

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) { trans.Rollback(); }
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (conn != null) { conn.Close(); }
            }


            return result;
        }

    }
}
