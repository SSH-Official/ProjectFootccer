using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
{
    public abstract class DAO_Base
    {
        protected object ExecuteQuery(string Query, Func<MySqlCommand, object> ResultMethod)
        {
            string strConn = App.Instance.DB.Settings.ConnectionString;
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


        protected object ExecuteTransaction(Func<MySqlCommand, object> ResultMethod)
        {
            string strConn = App.Instance.DB.Settings.ConnectionString;
            object result = null;
            MySqlConnection conn = null;
            MySqlTransaction trans = null;            

            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();
                trans = conn.BeginTransaction();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    result = ResultMethod(cmd);
                }

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
