using MySqlConnector;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System;
using FootccerClient.Footccer.DTO;
using FootccerClient.Footccer.DAO;
using System.Collections;
using System.Windows.Forms;
using FootccerClient.Footccer.DTO.Builder;
using System.Drawing;

namespace FootccerClient.Footccer.DBExecuter
{
    public partial class MyPage_DAO : SSH_DAO
    {
        public UserInfoDTO ReadUserInfoAsSession()
        {
            return ReadUserInfo(App.Instance.Session.ID);
        }

        public UserInfoDTO ReadUserInfo(string UID)
        {
            return ExecuteTransaction((cmd) =>
            {
                cmd.CommandText = "SELECT " +
                "U.`idx`, U.`id`, I.`name`, I.`gender`, I.`contact`, I.`email`, " +
                "CT.`idx`, CT.`name`, AC.`idx`, AC.`name`, IM.`imageurl` " +
                "FROM `User` AS U " +
                "LEFT JOIN `UserInfo` AS I ON U.`idx` = I.`User_idx` " +
                "LEFT JOIN `City` AS CT ON I.`prefer_City_idx` = CT.`idx` " +
                "LEFT JOIN `Activity` AS AC ON I.`prefer_Activity_idx` = AC.`idx` " +
                "LEFT JOIN `Image` AS IM ON I.`Image_idx` = IM.`idx` " +
                "WHERE U.`id` = @id; ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = UID;

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    List < UserInfoDTO > _list = new List<UserInfoDTO>();

                    while (rdr.Read())
                    {
                        Queue<int> intArgs = new Queue<int>();
                        Queue<string> strArgs = new Queue<string>();
                        Queue<Image> imgArgs = new Queue<Image>();

                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                case 6:
                                case 8:
                                    intArgs.Enqueue(rdr.GetInt32(i)); break;
                                case 10:
                                    string url = rdr.GetString(i);
                                    Image img = App.Instance.Image.GetImageFromURL(url);
                                    img.Tag = url;
                                    imgArgs.Enqueue(img); break;
                                default:
                                    strArgs.Enqueue(rdr.GetString(i)); break;
                            }
                        }

                        UserInfoDTO userInfo = new UserInfoDTOBuilder()
                                                .SetUser(new UserDTO(intArgs.Dequeue(), strArgs.Dequeue()))
                                                .SetName(strArgs.Dequeue())
                                                .SetGender(strArgs.Dequeue())
                                                .SetContact(strArgs.Dequeue())
                                                .SetEmail(strArgs.Dequeue())
                                                .SetPrefer(new PreferenceDTO(
                                                    new CityDTO(intArgs.Dequeue(), strArgs.Dequeue()),
                                                    new ActivityDTO(intArgs.Dequeue(), strArgs.Dequeue())))
                                                .SetImage(imgArgs.Dequeue())
                                                .Build(); ;

                        _list.Add(userInfo);
                    }

                    int _count = _list.Count;
                    if (_count < 1) { throw new Exception("검색 결과가 없습니다.."); }
                    else if (_count > 1) { throw new Exception("DB에 중복 아이디가 있습니다.."); }
                    else { return _list[0]; }
                }
            }) as UserInfoDTO;
        }


        public bool UpdateUserInfo(UserInfoDTO userinfo)
        {
            object result = ExecuteTransaction((cmd) =>
            {
                cmd.CommandText = "UPDATE ... ";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();

                return true;
            });

            return (result != null) && (bool)result;
        }


        public bool UpdateUserPassword(UserDTO user, string oldPwd, string newPwd)
        {
            object result = ExecuteTransaction((cmd) =>
            {
                cmd.CommandText =
                "SELECT CASE WHEN U.`password` = @oldPwd THEN TRUE ELSE FALSE END " +
                "FROM `User` AS U " +
                "WHERE U.`id` = @id ";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@oldPwd", MySqlDbType.VarChar, 50);
                cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50);
                cmd.Parameters[0].Value = oldPwd;
                cmd.Parameters[1].Value = user.ID;
                bool isCorrectPassword = false;
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    isCorrectPassword = rdr.GetBoolean(0);
                }

                if (isCorrectPassword == false) { throw new Exception("기존 비밀번호가 틀립니다."); }
                else
                {
                    cmd.CommandText =
                    "UPDATE `User` " +
                    "SET `password` = @pwd " +
                    "WHERE `id` = @id; ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@pwd", MySqlDbType.VarChar, 50);
                    cmd.Parameters.Add("@id", MySqlDbType.VarChar, 50);
                    cmd.Parameters[0].Value = newPwd;
                    cmd.Parameters[1].Value = user.ID;

                    cmd.ExecuteNonQuery();

                    return true;
                }
            });

            return (result != null) && (bool)result;
        }
    }
}





