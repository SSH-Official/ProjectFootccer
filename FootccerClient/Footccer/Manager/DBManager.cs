using FootccerClient.Footccer.DBExecuter;
using FootccerClient.Work_ELO.DB;
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
        public MyPageDBExecuter MyPage { get; }
        public PartySearchDBExecuter PartySearch { get; }
        public CSCD LHJDB { get; }

        public DBManager() 
        {
            CreateParty = new CreatePartyDBExecuter();
            MyPage = new MyPageDBExecuter();
            PartySearch = new PartySearchDBExecuter();
            LHJDB = new CSCD();
        }
    }
}
