using FootccerClient.Footccer;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Work_ELO.DB
{
    public class CSCD
    {
        private LHJDBExecuter dao { get; }

        public CSCD()
        {
            dao = new LHJDBExecuter();
        }

        //(수정)session index로 검색해야 합니다.
        public DataTable getRecordTable()
        {            
            string sql = "select p.date, p.name, l.side, r.result, p.Leader_idx " +
                         "from List l " +
                         "join Party p on p.idx = l.Party_idx " +
                         "join Record r on l.idx = r.List_idx " +
                         "where l.User_idx = @User_idx ";
            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add(new MySqlParameter("@User_idx", MySqlDbType.Int32, 10)).Value = 2;//App.Instance.Session.User.Index;

                DataSet ds = dao.selectUsingAdapter(cmd);
                DataTable dt = ds.Tables[0];
                return dt;
            }            
        }
    }
}
