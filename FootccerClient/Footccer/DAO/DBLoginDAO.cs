
using FootccerClient.Footccer.DBExecuter;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace FootccerClient.Footccer.DAO
{   
    
   
    public class DBLoginDAO : DAO_Base
    {
        public string connectionstr { get { return App.Instance.DB.Settings.ConnectionString; } }


        public bool Checkjoinmember(JoinmemberInfoDTO info)
        {
            object result = ExecuteTransaction((cmd) =>
            {
                LoginDBExecuter DBE = new LoginDBExecuter(cmd);

                DBE.SetSQL_InsertTOUser(info).ExecuteNonQuery();
                int User_idx = DBE.SetSQL_ReadUserIndex(info).ReadUserIndex();
                DBE.SetSQL_InsertToUserInfo(info, User_idx).ExecuteNonQuery();

                return true;
            }) ?? false;

            return (bool)result;
           
        }

        public bool CheckLoginSuccess(UserCredentialDTO_RegisterUser info)
        {
            object result = ExecuteTransaction((cmd) =>
            {
                LoginDBExecuter DBE = new LoginDBExecuter(cmd);

                int login_status = DBE.SetSQL_CheckLoginSuccess(info).CheckLoginSuccess(info);

                return (login_status == 1);
            }) ?? false;

            return (bool)result;
        }

        public UserDTO GetUser(UserCredentialDTO_RegisterUser info)
        {
            object result = ExecuteTransaction((cmd) =>
            {
                LoginDBExecuter DBE = new LoginDBExecuter(cmd);

                return DBE.SetSQL_ReadUser(info).ReadUser();
            });

            if (result == null) throw new Exception("유저 정보 얻기에 실패했습니다..");
            return (UserDTO)result;
        }
    }

}