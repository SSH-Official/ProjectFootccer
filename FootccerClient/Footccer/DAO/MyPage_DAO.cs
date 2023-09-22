using MySqlConnector;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System;
using FootccerClient.Footccer.DTO;
using FootccerClient.Footccer.DAO;
using System.Collections;
using System.Windows.Forms;

namespace FootccerClient.Footccer.DBExecuter
{
    public class MyPage_DAO : SSH_DAO
    {
        public UserInfoDTO GetUserInfoAsSession()
        {
            return GetUserInfo(App.Instance.Session.User);
        }


        private UserInfoDTO GetUserInfo_ForExample(UserDTO user)
        {
            // 세부 내용을 실행해줄 클래스 호출
            MyPageDBExecuter DBE = new MyPageDBExecuter();

            // DB 접근 - 데이터 반환을 위한 객체들 선언
            string strConn = DefaultConnectionString;
            UserInfoDTO theResult = null;
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader rdr = null;

            // DB 접속 - 데이터 반환을 위한 try - catch 문 
            try
            {
                conn = new MySqlConnection(strConn);
                conn.Open();

                string query = string.Format(DBE.GetSQLFormat_ForUserInfo(), user.ID);
                cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();

                theResult = DBE.ParseToUserInfo(rdr);
                // 또는 직접 필요한 파싱 방법을 사용
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


        private UserInfoDTO GetUserInfo(UserDTO user)
        {
            MyPageDBExecuter DBE = new MyPageDBExecuter();
            string query = string.Format(DBE.GetSQLFormat_ForUserInfo(), user.ID);
            Func<MySqlDataReader, object> method = DBE.ParseToUserInfo_UsingBuilder;            
            return ExecuteQuery(query, method) as UserInfoDTO;
        }

        
    }
}





