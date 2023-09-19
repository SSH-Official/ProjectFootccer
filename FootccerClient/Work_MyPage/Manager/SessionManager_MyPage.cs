using FootccerClient.Work_MyPage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootccerClient.Work_MyPage.Manager
{
    public class SessionManager_MyPage
    {
        public UserCredentialDTO User;


        internal void TestSetup(UserCredentialDTO user)
        {
            this.User = user;
        }

        public void LogOut()
        {
            User = new UserCredentialDTO(-1, null, null);
        }
    }
}
