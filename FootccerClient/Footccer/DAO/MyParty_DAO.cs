using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using System.Collections.Generic;

namespace FootccerClient.Footccer.DAO
{
    public partial class MyParty_DAO : DAO_Base
    {
        public List<PartyDTO> ReadPartyList(int userID) => ExecuteTransaction(new CRUD(), (CRUD) => CRUD.ReadPartyList(userID));
    }

    partial class MyParty_DAO
    {
        class CRUD : CRUD_Base
        {
            public List<PartyDTO> ReadPartyList(int userID)
            {
                cmd.CommandText = "";

                return ReadDataList((rdr) =>
                {

                    return new PartyDTO();
                });
            }
        }
    }
}