using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DAO.CRUD;
using FootccerClient.Footccer.DTO;

namespace FootccerClient.Footccer.DAO
{
    public class PartyJoinDAO : DAO_Base
    {
        public TeamMemberDTO ReadUserInfo(int idx,int Pidx) => ExecuteTransaction((cmd) =>
            {
                var CRUD = new TeamMemberCRUD(cmd);

                return CRUD.Readmemberone(idx, Pidx);
            });//파티원 정보 읽어오는 코드
    }
}
