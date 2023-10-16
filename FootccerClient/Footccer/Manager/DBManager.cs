using FootccerClient.Footccer.DAO;
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

        public CreateParty_DAO CreateParty { get; }
        public MyPage_DAO MyPage { get; }
        public PartySearch_DAO PartySearch { get; }
        public DBLogin_DAO Login { get; }

        public Position_DAO Position { get; }
        public LHJDB_DAO LHJDB { get; }
        public TeamDAO Team { get; }

        public PartyJoinDAO PartyJoin { get; }
        public MyParty_DAO MyParty { get; internal set; }

        public PersonalStat_DAO personalstat{get;}

        public DBManager()
        {
            Settings = DBSettings.KB_Default;

            CreateParty = new CreateParty_DAO();
            MyPage = new MyPage_DAO();
            PartySearch = new PartySearch_DAO();
            Login = new DBLogin_DAO();
            Position = new Position_DAO();
            LHJDB = new LHJDB_DAO();
            Team = new TeamDAO();
            PartyJoin = new PartyJoinDAO();
            MyParty = new MyParty_DAO();
            personalstat = new PersonalStat_DAO();
        }


        



        

        
    }
}
