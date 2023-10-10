using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
{
    partial class PartySearch_DAO
    {
        class CRUD : CRUD_Base
        {
            public List<CityDTO> ReadAllCity()
            {
                string sql = "SELECT * FROM `City`;";
                cmd.CommandText = sql;

                return ReadDataList((rdr) =>
                {
                    int idx = Convert.ToInt32(rdr["idx"]);
                    string name = Convert.ToString(rdr["name"]);
                    CityDTO theCity = new CityDTO(idx, name);

                    return theCity;
                });
            }

            public List<ActivityDTO> ReadAllActivities()
            {
                string sql = "SELECT * FROM `Activity`;";
                cmd.CommandText = sql;

                return ReadDataList((rdr) =>
                {
                    int idx = Convert.ToInt32(rdr["idx"]);
                    string name = Convert.ToString(rdr["name"]);
                    ActivityDTO Activity = new ActivityDTO(idx, name);

                    return Activity;
                });
            }

            public List<PartyDTO> ReadParty(string kind, string seed)
            {
                string sql = SearchSQL(kind, seed);
                cmd.CommandText = sql;

                return ReadDataList((rdr) =>
                {
                    int idx = Convert.ToInt32(rdr["Paridx"]);
                    string Actname = Convert.ToString(rdr["Actname"]);
                    string Uname = Convert.ToString(rdr["Uiname"]);
                    string Parname = Convert.ToString(rdr["Parname"]);
                    string CTname = Convert.ToString(rdr["CTname"]);
                    string PLname = Convert.ToString(rdr["PLname"]);
                    string PLaddress = Convert.ToString(rdr["PLaddress"]);
                    string date = Convert.ToString(rdr["date"]);
                    int max = Convert.ToInt32(rdr["max"]);
                    int count = Convert.ToInt32(rdr["count"]);
                    int Uidx = Convert.ToInt32(rdr["Uiidx"]);
                    PartyDTO party = new PartyDTO(idx, Actname, Uname, Parname, CTname, PLname, PLaddress, date, max, count, Uidx);

                    return party;
                });

            }

            private string SearchSQL(string kind, string seed)
            {
                string sql =
                    "SELECT Par.`idx` as Paridx, Act.`name` AS Actname,Ui.`name`AS Uiname," +
                    "Par.`name`AS Parname,CT.`name`AS CTname,PL.`name`AS PLname," +
                    "PL.`address` AS PLaddress,`date`,`max`,`count`, Ui.`User_idx` as Uiidx " +
                    "FROM `Party` AS Par " +
                    "LEFT JOIN `Activity` AS Act ON Par.Activity_idx = Act.idx " +
                    "LEFT JOIN `UserInfo` AS Ui ON Par.Leader_idx = Ui.User_idx " +
                    "LEFT JOIN `Place` AS PL ON Par.Place_idx = PL.idx " +
                    "LEFT JOIN `City` AS CT ON PL.City_idx = CT.idx ";
                if (seed != "")
                {
                    sql += "WHERE ";
                    switch (kind)
                    {
                        case "제목":
                            sql += $"Par.`name` LIKE \"%{seed}%\"";
                            break;
                        case "작성자":
                            sql += $"Ui.`name` LIKE \"%{seed}%\"";
                            break;
                        case "지역":
                            sql += $"CT.`idx` = {seed}";
                            break;
                        case "종류":
                            sql += $"Act.`idx` = {seed}";
                            break;
                        case "날짜":
                            sql += $"date = '{seed}'";
                            break;
                    }
                }
                return sql;
            }

        }
    }
}
