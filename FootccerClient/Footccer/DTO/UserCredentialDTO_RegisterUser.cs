using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class UserCredentialDTO_RegisterUser
    {
        public string ID { get; }
        public string Password { get; }

        public UserCredentialDTO_RegisterUser(string iD, string password)
        {
            ID = iD;
            Password = password;
        }
    }
}
