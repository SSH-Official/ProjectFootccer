using FootccerClient.Footccer.Manager.CreateParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.Manager
{
    public class DBManager
    {
        public LHJDBManager Lhj { get;}
        public MyPageSQLMaker MyPage { get; }

        public DBManager() 
        {
            Lhj = new LHJDBManager();
            MyPage = new MyPageSQLMaker();
        }
    }
}
