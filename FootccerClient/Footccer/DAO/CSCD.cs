using FootccerClient.Footccer;
using FootccerClient.Footccer.DBExecuter;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
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
            string sql = "select p.date, p.name, l.side, r.result, p.Leader_idx, p.idx, l.idx " +
                         "from Party p " +
                         "join Record r on p.idx = r.Party_idx " +
                         "join List l on l.Party_idx = p.idx " +
                         "where l.User_idx = @User_idx and p.date < sysdate() ";              
            using (MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add(new MySqlParameter("@User_idx", MySqlDbType.Int32, 10)).Value = 2;// App.Instance.Session.User.Index;

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
        public int updateRecord(RecordDTO dto)
        {
            string sql = "update Record set result = @result, " +
                                        "score = @score, " +
                                        "alter_elo = @alter_elo " +
                                        "where Party_idx = @idx ";
            using(MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add(new MySqlParameter("@result", MySqlDbType.VarChar, 1)).Value = dto.result;
                cmd.Parameters.Add(new MySqlParameter("@score", MySqlDbType.VarChar, 50)).Value = dto.score;
                cmd.Parameters.Add(new MySqlParameter("@alter_elo", MySqlDbType.Int32, 10)).Value = dto.alter_elo;
                cmd.Parameters.Add(new MySqlParameter("@idx", MySqlDbType.Int32, 10)).Value = dto.Party_idx;
                return dao.nonSQL(cmd);
            }
        }

        public int updateElo(int Party_idx, int alter_elo, char side)
        {
            string sql = "update Party p " +
                         "join List l on p.idx = l.Party_idx " +
                         "join UserInfo u on l.User_idx = u.User_idx " +
                         "set u.elo = u.elo + @alter_elo " +
                         "where p.idx = @Party_idx and l.side = @side";
            using(MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add(new MySqlParameter("@alter_elo", MySqlDbType.Int32, 10)).Value = alter_elo;
                cmd.Parameters.Add(new MySqlParameter("@Party_idx", MySqlDbType.Int32, 10)).Value = Party_idx;
                cmd.Parameters.Add(new MySqlParameter("@side", MySqlDbType.VarChar, 1)).Value = side;
                return dao.nonSQL(cmd);
            }
        }

        public int insertStat(StatDTO dto)
        {
            string sql = "insert into Stat (List_idx, score, assist, distance, heartRate)" +
                         "values (@List_idx, @score, @assist, @distance, @heartRate)";
            using(MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add(new MySqlParameter("@List_idx", MySqlDbType.Int32, 10)).Value = dto.List_idx;
                cmd.Parameters.Add(new MySqlParameter("@score", MySqlDbType.Int32, 10)).Value = dto.score;
                cmd.Parameters.Add(new MySqlParameter("@assist", MySqlDbType.Int32, 10)).Value = dto.assist;
                cmd.Parameters.Add(new MySqlParameter("@distance", MySqlDbType.Int32, 10)).Value = dto.distance;
                cmd.Parameters.Add(new MySqlParameter("@heartRate", MySqlDbType.Int32, 10)).Value = dto.heartRate;
                return dao.nonSQL(cmd);
            }
        }

        public StatDTO getStat(int List_idx)
        {
            string sql = "select score, assist, distance, heartRate from Stat where List_idx = @List_idx ";
            
            using(MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add(new MySqlParameter("@List_idx", MySqlDbType.Int32, 10)).Value = List_idx;

                DataSet ds = dao.selectUsingAdapter(cmd);
                DataTable dt = ds.Tables[0];
                DataRow dr = null;
                if(dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    StatDTO dto = new StatDTO(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]));
                    return dto;
                }                
                else
                {
                    return null;
                }                
            }
        }

        public int updateStat(StatDTO dto)
        {
            string sql = "update Stat set score = @score, assist = @assist, distance = @distance, heartRate = @heartRate where List_idx = @List_idx ";

            using(MySqlCommand cmd = new MySqlCommand(sql))
            {
                cmd.Parameters.Add(new MySqlParameter("@score", MySqlDbType.Int32, 10)).Value = dto.score;
                cmd.Parameters.Add(new MySqlParameter("@assist", MySqlDbType.Int32, 10)).Value = dto.assist;
                cmd.Parameters.Add(new MySqlParameter("@distance", MySqlDbType.Int32, 10)).Value = dto.distance;
                cmd.Parameters.Add(new MySqlParameter("@heartRate", MySqlDbType.Int32, 10)).Value = dto.heartRate;
                cmd.Parameters.Add(new MySqlParameter("@List_idx", MySqlDbType.Int32, 10)).Value = dto.List_idx;

                return dao.nonSQL(cmd);
            }
        }
    }
}
