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
        public CreateParty_DAO CreateParty { get; } = new CreateParty_DAO();
        public MyPage_DAO MyPage { get; } = new MyPage_DAO();
        public PartySearch_DAO PartySearch { get; } = new PartySearch_DAO();
        public DBLogin_DAO Login { get; } = new DBLogin_DAO();
        public Position_DAO Position { get; } = new Position_DAO();
        public LHJDB_DAO LHJDB { get; } = new LHJDB_DAO();
        public TeamDAO Team { get; } = new TeamDAO();
        public PartyJoinDAO PartyJoin { get; } = new PartyJoinDAO();
        public MyParty_DAO MyParty { get; } = new MyParty_DAO();
        public PersonalStat_DAO personalstat { get; } = new PersonalStat_DAO();
        public Session_DAO Session { get; } = new Session_DAO();


        public DBManager()
        {
            Settings = DBSettings.KB_Default;
        }


        



        

        
    }
}
