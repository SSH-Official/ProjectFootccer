using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace FootccerClient.Footccer.DAO
{
    public partial class MyParty_DAO : DAO_Base
    {
        public List<(PartyDTO, bool)> ReadPartyListAsSession() => ReadPartyList(App.Instance.Session.User.ID);
        public List<(PartyDTO, bool)> ReadPartyList(string userID) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.ReadPartyList(userID));        
    }

    partial class MyParty_DAO
    {
        class CRUD : CRUD_Base
        {
            public List<int> ReadPartyIndexArray(string userID)
            {
                cmd.CommandText = "";
                cmd.Parameters.Add("@Uid", MySqlDbType.VarChar, 50).Value = userID;

                return ReadDataList(rdr => rdr.GetInt32(1));
            }

            public List<(PartyDTO, bool)> ReadPartyList(string userID)
            {
                cmd.CommandText = "SELECT ";
                cmd.Parameters.Add("@Uid", MySqlDbType.VarChar, 50).Value = userID;

                return ReadDataList((rdr) =>
                {
                    (var party, var isLeader) = ParseToPartyDTO(rdr);
                    
                    return (new PartyDTO(), isLeader);
                });
            }

            private (PartyDTO, bool) ParseToPartyDTO(MySqlDataReader rdr)
            {
                var idx = rdr.GetInt32(0);
                var Actname = rdr.GetString(1);
                var Uname = rdr.GetString(2);
                var Parname = rdr.GetString(3);
                var CTname = rdr.GetString(4);
                var PLname = rdr.GetString(5);
                var PLaddress = rdr.GetString(6);
                var date = rdr.GetString(7);
                var max = rdr.GetInt32(8);
                var count = rdr.GetInt32(9);
                var Uidx = rdr.GetInt32(10);
                var isLeader = rdr.GetBoolean(11);

                var party = new PartyDTO(idx,Actname,Uname,Parname,CTname,PLname,PLaddress,date,max,count,Uidx);
                return (party, isLeader);
            }
        }


    }
}