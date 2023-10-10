
using FootccerClient.Footccer.DAO.Base;
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
    
   
    public partial class DBLogin_DAO : DAO_Base
    {
        public bool Checkjoinmember(JoinmemberInfoDTO info) => ExecuteTransaction(new CRUD(), (CRUD) =>
        {
            CRUD.CreateUser(info);
            CRUD.CreateUserInfo(info);

            return true;
        });
        public bool CheckLoginSuccess(UserCredentialDTO_RegisterUser info) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.CheckLoginSuccess(info));
        public UserDTO GetUser(UserCredentialDTO_RegisterUser info) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.ReadUser(info) ?? throw new Exception("유저 정보 얻기에 실패했습니다.."));

        
    }

    

}