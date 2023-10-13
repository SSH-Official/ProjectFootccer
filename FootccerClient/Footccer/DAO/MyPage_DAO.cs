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
using FootccerClient.Footccer.DAO.Base;

namespace FootccerClient.Footccer.DAO
{
    /// <summary>
    /// 마이페이지에 사용되는 DAO 객체입니다.
    /// </summary>
    public partial class MyPage_DAO : DAO_Base
    {
        public UserInfoDTO ReadUserInfoAsSession() => ReadUserInfo(App.Instance.Session.ID);
        public UserInfoDTO ReadUserInfo(string UID) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.ReadUserInfo(UID));
        
        public bool UpdateUserInfo(UserInfoDTO userinfo) => ExecuteTransaction((cmd) =>
        {
            cmd.CommandText = "UPDATE ... ";
            cmd.Parameters.Clear();
            cmd.ExecuteNonQuery();

            return true;
        });


        public bool UpdateUserPassword(UserDTO user, string oldPwd, string newPwd) => ExecuteTransaction(new CRUD(), (CRUD) =>
        {
            bool isCorrectPassword = CRUD.CheckPassword(user, oldPwd);

            if (isCorrectPassword == false) { throw new Exception("기존 비밀번호가 틀립니다."); }
            else
            {
                return CRUD.UpdatePassword(user, newPwd);
            }
        }) > 0; // 실행된 NonQuery가 양수임 -> 제대로 실행되었음

        public UserInfoDTO GetUserInfoAsSession() => GetUserInfo(App.Instance.Session.User);
        public UserInfoDTO GetUserInfo(UserDTO user) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.ReadUserInfo(user.ID));
        public bool UpdateUserinfo(UserInfoDTO updateinfo) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.UpdateUserInfo(updateinfo));

    }

}