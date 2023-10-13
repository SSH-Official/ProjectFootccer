using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
//using MySql.Data.MySqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
{
    partial class PersonalStat_DAO
    {
        class CRUD : CRUD_Base
        {
           public PersonalStatDTO Getactstat(int idx)
            {
                string sql = "SELECT COUNT(*), sum(case l.idx when l.side = r.result then 1 ELSE null END) AS result, " +
                       "AVG(s.score), AVG(s.assist), AVG(s.distance), " +
                       "MAX(s.score), MAX(s.assist), MAX(s.distance) FROM List l " +
                       "JOIN Party p ON l.Party_idx = p.idx " +
                       "join Record r ON r.Party_idx = p.idx " +
                       "LEFT JOIN Stat s ON s.List_idx = l.idx " +
                       "WHERE l.User_idx = @User_idx ";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new MySqlParameter("@User_idx", MySqlDbType.Int32, 10)).Value = idx;

                DataTable dt = ReadDataTable(cmd);

                DataRow dr;
                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    try 
                    {
                        PersonalStatDTO dto = new PersonalStatDTO(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToDouble(dr[3]), Convert.ToDouble(dr[4]), Convert.ToInt32(dr[5]), Convert.ToInt32(dr[6]), Convert.ToInt32(dr[7]));
                        return dto;
                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
                    
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

   
