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
            string sql = "select p.date, p.name, l.side, r.result, p.Leader_idx, p.idx " +
                         "from List l " +
                         "join Party p on p.idx = l.Party_idx " +
                         "join Record r on l.idx = r.List_idx " +
                         "where l.User_idx = @User_idx and p.date < Sysdate() ";
            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add(new MySqlParameter("@User_idx", MySqlDbType.Int32, 10)).Value = 2;//App.Instance.Session.User.Index;

                DataSet ds = dao.selectUsingAdapter(cmd);
                DataTable dt = ds.Tables[0];
                return dt;
            }
        }

        public CalculateEloDTO getPartyAverageELO(int idx)
        {
            string sql = "select avg(u.elo), l.side " +
                         "from List l " +
                         "join UserInfo u on u.User_idx = l.User_idx " +
                         "where l.Party_idx = @idx " +
                         "group by l.side";
            using(MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add(new MySqlParameter("@idx", MySqlDbType.Int32, 10)).Value = idx;

                DataSet ds = dao.selectUsingAdapter(cmd);
                DataTable dt = ds.Tables[0];
                DataRow drA = dt.Rows[0];
                DataRow drB = dt.Rows[1];
                CalculateEloDTO dto = new CalculateEloDTO(Convert.ToInt32(drA[0]), Convert.ToInt32(drB[0]));
                return dto;
            }
        }
    }
}
