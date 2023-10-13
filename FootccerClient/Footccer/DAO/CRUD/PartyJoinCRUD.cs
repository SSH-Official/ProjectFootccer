using FootccerClient.Footccer.DTO;
using MySqlConnector;
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
            string sql = "SELECT L.User_idx AS idx, COUNT(*) AS count, Ui.name AS username, side, Ui.elo as elo FROM `List` AS L " +
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
                TeamDTO TeamMember = new TeamDTO(idx, username, side, elo);

                return TeamMember;
            });
        }
    }
}
