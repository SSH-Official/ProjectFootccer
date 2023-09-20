using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Work_PartySearch
{
    public class ActivityDTO
    {
        public int Index { get; }
        public string Name { get; }

        public ActivityDTO(int Index, string Name)
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
