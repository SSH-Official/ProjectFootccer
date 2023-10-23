using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using FootccerClient.Footccer.DTO.Builder;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
{
    partial class MyParty_DAO
    {
        class CRUD : CRUD_Base
        {
            public List<int> ReadPartyIndexArray(string userID)
            {
                cmd.CommandText = "";
                cmd.Parameters.Add("@Uid", MySqlDbType.VarChar, 50).Value = userID;

                return ReadDataList(rdr => rdr.GetInt32(1));
            }

            public List<PartyDTO> ReadPartyList(string userID)
            {
                cmd.CommandText =
                    "SELECT Par.idx, Act.`name`, Ldui.nickname, Par.`name`,\r\n" +
                    "Ct.`name`, Plc.`name`, Plc.address, Par.`date`,\r\n" +
                    "Par.`max`, Par.`count`, Ld.idx\r\n" +
                    "FROM Party AS Par\r\n" +
                    "LEFT JOIN Activity AS Act ON Act.idx = Par.Activity_idx\r\n" +
                    "LEFT JOIN Place AS Plc ON Plc.idx = Par.Place_idx\r\n" +
                    "LEFT JOIN City AS Ct ON Ct.idx = Plc.City_idx\r\n" +
                    "LEFT JOIN `User` AS Ld ON Ld.idx = Par.Leader_idx\r\n" +
                    "LEFT JOIN `UserInfo` AS Ldui ON Ld.idx = Ldui.User_idx\r\n" +
                    "LEFT JOIN `List` AS Li ON Par.idx = Li.Party_idx\r\n" +
                    "LEFT JOIN `User` AS U ON U.idx = Li.User_idx\r\n" +
                    "WHERE U.id = @Uid AND Par.`date` >= DATE(SYSDATE()); ";
                cmd.Parameters.Add("@Uid", MySqlDbType.VarChar, 50).Value = userID;

                return ReadDataList((rdr) =>
                {
                    var party = ParseToPartyDTO(rdr);

                    return party;
                });
            }

            private PartyDTO ParseToPartyDTO(MySqlDataReader rdr)
            {
                var idx = rdr.GetInt32(0);
                var Actname = rdr.GetString(1);
                var Uname = rdr.GetString(2);
                var Parname = rdr.GetString(3);
                var CTname = rdr.GetString(4);
                var PLname = rdr.GetString(5);
                var PLaddress = rdr.GetString(6);
                var date = rdr.GetDateTime(7);
                var max = rdr.GetInt32(8);
                var count = rdr.GetInt32(9);
                var Uidx = rdr.GetInt32(10);

                var party = new PartyDTOBuilder()
                    .SetIndex(idx)
                    .SetActname(Actname)
                    .SetUname(Uname)
                    .SetParname(Parname)
                    .SetCTname(CTname)
                    .SetPLname(PLname)
                    .SetPLaddress(PLaddress)
                    .SetDate(date)
                    .SetMax(max)
                    .SetCount(count)
                    .SetUidx(Uidx)
                    .Build();
                return party;
            }
        }


    }
}
