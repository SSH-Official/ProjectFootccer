using FootccerClient.Footccer.DTO.Builder;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Policy;
using FootccerClient.Footccer.Util;

namespace FootccerClient.Footccer.DBExecuter
{
    public class MyPageDBExecuter : DBExecture_Base
    {
        public MyPageDBExecuter(MySqlCommand cmd) : base(cmd)
        {
        }

        public MyPageDBExecuter SetSQL_ReadUserInfo(string UID)
        {
            cmd.CommandText = "SELECT " +
                            "U.`idx` AS `UserIdx`, " +
                            "U.`id` AS `UserID`, I.`name` AS `UserName`, " +
                            "I.`gender`, I.`contact`, I.`email`, " +
                            "CT.`idx` AS `CityIdx`, CT.`name` AS `CityName`, " +
                            "AC.`idx` AS `ActIdx`, AC.`name` AS `ActName`, " +
                            "IM.`imageurl` " +
                            "FROM `User` AS U " +
                            "LEFT JOIN `UserInfo` AS I ON U.`idx` = I.`User_idx` " +
                            "LEFT JOIN `City` AS CT ON I.`prefer_City_idx` = CT.`idx` " +
                            "LEFT JOIN `Activity` AS AC ON I.`prefer_Activity_idx` = AC.`idx` " +
                            "LEFT JOIN `Image` AS IM ON I.`Image_idx` = IM.`idx` " +
                            "WHERE U.`id` = @id; ";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50).Value = UID;
            return this;
        }

        public UserInfoDTO ReadUserInfo()
        {
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                List<UserInfoDTO> _list = new List<UserInfoDTO>();

                while (rdr.Read())
                {
                    UserInfoDTO userInfo = ParseToUserInfo(rdr);
                    _list.Add(userInfo);
                }

                return GetUserInfo_IfOnlyOne(_list);
            }
        }
        private static UserInfoDTO ParseToUserInfo(MySqlDataReader rdr)
        {
            ImageMaker IM = new ImageMaker();
            return new UserInfoDTOBuilder()
                .SetUser(new UserDTO(rdr.GetInt32("UserIdx"), rdr.GetString("UserID")))
                .SetName(rdr.GetString("UserName"))
                .SetGender(rdr.GetString("gender"))
                .SetContact(rdr.GetString("contact"))
                .SetEmail(rdr.GetString("email"))
                .SetPrefer(new PreferenceDTO(
                    new CityDTO(rdr.GetInt32("CityIdx"), rdr.GetString("CityName")),
                    new ActivityDTO(rdr.GetInt32("ActIdx"), rdr.GetString("ActName"))
                    ))
                .SetImage(IM.GetImageFromURL(rdr.GetString("imageurl")))
                .Build();
        }
        private UserInfoDTO GetUserInfo_IfOnlyOne(List<UserInfoDTO> _list)
        {
            int _count = _list.Count;
            if (_count < 1) { throw new Exception("검색 결과가 없습니다.."); }
            else if (_count > 1) { throw new Exception("DB에 중복 아이디가 있습니다.."); }
            else { return _list[0]; }
        }


        public MyPageDBExecuter SetSQL_CheckPassword(UserDTO user, string oldPwd)
        {
            cmd.CommandText =
                "SELECT CASE WHEN U.`password` = @oldPwd THEN TRUE ELSE FALSE END " +
                "FROM `User` AS U " +
                "WHERE U.`id` = @id ";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@oldPwd", MySqlDbType.VarChar, 50).Value = oldPwd;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50).Value = user.ID;
            return this;
        }

        public bool CheckPassword()
        {
            bool isCorrectPassword = false;
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                isCorrectPassword = rdr.GetBoolean(0);
            }
            return isCorrectPassword;
        }


        public MyPageDBExecuter SetSQL_UpdatePassword(UserDTO user, string newPwd)
        {
            cmd.CommandText =
                    "UPDATE `User` " +
                    "SET `password` = @pwd " +
                    "WHERE `id` = @id; ";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@pwd", MySqlDbType.VarChar, 50).Value = newPwd;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50).Value = user.ID;
            return this;
        }
    }
}
