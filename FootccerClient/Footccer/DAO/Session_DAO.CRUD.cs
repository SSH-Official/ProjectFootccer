using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using System;
using System.Drawing;

namespace FootccerClient.Footccer.DAO
{
    partial class Session_DAO
    {
        class CRUD : CRUD_Base
        {
            internal Image ReadUserImage(UserDTO user)
            {
                cmd.CommandText = "SELECT imageurl\r\n" +
                    "FROM `User`\r\n" +
                    "LEFT JOIN UserInfo ON `User`.idx = UserInfo.User_idx\r\n" +
                    "LEFT JOIN Image ON Image.idx = UserInfo.Image_idx\r\n" +
                    "WHERE `User`.id = @Uid;";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Uid", MySqlConnector.MySqlDbType.VarChar, 50).Value = user.ID;

                return ReadData(rdr => App.Instance.Image.GetImageFromURL(rdr.GetString(0)));
            }

            internal string ReadUserName(UserDTO user)
            {
                cmd.CommandText = "SELECT UserInfo.`name`\r\n" +
                    "FROM `User`\r\n" +
                    "LEFT JOIN UserInfo ON `User`.idx = UserInfo.User_idx\r\n" +
                    "WHERE `User`.id = @Uid;";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Uid", MySqlConnector.MySqlDbType.VarChar, 50).Value = user.ID;

                return ReadData(rdr => rdr.GetString(0));
            }
        }
    }
}