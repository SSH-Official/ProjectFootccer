
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
        public UserDTO User;


        internal void TestSetup(UserDTO user)
        {
            this.User = user;
        }

        public void LogOut()
        {
            User = new UserDTO(-1, null);
        }
    }
}
