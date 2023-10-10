using FootccerClient.Footccer.DAO.Base;
using FootccerClient.Footccer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO
{
    partial class Position_DAO
    {
        class CRUD : CRUD_Base
        {
            public List<PositionDTO> getPositionList()
            {
                string sql = "SELECT * FROM `Position`;";
                cmd.CommandText = sql;

                return ReadDataList((rdr) =>
                {
                    int idx = Convert.ToInt32(rdr["idx"]);
                    string position = Convert.ToString(rdr["position"]);
                    PositionDTO ps = new PositionDTO(idx, position);

                    return ps;
                });
            }
        }
    }
}
