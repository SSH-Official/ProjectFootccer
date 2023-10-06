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
        public UserInfoDTO ReadUserInfoAsSession() => ReadUserInfo(App.Instance.Session.ID);
        public UserInfoDTO ReadUserInfo(string UID) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new MyPageCRUD(cmd);
            return CRUD.ReadUserInfo(UID);
        });


        public bool UpdateUserInfo(UserInfoDTO userinfo) => ExecuteTransaction((cmd) =>
        {
            cmd.CommandText = "UPDATE ... ";
            cmd.Parameters.Clear();
            cmd.ExecuteNonQuery();

            return true;
        });


        public bool UpdateUserPassword(UserDTO user, string oldPwd, string newPwd) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new MyPageCRUD(cmd);
            bool isCorrectPassword = CRUD.CheckPassword(user, oldPwd);

            if (isCorrectPassword == false) { throw new Exception("기존 비밀번호가 틀립니다."); }
            else
            {
                return CRUD.UpdatePassword(user, newPwd);
            }
        }) > 0; // 실행된 NonQuery가 양수임 -> 제대로 실행되었음


        /// <summary>
        /// 세션 User 정보를 토대로 UserInfo를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public UserInfoDTO GetUserInfoAsSession() => GetUserInfo(App.Instance.Session.User);
        public UserInfoDTO GetUserInfo(UserDTO user) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new MyPageCRUD(cmd);

            return CRUD.ReadUserInfo(user.ID);
        });



        public bool UpdateUserinfo(UserInfoDTO updateinfo) => ExecuteTransaction((cmd) =>
        {
            var CRUD = new MyPageCRUD(cmd);

            return CRUD.UpdateUserInfo(updateinfo);
        });

    }




}