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

        public UserInfoDTO GetUserInfo(UserDTO user)
        {
            MyPageDBExecuter DBE = new MyPageDBExecuter();

            return ExecuteTransaction((cmd) =>
            {
                cmd.CommandText = DBE.GetSQL_SelectUserInfo_ForUser(user);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    return DBE.ParseToUserInfo(rdr);
                }
            }) as UserInfoDTO;
        }

        
    }
}





