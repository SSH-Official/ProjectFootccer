using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DTO
{
    public class ActivityDTO
    {
        public int Index { get; }
        public string Name { get; }
        public ActivityDTO(int index, string name)
        {
            Index = index;
            Name = name;
        }
        public override string ToString()
        {
            return $"ActivityDTO : {{ Index : {Index}, Name : {Name} }}";
        }
    }
}
