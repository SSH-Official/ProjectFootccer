using FootccerClient.Footccer.DAO.Base;
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
    partial class LHJDB_DAO
    {
        class CRUD : CRUD_Base
        {

            public CalculateEloDTO getPartyAverageELO(int idx)
            {
                string sql = "select avg(u.elo), l.side " +
                             "from List l " +
                             "join UserInfo u on u.User_idx = l.User_idx " +
                             "where l.Party_idx = @idx " +
                             "group by l.side";

                MySqlCommand cmd = this.cmd;
                cmd.CommandText = sql;
                cmd.Parameters.Add(new MySqlParameter("@idx", MySqlDbType.Int32, 10)).Value = idx;

                DataTable dt = ReadDataTable(cmd);
                DataRow drA = dt.Rows[0];
                DataRow drB = dt.Rows[1];
                CalculateEloDTO dto = new CalculateEloDTO(Convert.ToInt32(drA[0]), Convert.ToInt32(drB[0]));

                return dto;
            }

            //(수정)session index로 검색해야 합니다.
            public DataTable getRecordTable()
            {
                int testidx = 2; // App.Instance.Session.User.Index;

                string sql = "select p.date, p.name, l.side, r.result, p.Leader_idx, p.idx, l.idx " +
                             "from Party p " +
                             "join Record r on p.idx = r.Party_idx " +
                             "join List l on l.Party_idx = p.idx " +
                             "where l.User_idx = @User_idx and p.date < sysdate() ";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new MySqlParameter("@User_idx", MySqlDbType.Int32, 10)).Value = testidx;

                return ReadDataTable(cmd);
            }

            public int updateRecord(RecordDTO dto)
            {
                string sql = "update Record set result = @result, " +
                            "score = @score, " +
                            "alter_elo = @alter_elo " +
                            "where Party_idx = @idx ";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new MySqlParameter("@result", MySqlDbType.VarChar, 1)).Value = dto.result;
                cmd.Parameters.Add(new MySqlParameter("@score", MySqlDbType.VarChar, 50)).Value = dto.score;
                cmd.Parameters.Add(new MySqlParameter("@alter_elo", MySqlDbType.Int32, 10)).Value = dto.alter_elo;
                cmd.Parameters.Add(new MySqlParameter("@idx", MySqlDbType.Int32, 10)).Value = dto.Party_idx;

                return cmd.ExecuteNonQuery();
            }

            public int updateElo(int party_idx, int alter_elo, char side)
            {
                string sql = "update Party p " +
                             "join List l on p.idx = l.Party_idx " +
                             "join UserInfo u on l.User_idx = u.User_idx " +
                             "set u.elo = u.elo + @alter_elo " +
                             "where p.idx = @Party_idx and l.side = @side";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new MySqlParameter("@alter_elo", MySqlDbType.Int32, 10)).Value = alter_elo;
                cmd.Parameters.Add(new MySqlParameter("@Party_idx", MySqlDbType.Int32, 10)).Value = party_idx;
                cmd.Parameters.Add(new MySqlParameter("@side", MySqlDbType.VarChar, 1)).Value = side;

                return cmd.ExecuteNonQuery();
            }

            public int insertStat(StatDTO dto)
            {
                string sql = "insert into Stat (List_idx, score, assist, distance, heartRate)" +
                             "values (@List_idx, @score, @assist, @distance, @heartRate)";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new MySqlParameter("@List_idx", MySqlDbType.Int32, 10)).Value = dto.List_idx;
                cmd.Parameters.Add(new MySqlParameter("@score", MySqlDbType.Int32, 10)).Value = dto.score;
                cmd.Parameters.Add(new MySqlParameter("@assist", MySqlDbType.Int32, 10)).Value = dto.assist;
                cmd.Parameters.Add(new MySqlParameter("@distance", MySqlDbType.Int32, 10)).Value = dto.distance;
                cmd.Parameters.Add(new MySqlParameter("@heartRate", MySqlDbType.Int32, 10)).Value = dto.heartRate;

                return cmd.ExecuteNonQuery();
            }

            public StatDTO getStat(int list_idx)
            {
                string sql = "select score, assist, distance, heartRate from Stat where List_idx = @List_idx ";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new MySqlParameter("@List_idx", MySqlDbType.Int32, 10)).Value = list_idx;

                DataTable dt = ReadDataTable(cmd);

                DataRow dr;
                if (dt.Rows.Count > 0)
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

            public int updateStat(StatDTO dto)
            {

                string sql = "update Stat set score = @score, assist = @assist, distance = @distance, heartRate = @heartRate where List_idx = @List_idx ";

                cmd.CommandText = sql;
                cmd.Parameters.Add(new MySqlParameter("@score", MySqlDbType.Int32, 10)).Value = dto.score;
                cmd.Parameters.Add(new MySqlParameter("@assist", MySqlDbType.Int32, 10)).Value = dto.assist;
                cmd.Parameters.Add(new MySqlParameter("@distance", MySqlDbType.Int32, 10)).Value = dto.distance;
                cmd.Parameters.Add(new MySqlParameter("@heartRate", MySqlDbType.Int32, 10)).Value = dto.heartRate;
                cmd.Parameters.Add(new MySqlParameter("@List_idx", MySqlDbType.Int32, 10)).Value = dto.List_idx;

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
