using FootccerClient.Footccer.DBExecuter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Manager
{
    public class DBManager
    {
        public CreatePartyDBExecuter CreateParty { get; }
        public MyPage_DAO MyPage { get; }
        public PartySearchDBExecuter PartySearch { get; }

        public DBManager() 
        {
            CreateParty = new CreatePartyDBExecuter();
            MyPage = new MyPage_DAO();
            PartySearch = new PartySearchDBExecuter();
        }
    }
}
