using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Work_PartySearch
{
    public class CityDTO
    {
        public int Index { get; }
        public string Name { get; }

        public CityDTO(int Index, string Name)
        {
            this.Index = Index;
            this.Name = Name;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
