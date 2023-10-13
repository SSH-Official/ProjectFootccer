using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class UserDTO
    {
        public int Index { get; set; }
        public string ID { get; set; }

        public UserDTO(int index, string iD)
        {
            this.Index = index;
            this.ID = iD;
        }
        public override string ToString()
        {
            return $"User : {{ {Index}, {ID} }}";
        }
    }
}
