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
using FootccerClient.Footccer.DAO.CRUD;

namespace FootccerClient.Footccer.DBExecuter
{
    /// <summary>
    /// 마이페이지에 사용되는 DAO 객체입니다.
    /// </summary>
    public partial class MyPage_DAO : DAO_Base
    {
        public UserInfoDTO ReadUserInfoAsSession()
        {
            return ReadUserInfo(App.Instance.Session.ID);
        }

        public UserInfoDTO ReadUserInfo(string UID)
        {
            UserInfoDTO result = ExecuteTransaction((cmd) =>
            {
                MyPageCRUD CRUD = new MyPageCRUD(cmd);
                return CRUD.ReadUserInfo(UID);
            });

            return result;
        }


        public bool UpdateUserInfo(UserInfoDTO userinfo)
        {
            bool result = ExecuteTransaction((cmd) =>
            {
                cmd.CommandText = "UPDATE ... ";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();

                return true;
            });

            return result;
        }


        public bool UpdateUserPassword(UserDTO user, string oldPwd, string newPwd)
        {
            int result = ExecuteTransaction((cmd) =>
            {
                MyPageCRUD DBE = new MyPageCRUD(cmd);
                bool isCorrectPassword = DBE.CheckPassword(user, oldPwd);

                if (isCorrectPassword == false) { throw new Exception("기존 비밀번호가 틀립니다."); }
                else
                {
                    return DBE.UpdatePassword(user, newPwd);
                }
            });

            // 실행된 NonQuery가 양수임 -> 제대로 SQL이 실행되었음.
            return result > 0;
        }


        public UserInfoDTO GetUserInfoAsSession()
        {
            return GetUserInfo(App.Instance.Session.User);
        }

        public UserInfoDTO GetUserInfo(UserDTO user)
        {
            return ExecuteTransaction((cmd) =>
            {
                MyPageCRUD CRUD = new MyPageCRUD(cmd);
                return CRUD.ReadUserInfo(user.ID);
                /*cmd.CommandText = GetSQL_SelectUserInfo_ForUser(user);
                return 
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    return ParseToUserInfo(rdr);
                }*/
            });
        }
        

        public bool UpdateUserinfo(UserInfoDTO updateinfo)
        {
            object result = ExecuteTransaction((cmd) =>
            {
                string _userid = updateinfo.User.ID;

                /*int _useridx;
                cmd.CommandText = $"SELECT idx FROM `User` WHERE id = '{_userid}'; ";
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    _useridx = rdr.GetInt32("idx");
                }*/


                int _useridx = updateinfo.User.Index;

                string _name = updateinfo.Name;
                string _gender = updateinfo.Gender;
                string _contact = updateinfo.Contact;
                string _email = updateinfo.Email;
                int _cityidx = updateinfo.Prefer.City.Index;
                string _cityname = updateinfo.Prefer.City.Name;
                int _activityidx = updateinfo.Prefer.Activity.Index;
                string _activityname = updateinfo.Prefer.Activity.Name;

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
                ); return (result != null) && (bool)result;
        }
    }




}