using FootccerClient.Footccer.DTO;
using FootccerClient.Footccer.DTO.Builder;
using FootccerClient.Footccer.Util;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FootccerClient.Footccer.DAO.CRUD
{
    public class TeamMemberCRUD : CRUD_Base
    {
        public TeamMemberCRUD(MySqlCommand cmd) : base(cmd)
        {
        }

        public TeamMemberDTO Readmemberone(int idx,int Pidx)
        {
            cmd.CommandText = "SELECT `nickname`,UI.`User_idx`,`gender`,`contact`,`email`,P.`position` " +
                "FROM `UserInfo` AS UI " +
                "LEFT JOIN `List` AS L ON  L.User_idx=2 " +
                "LEFT JOIN `Position` AS P ON P.idx=L.`position` " +
                "WHERE UI.User_idx=@id AND Party_idx=@Pidx "; ;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50).Value = idx;
            cmd.Parameters.Add("@Pidx", MySqlDbType.VarChar, 50).Value = Pidx;
            return ReadData(ParseData_ToUserInfo);
        }//파티원 정보 읽어오는 코드

        private TeamMemberDTO ParseData_ToUserInfo(MySqlDataReader rdr)
        {
            string nickname = rdr.GetString(0);
            int idx = rdr.GetInt32(1);
            string gender = rdr.GetString(2);
            string contact = rdr.GetString(3);
            string email = rdr.GetString(4);
            string position = rdr.GetString(5);
            return new TeamMemberDTO(nickname,idx,gender,contact,email,position);
        }
    }
}
