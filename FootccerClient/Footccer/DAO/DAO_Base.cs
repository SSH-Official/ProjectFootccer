using FootccerClient.Footccer.DBExecuter;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
{
    /// <summary>
    /// DB에 대한 연결을 얻어온 후, 
    /// 단일 쿼리문 또는 트랜잭션을 실행하고
    /// 해당하는 결과값을 반환합니다.<br/>
    /// 도중에 예외가 발생하면 Message와 StackTrace를 콘솔에 입력하고 연결을 닫습니다.
    /// </summary>
    public abstract class DAO_Base
    {
        /// <summary>
        /// DB에 연결을 얻어 즉시 ResultMethod를 실행합니다.<br/>
        /// ResultMethod 내의 쿼리문이 실제로 즉시 실행되므로 주의해주세요. <br/>
        /// 도중에 예외가 발생하면 Message와 StackTrace를 콘솔에 입력하고 연결을 닫습니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ResultMethod"></param>
        /// <returns>
        /// 성공 : 입력받은 ResultMethod의 반환값이 반환됩니다. <br/>
        /// 실패 : 참조 형식일 경우 null, 값 형식일 경우 기본값이 반환됩니다. (int : 0, bool : false 등..)
        /// </returns>
        protected T ExecuteQuery<T>(string Query, Func<MySqlCommand, T> ResultMethod)
        {
            string strConn = App.Instance.DB.Settings.ConnectionString;
            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(Query, conn);

                return ResultMethod(cmd);
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

            return default;
        }


        /// <summary>
        /// DB에 연결을 얻어 트랜잭션을 열고, ResultMethod를 실행합니다.<br/>
        /// 도중에 예외가 발생하면 트랜잭션을 롤백하고, Message와 StackTrace를 콘솔에 입력하고 연결을 닫습니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ResultMethod"></param>
        /// <returns>
        /// 성공 : 입력받은 ResultMethod의 반환값이 반환됩니다. <br/>
        /// 실패 : 참조 형식일 경우 null, 값 형식일 경우 기본값이 반환됩니다. (int : 0, bool : false 등..)
        /// </returns>
        protected T ExecuteTransaction<T>(Func<MySqlCommand, T> ResultMethod)
        {
            string strConn = App.Instance.DB.Settings.ConnectionString;
            T result = default;
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
