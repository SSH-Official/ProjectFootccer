using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Work_MyPage.DTO
{
    public class CityDTO
    {
        public int Index { get; }
        public string Name { get; }
        public CityDTO(int index, string name)
        {
            Index = index;
            Name = name;
        }
        public override string ToString()
        {
            return $"CityDTO : {{ Index : {Index}, Name : {Name} }}";
        }
    }
}
