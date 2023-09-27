using MySqlConnector;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System;
using FootccerClient.Footccer.DTO;
using FootccerClient.Footccer.DAO;
using System.Collections;
using System.Windows.Forms;
using FootccerClient.Footccer.DTO.Builder;
using System.Drawing;

namespace FootccerClient.Footccer.DBExecuter
{
    public partial class MyPage_DAO : DAO_Base
    {
        public UserInfoDTO ReadUserInfoAsSession()
        {
            return ReadUserInfo(App.Instance.Session.ID);
        }

        public UserInfoDTO ReadUserInfo(string UID)
        {
            return ExecuteTransaction((cmd) =>
            {
                return new MyPageDBExecuter(cmd)
                    .SetSQL_ReadUserInfo(UID)
                    .ReadUserInfo();
            }) as UserInfoDTO;
        }


        public bool UpdateUserInfo(UserInfoDTO userinfo)
        {
            object result = ExecuteTransaction((cmd) =>
            {
                cmd.CommandText = "UPDATE ... ";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();

                return true;
            });

            return (result != null) && (bool)result;
        }


        public bool UpdateUserPassword(UserDTO user, string oldPwd, string newPwd)
        {
            object result = ExecuteTransaction((cmd) =>
            {
                bool isCorrectPassword = 
                    new MyPageDBExecuter(cmd)
                    .SetSQL_CheckPassword(user,oldPwd)
                    .CheckPassword();

                if (isCorrectPassword == false) { throw new Exception("기존 비밀번호가 틀립니다."); }
                else
                {
                    return new MyPageDBExecuter(cmd)
                        .SetSQL_UpdatePassword(user, newPwd)
                        .ExecuteNonQuery();
                }
            });

            // 실행된 NonQuery가 양수임 -> 제대로 SQL이 실행되었음.
            return (result != null) && ( (int)result > 0 ); 
            
        }
    }
}





