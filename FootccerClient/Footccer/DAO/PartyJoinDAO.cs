using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootccerClient.Footccer.DAO.CRUD;
using FootccerClient.Footccer.DTO;
using MySqlConnector;

namespace FootccerClient.Footccer.DAO
{
    public class PartyJoinDAO : DAO_Base
    {
        public TeamMemberDTO ReadUserInfo(int idx,int Pidx) => ExecuteTransaction((cmd) =>
            {
                var CRUD = new teammemberCRUD(cmd);

                return CRUD.Readmemberone(idx, Pidx);
            });
 /*       public (UserInfoDTO, PositionDTO) ReadUserInfo(int idx)
        {
            // 이름 성별 거주지 연락처 이메일 -> UserInfo DTO에서 읽을 수 있음
            // 포지션-> 파티에 내가 할당된 포지션.. 다른 DTO(DB테이블)에서..

            string sql = $"SELECT * FROM UserInfo WHERE User_idx = {idx};";
            // 밑의 주석은 연습용입니다..
            *//*App.Instance.DB.PartyJoin.ReadUserInfo(idx);

            return List<string>*//*
            throw new NotImplementedException();
            

        }*/
    }
}
