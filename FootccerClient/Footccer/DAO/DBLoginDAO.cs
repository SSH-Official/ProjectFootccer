
using FootccerClient.Footccer.DAO.CRUD;
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
            bool result = ExecuteTransaction((cmd) =>
            {
                LoginCRUD CRUD = new LoginCRUD(cmd);

                CRUD.CreateUser(info);
                CRUD.CreateUserInfo(info);

                return true;
            });

            

            return (bool)result;
           
        }

        public bool CheckLoginSuccess(UserCredentialDTO_RegisterUser info)
        {
            return ExecuteTransaction<bool>((cmd) =>
            {
                LoginCRUD DBE = new LoginCRUD(cmd);

                int login_status = DBE.CheckLoginSuccess(info);

                return (login_status == 1);
            });
        }

        public UserDTO GetUser(UserCredentialDTO_RegisterUser info)
        {
            UserDTO result = ExecuteTransaction((cmd) =>
            {
                LoginCRUD DBE = new LoginCRUD(cmd);
                return DBE.ReadUser(info);
            });

            if (result == null) throw new Exception("유저 정보 얻기에 실패했습니다..");
            return result;
        }
    }

}