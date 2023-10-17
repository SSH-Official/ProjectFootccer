using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using System;
using System.Drawing;

namespace FootccerClient.Footccer.DAO
{
    public partial class Session_DAO : DAO_Base
    {
        UserDTO User { get => App.Instance.Session.User; }

        public Image ReadSessionUserImage() => ExecuteTransaction(new CRUD(), CRUD => CRUD.ReadUserImage(User));
        public string ReadUserName() => ExecuteTransaction(new CRUD(), CRUD => CRUD.ReadUserName(User));
    }   
}