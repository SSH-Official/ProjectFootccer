using System.Collections.Specialized;

namespace FootccerClient.Footccer.LoginFeature
{
    public class JoinmemberInfo
    {
        public string Name { get; }
        
        public string Gender { get; }

        public string Email { get; }

        
        public string Id { get;}
        public string Password { get; }

        public string Birthday { get;}

        public string Nickname { get;}

        public string Phone { get;}


        public JoinmemberInfo(string name, string gender, string email,string id, string password, string birthday, string nickname, string phone)
        {   
            Name = name;
            Gender = gender;
            Email = email;
            Id = id;
            Password = password;
            Birthday = birthday;
            Nickname = nickname;
            Phone = phone;
        }
    }
}