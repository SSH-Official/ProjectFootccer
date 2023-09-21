
using FootccerClient.Footccer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootccerClient.Footccer.Manager
{
    public class SessionManager
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
