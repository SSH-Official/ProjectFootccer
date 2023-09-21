
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FootccerClient.Footccer.DBExecuter
{
    public class MyPageDBExecuter : Functional_DBExecuter_Base
    {
        public UserInfoDTO GetUserInfo(UserCredentialDTO Credential)
        {
            string sql = "SELECT " +
                "U.`idx`, U.`id`, " +
                "I.`name`, I.`gender`, I.`contact`, I.`email`, " +
                "CT.`idx`, CT.`name`, AC.`idx`, AC.`name`, IM.`imageurl` " +
                "FROM `User` AS U " +
                "LEFT JOIN `UserInfo` AS I ON U.`idx` = I.`User_idx` " +
                "LEFT JOIN `City` AS CT ON I.`prefer_City_idx` = CT.`idx` " +
                "LEFT JOIN `Activity` AS AC ON I.`prefer_Activity_idx` = AC.`idx` " +
                "LEFT JOIN `Image` AS IM ON I.`Image_idx` = IM.`idx` " +
                $"WHERE U.`id` = '{Credential.ID}'; ";

            return ExecuteQuery(sql, ParseToUserInfo) as UserInfoDTO;

            ////////////////////////////////////////////////////////////
            object ParseToUserInfo(MySqlDataReader rdr)
            {
                List<UserInfoDTO> _list = new List<UserInfoDTO>();

                while (rdr.Read())
                {
                    Queue<int> intArgs = new Queue<int>();
                    Queue<string> strArgs = new Queue<string>();
                    Queue<Image> imgArgs = new Queue<Image>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        switch (i)
                        {
                            case 0: case 6: case 8:
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
                    UserInfoDTO userInfo = new UserInfoDTO(
                        intArgs.Dequeue(), strArgs.Dequeue(), strArgs.Dequeue(), strArgs.Dequeue(), 
                        strArgs.Dequeue(), strArgs.Dequeue(), intArgs.Dequeue(), strArgs.Dequeue(), 
                        intArgs.Dequeue(), strArgs.Dequeue(), imgArgs.Dequeue());
                    _list.Add(userInfo);
                }

                int _count = _list.Count;
                if (_count < 1) { throw new Exception("검색 결과가 없습니다.."); }
                else if (_count > 1) { throw new Exception("DB에 중복 아이디가 있습니다.."); }
                else { return _list[0]; }

            }
        }

        

        internal UserInfoDTO GetUserInfoAsSession()
        {
            return GetUserInfo(App.Instance.Session.User);
        }
    }
}