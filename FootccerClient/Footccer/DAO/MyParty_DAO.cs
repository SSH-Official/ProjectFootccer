using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace FootccerClient.Footccer.DAO
{
    public partial class MyParty_DAO : DAO_Base
    {
        public List<PartyDTO> ReadPartyListAsSession() => ReadPartyList(App.Instance.Session.User.ID);
        public List<PartyDTO> ReadPartyList(string userID) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.ReadPartyList(userID));        
    }
}