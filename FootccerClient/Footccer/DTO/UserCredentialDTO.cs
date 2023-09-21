using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class UserCredentialDTO
    {
        public int Index { get; }
        public string ID { get; }
        public string Name { get; }

        public UserCredentialDTO(int index, string iD, string name)
        {
            this.Index = index;
            this.ID = iD;
            this.Name = name;
        }
        public override string ToString()
        {
            return $"User : {{ {Index}, {ID}, {Name} }}";
        }
    }
}
