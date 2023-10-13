using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FootccerClient.Footccer.DAO.CRUD
{
    public class PartyJoinCRUD : CRUD_Base
    {
        public PartyJoinCRUD(MySqlCommand cmd) : base(cmd)
        {
        }
        public List<TeamDTO> ReadTeamMember(int Pidx,char Team)
        {
            string sql = "SELECT L.User_idx AS idx, Ui.name AS username, side, Ui.elo as elo,L.position as formation FROM `List` AS L " +
                         "LEFT JOIN `UserInfo` AS Ui ON L.User_idx = Ui.User_idx " +
                         "WHERE Party_idx = @Pidx AND side = @Team" +
                         " GROUP BY L.idx, Ui.name, side, Ui.elo ";
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Pidx", MySqlDbType.VarChar, 50).Value = Pidx;
            cmd.Parameters.Add("@Team", MySqlDbType.VarChar, 50).Value = Team;
            return ReadDataList((rdr) =>
            {
                int idx = Convert.ToInt32(rdr["idx"]);
                string username = Convert.ToString(rdr["username"]);
                string side = Convert.ToString(rdr["side"]);
                int elo = Convert.ToInt32(rdr["elo"]);
                int formation = Convert.ToInt32(rdr["formation"]);
                TeamDTO TeamMember = new TeamDTO(idx, username, side, elo, formation);

                return TeamMember;
            });
        }
        public FormationDTO ReadFormationInfo(int pidx, char team)
        {
            cmd.CommandText = "SELECT * " +
                "FROM `Formation` " +
                "WHERE `Party_idx`= @Pidx AND `side`= @Team"; ;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@Pidx", MySqlDbType.Int32, 10).Value = pidx;
            cmd.Parameters.Add("@Team", MySqlDbType.VarChar, 50).Value = team;
            return ReadData(ParseData_ToFormationInfo);
        }

        private FormationDTO ParseData_ToFormationInfo(MySqlDataReader rdr)
        {
            int Pidx = rdr.GetInt32(0);
            char team = rdr.GetChar(1);
            int maxFW = rdr.GetInt32(2);
            int maxMF = rdr.GetInt32(3);
            int maxDF = rdr.GetInt32(4);
            int maxGK = rdr.GetInt32(5);
            return new FormationDTO(Pidx, team, maxFW, maxMF, maxDF, maxGK); ;
        }

        public int InsertList(ListDTO joinParty)
        {
            cmd.CommandText = "INSERT INTO `List` " +
                "(User_idx, Party_idx, side,`position`) " +
                "VALUES (@useridx, @pidx, @side, @Position)"; ;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@useridx", MySqlDbType.Int32, 10).Value = joinParty.User_idx;
            cmd.Parameters.Add("@pidx", MySqlDbType.Int32, 10).Value = joinParty.Party_idx;
            cmd.Parameters.Add("@side", MySqlDbType.VarChar, 1).Value = joinParty.side;
            cmd.Parameters.Add("@Position", MySqlDbType.Int32, 10).Value = joinParty.position;
            return cmd.ExecuteNonQuery();
        }

        public int UpdateCount(ListDTO joinParty)
        {
            cmd.CommandText = "UPDATE `Party` SET `count`= `count`+1 WHERE idx = @pidx";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@pidx", MySqlDbType.Int32, 10).Value = joinParty.Party_idx;
            return cmd.ExecuteNonQuery();
        }
    }
}
