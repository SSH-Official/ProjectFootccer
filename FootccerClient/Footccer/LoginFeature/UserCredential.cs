using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.LoginFeature
{
    public class UserCredential
    {
        public string ID { get; }
        public string Password { get; }

        public UserCredential(string iD, string password)
        {
            ID = iD;
            Password = password;
        }
    }
}
