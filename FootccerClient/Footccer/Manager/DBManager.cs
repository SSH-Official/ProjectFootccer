using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Manager
{
    public class DBManager
    {
        public PartySearchDBExecuter PartySearch { get; }

        public DBManager() {
            PartySearch = new PartySearchDBExecuter();
        }

    }
}
