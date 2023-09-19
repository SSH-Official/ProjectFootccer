using FootccerClient.Work_MyPage.DTO;
using System;
using System.Collections.Generic;

namespace FootccerClient.Footccer.Manager
{
    public class MyPageSQLMaker : SSHDBManager
    {
        public object GetUserInfo(UserCredentialDTO Credential)
        {
            object result = null;
            string sql = "";
            result = ExecuteQuery(sql, (rdr) =>
            {
                List<UserInfoDTO> _list = new List<UserInfoDTO>();

                //User_idx
                //gender
                //contact
                //email
                //prefer_City_idx
                //prefer_Activity_idx
                //Image_idx
                //birth

                while(rdr.Read())
                {
                    UserInfoDTO userInfo = new UserInfoDTO(1,null,null,null,null,null,1,null,1,null,null);
                    _list.Add(userInfo);
                }
                // TODO
                return _list[0];
                
            }) as UserInfoDTO;
            return result;
        }

        internal UserInfoDTO GetUserInfoAsSession()
        {
            throw new NotImplementedException();
        }
    }
}