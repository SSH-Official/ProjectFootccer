using FootccerClient.Footccer.DAO;
using FootccerClient.Footccer.DBExecuter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Manager
{
    public class DBManager
    {
        public DBSettings Settings { get; }
        public CreatePartyDBExecuter CreateParty { get; }
        public MyPage_DAO MyPage { get; }
        public PartySearch_DAO PartySearch { get; }
        public DBLoginDAO Login { get; }

        public PositionDBExecuter Position { get; }
        public CSCD LHJDB { get; }

        public DBManager()
        {
            Settings = DBSettings.KB_Default;

            CreateParty = new CreatePartyDBExecuter();
            MyPage = new MyPage_DAO();
            PartySearch = new PartySearch_DAO();
            Login = new DBLoginDAO();
            Position = new PositionDBExecuter();
            LHJDB = new CSCD();            
        }


        



        

        
    }
}
