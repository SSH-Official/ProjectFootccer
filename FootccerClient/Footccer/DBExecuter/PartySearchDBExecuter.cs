using FootccerClient.Footccer.DAO.CRUD;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;


namespace FootccerClient.Footccer.DBExecuter
{
    public class PartySearchDBExecuter : CRUD_Base
    {
        public PartySearchDBExecuter(MySqlCommand cmd) : base(cmd)
        {
        }

        internal PartySearchDBExecuter SetSQL_ReadAllCity()
        {
            string sql = "SELECT * FROM `City`;";
            cmd.CommandText = sql;
            return this;
        }

        internal List<CityDTO> ReadAllCity()
        {
            List<CityDTO> result = new List<CityDTO>();
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int idx = Convert.ToInt32(rdr["idx"]);
                    string name = Convert.ToString(rdr["name"]);
                    CityDTO theCity = new CityDTO(idx, name);

                    result.Add(theCity);
                }
            }

            return result;            
        }

        internal PartySearchDBExecuter SetSQL_ReadAllActivities()
        {
            string sql = "SELECT * FROM `Activity`;";
            cmd.CommandText = sql;
            return this;
        }

        internal List<ActivityDTO> ReadAllActivities()
        {
            List<ActivityDTO> result = new List<ActivityDTO>();
            using (MySqlDataReader rdr = cmd.ExecuteReader())

                while (rdr.Read())
                {
                    int idx = Convert.ToInt32(rdr["idx"]);
                    string name = Convert.ToString(rdr["name"]);
                    ActivityDTO Activity = new ActivityDTO(idx, name);

                    result.Add(Activity);
                }
            return result;
        }

        internal PartySearchDBExecuter SetSQL_ReadParty(string kind, string seed)
        {
            string sql = SearchSQL(kind, seed);
            cmd.CommandText = sql;
            return this;
        }
        private string SearchSQL(string kind, string seed)
        {
            string sql =
                "SELECT Par.`idx` as Paridx, Act.`name` AS Actname,U.`name`AS Uname," +
                "Par.`name`AS Parname,CT.`name`AS CTname,PL.`name`AS PLname," +
                "PL.`address` AS PLaddress,`date`,`max`,`count`, U.`idx` as Uidx " +
                "FROM `Party` AS Par " +
                "LEFT JOIN `Activity` AS Act ON Par.Activity_idx = Act.idx " +
                "LEFT JOIN `User` AS U ON Par.Leader_idx=U.idx " +
                "LEFT JOIN `Place` AS PL ON Par.Place_idx= PL.idx " +
                "LEFT JOIN `City` AS CT ON PL.City_idx=CT.idx ";
            if (seed != "")
            {
                sql += "WHERE ";
                switch (kind)
                {
                    case "제목":
                        sql += $"Par.`name` LIKE \"%{seed}%\"";
                        break;
                    case "작성자":
                        sql += $"U.`name` LIKE \"%{seed}%\"";
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

        internal List<PartyDTO> ReadParty()
        {
            List<PartyDTO> result = new List<PartyDTO>();
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int idx = Convert.ToInt32(rdr["Paridx"]);
                    string Actname = Convert.ToString(rdr["Actname"]);
                    string Uname = Convert.ToString(rdr["Uname"]);
                    string Parname = Convert.ToString(rdr["Parname"]);
                    string CTname = Convert.ToString(rdr["CTname"]);
                    string PLname = Convert.ToString(rdr["PLname"]);
                    string PLaddress = Convert.ToString(rdr["PLaddress"]);
                    string date = Convert.ToString(rdr["date"]);
                    int max = Convert.ToInt32(rdr["max"]);
                    int count = Convert.ToInt32(rdr["count"]);
                    int Uidx = Convert.ToInt32(rdr["Uidx"]);
                    PartyDTO party = new PartyDTO(idx, Actname, Uname, Parname, CTname, PLname, PLaddress, date, max, count, Uidx);

                    result.Add(party);
                }
            }
            return result;
        }
    }
}