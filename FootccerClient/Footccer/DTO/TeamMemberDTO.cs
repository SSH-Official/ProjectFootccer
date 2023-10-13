using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class TeamMemberDTO
    {
        private string nickname { get; }
        private int idx { get; }
        public string UserWithTag { get { return $"{this.nickname}#{this.idx}"; } }
        public string gender { get; }
        public string contact { get; }
        public string email { get; }
        public string position { get; }

        public TeamMemberDTO(string nickname,int idx,string gender,string contact,string email,string position)
        {
            this.nickname = nickname;
            this.idx = idx;
            this.gender = gender;
            this.contact = contact;
            this.email = email;
            this.position = position;
        }
    }
}
