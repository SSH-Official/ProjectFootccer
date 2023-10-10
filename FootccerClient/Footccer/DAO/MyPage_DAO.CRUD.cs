using FootccerClient.Footccer.DTO.Builder;
using FootccerClient.Footccer.DTO;
using FootccerClient.Footccer.Util;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootccerClient.Footccer.DAO.Base;

namespace FootccerClient.Footccer.DAO
{
    partial class MyPage_DAO
    {
        class CRUD : CRUD_Base
        {

            public UserInfoDTO ReadUserInfo(string UID)
            {
                SetSQL_ReadUserInfo(UID);
                return ReadData(ParseData_ToUserInfo);
            }
            private void SetSQL_ReadUserInfo(string UID)
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
            }
            private UserInfoDTO ParseData_ToUserInfo(MySqlDataReader rdr)
            {
                ImageMaker IM = App.Instance.Image;
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


            public bool CheckPassword(UserDTO user, string oldPwd)
            {
                cmd.CommandText =
                    "SELECT CASE WHEN U.`password` = @oldPwd THEN TRUE ELSE FALSE END " +
                    "FROM `User` AS U " +
                    "WHERE U.`id` = @id ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@oldPwd", MySqlDbType.VarChar, 50).Value = oldPwd;
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50).Value = user.ID;

                bool isCorrectPassword = false;
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    isCorrectPassword = rdr.GetBoolean(0);
                }

                return isCorrectPassword;
            }


            public int UpdatePassword(UserDTO user, string newPwd)
            {
                cmd.CommandText =
                        "UPDATE `User` " +
                        "SET `password` = @pwd " +
                        "WHERE `id` = @id; ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@pwd", MySqlDbType.VarChar, 50).Value = newPwd;
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50).Value = user.ID;

                return cmd.ExecuteNonQuery();
            }

            public bool UpdateUserInfo(UserInfoDTO updateinfo)
            {
                int _useridx = updateinfo.User.Index;
                string _contact = updateinfo.Contact;
                string _email = updateinfo.Email;
                int _cityidx = updateinfo.Prefer.City.Index;
                int _activityidx = updateinfo.Prefer.Activity.Index;

                cmd.CommandText =
                 "UPDATE `UserInfo` " +
                 "SET `contact` = ('" + _contact + "')," +
                 "`email`=('" + _email + "')," +
                 "`prefer_City_idx`=('" + _cityidx + "')," +
                 "`prefer_Activity_idx`=('" + _activityidx + "') " +
                 "WHERE `UserInfo`.`User_idx`= ('" + _useridx + "'); ";

                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();
                return true;
            }
        }
    }
}
